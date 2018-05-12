using SimpleWarehouse.Constants;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Presenter;
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

        public ITransactionGridViewManager TransactionGridManager { get; set; }
        public ITransactionDbManager TransactionDbManager { get; set; }



        public AbstractTransactionSection(HomePresenter presenter, TabPage tabPage, DataGridView dataGrid, ITransactionDbManager transactionDbManager)
        {
            this.Presenter = presenter;
            this.TransactionGridManager = new TransactionGridViewManager(tabPage, dataGrid, this.Presenter.Form, this);
            this.TransactionDbManager = transactionDbManager;
            this.SetTextbox(this.Presenter.Form);
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

        public abstract void UpdateTotalPriceAction(int rowId);

        protected abstract void SetTextbox(IHomeView form);

        //private logic
        private void AfterProductPickAction(Product product)
        {
            this.TransactionGridManager.AddSelectedProduct(this.TransactionGridManager.DataGrid.CurrentRow, product);
            this.TransactionGridManager.DataGrid.EndEdit();
        }


    }
}
