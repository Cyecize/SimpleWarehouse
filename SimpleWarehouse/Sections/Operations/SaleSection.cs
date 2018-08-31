using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Model.Enum;
using SimpleWarehouse.Services.Transactions;
using static SimpleWarehouse.Constants.TransactionDataTableNames;

namespace SimpleWarehouse.Sections.Operations
{
    class SaleSection : AbstractOperationSection
    {
        public SaleSection(IPresenter presenter, TabPage tabPage, DataGridView dataGrid, TextBox totalSubBox) 
            : base(presenter, tabPage, dataGrid, totalSubBox, new SaleTransactionDbService(presenter.GetStateManager().UserSession.SessionEntity))
        {
        }

        public override void UpdateTotalPriceAction(int rowId)
        {
            try
            {
                double quantity =
                    (double)base.OperationsViewService.GetDataAtRow(rowId, ProductQuantity);
                double prodPrice = (double)base.OperationsViewService.GetDataAtRow(rowId, ProductSellPrice);
                base.OperationsViewService.SetDataAtRow(rowId, TransactionTotalValue, $"{(quantity * prodPrice):F2}");
            }
            catch (Exception) {/*ignored*/ }
        }

        protected override List<TransactionProduct> GatherProductsForTransaction()
        {
            return base.GetProductsFromDataGrid(TransactionType.SALE);
        }
    }
}
