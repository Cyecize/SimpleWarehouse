using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleWarehouse.Constants;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Presenter;
using SimpleWarehouse.View;

namespace SimpleWarehouse.Services.TransactionServices
{
    public class DeliveryTransactionSection : AbstractTransactionSection
    {

        public DeliveryTransactionSection(HomePresenter presenter, TabPage tabPage, DataGridView dataGrid, ITransactionDbManager transactionDbManager) :
            base(presenter, tabPage, dataGrid, transactionDbManager)
        {

        }

        public override void UpdateTotalPriceAction(int rowId)
        {
            try
            {
                double quantity = (double)this.TransactionGridManager.DataGrid.Rows[rowId].Cells[TransactionDataTableNames.PRODUCT_QUANTITY].Value;
                double prodPrice = (double)this.TransactionGridManager.DataGrid.Rows[rowId].Cells[TransactionDataTableNames.PRODUCT_IMPORT_PRICE].Value;
                this.TransactionGridManager.DataGrid.Rows[rowId].Cells[TransactionDataTableNames.TRANSACTION_TOTAL_VALUE].Value = $"{(quantity * prodPrice):F2}";
            }
            catch (Exception) { }
        }

        protected override List<ProductTransaction> GatherProductsForTransaction()
        {
            return base.GetProductsFromDataGrid(false);
        }

        protected override void SetTextbox(IHomeView form)
        {
            base.TotalSumBox = form.TotalDeliveryMoney;
        }
    }
}
