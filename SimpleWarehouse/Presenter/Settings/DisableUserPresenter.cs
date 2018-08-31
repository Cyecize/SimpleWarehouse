using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleWarehouse.Constants;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Presenter.Other;
using SimpleWarehouse.View.SettingsRelated;

namespace SimpleWarehouse.Presenter.Settings
{
    public class DisableUserPresenter : AbstractPresenter, ISubmitablePresenter
    {
        private IDisableUserView Form { get; set; }

        public override ILoggable Loggable => Form;

        public DisableUserPresenter(IStateManager manager) : base(manager)
        {
            this.Form = (IDisableUserView)FormFactory.CreateForm("DisableUserForm", new object[] { this });
            ((Form)this.Form).FormClosing += (o, e) => this.Cancel();
          
            List<User> users = base.StateManager.UserService.FindAllExceptAdmins();
            users.Insert(0, new User { Username = string.Empty });
            this.Form.AddUsers(users);

        }

        public override void Dispose()
        {
            this.Form.HideAndDispose();
            base.StateManager.OutputWriter.WriteLine("Disable User Presenter was disposed");
        }

        

        public override void Update()
        {
            if (!base.IsFormShown)
            {
                this.Form.Show();
                base.IsFormShown = true;
            }
        }

        public void Submit()
        {
            User u = base.StateManager.UserService.FindByUsername(this.Form.SelectedUsername);
            if (u == null)
            {
                this.Form.Log(@"Моля изберете потребител");
                return;
            }
            if (Roles.IsAdmin(u.Roles))
            {
                this.Form.Log(@"Не може да редактирате администратор!");
                return;
            }

            base.StateManager.Push(new ConfirmActionPresenter(base.StateManager, this.OnConfirmation,
                $"Промяна на статуса за потребител {this.Form.SelectedUsername} активен: {this.Form.IsEnabled }"));
        }

        public void Cancel()
        {
            if (base.StateManager.IsPresenterActive(this))
            {
                base.StateManager.Pop();
            }

        }

        private void PerformEdit()
        {
            User u = base.StateManager.UserService.FindByUsername(this.Form.SelectedUsername);
            u.IsEnabled = this.Form.IsEnabled;
            base.StateManager.UserService.Save(u);
            this.Cancel();

        }

        private void OnConfirmation(bool isConf)
        {
            if (!isConf)
                this.Cancel();
            else
                this.PerformEdit();
        }
    }
}
