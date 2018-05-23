using SimpleWarehouse.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Model
{
    [DbTableNameReference(name: "invoices_users_joined")] //view
    public class Invoice
    {
        [DbNameReference(name: "id")]
        public int Id { get; set; }

        [DbNameReference(name: "user_id")]
        public int UserId { get; set; }

        [DbNameReference(name: "username")]
        public string Username { get; set; }

        [DbNameReference(name: "revenue_amount")]
        public double RevenueAmount { get; set; }

        [DbNameReference(name: "date")]
        public DateTime Date { get; set; }

        public Invoice()
        {
            this.Date = DateTime.Now;
            this.RevenueAmount = 0.0;
        }
    }
}
