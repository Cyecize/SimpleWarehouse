using SimpleWarehouse.Constants;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.IO;
using SimpleWarehouse.Model;
using SimpleWarehouse.Presenter;
using SimpleWarehouse.Service;
using SimpleWarehouse.Services.ProductSectionManagers;
using SimpleWarehouse.Services.RevenueRelated;
using SimpleWarehouse.Services.TransactionServices;
using SimpleWarehouse.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWarehouse.Services.RevisionRelated
{
    public class RevisionSection : IRevisionSection
    {
        private IHomeView Form { get; set; }
        private IMySqlManager SqlManager { get; set; }
        private ISession<IUser> LoggedUserSession { get; set; }
        private IStateManager StateManager { get; set; }
        private IRevisionDbManager RevisionDbManager { get; set; }

        private double SalesRevenue { get; set; }
        private DateTime StartDate { get; set; }
        private bool IsRevisionStarted { get; set; }
        private Revision Revision { get; set; }
        private List<RevisionProduct> RevisionProducts { get; set; }

        public IRevisionGridViewManager GridViewManager { get; set; }
        public IProductsRepositoryManager ProductsRepository { get; set; }
        public ITransactionDbManager DeliveryTransactionDbManager { get; set; }
        public ITransactionDbManager SaleTransactioDbManager { get; set; }
        public IRevenueStreamDbManager RevenueStreamDbManager { get; set; }
        public IRevenueStreamDbManager ExpenseStreamDbManager { get; set; }

        public RevisionSection(HomePresenter presenter)
        {
            this.Form = presenter.Form;
            this.SqlManager = presenter.GetStateManager().SqlManager;
            this.LoggedUserSession = presenter.GetStateManager().UserSession;
            this.StateManager = presenter.GetStateManager();
            this.RevisionDbManager = new RevisionDbManager(this.SqlManager);

            this.GridViewManager = new RevisionGridViewManager(presenter.Form.RevisionDataTable, this.Form, this);
            this.ProductsRepository = new ProductRepositoryManager(this.SqlManager);
            this.DeliveryTransactionDbManager = new DeliveryTransactionDbManager(this.SqlManager, this.LoggedUserSession.SessionEntity);
            this.SaleTransactioDbManager = new SalesTransactionDbManager(this.SqlManager, this.LoggedUserSession.SessionEntity);
            this.RevenueStreamDbManager = new RevenueDbManager(this.SqlManager);
            this.ExpenseStreamDbManager = new ExpensesDbManager(this.SqlManager);
            this.SalesRevenue = 0.0;
            this.IsRevisionStarted = false;
        }

        public void CancelOperation()
        {
            this.SalesRevenue = 0.0;
            this.ClearTextBoxValues();
            this.GridViewManager.ClearRows();
            this.IsRevisionStarted = false;
            this.Revision = null;
            this.RevisionProducts = null;
        }

        public void CommitRevisionAction()
        {
            if (!this.VerifyUserRole())
                return;
            if (!this.IsRevisionStarted)
            {
                this.Form.Log("Моля стартирайте ревизията първо!");
                return;
            }
            this.Revision =  this.ForgeRevision();
            this.RevisionProducts = this.ForgeRevisionProducts();
            string confirmText = $"{this.Revision.ToString()}\r\nТова ще редактира {this.RevisionProducts.Count} продуктa и ще премести сегашните приходи и разходи в архива.";
            this.StateManager.Push(new ConfirmActionPresenter(this.StateManager, this.OnRevisionConfirm, confirmText));
        }

        public void Initialize()
        {
            this.GridViewManager.Initialize();
            this.GridViewManager.ClearRows();
        }

        public void RefreshGridAction()
        {
            if (!this.VerifyUserRole())
                return;

            this.FillRevenueStreamInfo(); //updates the revenues and expenses just in case
            this.RefreshSubTotalAction();
        }

        public void UpdateTotalPriceAction(int rowId)
        {
            try
            {
                var actualQuantity = double.Parse(this.GridViewManager.DataGrid.Rows[rowId].Cells[RevisionDataGridViewColNames.ACTUAL_QUANTITY].Value.ToString().Trim());
                var prodPrice = double.Parse(this.GridViewManager.DataGrid.Rows[rowId].Cells[RevisionDataGridViewColNames.SELL_PRICE].Value.ToString().Trim());
                var availableQuantity = double.Parse(this.GridViewManager.DataGrid.Rows[rowId].Cells[RevisionDataGridViewColNames.AVAILABLE_QUANTITY].Value.ToString().Trim());
                if (actualQuantity >= 0)
                {
                    double difference = availableQuantity - actualQuantity;
                    this.GridViewManager.DataGrid.Rows[rowId].Cells[RevisionDataGridViewColNames.SUB_TOTAL].Value = $"{(difference * prodPrice):F2}";
                }
                else
                {
                    this.GridViewManager.DataGrid.Rows[rowId].Cells[RevisionDataGridViewColNames.SUB_TOTAL].Value = null;
                }
                this.RefreshSubTotalAction();
            }
            catch (Exception) { }
        }

        public void BeginRevision()
        {
            if (!this.VerifyUserRole())
                return;
            this.GridViewManager.ClearRows();
            this.GridViewManager.InsertProducts(this.ProductsRepository.FindAll().Where(p => p.IsVisible).ToList());
            this.FillRevenueStreamInfo();
            this.IsRevisionStarted = true;
        }

        //PRIVATE METHODS
        private void RefreshSubTotalAction()
        {
            double total = this.GetRevisionSubTotal();
            this.GridViewManager.DataGrid.EndEdit();
            this.Form.RevisionSubTotal = $"{total:F2}";
            this.Form.RevisonSubTotalPlusSalesRevenue = $"{(total + this.SalesRevenue):F2}";
        }

        private void FillRevenueStreamInfo()
        {
            List<RevenueStream> expenses = this.GetRevenueStream(TransactionTypes.Delivery);
            List<RevenueStream> revenues = this.GetRevenueStream(TransactionTypes.Sale);
            double expensesTotal = expenses.Sum(e => e.RevenueAmount);
            double revenuesTotal = revenues.Sum(e => e.RevenueAmount);
            List<RevenueStream> merged = new List<RevenueStream>();
            merged.AddRange(expenses);
            merged.AddRange(revenues);
            DateTime startDate = DateTime.Now;
            var oldestRevenueStream = merged.OrderBy(e => e.Date.Year).ThenBy(e => e.Date.Month).ThenBy(e => e.Date.Day).FirstOrDefault();
            if (oldestRevenueStream != null)
                startDate = oldestRevenueStream.Date;

            this.StartDate = startDate;
            //inserting the data
            var exp = $"{expensesTotal:F2}";
            var rev = $"{revenuesTotal:F2}";
            var stDate = $"Начална дата: {startDate.ToString("dd-MM-yyyy")}";
            var subTot = "0";
            this.SalesRevenue = this.GetNonRevisedSalesRevenue().Sum(r => r.RevenueAmount);
            var salesRev = $"{this.SalesRevenue:F2}";
            this.InsertTextBoxValues(exp, rev, stDate, subTot, salesRev);
        }

        private void ClearTextBoxValues()
        {
            this.InsertTextBoxValues(null, null, "Начална дата:", null, null);
        }

        private void InsertTextBoxValues(string expenses, string revenues, string startDate, string subTotal, string salesRevenue)
        {
            this.Form.RevisionExpenses = expenses;
            this.Form.RevisionRevenue = revenues;
            this.Form.RevisionStartDate = startDate;
            this.Form.RevisionSubTotal = subTotal;
            this.Form.RevisionSalesRevenue = salesRevenue;
            this.Form.RevisonSubTotalPlusSalesRevenue = this.SalesRevenue.ToString();
        }

        private bool VerifyUserRole()
        {
            if (!Roles.IsRequredRoleMet(this.LoggedUserSession.SessionEntity.Role, Config.USER_TYPICAL_ROLE))
            {
                this.Form.Log("Нямате права за тази операция!");
                return false;
            }
            return true;
        }

        private double GetRevisionSubTotal()
        {
            double total = 0.0;
            for (int i = 0; i < this.GridViewManager.DataGrid.Rows.Count; i++)
            {
                var row = this.GridViewManager.DataGrid.Rows[i];
                try
                {
                    total += double.Parse(row.Cells[RevisionDataGridViewColNames.SUB_TOTAL].Value.ToString());
                }
                catch (Exception) { }
            }
            return total;
        }

        private Revision ForgeRevision()
        {
            Revision revision = new Revision
            {
                StartDate = this.StartDate,
                Revenue = this.GetRevenueStream(TransactionTypes.Sale).Sum(r => r.RevenueAmount),
                Expenses = this.GetRevenueStream(TransactionTypes.Delivery).Sum(e => e.RevenueAmount),
                ActualRevenue = this.GetRevisionSubTotal() + this.SalesRevenue,
            };
            return revision;
        }

        private List<RevisionProduct> ForgeRevisionProducts()
        {
            List<RevisionProduct> revisionProducts = new List<RevisionProduct>();
            foreach (DataGridViewRow row in this.GridViewManager.DataGrid.Rows)
            {
                try
                {
                    int productId = (int)row.Cells[RevisionDataGridViewColNames.PRODUCT_ID].Value;
                    double actualQuantity = double.Parse(row.Cells[RevisionDataGridViewColNames.ACTUAL_QUANTITY].Value.ToString());
                    if (actualQuantity < 0)
                        continue;
                    Product product = this.ProductsRepository.FindProductById(productId);
                    RevisionProduct revisionProduct = new RevisionProduct
                    {
                        Id = product.Id,
                        AvailableQuantity = product.Quantity,
                        Quantity = actualQuantity,
                        SellPrice = product.SellPrice,
                    };

                    revisionProducts.Add(revisionProduct);
                }
                catch (Exception) { }
            }
            return revisionProducts;
        }

        private List<RevenueStream> GetRevenueStream(TransactionTypes transactionType)
        {
            switch (transactionType)
            {
                case TransactionTypes.Delivery:
                    return this.ExpenseStreamDbManager.FindAllNonRevisedEntities();
                case TransactionTypes.Sale:
                    return this.RevenueStreamDbManager.FindAllNonRevisedEntities();
                default:
                    return new List<RevenueStream>();
            }
        }       

        private List<RevenueStream> GetNonRevisedSalesRevenue()
        {
            List<Transaction> transactions = this.SaleTransactioDbManager.FindAllNonRevised()
                .Where(tr => tr.TransactionType == TransactionTypes.Sale.ToString()).ToList();
            List<RevenueStream> revenues = new List<RevenueStream>();
            foreach (var tr in transactions)
            {
                revenues.Add(this.RevenueStreamDbManager.FindOneByTransaction(tr.Id));
            }
            return revenues;
        }

        //FINALIZE REVISION AFTER COMMIT
        private void FinalizeRevisionAction()
        {
            this.RevisionDbManager.CreateRevision(this.Revision);
            this.SaleTransactioDbManager.ArchiveTransactions(); //same for deliveries
            this.RevenueStreamDbManager.ArchiveEntities();
            this.ExpenseStreamDbManager.ArchiveEntities();

            foreach (var revProd in this.RevisionProducts)
            {
                var product = this.ProductsRepository.FindProductById(revProd.Id);
                product.Quantity = revProd.Quantity;
                this.ProductsRepository.UpdateProduct(product, false);
            }

            this.CancelOperation();
            this.Form.Log("усшешна ревизия!");
        }

        //events
        private void OnRevisionConfirm(bool isConfirmed)
        {
            if (isConfirmed)
                this.FinalizeRevisionAction();
        }
    }
}
