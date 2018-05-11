using SimpleWarehouse.Constants;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Presenter.RevenueRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Services.RevenueRelated
{
    public class ArchivedExpensesSection : IArchivedEntitiesSection
    {
        private ExpensesPresenter Presenter { get; set; }
        public IRevenueViewManager ViewManager { get; set; }
        public IRevenueStreamDbManager DbManager { get; set; }


        public ArchivedExpensesSection(ExpensesPresenter presenter)
        {
            this.Presenter = presenter;
            this.ViewManager = new RevenueViewManager(this.Presenter.Form.ArchiveDataTable, RevenueDataTableNames.GetNamesForArchivedRevenues());
            this.DbManager = new ExpensesDbManager(this.Presenter.GetStateManager().SqlManager);
        }

        public void DisplayArchivedEntities()
        {
            var start = this.Presenter.Form.ArchivedEntitiesStartDate;
            var end = this.Presenter.Form.ArchivedEntitiesEndDate;
            List<RevenueStream> revenueStreams = this.DbManager.FindRevisedEntitiesByDate(start, end);
            this.ViewManager.DisplayRevenues(revenueStreams);
            this.Presenter.Form.TotalArchivedEntitiesRows = revenueStreams.Count.ToString();
            this.Presenter.Form.TotalArchivedEntitiesPrice = $"{revenueStreams.Sum(e => e.RevenueAmount):F2}";
        }
    }
}
