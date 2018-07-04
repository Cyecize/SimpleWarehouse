using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Service;
using SimpleWarehouse.Services.SettingsRelated;
using SimpleWarehouse.View.SettingsRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Presenter
{
    public class ChangePasswordPresenter : AbstractPresenter, IEditPresenter
    {
        private IChangePasswordView Form { get; set; }

        private UserRepositoryManager UserRepositiryManager { get; set; }

        public ChangePasswordPresenter(IStateManager manager) : base(manager)
        {
            this.Form = (IChangePasswordView)FormFactory.CreateForm("ChangePasswordForm", new object[] { this });
            this.UserRepositiryManager = new UserRepositoryManager(base.StateManager.SqlManager, base.StateManager.OutputWriter);
        }

        public void Cancel()
        {
            if (base.StateManager.IsPresenterActive(this))
                base.StateManager.Pop();
        }

        public void Submit()
        {
            IUser loggedUser = base.StateManager.UserSession.SessionEntity;
            string oldP = this.Form.OldPassword;
            string newPass = this.Form.NewPassword;
            string confPass = this.Form.NewPasswordConf;

            if(PasswordEncoder.EncodeMd5(oldP) != loggedUser.Password)
            {
                this.Form.Log("Грешна парола!");
                return;
            }

            if(newPass != confPass)
            {
                this.Form.Log("Паролите не съвпаднаха!");
                return;
            }

            User user = this.UserRepositiryManager.FindOneById(loggedUser.Id);
            user.Password = newPass;
            if (!this.UserRepositiryManager.IsUserInfoValid(user))
            {
                this.Form.Log("Невалидна парола!");
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
            IUser user = base.StateManager.UserSession.SessionEntity;
            user.Password = PasswordEncoder.EncodeMd5(this.Form.NewPassword);
            this.UserRepositiryManager.Save((User)user);
            this.Cancel();
        }
    }
}
