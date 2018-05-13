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
            List<ProductTransaction> products = new List<ProductTransaction>();
            for (int i = 0; i < base.TransactionGridManager.DataGrid.RowCount; i++)
            {
                var row = base.TransactionGridManager.DataGrid.Rows[i];
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
                    product = base.ProductsRepositoryManager.FindProductById(productId);
                    if (product == null)
                        throw new Exception();
                    selectedProductQuantity = (double)row.Cells[TransactionDataTableNames.PRODUCT_QUANTITY].Value;
                }
                catch (Exception) { throw new ArgumentException($"Имаше проблем на ред с номер {transactionNumber}"); }

                if (selectedProductQuantity <= 0)
                    throw new ArgumentException($"Изберете количесто над 0 на ред {transactionNumber}");

                // if (product.Quantity < selectedProductQuantity)
                //throw new ArgumentException($"Недостатчно количесто на ред {transactionNumber}");

                double subTotal = product.ImportPrice * selectedProductQuantity;
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

        protected override void SetTextbox(IHomeView form)
        {
            base.TotalSumBox = form.TotalDeliveryMoney;
        }
    }
}
