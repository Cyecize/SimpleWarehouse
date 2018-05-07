using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.View;

namespace SimpleWarehouse.Presenter.RevenueRelated
{
    public class RevenuePresenter : AbstractPresenter
    {
        public IRevenueView Form { get; set; }

        public RevenuePresenter(IStateManager manager) : base(manager)
        {
            this.Form = (IRevenueView)FormFactory.CreateForm("RevenueForm", new object[] { this });
            ((Form)this.Form).FormClosing += (sen, ev) => this.Dispose();  
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
