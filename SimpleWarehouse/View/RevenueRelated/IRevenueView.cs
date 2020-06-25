using System;
using System.Windows.Forms;
using SimpleWarehouse.Interfaces;

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
        
        string TotalEntitiesRows { get; set; }

        string TotalEntitiesPrice { get; set; }

        string CommentArchive { get; set; }
    }
}