using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SimpleWarehouse.Constants;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.IO;
using SimpleWarehouse.Model;
using SimpleWarehouse.Service;
using SimpleWarehouse.Services.SettingsRelated;
using SimpleWarehouse.View.SettingsRelated;

namespace SimpleWarehouse.Presenter
{
    public class CreateUserPresenter : AbstractPresenter, IEditPresenter
    {
        private ICreateUserView Form { get; set; }

        private UserRepositoryManager UserRepoManager { get; set; }

        public CreateUserPresenter(IStateManager manager) : base(manager)
        {
            this.Form = (ICreateUserView)FormFactory.CreateForm("CreateUserForm", new object[] { this });
            ((Form)this.Form).FormClosing += (o, e) => this.Cancel();

            this.UserRepoManager = new UserRepositoryManager(base.StateManager.SqlManager, base.StateManager.OutputWriter);

            this.Form.AddRole(Config.USER_TYPICAL_ROLE);
            this.Form.AddRole(Config.USER_LIMITED_ROLE);
        }



        public override void Dispose()
        {
            foreach (var id in base.EventIds)
            {
                base.StateManager.EventManager.RemoveEvent(id);
            }
            this.Form.HideAndDispose();
            base.StateManager.OutputWriter.WriteLine("Edit Product Presenter Disposed!");
        }

        public override void Update()
        {
            if (!base.IsFormShown)
            {
                this.Form.ShowAsDialog();
                base.IsFormShown = true;
            }
        }

        public void Submit()
        {
            string username = this.Form.NewUsername;
            string password = this.Form.NewPassword;
            string role = this.Form.Role;

            if (username == string.Empty || password.Length < 6 || role == null)
            {
                this.Form.Log("Паролата трябва да е поне 6 знака, потр. име - 1");
                return;
            }

            User u = this.UserRepoManager.FindOneByUsername(username);
            if (u != null)
            {
                this.Form.Log("Съществуващо потребителско име!");
                this.Form.NewUsername = "";
                return;
            }

            try
            {
                this.UserRepoManager.CreateUser(username, password, role);
                this.Cancel();
            }
            catch (ArgumentException e) { this.Form.Log(e.Message); }
        }

        public void Cancel()
        {
            if (base.StateManager.IsPresenterActive(this))
            {
                base.StateManager.Pop();
            }
        }
    }
}
