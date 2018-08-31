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
    public class RevenuePresenter : AbstractPresenter, IRevenueStreamPresenter
    {
        private const string PresenterTitle = "Приходи";
        public IRevenueStreamSection RevenueStreamSection { get; set; }
        public IRevenueView Form { get; set; }

        public override ILoggable Loggable { get => Form; }

        public RevenuePresenter(IStateManager manager) : base(manager)
        {
            this.Form = (IRevenueView)FormFactory.CreateForm("RevenueForm", new object[] { this });
            ((Form)this.Form).FormClosing += (sen, ev) => this.GoBackAction();
             this.RevenueStreamSection = new RevenueStreamSection(this, new RevenuesDbService());
            this.RevenueStreamSection.UpdateNonRevisedRevenueStreams();
            this.Form.Text = PresenterTitle;
        }

        public override void Dispose()
        {
            foreach (var id in base.EventIds)
            {
                base.StateManager.EventManager.RemoveEvent(id);
            }
            this.Form.HideAndDispose();
            base.StateManager.OutputWriter.WriteLine("Revenue Presenter Disposed!");
        }

        public override void Update()
        {
            if (!base.IsFormShown)
            {
                this.Form.Show();
                base.IsFormShown = true;
            }
        }

        public void GoBackAction()
        {
            if (base.StateManager.IsPresenterActive(this))
                base.StateManager.Set(new HomePresenter(base.StateManager));
        }
    }
}
