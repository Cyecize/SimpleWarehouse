using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SimpleWarehouse.App;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.IO;
using SimpleWarehouse.Model;
using SimpleWarehouse.Service;
using SimpleWarehouse.View;

namespace SimpleWarehouse.Presenter
{
    public class LoginPresenter : AbstractPresenter
    {
        private ILoginView Form { get; set; }
        private IEntityRepository<User> UserRepo { get; set; }
        private IUser LoggedUser;

        public LoginPresenter(IStateManager manager) : base(manager)
        {
            this.Form = (ILoginView)FormFactory.CreateForm("LoginForm", new object[] { this });
            this.UserRepo = new EntityRepo<User>(base.StateManager.SqlManager, base.StateManager.OutputWriter);
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
            string username = base.StateManager.SqlManager.EscapeString(this.Form.Username);
            string password = this.Form.Password;
            if (password == null || username == null || username == "" || password.Length < 6)
            {
                this.Form.Log("Invalid username / password");
                return;
            }

            IUser user = this.UserRepo.FindOneByQuery($"SELECT * FROM user_auth_joined WHERE username ='{username.ToLower()}' LIMIT 1");

            if (user == null)
            {
                this.Form.Log("Invalid username!");
                this.Form.Username = "";
                return;
            }
            string hashedPassword = PasswordEncoder.EncodeMd5(password);

            if (user.Password != hashedPassword)
            {
                this.Form.Log("Invalid password!");
                this.Form.Password = "";
                return;
            }

            if (!user.IsActive)
            {
                this.Form.Log("Този потребител не е активен!");
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
