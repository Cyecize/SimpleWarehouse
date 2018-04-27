using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;

namespace SimpleWarehouse.Presenter
{
    public class ErrorPresenter : AbstractPresenter
    {
        private IView Form;
        private bool IsStackPopped;

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
            base.StateManager.OutputWriter.WriteLine("Home Presenter Disposed!");
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
