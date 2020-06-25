using System;
using MaterialSkin.Controls;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Presenter.Other;
using SimpleWarehouse.Util;

namespace SimpleWarehouse.Forms
{
    public partial class ErrorForm : MaterialForm, IView
    {
        private readonly ErrorPresenter Presenter;

        public ErrorForm(ErrorPresenter presenter)
        {
            InitializeComponent();
            FormDecraptifier.Decraptify(this);
            Presenter = presenter;
        }

        public void HideAndDispose()
        {
            Hide();
            Dispose();
        }

        public void Log(string message)
        {
            ErrorBox.Text = message;
        }

        public void ShowAsDialog()
        {
            ShowDialog();
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            Presenter.AcceptError();
        }
    }
}