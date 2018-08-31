using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleWarehouse.Constants;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Model.Enum;
using SimpleWarehouse.Presenter;
using SimpleWarehouse.Presenter.Other;
using SimpleWarehouse.Services.Products;
using SimpleWarehouse.Services.Revenues;
using SimpleWarehouse.Services.Revisions;
using SimpleWarehouse.Services.Transactions;
using SimpleWarehouse.View;
using static SimpleWarehouse.Constants.RevisionDataGridViewColNames;

namespace SimpleWarehouse.Sections.Revisions
{
    public class RevisionSection : IRevisionSection
    {
        private const string PleaseStartRevisionFirst = "Моля стартирайте ревизията първо!";
        private const string SuccessfulRevision = "усшешна ревизия!";

        private IPresenter Presenter { get; set; }
        private IHomeView Form { get; set; }
        private IRevisionDbService RevisionDbService { get; set; }
        private double SalesRevenue { get; set; }
        private DateTime StartDate { get; set; }
        private bool IsRevisionStarted { get; set; }
        private Revision Revision { get; set; }
        private List<RevisionProduct> RevisionProducts { get; set; }

        public IRevisionViewService ViewService { get; set; }
        public IProductDbService ProductService { get; set; }
        public ITransactionDbService TransactionDbService { get; set; }
        public IRevenueStreamDbService RevenueDbService { get; set; }
        public IRevenueStreamDbService ExpenseDbService { get; set; }

        public RevisionSection(IPresenter presenter, IHomeView homeForm)
        {
            this.Form = homeForm;
            this.Presenter = presenter;
            this.RevisionDbService = new RevisionDbService();

            this.ViewService = new RevisionViewService(this.Form.RevisionDataTable, this.Form, this);
            this.ProductService = new ProductDbService();
            this.TransactionDbService = new InvariantTransactionDbService(this.Presenter.GetStateManager().UserSession.SessionEntity);
            this.RevenueDbService = new RevenuesDbService();
            this.ExpenseDbService = new ExpensesDbService();
            this.SalesRevenue = 0D;
            this.IsRevisionStarted = false;
        }

        public void CancelOperation()
        {
            this.SalesRevenue = 0.0;
            this.ClearTextBoxValues();
            this.ViewService.ClearRows();
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
                this.Form.Log(PleaseStartRevisionFirst);
                return;
            }
            this.Revision = this.ForgeRevision();
            this.RevisionProducts = this.ForgeRevisionProducts();
            string confirmText = $"{this.Revision.ToString()}\r\nТова ще редактира {this.RevisionProducts.Count} продуктa и ще премести сегашните приходи и разходи в архива.";
            this.Presenter.GetStateManager().Push(new ConfirmActionPresenter(this.Presenter.GetStateManager(), this.OnRevisionConfirm, confirmText));
        }

        public void Initialize()
        {
            this.ViewService.Initialize();
            this.ViewService.ClearRows();
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
                var actualQuantity = double.Parse(this.ViewService.GetDataAtRow(rowId, ActualQuantity).ToString().Trim());
                var prodPrice = double.Parse(this.ViewService.GetDataAtRow(rowId, SellPrice).ToString().Trim());
                var availableQuantity = double.Parse(this.ViewService.GetDataAtRow(rowId, AvailableQuantity).ToString().Trim());
                if (actualQuantity >= 0)
                {
                    double difference = availableQuantity - actualQuantity;
                    this.ViewService.SetDataAtRow(rowId, SubTotal, $"{(difference * prodPrice):F2}");
                }
                else
                {
                    this.ViewService.SetDataAtRow(rowId, SubTotal, null);
                }
                this.RefreshSubTotalAction();
            }
            catch (Exception) { }
        }

        public void BeginRevision()
        {
            if (!this.VerifyUserRole())
                return;
            this.ViewService.ClearRows();
            this.ViewService.InsertProducts(this.ProductService.FindAllVisible());
            this.FillRevenueStreamInfo();
            this.IsRevisionStarted = true;
        }

        //PRIVATE METHODS
        private void RefreshSubTotalAction()
        {
            double total = this.GetRevisionSubTotal();
            this.ViewService.EndEdit();
            this.Form.RevisionSubTotal = $"{total:F2}";
            this.Form.RevisonSubTotalPlusSalesRevenue = $"{(total + this.SalesRevenue):F2}";
        }

        private void FillRevenueStreamInfo()
        {
            var transactions = this.TransactionDbService.FindAllNonRevised().OrderBy(tr => tr.Date).ToList();
            DateTime startDate = DateTime.Now;
            var expensesTotal = this.ExpenseDbService.FindAllNonRevised().Sum(e =>
            {
                if (e.Date < startDate) startDate = e.Date;
                return e.RevenueAmount;
            });
            var revenuesTotal = this.RevenueDbService.FindAllNonRevised().Sum(r =>
            {
                if (r.Date < startDate) startDate = r.Date;
                return r.RevenueAmount;
            });
            var oldestRevenueStream = transactions.FirstOrDefault();
            if (oldestRevenueStream != null && oldestRevenueStream.Date < startDate)
                startDate = oldestRevenueStream.Date;

            this.StartDate = startDate;
            //inserting the data
            var stDate = $"Начална дата: {startDate.ToString(Config.DateTimeFormat)}";
            this.SalesRevenue = transactions.Where(tr => tr.TransactionType == TransactionType.SALE).Sum(r => r.RevenueAmount);
            this.InsertTextBoxValues($"{expensesTotal:F2}", $"{revenuesTotal:F2}", stDate, "0", $"{this.SalesRevenue:F2}");
        }

        private void ClearTextBoxValues()
        {
            this.InsertTextBoxValues(null, null, @"Начална дата:", null, null);
        }

        private void InsertTextBoxValues(string expenses, string revenues, string startDate, string subTotal, string salesRevenue)
        {
            this.Form.RevisionExpenses = expenses;
            this.Form.RevisionRevenue = revenues;
            this.Form.RevisionStartDate = startDate;
            this.Form.RevisionSubTotal = subTotal;
            this.Form.RevisionSalesRevenue = salesRevenue;
            this.Form.RevisonSubTotalPlusSalesRevenue = this.SalesRevenue.ToString(CultureInfo.InvariantCulture);
        }

        private bool VerifyUserRole()
        {
            if (!Roles.IsStandard(this.Presenter.GetStateManager().UserSession.SessionEntity.Roles))
            {
                this.Form.Log(Messages.NotAuthorizedMsg);
                return false;
            }
            return true;
        }

        private double GetRevisionSubTotal()
        {
            double total = 0.0;
            for (int rowId = 0; rowId < this.ViewService.GetRowsCount(); rowId++)
            {
                try
                {
                    total += double.Parse(this.ViewService.GetDataAtRow(rowId, SubTotal) + "");
                }
                catch (Exception) {/*ignored*/ }
            }
            return total;
        }

        private Revision ForgeRevision()
        {
            Revision revision = new Revision
            {
                StartDate = this.StartDate,
                Revenue = this.RevenueDbService.FindAllNonRevised().Sum(r => r.RevenueAmount),
                Expenses = this.ExpenseDbService.FindAllNonRevised().Sum(e => e.RevenueAmount),
                ActualRevenue = this.GetRevisionSubTotal() + this.SalesRevenue,
            };
            return revision;
        }

        private List<RevisionProduct> ForgeRevisionProducts()
        {
            List<RevisionProduct> revisionProducts = new List<RevisionProduct>();
            for (int rowId = 0; rowId < this.ViewService.GetRowsCount(); rowId++)
            {
                try
                {
                    int productId = (int)this.ViewService.GetDataAtRow(rowId, ProductId);
                    double actualQuantity = double.Parse(this.ViewService.GetDataAtRow(rowId, ActualQuantity) + "");
                    if (actualQuantity < 0)
                        continue;
                    Product product = this.ProductService.FindById(productId);
                    RevisionProduct revisionProduct = new RevisionProduct
                    {
                        Id = product.Id,
                        AvailableQuantity = product.Quantity,
                        Quantity = actualQuantity,
                        SellPrice = product.SellPrice,
                    };
                    revisionProducts.Add(revisionProduct);
                }
                catch (Exception)
                {
                    /*ignored*/
                }
            }

            return revisionProducts;
        }

        //FINALIZE REVISION AFTER COMMIT
        private void FinalizeRevisionAction()
        {
            this.RevisionDbService.CreateRevision(this.Revision);
            this.TransactionDbService.ArchiveTransactions(); //same for deliveries
            this.RevenueDbService.Archive();
            this.ExpenseDbService.Archive();

            foreach (var revProd in this.RevisionProducts)
            {
                var product = this.ProductService.FindById(revProd.Id);
                product.Quantity = revProd.Quantity;
                this.ProductService.UpdateProduct(product);
            }

            this.CancelOperation();
            this.Form.Log(SuccessfulRevision);
        }

        //events
        private void OnRevisionConfirm(bool isConfirmed)
        {
            if (isConfirmed)
                this.FinalizeRevisionAction();
        }
    }
}
