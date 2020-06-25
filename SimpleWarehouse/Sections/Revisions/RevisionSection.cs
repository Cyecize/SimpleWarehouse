using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using SimpleWarehouse.Constants;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Model.Enum;
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

        public RevisionSection(IPresenter presenter, IHomeView homeForm)
        {
            Form = homeForm;
            Presenter = presenter;
            RevisionDbService = new RevisionDbService();

            ViewService = new RevisionViewService(Form.RevisionDataTable, Form, this);
            ProductService = new ProductDbService();
            TransactionDbService =
                new InvariantTransactionDbService(Presenter.GetStateManager().UserSession.SessionEntity);
            RevenueDbService = new RevenuesDbService();
            ExpenseDbService = new ExpensesDbService();
            SalesRevenue = 0D;
            IsRevisionStarted = false;
        }

        private IPresenter Presenter { get; }
        private IHomeView Form { get; }
        private IRevisionDbService RevisionDbService { get; }
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

        public void CancelOperation()
        {
            SalesRevenue = 0.0;
            ClearTextBoxValues();
            ViewService.ClearRows();
            IsRevisionStarted = false;
            Revision = null;
            RevisionProducts = null;
        }

        public void CommitRevisionAction()
        {
            if (!VerifyUserRole())
                return;
            if (!IsRevisionStarted)
            {
                Form.Log(PleaseStartRevisionFirst);
                return;
            }

            Revision = ForgeRevision();
            RevisionProducts = ForgeRevisionProducts();
            var confirmText =
                $"{Revision}\r\nТова ще редактира {RevisionProducts.Count} продуктa и ще премести сегашните приходи и разходи в архива.";
            Presenter.GetStateManager()
                .Push(new ConfirmActionPresenter(Presenter.GetStateManager(), OnRevisionConfirm, confirmText));
        }

        public void Initialize()
        {
            ViewService.Initialize();
            ViewService.ClearRows();
        }

        public void RefreshGridAction()
        {
            if (!VerifyUserRole())
                return;

            FillRevenueStreamInfo(); //updates the revenues and expenses just in case
            RefreshSubTotalAction();
        }

        public void UpdateTotalPriceAction(int rowId)
        {
            try
            {
                var actualQuantity = double.Parse(ViewService.GetDataAtRow(rowId, ActualQuantity).ToString().Trim());
                var prodPrice = double.Parse(ViewService.GetDataAtRow(rowId, SellPrice).ToString().Trim());
                var availableQuantity =
                    double.Parse(ViewService.GetDataAtRow(rowId, AvailableQuantity).ToString().Trim());
                if (actualQuantity >= 0)
                {
                    var difference = availableQuantity - actualQuantity;
                    ViewService.SetDataAtRow(rowId, SubTotal, $"{difference * prodPrice:F2}");
                }
                else
                {
                    ViewService.SetDataAtRow(rowId, SubTotal, null);
                }

                RefreshSubTotalAction();
            }
            catch (Exception)
            {
            }
        }

        public void BeginRevision()
        {
            if (!VerifyUserRole())
                return;
            ViewService.ClearRows();
            ViewService.InsertProducts(ProductService.FindAllVisible());
            FillRevenueStreamInfo();
            IsRevisionStarted = true;
        }

        //PRIVATE METHODS
        private void RefreshSubTotalAction()
        {
            var total = GetRevisionSubTotal();
            ViewService.EndEdit();
            Form.RevisionSubTotal = $"{total:F2}";
            Form.RevisonSubTotalPlusSalesRevenue = $"{total + SalesRevenue:F2}";
        }

        private void FillRevenueStreamInfo()
        {
            var transactions = TransactionDbService.FindAllNonRevised().OrderBy(tr => tr.Date).ToList();
            var startDate = DateTime.Now;
            var expensesTotal = ExpenseDbService.FindAllNonRevised().Sum(e =>
            {
                if (e.Date < startDate) startDate = e.Date;
                return e.RevenueAmount;
            });
            var revenuesTotal = RevenueDbService.FindAllNonRevised().Sum(r =>
            {
                if (r.Date < startDate) startDate = r.Date;
                return r.RevenueAmount;
            });
            var oldestRevenueStream = transactions.FirstOrDefault();
            if (oldestRevenueStream != null && oldestRevenueStream.Date < startDate)
                startDate = oldestRevenueStream.Date;

            StartDate = startDate;
            //inserting the data
            var stDate = $"Начална дата: {startDate.ToString(Config.DateTimeFormat)}";
            SalesRevenue = transactions.Where(tr => tr.TransactionType == TransactionType.SALE)
                .Sum(r => r.RevenueAmount);
            InsertTextBoxValues($"{expensesTotal:F2}", $"{revenuesTotal:F2}", stDate, "0", $"{SalesRevenue:F2}");
        }

        private void ClearTextBoxValues()
        {
            InsertTextBoxValues(null, null, @"Начална дата:", null, null);
        }

        private void InsertTextBoxValues(string expenses, string revenues, string startDate, string subTotal,
            string salesRevenue)
        {
            Form.RevisionExpenses = expenses;
            Form.RevisionRevenue = revenues;
            Form.RevisionStartDate = startDate;
            Form.RevisionSubTotal = subTotal;
            Form.RevisionSalesRevenue = salesRevenue;
            Form.RevisonSubTotalPlusSalesRevenue = SalesRevenue.ToString(CultureInfo.InvariantCulture);
        }

        private bool VerifyUserRole()
        {
            if (!Roles.IsStandard(Presenter.GetStateManager().UserSession.SessionEntity.Roles))
            {
                Form.Log(Messages.NotAuthorizedMsg);
                return false;
            }

            return true;
        }

        private double GetRevisionSubTotal()
        {
            var total = 0.0;
            for (var rowId = 0; rowId < ViewService.GetRowsCount(); rowId++)
                try
                {
                    total += double.Parse(ViewService.GetDataAtRow(rowId, SubTotal) + "");
                }
                catch (Exception)
                {
                    /*ignored*/
                }

            return total;
        }

        private Revision ForgeRevision()
        {
            var revision = new Revision
            {
                StartDate = StartDate,
                Revenue = RevenueDbService.FindAllNonRevised().Sum(r => r.RevenueAmount),
                Expenses = ExpenseDbService.FindAllNonRevised().Sum(e => e.RevenueAmount),
                ActualRevenue = GetRevisionSubTotal() + SalesRevenue
            };
            return revision;
        }

        private List<RevisionProduct> ForgeRevisionProducts()
        {
            var revisionProducts = new List<RevisionProduct>();
            for (var rowId = 0; rowId < ViewService.GetRowsCount(); rowId++)
                try
                {
                    var productId = (int) ViewService.GetDataAtRow(rowId, ProductId);
                    var actualQuantity = double.Parse(ViewService.GetDataAtRow(rowId, ActualQuantity) + "");
                    if (actualQuantity < 0)
                        continue;
                    var product = ProductService.FindById(productId);
                    var revisionProduct = new RevisionProduct
                    {
                        Id = product.Id,
                        AvailableQuantity = product.Quantity,
                        Quantity = actualQuantity,
                        SellPrice = product.SellPrice
                    };
                    revisionProducts.Add(revisionProduct);
                }
                catch (Exception)
                {
                    /*ignored*/
                }

            return revisionProducts;
        }

        //FINALIZE REVISION AFTER COMMIT
        private void FinalizeRevisionAction()
        {
            RevisionDbService.CreateRevision(Revision);
            TransactionDbService.ArchiveTransactions(); //same for deliveries
            RevenueDbService.Archive();
            ExpenseDbService.Archive();

            foreach (var revProd in RevisionProducts)
            {
                var product = ProductService.FindById(revProd.Id);
                product.Quantity = revProd.Quantity;
                ProductService.UpdateProduct(product);
            }

            CancelOperation();
            Form.Log(SuccessfulRevision);
        }

        //events
        private void OnRevisionConfirm(bool isConfirmed)
        {
            if (isConfirmed)
                FinalizeRevisionAction();
        }
    }
}