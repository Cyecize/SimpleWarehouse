using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.RevenueRelated.View;
using SimpleWarehouse.Services.RevenueRelated;
using SimpleWarehouse.View;

namespace SimpleWarehouse.Presenter.RevenueRelated
{
    public class RevenuePresenter : AbstractPresenter, IRevenuePresenter
    {
        public IAddEntitySection AddEntitySection { get; set; }
        public IArchivedEntitiesSection ArchivedEntitiesSection { get; set; }
        public IRevenueView Form { get; set; }

        public RevenuePresenter(IStateManager manager) : base(manager)
        {
            this.Form = (IRevenueView)FormFactory.CreateForm("RevenueForm", new object[] { this });
            ((Form)this.Form).FormClosing += (sen, ev) => this.GoBackAction();
            this.AddEntitySection = new AddRevenueSection(this);
            this.ArchivedEntitiesSection = new ArchivedRevenuesSection(this);

            this.AddEntitySection.UpdateNonRevisedEntities();
            this.Form.Text = "Приходи";

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
