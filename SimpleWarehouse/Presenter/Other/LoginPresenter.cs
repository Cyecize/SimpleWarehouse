using System.Windows.Forms;
using SimpleWarehouse.App;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Util;
using SimpleWarehouse.View;

namespace SimpleWarehouse.Presenter.Other
{
    public class LoginPresenter : AbstractPresenter
    {
        private const string INVALID_USER_PASSWORD = "Invalid username / password";
        private const string INVALID_USERNAME = "Грешно потр. име!";
        private const string INVALID_PASSWORD = "Грешна парола!";
        private const string USER_IS_DISABLED = "Потребителя не е активен!";
        private ILoginView Form { get; set; }

        public override ILoggable Loggable{  get => Form;  }

        private User LoggedUser;

        public LoginPresenter(IStateManager manager) : base(manager)
        {
            this.Form = (ILoginView)FormFactory.CreateForm("LoginForm", new object[] { this });
            ((Form)(this.Form)).FormClosing += (sender, args) =>
            {
                if (this.LoggedUser == null)
                    ApplicationState.IsRunning = false;
            };
        }

        public void FirstRunAction()
        {
            this.LoggedUser = new User();
            base.StateManager.Pop();
            base.StateManager.Set(new FirstRunPresenter(base.StateManager, base.StateManager.DbConnectionPropertiesManager));
        }

        public void LoginAction()
        {
            string username = this.Form.Username;
            string password = this.Form.Password;
            if (password == null || username == null || username == "" || password.Length < 6)
            {
                this.Form.Log(INVALID_USER_PASSWORD);
                return;
            }

            User user = base.StateManager.UserService.FindByUsername(username);

            if (user == null)
            {
                this.Form.Log(INVALID_USERNAME);
                this.Form.Username = "";
                return;
            }
            string hashedPassword = PasswordEncoder.EncodeMd5(password);

            if (user.Password != hashedPassword)
            {
                this.Form.Log(INVALID_PASSWORD);
                this.Form.Password = "";
                return;
            }
            if (!user.IsEnabled)
            {
                this.Form.Log(USER_IS_DISABLED);
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
