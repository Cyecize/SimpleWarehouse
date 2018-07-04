using MaterialSkin.Controls;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Services;
using SimpleWarehouse.View;
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
    public partial class DisableUserForm : MaterialForm, IDisableUserView
    {

        private IEditPresenter Presenter { get; set; }

        public DisableUserForm(IEditPresenter presenter)
        {
            InitializeComponent();
            this.Presenter = presenter;
            FormDecraptifier.Decraptify(this);
            this.Log("");
            this.UsersListBox.SelectedValueChanged += (o, e) => this.UpdateSelectionAction();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public string SelectedUsername { get => this.SelectedUsernameBox.Text; set => this.SelectedUsernameBox.Text = value; }
        public bool IsEnabled { get => this.IsUserEnabledCheckbox.Checked; set => this.IsUserEnabledCheckbox.Checked = value; }

        public void AddUsers(List<User> users)
        {
            this.UsersListBox.DataSource = users;
        }

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

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.Cancel();
        }

        private void UpdateSelectionAction()
        {
            object val = this.UsersListBox.SelectedItem;
            if (val == null)
                return;
            if (val.ToString() == string.Empty)
                return;
            User u = (User)val;
            this.SelectedUsername = u.Username;
            this.IsEnabled = u.IsActive;
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.Submit();
        }
    }
}
