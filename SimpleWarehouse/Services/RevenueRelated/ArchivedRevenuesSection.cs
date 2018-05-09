using SimpleWarehouse.Constants;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Presenter.RevenueRelated;
using SimpleWarehouse.RevenueRelated.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Services.RevenueRelated
{
    public class ArchivedRevenuesSection : IArchivedEntitiesSection
    {
        private RevenuePresenter Presenter;
        private IRevenueView Form;
        public IRevenueViewManager ArchiveRevenueViewManager { get; set; }
        public IRevenueDbManager RevenueDbManager { get; set; }

        public ArchivedRevenuesSection(RevenuePresenter presenter)
        {
            this.Presenter = presenter;
            this.Form = presenter.Form;
            this.ArchiveRevenueViewManager = new RevenueViewManager(this.Form.ArchiveDataTable, RevenueDataTableNames.GetNamesForArchivedRevenues());
            this.RevenueDbManager = new RevenueDbManager(this.Presenter.GetStateManager().SqlManager);
        }

        public void DisplayArchivedEntities()
        {
            var start = this.Form.ArchivedEntitiesStartDate;
            var end = this.Form.ArchivedEntitiesEndDate;
            List<Revenue> revenues = this.RevenueDbManager.FindRevisedRevenuesByDate(start, end);
            this.ArchiveRevenueViewManager.DisplayRevenues(revenues);
            this.Form.TotalArchivedEntitiesRows = $"{revenues.Count}";
            this.Form.TotalArchivedEntitiesPrice = $"{revenues.Sum((x)=> x.RevenueAmount):F2}";
        }
    }
}
