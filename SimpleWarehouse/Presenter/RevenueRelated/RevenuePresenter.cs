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
    public class RevenuePresenter : AbstractPresenter
    {
        public AddRevenueSection AddRevenueSection { get; set; }
        public ArchivedRevenuesSection ArchivedRevenuesSection { get; set; }
        public IRevenueView Form { get; set; }

        public RevenuePresenter(IStateManager manager) : base(manager)
        {
            this.Form = (IRevenueView)FormFactory.CreateForm("RevenueForm", new object[] { this });
            ((Form)this.Form).FormClosing += (sen, ev) => this.Dispose();
            this.AddRevenueSection = new AddRevenueSection(this);
            this.ArchivedRevenuesSection = new ArchivedRevenuesSection(this);

            this.AddRevenueSection.UpdateNonRevisedRevenues();
            
        }

        public override void Dispose()
        {
            foreach (var id in base.EventIds)
            {
                base.StateManager.EventManager.RemoveEvent(id);
            }
            this.Form.HideAndDispose();
            base.StateManager.OutputWriter.WriteLine("Revenue Presenter Disposed!");
            if (base.StateManager.IsPresenterActive(this))
                base.StateManager.Pop();
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
