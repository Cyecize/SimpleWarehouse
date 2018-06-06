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
        DateTime NewEntityDate { get; set; }

        DateTime ArchivedEntitiesStartDate { get; set; }

        DateTime ArchivedEntitiesEndDate { get; set; }

        double NewEntityAmount { get; set; }

        string CommentText { get; set; }

        DataGridView NotRevisedDataTable { get; set; }

        DataGridView ArchiveDataTable { get; set; }

        string TotalArchivedEntitiesRows { get; set; }

        string TotalArchivedEntitiesPrice { get; set; }
    }
}
