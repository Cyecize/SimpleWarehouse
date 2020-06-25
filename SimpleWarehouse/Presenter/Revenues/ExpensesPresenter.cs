using System.Windows.Forms;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.RevenueRelated.View;
using SimpleWarehouse.Sections.Revenues;
using SimpleWarehouse.Services.Revenues;

namespace SimpleWarehouse.Presenter.Revenues
{
    internal class ExpensesPresenter : AbstractPresenter, IRevenueStreamPresenter
    {
        public ExpensesPresenter(IStateManager manager) : base(manager)
        {
            Form = (IRevenueView) FormFactory.CreateForm("RevenueForm", new object[] {this});
            ((Form) Form).FormClosing += (sen, ev) => GoBackAction();
            Form.Text = "Разходи";
            RevenueStreamSection = new RevenueStreamSection(this, new ExpensesDbService());
            RevenueStreamSection.UpdateNonRevisedRevenueStreams(string.Empty);
        }

        public IRevenueStreamSection RevenueStreamSection { get; set; }

        public IRevenueView Form { get; set; }

        public override ILoggable Loggable => Form;

        public void GoBackAction()
        {
            if (StateManager.IsPresenterActive(this))
                StateManager.Set(new HomePresenter(StateManager));
        }

        public override void Dispose()
        {
            foreach (var id in EventIds) StateManager.EventManager.RemoveEvent(id);
            Form.HideAndDispose();
            StateManager.OutputWriter.WriteLine("Expenses Presenter Disposed!");
        }

        public override void Update()
        {
            if (!IsFormShown)
            {
                Form.Show();
                IsFormShown = true;
            }
        }
    }
}