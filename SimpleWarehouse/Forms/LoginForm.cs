using MaterialSkin.Controls;
using SimpleWarehouse.Presenter;
using SimpleWarehouse.Services;
using SimpleWarehouse.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleWarehouse.Presenter.Other;
using SimpleWarehouse.Util;

namespace SimpleWarehouse.Forms
{
    public partial class LoginForm : MaterialForm, ILoginView
    {
        private LoginPresenter Presenter; 
        public LoginForm(LoginPresenter presenter)
        {
            InitializeComponent();
            this.Presenter = presenter;
            this.Text = "Вход";
            this.UsernameField.Select();
            this.UsernameField.KeyPress += this.OnKeyPress;
            this.PasswordField.KeyPress += this.OnKeyPress;
            this.LoginBtn.KeyPress += this.OnKeyPress;
            FormDecraptifier.Decraptify(this);
        }

        public string Username { get => this.UsernameField.Text; set => this.UsernameField.Text = value; }
        public string Password { get => this.PasswordField.Text; set => this.PasswordField.Text = value; }

        public void HideAndDispose()
        {
            this.Hide();
            this.Dispose();
        }

        public void Log(string message)
        {
            this.LogLabel.Text = message;
        }

        public void ShowAsDialog()
        {
            this.ShowDialog();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.LoginAction();
        }

        private void OnKeyPress(Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.LoginBtn.PerformClick();
            }
        }

        private void FirstRunBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.FirstRunAction();
        }
    }
}
