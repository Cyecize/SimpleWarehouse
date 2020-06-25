using System.Windows.Forms;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;

namespace SimpleWarehouse.Presenter.Other
{
    public class ErrorPresenter : AbstractPresenter
    {
        private bool IsStackPopped;

        public ErrorPresenter(IStateManager manager, string message) : base(manager)
        {
            IsStackPopped = false;
            Form = (IView) FormFactory.CreateForm("ErrorForm", new object[] {this});
            ((Form) Form).FormClosing += (sen, e) => { AcceptError(); };

            Form.Log(message);
        }

        public ErrorPresenter(IStateManager manager, string message, bool showNonDialog) : this(manager, message)
        {
            IsFormShown = true;
            Form.Show();
        }

        private IView Form { get; }

        public override ILoggable Loggable => Form;

        public void AcceptError()
        {
            if (!IsStackPopped)
            {
                StateManager.Pop();
                IsStackPopped = true;
            }
        }

        public override void Dispose()
        {
            Form.HideAndDispose();
            StateManager.OutputWriter.WriteLine("Error StreamPresenter Disposed!");
        }

        public override void Update()
        {
            if (!IsFormShown)
            {
                Form.ShowAsDialog();
                IsFormShown = true;
            }
        }
    }
}