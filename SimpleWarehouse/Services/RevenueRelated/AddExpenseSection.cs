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
    class AddExpenseSection : IAddEntitySection
    {
        private ExpensesPresenter Presenter { get; set; }

        public IRevenueViewManager ViewManager { get; set; }
        public IRevenueStreamDbManager DbManager { get; set; }

        public AddExpenseSection(ExpensesPresenter presenter)
        {
            this.Presenter = presenter;
            this.ViewManager = new RevenueViewManager(this.Presenter.Form.NotRevisedDataTable, RevenueDataTableNames.GetNamesForAddRevenue());
            this.DbManager = new ExpensesDbManager(this.Presenter.GetStateManager().SqlManager);
        }

        public void AddEntityAction()
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
                this.Presenter.Form.Log("Невалидна стойност!");
                return;
            }
            try
            {
                this.DbManager.CreateEntity(revenue);
                this.UpdateNonRevisedEntities();
                this.Presenter.Form.NewEntityAmount = 0;
            }
            catch (ArgumentException e)
            {
                this.Presenter.Form.Log(e.Message);
            }
        }

        public void UpdateNonRevisedEntities()
        {
            this.ViewManager.DisplayRevenues(this.DbManager.FindAllNonRevisedEntities());
        }
    }
}
