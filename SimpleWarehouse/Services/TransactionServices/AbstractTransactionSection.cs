using SimpleWarehouse.Constants;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Presenter;
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
        public ITransactionGridViewManager TransactionGridManager { get; set; }
        public ITransactionDbManager TransactionDbManager { get; set; }


        public AbstractTransactionSection(HomePresenter presenter, TabPage tabPage, DataGridView dataGrid, ITransactionDbManager transactionDbManager)
        {
            this.Presenter = presenter;
            this.TransactionGridManager = new TransactionGridViewManager(tabPage, dataGrid, this.Presenter.Form, this);
            this.TransactionDbManager = transactionDbManager;
        }

        public void PickAProductRequest()
        {
            Console.WriteLine("Searching..");
            this.Presenter.GetStateManager().Push(new SearchProductPresenter(this.Presenter.GetStateManager(), this.AfterProductPickAction));         
        }

        public void Dispose()
        {
            this.TransactionGridManager.Dispose();
        }

        public void Initialize()
        {
            this.TransactionGridManager.Initialize();
        }

        public abstract void UpdateTotalPriceAction(int rowId);

        //private logic
        private void AfterProductPickAction(Product product)
        {
            this.TransactionGridManager.AddSelectedProduct(this.TransactionGridManager.DataGrid.CurrentRow, product);
            this.TransactionGridManager.DataGrid.EndEdit();
        }
        
    }
}
