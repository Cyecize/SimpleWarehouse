using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Model.Enum;
using SimpleWarehouse.Presenter.Products;
using SimpleWarehouse.Services.Operations;
using SimpleWarehouse.Services.Products;
using SimpleWarehouse.Services.Transactions;
using static SimpleWarehouse.Constants.TransactionDataTableNames;

namespace SimpleWarehouse.Sections.Operations
{
    public abstract class AbstractOperationSection : IOperationsSection
    {
        private const string ProductAlreadyChosen = "Вече сте избрали този продукт";
        private const string ChooseAtLeastOneProduct = "Изберете поне един продукт!";
        private const string SuccessfulOperation = "Успешна транзакция!";
        private const string ThereWasAnErrorOnRow = "Имаше проблем на ред с номер ";
        private const string ChooseValidQuantity = "Изберете валидно киличество на ред ";
        private const string InsufficientAmount = "Недостатчно количесто на ред ";

        protected AbstractOperationSection(IPresenter presenter, TabPage tabPage, DataGridView dataGrid,
            TextBox totalSubBox, ITransactionDbService transactionDbService)
        {
            ProductDbService = new ProductDbService();
            Presenter = presenter;
            TotalSumBox = totalSubBox;
            OperationsViewService = new OperationViewService(tabPage, dataGrid, presenter.Loggable, this);
            TransactionDbService = transactionDbService;
        }


        private IPresenter Presenter { get; }

        protected TextBox TotalSumBox { get; set; }

        protected IProductDbService ProductDbService { get; set; }

        public IOperationsViewService OperationsViewService { get; set; }

        public ITransactionDbService TransactionDbService { get; set; }

        public void CancelOperation()
        {
            OperationsViewService.ClearRows();
            RefreshGridAction();
        }

        public void Initialize()
        {
            OperationsViewService.Initialize();
        }

        public void PickAProductRequest()
        {
            Presenter.GetStateManager().OutputWriter.WriteLine("Searching..");
            Presenter.GetStateManager()
                .Push(new SearchProductPresenter(Presenter.GetStateManager(), AfterProductPickAction));
        }

        public abstract void UpdateTotalPriceAction(int rowId);

        public void RefreshGridAction()
        {
            TotalSumBox.Text = $@"{OperationsViewService.RefreshGrid():F2}";
        }

        public void CreateTransactionAction()
        {
            try
            {
                var products = GatherProductsForTransaction();
                if (products.Count < 1)
                {
                    Presenter.Loggable.Log(ChooseAtLeastOneProduct);
                    return;
                }

                TransactionDbService.AddTransaction(products);
                OperationsViewService.ClearRows();
                Presenter.Loggable.Log(SuccessfulOperation);
            }
            catch (ArgumentException e)
            {
                Presenter.Loggable.Log(e.Message);
            }
        }

        protected abstract List<TransactionProduct> GatherProductsForTransaction();

        protected List<TransactionProduct> GetProductsFromDataGrid(TransactionType transactionType)
        {
            var products = new List<TransactionProduct>();
            for (var i = 0; i < OperationsViewService.GetRowsCount(); i++)
            {
                //var row = this.OperationsViewService.DataGrid.Rows[i];
                var transactionNumber = OperationsViewService.GetDataAtRow(i, TransactionNumber);
                var productId = -1;
                var selectedProductQuantity = 0D;
                Product product;
                try
                {
                    var prodIdCell = OperationsViewService.GetDataAtRow(i, ProductId);
                    if (prodIdCell == null)
                        continue;
                    productId = (int) prodIdCell;
                    product = ProductDbService.FindById(productId);
                    if (product == null)
                        throw new Exception();
                    selectedProductQuantity = double.Parse(OperationsViewService.GetDataAtRow(i, ProductQuantity) + "");
                }
                catch (Exception)
                {
                    throw new ArgumentException($"{ThereWasAnErrorOnRow} {transactionNumber}");
                }

                if (selectedProductQuantity <= 0D)
                    throw new ArgumentException($"{ChooseValidQuantity} {transactionNumber}");

                if (transactionType == TransactionType.SALE)
                    if (product.Quantity < selectedProductQuantity)
                        throw new ArgumentException($"{InsufficientAmount} {transactionNumber}");

                var subTotal = 0.0;
                switch (transactionType)
                {
                    case TransactionType.SALE:
                        subTotal = product.SellPrice * selectedProductQuantity;
                        break;
                    case TransactionType.DELIVERY:
                        subTotal = product.ImportPrice * selectedProductQuantity;
                        break;
                }

                var productTransaction = new TransactionProduct
                {
                    ProductId = product.Id,
                    ProductQuantity = selectedProductQuantity,
                    SubTotalPrice = subTotal
                };
                products.Add(productTransaction);
            }

            return products;
        }

        //PRIVATE LOGIC
        private void AfterProductPickAction(Product product)
        {
            if (OperationsViewService.GetAllProductIds().Contains(product.Id))
            {
                Presenter.Loggable.Log(ProductAlreadyChosen);
                return;
            }

            OperationsViewService.AddSelectedProduct(OperationsViewService.GetCurrentRow(), product);
        }
    }
}