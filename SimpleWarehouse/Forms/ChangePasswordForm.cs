using System;
using System.Windows.Forms;
using MaterialSkin.Controls;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Util;
using SimpleWarehouse.View.SettingsRelated;

namespace SimpleWarehouse.Forms
{
    public partial class ChangePasswordForm : MaterialForm, IChangePasswordView
    {
        public ChangePasswordForm(ISubmitablePresenter presenter)
        {
            InitializeComponent();
            Presenter = presenter;
            FormDecraptifier.Decraptify(this);
            NewPassBox.PasswordChar = '*';
            OldPasswordBox.PasswordChar = '*';
            ConfPassBox.PasswordChar = '*';
            FormClosing += (o, e) => Presenter.Cancel();
            StartPosition = FormStartPosition.CenterScreen;
            Log("");
        }

        private ISubmitablePresenter Presenter { get; }

        public string OldPassword
        {
            get => OldPasswordBox.Text;
            set => OldPasswordBox.Text = value;
        }

        public string NewPassword
        {
            get => NewPassBox.Text;
            set => NewPassBox.Text = value;
        }

        public string NewPasswordConf
        {
            get => ConfPassBox.Text;
            set => ConfPassBox.Text = value;
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
            LogLabel.Text = message;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Presenter.Cancel();
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            Presenter.Submit();
        }
    }
}