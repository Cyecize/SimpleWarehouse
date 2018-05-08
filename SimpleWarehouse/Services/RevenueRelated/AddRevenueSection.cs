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
    public class AddRevenueSection
    {
        private RevenuePresenter Presenter;
        private IRevenueView Form;
        public IRevenueViewManager AddRevenueViewManager { get; set; }
        public IRevenueDbManager RevenueDbManager { get; set; }

        public AddRevenueSection(RevenuePresenter presenter)
        {
            this.Presenter = presenter;
            this.Form = presenter.Form;
            this.AddRevenueViewManager = new RevenueViewManager(this.Form.NotRevisedDataTable, RevenueDataTableNames.GetNamesForAddRevenue());
            this.RevenueDbManager = new RevenueDbManager(this.Presenter.GetStateManager().SqlManager);
        }

        public void UpdateNonRevisedRevenues()
        {
            this.AddRevenueViewManager.DisplayRevenues(this.RevenueDbManager.FindAllNonRevisedRevenues());
        }

        public void AddRevenueAction()
        {
            DateTime revenueDate = this.Form.NewRevenueDate;
            double amount = this.Form.NewRevenueAmount;
            Revenue revenue = new Revenue()
            {
                Date = revenueDate,
                RevenueAmount = amount,
                UserId = this.Presenter.GetStateManager().UserSession.SessionEntity.Id,
                IsRevised = false
            };
            if (revenue.RevenueAmount <= 0)
            {
                this.Form.Log("Невалидна стойност!");
                return;
            }
            try
            {
                this.RevenueDbManager.CreateRevenue(revenue);
                this.UpdateNonRevisedRevenues();
                this.Form.NewRevenueAmount = 0;
            }
            catch (ArgumentException e)
            {
                this.Form.Log(e.Message);
            }
        }

    }
}
