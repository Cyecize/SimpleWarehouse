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
using SimpleWarehouse.Services.SettingsRelated;
using SimpleWarehouse.View.SettingsRelated;

namespace SimpleWarehouse.Presenter
{
    public class DisableUserPresenter : AbstractPresenter, IEditPresenter
    {
        private IDisableUserView Form { get; set; }

        private UserRepositoryManager   UserRepoManager { get; set; }

        public DisableUserPresenter(IStateManager manager) : base(manager)
        {
            this.Form = (IDisableUserView)FormFactory.CreateForm("DisableUserForm", new object[] { this });
            ((Form)this.Form).FormClosing += (o, e) => this.Cancel();
            this.UserRepoManager = new UserRepositoryManager(base.StateManager.SqlManager, base.StateManager.OutputWriter);

            List<User> users = this.UserRepoManager.FindAllExceptAdmins();
            users.Insert(0,new User { Username = string.Empty}); 
            this.Form.AddUsers(users);
            
        }

        public override void Dispose()
        {
            this.Form.HideAndDispose();
            base.StateManager.OutputWriter.WriteLine("Disable User Presenter was disposed");
        }

        public override void Update()
        {
            if(!base.IsFormShown)
            {
                this.Form.Show();
                base.IsFormShown = true;
            }
        }

        public void Submit()
        {
            User u = this.UserRepoManager.FindOneByUsername(this.Form.SelectedUsername);
            if(u == null)
            {
                this.Form.Log("Моля изберете потребител");
                return;
            }
            if(Roles.IsExactRole(Config.USER_ADMIN_ROLE, u.Role))
            {
                this.Form.Log("Не може да редактирате администратор!");
                return;
            }

            base.StateManager.Push(new ConfirmActionPresenter(base.StateManager, this.OnConfirmation, 
                $"Промяна на статуса за потребител {this.Form.SelectedUsername} активен: {this.Form.IsEnabled }" ));
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
            User u = this.UserRepoManager.FindOneByUsername(this.Form.SelectedUsername);
            u.IsActive = this.Form.IsEnabled;
            this.UserRepoManager.Save(u);
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
