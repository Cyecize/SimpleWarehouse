using SimpleWarehouse.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Model
{
    [Table("transactions")]
    public class Transaction
    {
       
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [Index(IsUnique = true)]
        public int Id { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        [Column("transaction_type")]
        [Required]
        public TransactionType TransactionType { get; set; }

        [Column("is_revised")]
        public bool IsRevised { get; set; }

        [ForeignKey("Expense")]
        [Column("expense_id")]
        public int? ExpenseId { get; set; }

        public virtual Expense Expense { get; set; }

        [ForeignKey("Revenue")]
        [Column("revenue_id")]
        public int? RevenueId { get; set; }

        public virtual Revenue Revenue { get; set; }

        public virtual List<TransactionProduct> TransactionProducts { get; set; }

        [NotMapped]
        public double RevenueAmount
        {
            get
            {
                if (this.Revenue != null) return this.Revenue.RevenueAmount;
                if (this.Expense != null) return this.Expense.RevenueAmount;
                return 0D;
            }
        }

        [NotMapped]
        public User User
        {
            get
            {
                if (this.Revenue != null) return this.Revenue.User;
                if (this.Expense != null) return this.Expense.User;
                return null;
            }
        }

        public Transaction()
        {
            this.IsRevised = false;
            this.Date = DateTime.Now;
            this.TransactionProducts = new List<TransactionProduct>();
        }
    }
}
