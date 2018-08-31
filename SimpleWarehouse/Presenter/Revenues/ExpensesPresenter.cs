using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.RevenueRelated.View;
using SimpleWarehouse.Sections.Revenues;
using SimpleWarehouse.Services.Revenues;

namespace SimpleWarehouse.Presenter.Revenues
{
    class ExpensesPresenter : AbstractPresenter, IRevenueStreamPresenter
    {
        public IRevenueStreamSection RevenueStreamSection { get; set; }
        
        public IRevenueView Form { get; set; }

        public override ILoggable Loggable { get => Form; }

        public ExpensesPresenter(IStateManager manager) : base(manager)
        {
            this.Form = (IRevenueView)FormFactory.CreateForm("RevenueForm", new object[] { this });
            ((Form)this.Form).FormClosing += (sen, ev) => this.GoBackAction();
            this.Form.Text = "Разходи";
            this.RevenueStreamSection = new RevenueStreamSection(this, new ExpensesDbService());
            this.RevenueStreamSection.UpdateNonRevisedRevenueStreams();
        }

        public void GoBackAction()
        {
            if (base.StateManager.IsPresenterActive(this))
                base.StateManager.Set(new HomePresenter(base.StateManager));
        }

        public override void Dispose()
        {
            foreach (var id in base.EventIds)
            {
                base.StateManager.EventManager.RemoveEvent(id);
            }
            this.Form.HideAndDispose();
            base.StateManager.OutputWriter.WriteLine("Expenses Presenter Disposed!");
        }

        public override void Update()
        {
            if (!base.IsFormShown)
            {
                this.Form.Show();
                base.IsFormShown = true;
            }
        }
    }
}
