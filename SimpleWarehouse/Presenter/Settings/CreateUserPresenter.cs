using System;
using System.Windows.Forms;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model.Enum;
using SimpleWarehouse.View.SettingsRelated;

namespace SimpleWarehouse.Presenter.Settings
{
    internal class CreateUserPresenter : AbstractPresenter, ISubmitablePresenter
    {
        private const string InvalidInfoMsg = "Паролата трябва да е поне 6 знака, потр. име - 1";
        private const string UsernameIsInUserMsg = "Съществуващо потребителско име!";

        public CreateUserPresenter(IStateManager manager) : base(manager)
        {
            Form = (ICreateUserView) FormFactory.CreateForm("CreateUserForm", new object[] {this});
            ((Form) Form).FormClosing += (o, e) => Cancel();

            Form.AddRole(RoleType.WORKER.ToString());
            Form.AddRole(RoleType.STANDARD.ToString());
        }

        private ICreateUserView Form { get; }

        public override ILoggable Loggable => Form;

        public void Submit()
        {
            var username = Form.NewUsername;
            var password = Form.NewPassword;
            var role = Form.Role;
            var roleType = RoleType.WORKER;
            try
            {
                roleType = (RoleType) Enum.Parse(typeof(RoleType), role, true);
            }
            catch (Exception)
            {
                /**/
            }

            if (!StateManager.UserService.IsInfoValid(username, password) || role == null)
            {
                Form.Log(InvalidInfoMsg);
                return;
            }

            var u = StateManager.UserService.FindByUsername(username);
            if (u != null)
            {
                Form.Log(UsernameIsInUserMsg);
                Form.NewUsername = "";
                return;
            }

            try
            {
                StateManager.UserService.CreateUser(username, password, roleType);
                Cancel();
            }
            catch (ArgumentException e)
            {
                Form.Log(e.Message);
            }
        }

        public void Cancel()
        {
            if (StateManager.IsPresenterActive(this)) StateManager.Pop();
        }

        public override void Dispose()
        {
            foreach (var id in EventIds) StateManager.EventManager.RemoveEvent(id);
            Form.HideAndDispose();
            StateManager.OutputWriter.WriteLine("Edit Product Presenter Disposed!");
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