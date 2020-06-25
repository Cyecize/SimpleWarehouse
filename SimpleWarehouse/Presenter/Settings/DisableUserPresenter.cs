using System.Windows.Forms;
using SimpleWarehouse.Constants;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Presenter.Other;
using SimpleWarehouse.View.SettingsRelated;

namespace SimpleWarehouse.Presenter.Settings
{
    public class DisableUserPresenter : AbstractPresenter, ISubmitablePresenter
    {
        public DisableUserPresenter(IStateManager manager) : base(manager)
        {
            Form = (IDisableUserView) FormFactory.CreateForm("DisableUserForm", new object[] {this});
            ((Form) Form).FormClosing += (o, e) => Cancel();

            var users = StateManager.UserService.FindAllExceptAdmins();
            users.Insert(0, new User {Username = string.Empty});
            Form.AddUsers(users);
        }

        private IDisableUserView Form { get; }

        public override ILoggable Loggable => Form;

        public void Submit()
        {
            var u = StateManager.UserService.FindByUsername(Form.SelectedUsername);
            if (u == null)
            {
                Form.Log(@"Моля изберете потребител");
                return;
            }

            if (Roles.IsAdmin(u.Roles))
            {
                Form.Log(@"Не може да редактирате администратор!");
                return;
            }

            StateManager.Push(new ConfirmActionPresenter(StateManager, OnConfirmation,
                $"Промяна на статуса за потребител {Form.SelectedUsername} активен: {Form.IsEnabled}"));
        }

        public void Cancel()
        {
            if (StateManager.IsPresenterActive(this)) StateManager.Pop();
        }

        public override void Dispose()
        {
            Form.HideAndDispose();
            StateManager.OutputWriter.WriteLine("Disable User Presenter was disposed");
        }


        public override void Update()
        {
            if (!IsFormShown)
            {
                Form.Show();
                IsFormShown = true;
            }
        }

        private void PerformEdit()
        {
            var u = StateManager.UserService.FindByUsername(Form.SelectedUsername);
            u.IsEnabled = Form.IsEnabled;
            StateManager.UserService.Save(u);
            Cancel();
        }

        private void OnConfirmation(bool isConf)
        {
            if (!isConf)
                Cancel();
            else
                PerformEdit();
        }
    }
}