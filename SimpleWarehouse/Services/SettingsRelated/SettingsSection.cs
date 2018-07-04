using SimpleWarehouse.Constants;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
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
                this.Presenter.GetStateManager().OutputWriter.WriteLine($"You need to be at least {Config.USER_TYPICAL_ROLE}");
                return;
            }
            this.Presenter.GetStateManager().Push(new CreateUserPresenter(this.Presenter.GetStateManager()));
        }

        public void DisableUserRequest()
        {
            string userRole = this.Presenter.GetStateManager().UserSession.SessionEntity.Role;
            if(!Roles.IsRequredRoleMet(userRole, Config.USER_ADMIN_ROLE))
            {
                this.Presenter.GetStateManager().OutputWriter.WriteLine($"You are not {Config.USER_ADMIN_ROLE}");
                return;
            }
            this.Presenter.GetStateManager().Push(new DisableUserPresenter(this.Presenter.GetStateManager()));
        }

        public void ChangePasswordRequest()
        {
            this.Presenter.GetStateManager().Push(new ChangePasswordPresenter(this.Presenter.GetStateManager()));
        }

        public void ShowDbInfoAction()
        {
            DbProperties properties = this.Presenter.GetStateManager().SqlManager.ConnectionProperties;
            string infoMsg = properties.ToString();
            this.Presenter.GetStateManager().Push(new ErrorPresenter(this.Presenter.GetStateManager(), infoMsg));
        }
    }
}
