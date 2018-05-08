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
    public class ArchivedRevenuesSection
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

        public void DisplayArchivedRevenues()
        {
            var start = this.Form.ArchivedRevenuesStartDate;
            var end = this.Form.ArchivedRevenuesEndDate;
            List<Revenue> revenues = this.RevenueDbManager.FindRevisedRevenuesByDate(start, end);
            this.ArchiveRevenueViewManager.DisplayRevenues(revenues);
            this.Form.TotalArchivedRevenuesRows = $"{revenues.Count}";
            this.Form.TotalArchivedRevenuesPrice = $"{revenues.Sum((x)=> x.RevenueAmount):F2}";
        }
    }
}
