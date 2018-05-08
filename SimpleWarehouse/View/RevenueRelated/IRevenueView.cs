using SimpleWarehouse.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWarehouse.RevenueRelated.View
{
    public interface IRevenueView : IView
    {
        DateTime NewRevenueDate { get; set; }

        DateTime ArchivedRevenuesStartDate { get; set; }

        DateTime ArchivedRevenuesEndDate { get; set; }

        double NewRevenueAmount { get; set; }

        DataGridView NotRevisedDataTable { get; set; }

        DataGridView ArchiveDataTable { get; set; }

        string TotalArchivedRevenuesRows { get; set; }

        string TotalArchivedRevenuesPrice { get; set; }
    }
}
