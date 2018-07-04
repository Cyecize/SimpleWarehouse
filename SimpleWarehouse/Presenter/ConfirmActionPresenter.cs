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
    public class ConfirmActionPresenter : AbstractPresenter, IEditPresenter
    {
        public delegate void WorkCompletedCallBack(bool isConfirmed);

        private bool IsConfirmPerformed { get; set; }

        private WorkCompletedCallBack CallBack { get; set; }

        public IConfirmActionView Form { get; set; }

        public ConfirmActionPresenter(IStateManager manager, WorkCompletedCallBack callBack, string confirmText) : base(manager)
        {
            this.Form = (IConfirmActionView)FormFactory.CreateForm("ConfirmActionForm", new object[] { this });
            ((Form)this.Form).FormClosing += (o, e) => this.Cancel();
            this.Form.ConfirmTextContent = confirmText;
            this.CallBack = callBack;
            this.IsConfirmPerformed = false;
            this.Form.Text = "Потвърждаване";
        }

        public void Submit()
        {
            this.Close();
            if (!this.IsConfirmPerformed)
            {
                this.CallBack(true);
                this.IsConfirmPerformed = true;
            }
        }

        public void Cancel()
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
            base.StateManager.OutputWriter.WriteLine("Confirm Presenter Disposed");
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
