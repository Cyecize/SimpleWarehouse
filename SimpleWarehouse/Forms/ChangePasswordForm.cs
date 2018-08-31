using MaterialSkin.Controls;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Services;
using SimpleWarehouse.View.SettingsRelated;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleWarehouse.Util;

namespace SimpleWarehouse.Forms
{
    public partial class ChangePasswordForm : MaterialForm, IChangePasswordView
    {
        private ISubmitablePresenter Presenter { get; set; }
        public string OldPassword { get => this.OldPasswordBox.Text; set => this.OldPasswordBox.Text = value; }
        public string NewPassword { get => this.NewPassBox.Text; set => this.NewPassBox.Text = value; }
        public string NewPasswordConf { get => this.ConfPassBox.Text; set => this.ConfPassBox.Text = value; }

        public ChangePasswordForm(ISubmitablePresenter presenter)
        {
            InitializeComponent();
            this.Presenter = presenter;
            FormDecraptifier.Decraptify(this);
            this.NewPassBox.PasswordChar = '*';
            this.OldPasswordBox.PasswordChar = '*';
            this.ConfPassBox.PasswordChar = '*';
            this.FormClosing += (o, e) => this.Presenter.Cancel();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Log("");
        }

        public void HideAndDispose()
        {
            this.Hide();
            this.Dispose();
        }

        public void ShowAsDialog()
        {
            this.ShowDialog();
        }

        public void Log(string message)
        {
            this.LogLabel.Text = message;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.Cancel();
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.Submit();
        }
    }
}
