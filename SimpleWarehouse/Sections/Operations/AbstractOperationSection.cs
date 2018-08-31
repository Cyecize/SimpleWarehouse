using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleWarehouse.Constants;
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
        

        private IPresenter Presenter { get; set; }

        protected TextBox TotalSumBox { get; set; }

        protected IProductDbService ProductDbService { get; set; }

        public IOperationsViewService OperationsViewService { get; set; }

        public ITransactionDbService TransactionDbService { get; set; }

        protected AbstractOperationSection(IPresenter presenter, TabPage tabPage, DataGridView dataGrid, TextBox totalSubBox, ITransactionDbService transactionDbService)
        {
            this.ProductDbService = new ProductDbService();
            this.Presenter = presenter;
            this.TotalSumBox = totalSubBox;
            this.OperationsViewService = new OperationViewService(tabPage, dataGrid, presenter.Loggable, this);
            this.TransactionDbService = transactionDbService;
        }

        public void CancelOperation()
        {
            this.OperationsViewService.ClearRows();
            this.RefreshGridAction();
        }

        public void Initialize()
        {
            this.OperationsViewService.Initialize();
        }

        public void PickAProductRequest()
        {
            this.Presenter.GetStateManager().OutputWriter.WriteLine("Searching..");
            this.Presenter.GetStateManager().Push(new SearchProductPresenter(this.Presenter.GetStateManager(), this.AfterProductPickAction));
        }

        public abstract void UpdateTotalPriceAction(int rowId);

        public void RefreshGridAction()
        {
            this.TotalSumBox.Text = $@"{this.OperationsViewService.RefreshGrid():F2}";
        }

        public void CreateTransactionAction()
        {
            try
            {
                List<TransactionProduct> products = this.GatherProductsForTransaction();
                if (products.Count < 1)
                {
                    this.Presenter.Loggable.Log(ChooseAtLeastOneProduct);
                    return;
                }
                this.TransactionDbService.AddTransaction(products);
                this.OperationsViewService.ClearRows();
                this.Presenter.Loggable.Log(SuccessfulOperation);
            }
            catch (ArgumentException e) { this.Presenter.Loggable.Log(e.Message); }
        }

        protected abstract List<TransactionProduct> GatherProductsForTransaction();

        protected List<TransactionProduct> GetProductsFromDataGrid(TransactionType transactionType)
        {
            List<TransactionProduct> products = new List<TransactionProduct>();
            for (int i = 0; i < this.OperationsViewService.GetRowsCount(); i++)
            {
                //var row = this.OperationsViewService.DataGrid.Rows[i];
                object transactionNumber = this.OperationsViewService.GetDataAtRow(i, TransactionNumber);
                int productId = -1;
                double selectedProductQuantity = 0D;
                Product product;
                try
                {
                    var prodIdCell = this.OperationsViewService.GetDataAtRow(i, ProductId);
                    if (prodIdCell == null)
                        continue;
                    productId = (int)prodIdCell;
                    product = this.ProductDbService.FindById(productId);
                    if (product == null)
                        throw new Exception();
                    selectedProductQuantity = double.Parse( this.OperationsViewService.GetDataAtRow(i, ProductQuantity) + "");
                }
                catch (Exception) { throw new ArgumentException($"{ThereWasAnErrorOnRow} {transactionNumber}"); }

                if (selectedProductQuantity  <= 0D)
                    throw new ArgumentException($"{ChooseValidQuantity} {transactionNumber}");

                if (transactionType == TransactionType.SALE)
                {
                    if (product.Quantity < selectedProductQuantity)
                        throw new ArgumentException($"{InsufficientAmount} {transactionNumber}");
                }

                double subTotal = 0.0;
                switch (transactionType)
                {
                    case TransactionType.SALE:
                        subTotal = product.SellPrice * selectedProductQuantity;
                        break;
                    case TransactionType.DELIVERY:
                        subTotal = product.ImportPrice * selectedProductQuantity;
                        break;
                }

                TransactionProduct productTransaction = new TransactionProduct
                {
                    ProductId = product.Id,
                    ProductQuantity = selectedProductQuantity,
                    SubTotalPrice = subTotal,
                };
                products.Add(productTransaction);
            }

            return products;
        }
        //PRIVATE LOGIC
        private void AfterProductPickAction(Product product)
        {
            if (this.OperationsViewService.GetAllProductIds().Contains(product.Id))
            {
                this.Presenter.Loggable.Log(ProductAlreadyChosen);
                return;
            }
            this.OperationsViewService.AddSelectedProduct(this.OperationsViewService.GetCurrentRow(), product);
        }

    }
}
