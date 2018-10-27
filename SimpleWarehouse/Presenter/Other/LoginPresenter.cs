using System;
using System.Windows.Forms;
using SimpleWarehouse.App;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Presenter.Settings;
using SimpleWarehouse.Util;
using SimpleWarehouse.View;

namespace SimpleWarehouse.Presenter.Other
{
    public class LoginPresenter : AbstractPresenter
    {
        private const string InvalidUserPassword = "Invalid username / password";
        private const string InvalidUsername = "Грешно потр. име!";
        private const string InvalidPassword = "Грешна парола!";
        private const string UserIsDisabled = "Потребителя не е активен!";
        private ILoginView Form { get; set; }

        public override ILoggable Loggable => this.Form;

        private User LoggedUser { get; set; }

        public LoginPresenter(IStateManager manager) : base(manager)
        {
            this.Form = (ILoginView)FormFactory.CreateForm("LoginForm", new object[] { this });
            ((Form)(this.Form)).FormClosing += (sender, args) =>
            {
                if (this.LoggedUser == null)
                    ApplicationState.IsRunning = false;
            };
            this.Form.DbName = base.StateManager.DbConnectionPropertiesManager.GetSettings().DatabaseName;
        }

        public void FirstRunAction()
        {
            this.LoggedUser = new User();
            base.StateManager.Pop();
            base.StateManager.Database.Dispose();
            base.StateManager.ConnectionManager.CloseConnection();  
            base.StateManager.Set(new FirstRunPresenter(base.StateManager, base.StateManager.DbConnectionPropertiesManager));
        }

        public void ChooseDatabaseAction()
        {
            this.LoggedUser = new User();
            base.StateManager.Pop();
            base.StateManager.Set(new SwitchDatabasePresenter(base.StateManager));
        }

        public void LoginAction()
        {
            string username = this.Form.Username;
            string password = this.Form.Password;
            if (password == null || username == null || username == "" || password.Length < 6)
            {
                this.Form.Log(InvalidUserPassword);
                return;
            }

            User user = base.StateManager.UserService.FindByUsername(username);
           
            if (user == null)
            {
                this.Form.Log(InvalidUsername);
                this.Form.Username = "";
                return;
            }
            string hashedPassword = PasswordEncoder.EncodeMd5(password);

            if (user.Password != hashedPassword)
            {
                this.Form.Log(InvalidPassword);
                this.Form.Password = "";
                return;
            }
            if (!user.IsEnabled)
            {
                this.Form.Log(UserIsDisabled);
                return;
            }

            this.LoggedUser = user;
            base.StateManager.UserSession.SessionEntity = user;
            base.StateManager.Pop();
        }

        public override void Dispose()
        {
            this.Form.HideAndDispose();
        }

        public override void Update()
        {
            if (!base.IsFormShown)
            {
                this.Form.ShowAsDialog();
                base.IsFormShown = true;
            }
        } 
    }
}
