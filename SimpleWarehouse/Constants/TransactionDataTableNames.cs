using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Constants
{
    public class TransactionDataTableNames
    {
        public const string TransactionNumber = "ProdTransactionCounter";

        public const string ProductName = "ProdTransactionProductName";

        public const string ProductQuantity = "ProdTransactionQuantity";

        public const string ProductImportPrice = "ProdTransactionImportPrice";

        public const string ProductSellPrice = "ProdTransactionSellPrice";

        public const string TransactionTotalValue = "ProdTransactionTotalPrice";

        public const string ProductAvailableQuantity = "ProdTransactionAvailableQuantity";

        public const string ProductId = "ProdTransactionProductId";
    }
}
