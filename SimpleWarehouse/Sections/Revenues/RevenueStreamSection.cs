using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWarehouse.Constants;
using SimpleWarehouse.Model;
using SimpleWarehouse.Presenter.Revenues;
using SimpleWarehouse.Services.Revenues;

namespace SimpleWarehouse.Sections.Revenues
{
    public class RevenueStreamSection : IRevenueStreamSection
    {
        private const string InvalidValueMgs = "Невалидна стойност!";

        private IRevenueStreamPresenter Presenter { get; set; }

        private IRevenueStreamViewManager ViewManager { get; set; }

        private IRevenueStreamViewManager ArchiveViewManager { get; set; }

        private IRevenueStreamDbService RevenueStreamDbService { get; set; }

        public RevenueStreamSection(IRevenueStreamPresenter presenter, IRevenueStreamDbService dbService)
        {
            this.Presenter = presenter;
            this.RevenueStreamDbService = dbService;
            this.ViewManager = new RevenueStreamViewManager(this.Presenter.Form.NotRevisedDataTable, RevenueDataTableNames.GetNamesForAddRevenue());
            this.ArchiveViewManager = new RevenueStreamViewManager(this.Presenter.Form.ArchiveDataTable, RevenueDataTableNames.GetNamesForArchivedRevenues());
        }

        public void AddRevenueStreamAction()
        {
            DateTime revenueDate = this.Presenter.Form.NewEntityDate;
            double amount = this.Presenter.Form.NewEntityAmount;
            string comment = this.Presenter.Form.CommentText;
            RevenueStream revenue = new RevenueStream()
            {
                Date = revenueDate,
                RevenueAmount = amount,
                UserId = this.Presenter.GetStateManager().UserSession.SessionEntity.Id,
                IsRevised = false,
                Comment = comment,
            };
            if (revenue.RevenueAmount <= 0)
            {
                this.Presenter.Form.Log(InvalidValueMgs);
                return;
            }
            try
            {
                this.RevenueStreamDbService.CreateRevenueStream(revenue);
                this.UpdateNonRevisedRevenueStreams();
                this.Presenter.Form.NewEntityAmount = 0;
            }
            catch (ArgumentException e)
            {
                this.Presenter.Form.Log(e.Message);
            }
        }

        public void DisplayArchivedRevenueStreams()
        {
            var start = this.Presenter.Form.ArchivedEntitiesStartDate;
            var end = this.Presenter.Form.ArchivedEntitiesEndDate;
            List<RevenueStream> revenueStreams = this.RevenueStreamDbService.FindAllArchived(start, end);
            this.ArchiveViewManager.DisplayRevenues(revenueStreams);
            this.Presenter.Form.TotalArchivedEntitiesRows = revenueStreams.Count.ToString();
            this.Presenter.Form.TotalArchivedEntitiesPrice = $"{revenueStreams.Sum(e => e.RevenueAmount):F2}";
            
        }

        public void UpdateNonRevisedRevenueStreams()
        {
            this.ViewManager.DisplayRevenues(this.RevenueStreamDbService.FindAllNonRevised());
        }
    }
}
