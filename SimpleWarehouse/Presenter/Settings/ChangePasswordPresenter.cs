using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
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

        private IChangePasswordView Form { get; set; }

        public override ILoggable Loggable => Form;

        public ChangePasswordPresenter(IStateManager manager) : base(manager)
        {
            this.Form = (IChangePasswordView)FormFactory.CreateForm("ChangePasswordForm", new object[] { this });
        }

        public void Cancel()
        {
            if (base.StateManager.IsPresenterActive(this))
                base.StateManager.Pop();
        }

        public void Submit()
        {
            User loggedUser = base.StateManager.UserSession.SessionEntity;
            string oldP = this.Form.OldPassword;
            string newPass = this.Form.NewPassword;
            string confPass = this.Form.NewPasswordConf;

            if (PasswordEncoder.EncodeMd5(oldP) != loggedUser.Password)
            {
                this.Form.Log(WrongPasswordMsg);
                return;
            }

            if (newPass != confPass)
            {
                this.Form.Log(PasswordsDoNotMatchMsg);
                return;
            }
            if (!base.StateManager.UserService.IsInfoValid(loggedUser.Username, newPass))
            {
                this.Form.Log(InvalidPasswordMsg);
                return;
            }

            base.StateManager.Push(new ConfirmActionPresenter(base.StateManager, this.OnConfirmAction, $"Промяна на паролата на потребител {loggedUser.Username}?"));
        }

        public override void Dispose()
        {
            this.Form.HideAndDispose();
            base.StateManager.OutputWriter.WriteLine("Change Password Presenter was disposed");
        }

        public override void Update()
        {
            if (!base.IsFormShown)
            {
                this.Form.Show();
                base.IsFormShown = true;
            }
        }

        //PRIVATE LOGIC
        private void OnConfirmAction(bool isConfirmed)
        {
            if (!isConfirmed)
                this.Cancel();
            else
                this.SaveUser();

        }

        private void SaveUser()
        {
            User user = base.StateManager.UserSession.SessionEntity;
            user.Password = PasswordEncoder.EncodeMd5(this.Form.NewPassword);
            base.StateManager.UserService.Save(user);
            this.Cancel();
        }
    }
}
