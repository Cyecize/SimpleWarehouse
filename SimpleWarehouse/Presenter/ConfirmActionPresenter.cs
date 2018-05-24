using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.View;

namespace SimpleWarehouse.Presenter
{
    public class ConfirmActionPresenter : AbstractPresenter
    {
        public delegate void WorkCompletedCallBack(bool isConfirmed);

        private bool IsConfirmPerformed { get; set; }

        private WorkCompletedCallBack CallBack { get; set; }

        public IConfirmActionView Form { get; set; }

        public ConfirmActionPresenter(IStateManager manager, WorkCompletedCallBack callBack, string confirmText) : base(manager)
        {
            this.Form = (IConfirmActionView)FormFactory.CreateForm("ConfirmActionForm", new object[] { this });
            ((Form)this.Form).FormClosing += (o, e) => this.DeclineAction();
            this.Form.ConfirmTextContent = confirmText;
            this.CallBack = callBack;
            this.IsConfirmPerformed = false;
        }

        public void ConfirmAction()
        {
            if (!this.IsConfirmPerformed)
            {
                this.CallBack(true);
                this.IsConfirmPerformed = true;
            }
            this.Close();
        }

        public void DeclineAction()
        {
            if (!this.IsConfirmPerformed)
            {
                this.CallBack(false);
                this.IsConfirmPerformed = true;
            }
            this.Close();

        }

        private void Close()
        {
            if (base.StateManager.IsPresenterActive(this))
                base.StateManager.Pop();
        }

        //OVERRIDES
        public override void Dispose()
        {
            this.Form.HideAndDispose();
            Console.WriteLine("Confirm Presenter Disposed");
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
