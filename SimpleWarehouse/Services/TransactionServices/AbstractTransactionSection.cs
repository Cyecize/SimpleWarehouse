using SimpleWarehouse.Constants;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Presenter;
using SimpleWarehouse.Services.ProductSectionManagers;
using SimpleWarehouse.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWarehouse.Services.TransactionServices
{
    public abstract class AbstractTransactionSection : ITransactionSection
    {
        private HomePresenter Presenter { get; set; }

        protected TextBox TotalSumBox { get; set; }
        protected IProductsRepositoryManager ProductsRepositoryManager { get; set; }

        public ITransactionGridViewManager TransactionGridManager { get; set; }
        public ITransactionDbManager TransactionDbManager { get; set; }


        public AbstractTransactionSection(HomePresenter presenter, TabPage tabPage, DataGridView dataGrid, ITransactionDbManager transactionDbManager)
        {
            this.Presenter = presenter;
            this.TransactionGridManager = new TransactionGridViewManager(tabPage, dataGrid, this.Presenter.Form, this);
            this.TransactionDbManager = transactionDbManager;
            this.SetTextbox(this.Presenter.Form);
            this.ProductsRepositoryManager = new ProductRepositoryManager(this.Presenter.GetStateManager().SqlManager);
        }

        public void PickAProductRequest()
        {
            Console.WriteLine("Searching..");
            this.Presenter.GetStateManager().Push(new SearchProductPresenter(this.Presenter.GetStateManager(), this.AfterProductPickAction));
        }

        public void CancelOperation()
        {
            this.TransactionGridManager.ClearRows();
            this.RefreshGridAction();
        }

        public void Initialize()
        {
            this.TransactionGridManager.Initialize();
        }

        public void RefreshGridAction()
        {
            double total = 0.0;
            for (int i = 0; i < this.TransactionGridManager.DataGrid.Rows.Count; i++)
            {
                this.UpdateTotalPriceAction(i);
                var row = this.TransactionGridManager.DataGrid.Rows[i];
                try
                {
                    total += double.Parse(row.Cells[TransactionDataTableNames.TRANSACTION_TOTAL_VALUE].Value.ToString());
                }
                catch (Exception) { }
            }
            this.TransactionGridManager.DataGrid.EndEdit();
            this.TotalSumBox.Text = $"{total:F2}";
        }

        public void CreateTransactionAction()
        {
            try
            {
                List<ProductTransaction> products = this.GatherProductsForTransaction();
                if (products.Count < 1)
                {
                    this.Presenter.Form.Log("Изберете поне един продукт!");
                    return;
                }
                this.TransactionDbManager.AddTransaction(products);
                this.TransactionGridManager.ClearRows();
                this.Presenter.Form.Log("Успешна транзакция!");
            }
            catch (ArgumentException e) { this.Presenter.Form.Log(e.Message); return; }
        }

        public abstract void UpdateTotalPriceAction(int rowId);

        protected abstract void SetTextbox(IHomeView form);

        protected abstract List<ProductTransaction> GatherProductsForTransaction();

        protected List<ProductTransaction> GetProductsFromDataGrid(TransactionTypes transactionType)
        {
            List<ProductTransaction> products = new List<ProductTransaction>();
            for (int i = 0; i < this.TransactionGridManager.DataGrid.RowCount; i++)
            {
                var row = this.TransactionGridManager.DataGrid.Rows[i];
                object transactionNumber = row.Cells[TransactionDataTableNames.TRANSACTION_NUMBER].Value;
                int productId = -1;
                double selectedProductQuantity = 0.0;
                Product product;
                try
                {
                    var prodIdCell = row.Cells[TransactionDataTableNames.PRODUCT_ID].Value;
                    if (prodIdCell == null)
                        continue;
                    productId = (int)prodIdCell;
                    product = this.ProductsRepositoryManager.FindProductById(productId);
                    if (product == null)
                        throw new Exception();
                    selectedProductQuantity = (double)row.Cells[TransactionDataTableNames.PRODUCT_QUANTITY].Value;
                }
                catch (Exception) { throw new ArgumentException($"Имаше проблем на ред с номер {transactionNumber}"); }

                if (selectedProductQuantity <= 0)
                    throw new ArgumentException($"Изберете количесто над 0 на ред {transactionNumber}");

                if (transactionType == TransactionTypes.Sale)
                {
                    if (product.Quantity < selectedProductQuantity)
                        throw new ArgumentException($"Недостатчно количесто на ред {transactionNumber}");
                }

                double subTotal = 0.0;
                switch (transactionType)
                {
                    case TransactionTypes.Sale:
                        subTotal = product.SellPrice * selectedProductQuantity;
                        break;
                    case TransactionTypes.Delivery:
                        subTotal = product.ImportPrice * selectedProductQuantity;
                        break;
                }

                ProductTransaction productTransaction = new ProductTransaction
                {
                    ProductId = product.Id,
                    ProductQuantity = selectedProductQuantity,
                    SubTotalPrice = subTotal,
                };
                products.Add(productTransaction);
            }

            return products;
        }

        //private logic
        private void AfterProductPickAction(Product product)
        {
            if (this.TransactionGridManager.GetAllProductIds().Contains(product.Id))
            {
                this.Presenter.Form.Log("Вече сте избрали този продукт");
                return;
            }
            this.TransactionGridManager.AddSelectedProduct(this.TransactionGridManager.DataGrid.CurrentRow, product);
            this.TransactionGridManager.DataGrid.EndEdit();
        }


    }
}
