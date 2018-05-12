using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleWarehouse.Constants;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Presenter;

namespace SimpleWarehouse.Services.TransactionServices
{
    public class SaleTransactionSection : AbstractTransactionSection
    {
        public SaleTransactionSection(HomePresenter presenter, TabPage tabPage, DataGridView dataGrid) : base(presenter, tabPage, dataGrid, null)
        {

        }

        public override void UpdateTotalPriceAction(int rowId)
        {
            try
            {
                double quantity = (double)this.TransactionGridManager.DataGrid.Rows[rowId].Cells[TransactionDataTableNames.PRODUCT_QUANTITY].Value;
                double prodPrice = (double)this.TransactionGridManager.DataGrid.Rows[rowId].Cells[TransactionDataTableNames.PRODUCT_SELL_PRICE].Value;
                this.TransactionGridManager.DataGrid.Rows[rowId].Cells[TransactionDataTableNames.TRANSACTION_TOTAL_VALUE].Value = $"{(quantity * prodPrice):F2}";
            }
            catch (Exception) { }
        }
    }
}
