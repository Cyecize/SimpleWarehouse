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
   public class DeliverySection : AbstractOperationSection
    {
        public DeliverySection(IPresenter presenter, TabPage tabPage, DataGridView dataGrid, TextBox totalSumBox) 
            : base(presenter, tabPage, dataGrid, totalSumBox, new DeliveryTransactionDbService(presenter.GetStateManager().UserSession.SessionEntity))
        {

        }

        public override void UpdateTotalPriceAction(int rowId)
        {
            try
            {
                double quantity =
                    (double) base.OperationsViewService.GetDataAtRow(rowId, ProductQuantity);
                double prodPrice = (double)base.OperationsViewService.GetDataAtRow(rowId, ProductImportPrice);
                base.OperationsViewService.SetDataAtRow(rowId, TransactionTotalValue, $"{(quantity * prodPrice):F2}");
            }
            catch (Exception) {/*ignored*/ }
        }

        protected override List<TransactionProduct> GatherProductsForTransaction()
        {
            return base.GetProductsFromDataGrid(TransactionType.DELIVERY);
        }
    }
}
