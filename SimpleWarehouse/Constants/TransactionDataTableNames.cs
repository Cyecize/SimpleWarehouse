using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Constants
{
    public class TransactionDataTableNames
    {
        public const string TRANSACTION_NUMBER = "ProdTransactionCounter";

        public const string PRODUCT_NAME = "ProdTransactionProductName";

        public const string PRODUCT_QUANTITY = "ProdTransactionQuantity";

        public const string PRODUCT_IMPORT_PRICE = "ProdTransactionImportPrice";

        public const string PRODUCT_SELL_PRICE = "ProdTransactionSellPrice";

        public const string TRANSACTION_TOTAL_VALUE = "ProdTransactionTotalPrice";

        public const string PRODUCT_AVAILABLE_QUANTITY = "ProdTransactionAvailableQuantity";

        public const string PRODUCT_ID = "ProdTransactionProductId";
    }
}
