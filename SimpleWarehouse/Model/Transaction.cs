using SimpleWarehouse.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Model
{
    public class Transaction
    {
        [DbNameReference(name:"id")]
        public int Id { get; set; }

        [DbNameReference(name: "date")]
        public DateTime Date { get; set; }

        [DbNameReference(name: "transaction_type")]
        public string TransactionType { get; set; }

        [DbNameReference(name: "is_revised")]
        public bool IsRevised { get; set; }

    }
}
