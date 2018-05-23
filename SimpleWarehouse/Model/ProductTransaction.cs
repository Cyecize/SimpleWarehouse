using SimpleWarehouse.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Model
{
    [DbTableNameReference(name: "products_transactions")]
    public class ProductTransaction
    {
        [DbNameReference(name: "product_id")]
        public int ProductId { get; set; }

        [DbNameReference(name: "transaction_id")]
        public int TransactionId { get; set; }

        [DbNameReference(name: "product_quantity")]
        public double ProductQuantity { get; set; }

        public double SubTotalPrice { get; set; }

    }
}
