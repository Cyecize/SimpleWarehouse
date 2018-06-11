using SimpleWarehouse.Constants;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Services.SettingsRelated
{
    public class SettingsSection
    {
        public IPresenter Presenter { get; set; }

        public SettingsSection(IPresenter presenter)
        {
            this.Presenter = presenter;
        }

        public void CreateUserRequest()
        {
            string userRole = this.Presenter.GetStateManager().UserSession.SessionEntity.Role;
            if (!Roles.IsRequredRoleMet(userRole, Config.USER_TYPICAL_ROLE))
            {
                Console.WriteLine("Required Role not met!");
                return;
            }
            this.Presenter.GetStateManager().Push(new CreateUserPresenter(this.Presenter.GetStateManager()));
        }

        public void DisableUserRequest()
        {

        }
    }
}
