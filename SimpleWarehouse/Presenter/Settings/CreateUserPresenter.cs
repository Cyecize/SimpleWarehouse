using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Model.Enum;
using SimpleWarehouse.View.SettingsRelated;

namespace SimpleWarehouse.Presenter.Settings
{
    class CreateUserPresenter : AbstractPresenter, ISubmitablePresenter
    {
        private const string InvalidInfoMsg = "Паролата трябва да е поне 6 знака, потр. име - 1";
        private const string UsernameIsInUserMsg = "Съществуващо потребителско име!";

        private ICreateUserView Form { get; set; }

        public override ILoggable Loggable => Form;

        public CreateUserPresenter(IStateManager manager) : base(manager)
        {
            this.Form = (ICreateUserView)FormFactory.CreateForm("CreateUserForm", new object[] { this });
            ((Form)this.Form).FormClosing += (o, e) => this.Cancel();

            this.Form.AddRole(RoleType.WORKER.ToString());
            this.Form.AddRole(RoleType.STANDARD.ToString());
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
            RoleType roleType = RoleType.WORKER;
            try
            {
                roleType = (RoleType) Enum.Parse(typeof(RoleType), role, true);
            }
            catch (Exception) { /**/}

            if (!base.StateManager.UserService.IsInfoValid(username, password) || role == null)
            {
                this.Form.Log(InvalidInfoMsg);
                return;
            }

            User u = base.StateManager.UserService.FindByUsername(username);
            if (u != null)
            {
                this.Form.Log(UsernameIsInUserMsg);
                this.Form.NewUsername = "";
                return;
            }

            try
            {
                base.StateManager.UserService.CreateUser(username, password, roleType);
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
