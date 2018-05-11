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

namespace SimpleWarehouse.Presenter.RevenueRelated
{
    public class ExpensesPresenter : AbstractPresenter, IRevenuePresenter
    {
        public IAddEntitySection AddEntitySection { get; set; }
        public IArchivedEntitiesSection ArchivedEntitiesSection { get; set; }
        public IRevenueView Form { get; set; }

        public ExpensesPresenter(IStateManager manager) : base(manager)
        {
            this.Form = (IRevenueView)FormFactory.CreateForm("RevenueForm", new object[] { this });
            ((Form)this.Form).FormClosing += (sen, ev) => this.GoBackAction();
            this.Form.Text = "Разходи";
            this.AddEntitySection = new AddExpenseSection(this);
            this.ArchivedEntitiesSection = new ArchivedExpensesSection(this);
            this.AddEntitySection.UpdateNonRevisedEntities();
        }

        public void GoBackAction()
        {   
            if(base.StateManager.IsPresenterActive(this))
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
