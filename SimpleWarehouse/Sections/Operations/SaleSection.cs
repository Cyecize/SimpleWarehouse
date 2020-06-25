using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Model.Enum;
using SimpleWarehouse.Services.Transactions;
using static SimpleWarehouse.Constants.TransactionDataTableNames;

namespace SimpleWarehouse.Sections.Operations
{
    internal class SaleSection : AbstractOperationSection
    {
        public SaleSection(IPresenter presenter, TabPage tabPage, DataGridView dataGrid, TextBox totalSubBox)
            : base(presenter, tabPage, dataGrid, totalSubBox,
                new SaleTransactionDbService(presenter.GetStateManager().UserSession.SessionEntity))
        {
        }

        public override void UpdateTotalPriceAction(int rowId)
        {
            try
            {
                var quantity =
                    (double) OperationsViewService.GetDataAtRow(rowId, ProductQuantity);
                var prodPrice = (double) OperationsViewService.GetDataAtRow(rowId, ProductSellPrice);
                OperationsViewService.SetDataAtRow(rowId, TransactionTotalValue, $"{quantity * prodPrice:F2}");
            }
            catch (Exception)
            {
                /*ignored*/
            }
        }

        protected override List<TransactionProduct> GatherProductsForTransaction()
        {
            return GetProductsFromDataGrid(TransactionType.SALE);
        }
    }
}