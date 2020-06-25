using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MaterialSkin.Controls;
using SimpleWarehouse.Presenter.Other;
using SimpleWarehouse.Util;
using SimpleWarehouse.View;

namespace SimpleWarehouse.Forms
{
    public partial class FirstRunForm : MaterialForm, IFirstRunView
    {
        public FirstRunForm(FirstRunPresenter presenter)
        {
            InitializeComponent();
            Presenter = presenter;
            LogLabel.Click += (o, e) => LogLabel.Text = "";
            PasswordTextBox.PasswordChar = '*';
            NewUserConfPasswordTextBox.PasswordChar = '*';
            NewUserPasswordTextBox.PasswordChar = '*';
            Log("");
            FormDecraptifier.Decraptify(this);
            StartPosition = FormStartPosition.CenterScreen;
        }

        private FirstRunPresenter Presenter { get; }

        public string Server
        {
            get => ServerTextBox.Text;
            set => ServerTextBox.Text = value;
        }

        public string Port
        {
            get => PortTextBox.Text;
            set => PortTextBox.Text = value;
        }

        public string Username
        {
            get => UsernameTextBox.Text;
            set => UsernameTextBox.Text = value;
        }

        public string Password
        {
            get => PasswordTextBox.Text;
            set => PasswordTextBox.Text = value;
        }

        public string SelectedDatabase
        {
            get => (string) AvaivableDatabasesListBox.SelectedValue;
            set => AvaivableDatabasesListBox.SelectedValue = value;
        }

        public string NewDatabaseName
        {
            get => NewDbTextBox.Text;
            set => NewDbTextBox.Text = value;
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

        public void SetDatabases(List<string> databases)
        {
            AvaivableDatabasesListBox.DataSource = databases;
        }

        public void SetUserBtnStatus(bool isEnabled)
        {
            CreateUserBtn.Enabled = isEnabled;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Presenter.ShowDatabasesAction();
        }

        private void TestConnBtn_Click(object sender, EventArgs e)
        {
            Presenter.TestConnectionAction();
        }

        private void SelectDatabaseBtn_Click(object sender, EventArgs e)
        {
            Presenter.SelectDatabaseAction();
        }

        private void CreateDatabaseBtn_Click(object sender, EventArgs e)
        {
            Presenter.CreateDatabaseAction();
        }

        private void CreateUserBtn_Click(object sender, EventArgs e)
        {
            Presenter.CreateAdministratorAction(NewUserUsernameTextBox.Text, NewUserPasswordTextBox.Text,
                NewUserConfPasswordTextBox.Text);
        }

        private void ConcludeBtn_Click(object sender, EventArgs e)
        {
            Presenter.FinalizeSetupAction();
        }
    }
}