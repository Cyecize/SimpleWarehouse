using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleWarehouse.Model
{
    public class RevenueStream
    {
        public RevenueStream()
        {
            IsRevised = false;
            Date = DateTime.Now;
            RevenueAmount = 0D;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("revenue_amount")] public double RevenueAmount { get; set; }

        [Column("date")] public DateTime Date { get; set; }

        [Column("is_revised")] public bool IsRevised { get; set; }

        [StringLength(255)]
        [Column("comment")]
        public string Comment { get; set; }

        [ForeignKey("User")]
        [Column("user_id")]
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}