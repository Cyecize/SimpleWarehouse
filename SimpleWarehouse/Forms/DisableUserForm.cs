using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MaterialSkin.Controls;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Util;
using SimpleWarehouse.View.SettingsRelated;

namespace SimpleWarehouse.Forms
{
    public partial class DisableUserForm : MaterialForm, IDisableUserView
    {
        public DisableUserForm(ISubmitablePresenter presenter)
        {
            InitializeComponent();
            Presenter = presenter;
            FormDecraptifier.Decraptify(this);
            Log("");
            UsersListBox.SelectedValueChanged += (o, e) => UpdateSelectionAction();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private ISubmitablePresenter Presenter { get; }

        public string SelectedUsername
        {
            get => SelectedUsernameBox.Text;
            set => SelectedUsernameBox.Text = value;
        }

        public bool IsEnabled
        {
            get => IsUserEnabledCheckbox.Checked;
            set => IsUserEnabledCheckbox.Checked = value;
        }

        public void AddUsers(List<User> users)
        {
            UsersListBox.DataSource = users;
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

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Presenter.Cancel();
        }

        private void UpdateSelectionAction()
        {
            var val = UsersListBox.SelectedItem;
            if (val == null)
                return;
            if (val.ToString() == string.Empty)
                return;
            var u = (User) val;
            SelectedUsername = u.Username;
            IsEnabled = u.IsEnabled;
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            Presenter.Submit();
        }
    }
}