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
        private const string InvalidUserPassword = "Invalid username / password";
        private const string InvalidUsername = "Грешно потр. име!";
        private const string InvalidPassword = "Грешна парола!";
        private const string UserIsDisabled = "Потребителя не е активен!";

        public LoginPresenter(IStateManager manager) : base(manager)
        {
            Form = (ILoginView) FormFactory.CreateForm("LoginForm", new object[] {this});
            ((Form) Form).FormClosing += (sender, args) =>
            {
                if (LoggedUser == null)
                    ApplicationState.IsRunning = false;
            };
            Form.DbName = StateManager.DbConnectionPropertiesManager.GetSettings().DatabaseName;
        }

        private ILoginView Form { get; }

        public override ILoggable Loggable => Form;

        private User LoggedUser { get; set; }

        public void FirstRunAction()
        {
            LoggedUser = new User();
            StateManager.Pop();
            StateManager.Database.Dispose();
            StateManager.ConnectionManager.CloseConnection();
            StateManager.Set(new FirstRunPresenter(StateManager, StateManager.DbConnectionPropertiesManager));
        }

        public void ChooseDatabaseAction()
        {
            LoggedUser = new User();
            StateManager.Pop();
            StateManager.Set(new SwitchDatabasePresenter(StateManager));
        }

        public void LoginAction()
        {
            var username = Form.Username;
            var password = Form.Password;
            if (password == null || username == null || username == "" || password.Length < 6)
            {
                Form.Log(InvalidUserPassword);
                return;
            }

            var user = StateManager.UserService.FindByUsername(username);

            if (user == null)
            {
                Form.Log(InvalidUsername);
                Form.Username = "";
                return;
            }

            var hashedPassword = PasswordEncoder.EncodeMd5(password);

            if (user.Password != hashedPassword)
            {
                Form.Log(InvalidPassword);
                Form.Password = "";
                return;
            }

            if (!user.IsEnabled)
            {
                Form.Log(UserIsDisabled);
                return;
            }

            LoggedUser = user;
            StateManager.UserSession.SessionEntity = user;
            StateManager.Pop();
        }

        public override void Dispose()
        {
            Form.HideAndDispose();
        }

        public override void Update()
        {
            if (!IsFormShown)
            {
                Form.ShowAsDialog();
                IsFormShown = true;
            }
        }
    }
}