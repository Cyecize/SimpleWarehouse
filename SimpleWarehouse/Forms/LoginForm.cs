using System;
using System.Windows.Forms;
using MaterialSkin.Controls;
using SimpleWarehouse.Presenter.Other;
using SimpleWarehouse.Util;
using SimpleWarehouse.View;

namespace SimpleWarehouse.Forms
{
    public partial class LoginForm : MaterialForm, ILoginView
    {
        public LoginForm(LoginPresenter presenter)
        {
            InitializeComponent();
            Presenter = presenter;
            Text = "Вход";
            UsernameField.Select();
            UsernameField.KeyPress += OnKeyPress;
            PasswordField.KeyPress += OnKeyPress;
            LoginBtn.KeyPress += OnKeyPress;
            FormDecraptifier.Decraptify(this);
        }

        private LoginPresenter Presenter { get; }

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        public string Username
        {
            get => UsernameField.Text;
            set => UsernameField.Text = value;
        }

        public string Password
        {
            get => PasswordField.Text;
            set => PasswordField.Text = value;
        }

        public string DbName
        {
            get => DbLabel.Text;
            set => DbLabel.Text = value;
        }

        public void HideAndDispose()
        {
            Hide();
            Dispose();
        }

        public void Log(string message)
        {
            LogLabel.Text = message;
        }

        public void ShowAsDialog()
        {
            ShowDialog();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            Presenter.LoginAction();
        }

        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter) LoginBtn.PerformClick();
        }

        private void FirstRunBtn_Click(object sender, EventArgs e)
        {
            Presenter.FirstRunAction();
        }

        private void ChooseDatabaseBtn_Click(object sender, EventArgs e)
        {
            Presenter.ChooseDatabaseAction();
        }
    }
}