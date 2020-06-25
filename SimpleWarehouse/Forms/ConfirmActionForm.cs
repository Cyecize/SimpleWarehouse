using System;
using MaterialSkin.Controls;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Util;
using SimpleWarehouse.View;

namespace SimpleWarehouse.Forms
{
    public partial class ConfirmActionForm : MaterialForm, IConfirmActionView
    {
        public ConfirmActionForm(ISubmitablePresenter presenter)
        {
            InitializeComponent();
            FormDecraptifier.Decraptify(this);
            Presenter = presenter;
        }

        private ISubmitablePresenter Presenter { get; }

        public string ConfirmTextContent
        {
            get => ConfirmTextBox.Text;
            set => ConfirmTextBox.Text = value;
        }

        public void HideAndDispose()
        {
            Hide();
            Dispose();
        }

        public void ShowAsDialog()
        {
            ShowDialog();
        }

        public void Log(string message)
        {
            throw new NotImplementedException();
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            Presenter.Submit();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Presenter.Cancel();
        }
    }
}