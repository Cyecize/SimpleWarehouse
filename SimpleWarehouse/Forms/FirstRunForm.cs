using MaterialSkin.Controls;
using SimpleWarehouse.Interfaces;
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
    public partial class FirstRunForm : MaterialForm, IFirstRunView
    {
        private FirstRunPresenter Presenter { get; set; }
        public string Server { get => this.ServerTextBox.Text; set => this.ServerTextBox.Text = value; }
        public string Port { get => this.PortTextBox.Text; set => this.PortTextBox.Text = value; }
        public string Username { get => this.UsernameTextBox.Text; set => this.UsernameTextBox.Text = value; }
        public string Password { get => this.PasswordTextBox.Text; set => this.PasswordTextBox.Text = value; }
        public string SelectedDatabase { get =>(string)this.AvaivableDatabasesListBox.SelectedValue; set => this.AvaivableDatabasesListBox.SelectedValue = value; }
        public string NewDatabaseName { get => this.NewDbTextBox.Text; set => this.NewDbTextBox.Text = value; }

        public FirstRunForm(FirstRunPresenter presenter)
        {
            InitializeComponent();
            this.Presenter = presenter;
            this.LogLabel.Click += (o, e) => this.LogLabel.Text = "";
            this.PasswordTextBox.PasswordChar = '*';
            this.NewUserConfPasswordTextBox.PasswordChar = '*';
            this.NewUserPasswordTextBox.PasswordChar = '*';
            this.Log("");
            FormDecraptifier.Decraptify(this);
            this.StartPosition = FormStartPosition.CenterScreen;
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Presenter.ShowDatabasesAction();
        }

        private void TestConnBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.TestConnectionAction();
        }

        public void SetDatabases(List<string> databases)
        {
            this.AvaivableDatabasesListBox.DataSource = databases;
        }

        private void SelectDatabaseBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.SelectDatabaseAction();
        }

        private void CreateDatabaseBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.CreateDatabaseAction();
        }

        public void SetUserBtnStatus(bool isEnabled)
        {
            this.CreateUserBtn.Enabled = isEnabled;
        }

        private void CreateUserBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.CreateAdministratorAction(this.NewUserUsernameTextBox.Text, this.NewUserPasswordTextBox.Text, this.NewUserConfPasswordTextBox.Text);
        }

        private void ConcludeBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.FinalizeSetupAction();
        }
    }
}
