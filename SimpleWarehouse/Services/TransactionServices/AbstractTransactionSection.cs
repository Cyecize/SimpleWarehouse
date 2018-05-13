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
                   total+=  double.Parse( row.Cells[TransactionDataTableNames.TRANSACTION_TOTAL_VALUE].Value.ToString());   
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
                double totalSum = products.Sum(p => p.SubTotalPrice);
                this.TransactionDbManager.AddTransaction(products);
                this.TransactionGridManager.ClearRows();
                this.Presenter.Form.Log("Успешна транзакция!");
            }
            catch(ArgumentException e) { this.Presenter.Form.Log(e.Message); return; }
            this.Presenter.Form.Log("So far so good");
        }

        public abstract void UpdateTotalPriceAction(int rowId);

        protected abstract void SetTextbox(IHomeView form);

        protected abstract List<ProductTransaction> GatherProductsForTransaction();

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
