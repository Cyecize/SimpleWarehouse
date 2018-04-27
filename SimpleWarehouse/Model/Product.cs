using SimpleWarehouse.Attributes;
using SimpleWarehouse.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Model
{
    public class Product
    {
        [DbNameReference(name: "id")]
        public int Id { get; set; }

        [DbNameReference(name: "category_id")]
        public int CategoryId { get; set; }

        [DbNameReference(name: "category_name")]
        public string CategoryName { get; set; }

        [DbNameReference(name: "product_name")]
        public string ProductName { get; set; }

        [DbNameReference(name: "quantity")]
        public double Quantity { get; set; }

        [DbNameReference(name: "import_price")]
        public double ImportPrice { get; set; }

        [DbNameReference(name: "sell_price")]
        public double SellPrice { get; set; }

        [DbNameReference(name: "is_visible")]
        public bool IsVisible { get; set; }

       

    }
}
