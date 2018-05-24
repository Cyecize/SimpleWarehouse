using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Model
{
    public class RevisionProduct
    {
        public int Id { get; set; }

        public double Quantity { get; set; }

        public double AvailableQuantity { get; set; }

        public double SellPrice { get; set; }

    }
}
