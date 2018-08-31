using System.Windows.Forms;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;

namespace SimpleWarehouse.Presenter.Other
{
    public class ErrorPresenter : AbstractPresenter
    {
        private IView Form { get; set; }
        private bool IsStackPopped;

        public override ILoggable Loggable { get => Form; }

        public ErrorPresenter(IStateManager manager, string message) : base(manager)
        {
            this.IsStackPopped = false;
            this.Form = (IView)FormFactory.CreateForm("ErrorForm", new object[] { this });
            ((Form)this.Form).FormClosing += (sen, e) =>
            {
                this.AcceptError();
            };

            this.Form.Log(message);
        }

        public ErrorPresenter(IStateManager manager, string message, bool showNonDialog) : this(manager, message)
        {
            this.IsFormShown = true;
            this.Form.Show();
        }

        public void AcceptError()
        {
            if (!this.IsStackPopped)
            {
                base.StateManager.Pop();
                this.IsStackPopped = true;
            }
           
        }

        public override void Dispose()
        {
            this.Form.HideAndDispose();
            base.StateManager.OutputWriter.WriteLine("Error StreamPresenter Disposed!");
        }

        public override void Update()
        {
            if (!base.IsFormShown)
            {
                this.Form.ShowAsDialog();
                base.IsFormShown = true;
            }
        }
    }
}
