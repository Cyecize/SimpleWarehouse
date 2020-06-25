using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SimpleWarehouse.Model.Enum;

namespace SimpleWarehouse.Model
{
    [Table("transactions")]
    public class Transaction
    {
        public Transaction()
        {
            IsRevised = false;
            Date = DateTime.Now;
            TransactionProducts = new List<TransactionProduct>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [Index(IsUnique = true)]
        public int Id { get; set; }

        [Column("date")] public DateTime Date { get; set; }

        [Column("transaction_type")]
        [Required]
        public TransactionType TransactionType { get; set; }

        [Column("is_revised")] public bool IsRevised { get; set; }

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
                if (Revenue != null) return Revenue.RevenueAmount;
                if (Expense != null) return Expense.RevenueAmount;
                return 0D;
            }
        }

        [NotMapped]
        public User User
        {
            get
            {
                if (Revenue != null) return Revenue.User;
                if (Expense != null) return Expense.User;
                return null;
            }
        }
    }
}