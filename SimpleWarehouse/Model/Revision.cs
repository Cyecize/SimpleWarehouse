using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWarehouse.Constants;

namespace SimpleWarehouse.Model
{
    [Table("revisions")]
    public class Revision
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [Index(IsUnique = true)]
        public int Id { get; set; }

        [Column("expenses")]
        public double Expenses { get; set; }

        [Column("revenue")]
        public double Revenue { get; set; }

        [Column("actual_revenue")]
        public double ActualRevenue { get; set; }

        [Required]
        [Column("start_date")]
        public DateTime StartDate { get; set; }

        [Column("revision_date")]
        public DateTime RevisionDate { get; set; }

        public Revision()
        {
            this.RevisionDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Приходи: {this.Revenue:F2} \r\n" +
                   $"Разходи: {this.Expenses:F2}\r\n" +
                   $"Изчислени приходи (ревизия): {this.ActualRevenue:F2}\r\n" +
                   $"Начална дата: {this.StartDate.ToString(Config.DateTimeFormat)}\r\n" +
                   $"Дата на ревизия: {this.RevisionDate.ToString(Config.DateTimeFormat)}\r\n";
        }
    }
}
