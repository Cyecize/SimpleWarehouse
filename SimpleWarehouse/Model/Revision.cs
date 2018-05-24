using SimpleWarehouse.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Model
{
    [DbTableNameReference(name: "revisions")]
    public class Revision
    {
        [DbNameReference(name: "id")]
        public int Id { get; set; }

        [DbNameReference(name: ("expenses"))]
        public double Expenses { get; set; }

        [DbNameReference(name: "revenue")]
        public double Revenue { get; set; }

        [DbNameReference(name: "actual_revenue")]
        public double ActualRevenue { get; set; }

        [DbNameReference(name: "start_date")]
        public DateTime StartDate { get; set; }

        [DbNameReference(name: "revision_date")]
        public DateTime Date { get; set; }

        public Revision()
        {
            this.Date = DateTime.Now;
            this.Expenses = 0.0;
            this.Revenue = 0.0;
        }

        public override string ToString()
        {
            return $"Приходи: {this.Revenue:F2} \r\n" +
                $"Разходи: {this.Expenses:F2}\r\n" +
                $"Изчислени приходи (ревизия): {this.ActualRevenue:F2}\r\n" +
                $"Начална дата: {this.StartDate.ToString("dd/MM/yyyy")}\r\n" +
                $"Дата на ревизия: {this.Date.ToString("dd/MM/yyyy")}\r\n";
        }
    }
}
