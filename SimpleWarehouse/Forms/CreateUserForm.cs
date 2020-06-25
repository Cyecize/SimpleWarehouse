using System;
using MaterialSkin.Controls;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Util;
using SimpleWarehouse.View.SettingsRelated;

namespace SimpleWarehouse.Forms
{
    public partial class CreateUserForm : MaterialForm, ICreateUserView
    {
        public CreateUserForm(ISubmitablePresenter presenter)
        {
            InitializeComponent();
            Presenter = presenter;
            FormDecraptifier.Decraptify(this);
            Log("");
            PasswordBox.PasswordChar = '*';
            PasswordConfirm.PasswordChar = '*';
        }

        private ISubmitablePresenter Presenter { get; }

        public string NewUsername
        {
            get => UsernameBox.Text;
            set => UsernameBox.Text = value;
        }

        public string NewPassword
        {
            get => PasswordBox.Text;
            set => PasswordBox.Text = value;
        }

        public string Role
        {
            get => (string) RolesDropdown.SelectedItem;
            set => RolesDropdown.SelectedItem = value;
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

        public void AddRole(string role)
        {
            RolesDropdown.Items.Add(role);
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (PasswordBox.Text != PasswordConfirm.Text)
            {
                Log(@"Паролите не съвпадат!");
                return;
            }

            Presenter.Submit();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Presenter.Cancel();
        }
    }
}