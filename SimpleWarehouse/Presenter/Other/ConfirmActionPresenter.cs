using System.Windows.Forms;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.View;

namespace SimpleWarehouse.Presenter.Other
{
    public class ConfirmActionPresenter : AbstractPresenter, ISubmitablePresenter
    {
        public delegate void WorkCompletedCallBack(bool isConfirmed);

        public ConfirmActionPresenter(IStateManager manager, WorkCompletedCallBack callBack, string confirmText) :
            base(manager)
        {
            Form = (IConfirmActionView) FormFactory.CreateForm("ConfirmActionForm", new object[] {this});
            ((Form) Form).FormClosing += (o, e) => Cancel();
            Form.ConfirmTextContent = confirmText;
            CallBack = callBack;
            IsConfirmPerformed = false;
            Form.Text = @"Потвърждаване";
        }

        private bool IsConfirmPerformed { get; set; }

        private WorkCompletedCallBack CallBack { get; }

        public IConfirmActionView Form { get; set; }

        public override ILoggable Loggable => Form;

        public void Submit()
        {
            Close();
            if (!IsConfirmPerformed)
            {
                CallBack(true);
                IsConfirmPerformed = true;
            }
        }

        public void Cancel()
        {
            if (!IsConfirmPerformed)
            {
                CallBack(false);
                IsConfirmPerformed = true;
            }

            Close();
        }

        private void Close()
        {
            if (StateManager.IsPresenterActive(this))
                StateManager.Pop();
        }

        //OVERRIDES
        public override void Dispose()
        {
            Form.HideAndDispose();
            StateManager.OutputWriter.WriteLine("Confirm Presenter Disposed");
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