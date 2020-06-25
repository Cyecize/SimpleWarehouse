using System;
using System.Linq;
using SimpleWarehouse.Constants;
using SimpleWarehouse.Model;
using SimpleWarehouse.Presenter.Revenues;
using SimpleWarehouse.Services.Revenues;

namespace SimpleWarehouse.Sections.Revenues
{
    public class RevenueStreamSection : IRevenueStreamSection
    {
        private const string InvalidValueMgs = "Невалидна стойност!";

        public RevenueStreamSection(IRevenueStreamPresenter presenter, IRevenueStreamDbService dbService)
        {
            Presenter = presenter;
            RevenueStreamDbService = dbService;
            ViewManager = new RevenueStreamViewManager(Presenter.Form.NotRevisedDataTable,
                RevenueDataTableNames.GetNamesForAddRevenue());
            ArchiveViewManager = new RevenueStreamViewManager(Presenter.Form.ArchiveDataTable,
                RevenueDataTableNames.GetNamesForArchivedRevenues());
        }

        private IRevenueStreamPresenter Presenter { get; }

        private IRevenueStreamViewManager ViewManager { get; }

        private IRevenueStreamViewManager ArchiveViewManager { get; }

        private IRevenueStreamDbService RevenueStreamDbService { get; }

        public void AddRevenueStreamAction()
        {
            var revenueDate = Presenter.Form.NewEntityDate;
            var amount = Presenter.Form.NewEntityAmount;
            var comment = Presenter.Form.CommentText;
            var revenue = new RevenueStream
            {
                Date = revenueDate,
                RevenueAmount = amount,
                UserId = Presenter.GetStateManager().UserSession.SessionEntity.Id,
                IsRevised = false,
                Comment = comment
            };
            if (revenue.RevenueAmount <= 0)
            {
                Presenter.Form.Log(InvalidValueMgs);
                return;
            }

            try
            {
                RevenueStreamDbService.CreateRevenueStream(revenue);
                UpdateNonRevisedRevenueStreams();
                Presenter.Form.NewEntityAmount = 0;
            }
            catch (ArgumentException e)
            {
                Presenter.Form.Log(e.Message);
            }
        }

        public void DisplayArchivedRevenueStreams()
        {
            var start = Presenter.Form.ArchivedEntitiesStartDate;
            var end = Presenter.Form.ArchivedEntitiesEndDate;
            var comment = Presenter.Form.CommentArchive;
            var revenueStreams = RevenueStreamDbService.FindAllArchived(start, end, comment);
            ArchiveViewManager.DisplayRevenues(revenueStreams);
            Presenter.Form.TotalArchivedEntitiesRows = revenueStreams.Count.ToString();
            Presenter.Form.TotalArchivedEntitiesPrice = $"{revenueStreams.Sum(e => e.RevenueAmount):F2}";
        }

        public void UpdateNonRevisedRevenueStreams()
        {
            ViewManager.DisplayRevenues(RevenueStreamDbService.FindAllNonRevised());
        }
    }
}