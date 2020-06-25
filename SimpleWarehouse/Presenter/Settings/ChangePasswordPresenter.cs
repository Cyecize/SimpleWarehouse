using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Presenter.Other;
using SimpleWarehouse.Util;
using SimpleWarehouse.View.SettingsRelated;

namespace SimpleWarehouse.Presenter.Settings
{
    public class ChangePasswordPresenter : AbstractPresenter, ISubmitablePresenter
    {
        private const string WrongPasswordMsg = "Грешна парола!";
        private const string PasswordsDoNotMatchMsg = "Паролите не съвпаднаха!";
        private const string InvalidPasswordMsg = "Невалидна парола!";

        public ChangePasswordPresenter(IStateManager manager) : base(manager)
        {
            Form = (IChangePasswordView) FormFactory.CreateForm("ChangePasswordForm", new object[] {this});
        }

        private IChangePasswordView Form { get; }

        public override ILoggable Loggable => Form;

        public void Cancel()
        {
            if (StateManager.IsPresenterActive(this))
                StateManager.Pop();
        }

        public void Submit()
        {
            var loggedUser = StateManager.UserSession.SessionEntity;
            var oldP = Form.OldPassword;
            var newPass = Form.NewPassword;
            var confPass = Form.NewPasswordConf;

            if (PasswordEncoder.EncodeMd5(oldP) != loggedUser.Password)
            {
                Form.Log(WrongPasswordMsg);
                return;
            }

            if (newPass != confPass)
            {
                Form.Log(PasswordsDoNotMatchMsg);
                return;
            }

            if (!StateManager.UserService.IsInfoValid(loggedUser.Username, newPass))
            {
                Form.Log(InvalidPasswordMsg);
                return;
            }

            StateManager.Push(new ConfirmActionPresenter(StateManager, OnConfirmAction,
                $"Промяна на паролата на потребител {loggedUser.Username}?"));
        }

        public override void Dispose()
        {
            Form.HideAndDispose();
            StateManager.OutputWriter.WriteLine("Change Password Presenter was disposed");
        }

        public override void Update()
        {
            if (!IsFormShown)
            {
                Form.Show();
                IsFormShown = true;
            }
        }

        //PRIVATE LOGIC
        private void OnConfirmAction(bool isConfirmed)
        {
            if (!isConfirmed)
                Cancel();
            else
                SaveUser();
        }

        private void SaveUser()
        {
            var user = StateManager.UserSession.SessionEntity;
            user.Password = PasswordEncoder.EncodeMd5(Form.NewPassword);
            StateManager.UserService.Save(user);
            Cancel();
        }
    }
}