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

        public RevenuePresenter(IStateManager manager) : base(manager)
        {
            Form = (IRevenueView) FormFactory.CreateForm("RevenueForm", new object[] {this});
            ((Form) Form).FormClosing += (sen, ev) => GoBackAction();
            RevenueStreamSection = new RevenueStreamSection(this, new RevenuesDbService());
            RevenueStreamSection.UpdateNonRevisedRevenueStreams();
            Form.Text = PresenterTitle;
        }

        public IRevenueStreamSection RevenueStreamSection { get; set; }
        public IRevenueView Form { get; set; }

        public override ILoggable Loggable => Form;

        public override void Dispose()
        {
            foreach (var id in EventIds) StateManager.EventManager.RemoveEvent(id);
            Form.HideAndDispose();
            StateManager.OutputWriter.WriteLine("Revenue Presenter Disposed!");
        }

        public override void Update()
        {
            if (!IsFormShown)
            {
                Form.Show();
                IsFormShown = true;
            }
        }

        public void GoBackAction()
        {
            if (StateManager.IsPresenterActive(this))
                StateManager.Set(new HomePresenter(StateManager));
        }
    }
}