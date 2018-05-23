using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.View
{
    public interface IRevisionView
    {
        string RevisionRevenue { get; set; }

        string RevisionExpenses { get; set; }

        string RevisionSalesRevenue { get; set; }

        string RevisionSubTotal { get; set; }

        string RevisionStartDate { get; set; }
    }
}
