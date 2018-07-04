using SimpleWarehouse.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Model
{
    [DbTableNameReference(name: "transactions_joined")]
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

        [DbNameReference("user_id")]
        private double _userId { get; set; }

        public int UserId { get => (int)this._userId; }

        [DbNameReference("revenue_stream_id")]
        public int RevenueStreamId { get; set; }

        [DbNameReference(name: "revenue_amount")]
        public double RevenueAmount { get; set; }

        [DbNameReference(name: "username")]
        public string Username { get; set; }

    }
}
