using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Model
{
    public class RevenueStream
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("revenue_amount")]
        public double RevenueAmount { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        [Column("is_revised")]
        public bool IsRevised { get; set; }

        [StringLength(maximumLength: 255)]
        [Column("comment")]
        public string Comment { get; set; }

        [ForeignKey("User")]
        [Column("user_id")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public RevenueStream()
        {
            this.IsRevised = false;
            this.Date = DateTime.Now;
            this.RevenueAmount = 0D;
        }
    }
}
