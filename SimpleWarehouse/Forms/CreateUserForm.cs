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

namespace SimpleWarehouse.Forms
{
    public partial class CreateUserForm : MaterialForm, ICreateUserView
    {

        private IEditPresenter Presenter { get; set; }
        public string NewUsername { get => this.UsernameBox.Text; set => this.UsernameBox.Text = value; }
        public string NewPassword { get => this.PasswordBox.Text; set => this.PasswordBox.Text = value; }
        public string Role { get => (string)this.RolesDropdown.SelectedItem; set => this.RolesDropdown.SelectedItem = value; }

        public CreateUserForm(IEditPresenter presenter)
        {
            InitializeComponent();
            this.Presenter = presenter;
            FormDecraptifier.Decraptify(this);
            this.Log("");
            this.PasswordBox.PasswordChar = '*';
            this.PasswordConfirm.PasswordChar = '*';
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

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            if(this.PasswordBox.Text != this.PasswordConfirm.Text)
            {
                this.Log("Паролите не съвпадат!");
                return;
            }
            this.Presenter.Submit();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.Cancel();
        }

        public void AddRole(string role)
        {
            this.RolesDropdown.Items.Add(role);
        }
    }
}
