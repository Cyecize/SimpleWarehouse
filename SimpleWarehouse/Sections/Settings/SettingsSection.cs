using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWarehouse.Constants;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Model.Enum;
using SimpleWarehouse.Presenter.Other;
using SimpleWarehouse.Presenter.Settings;

namespace SimpleWarehouse.Sections.Settings
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
            if (!Roles.IsStandard(this.Presenter.GetStateManager().UserSession.SessionEntity.Roles))
            {
                this.Presenter.GetStateManager().OutputWriter.WriteLine($"You need to be at least {RoleType.STANDARD}");
                return;
            }
            this.Presenter.GetStateManager().Push(new CreateUserPresenter(this.Presenter.GetStateManager()));
        }

        public void DisableUserRequest()
        {
            if (!Roles.IsAdmin(this.Presenter.GetStateManager().UserSession.SessionEntity.Roles))
            {
                this.Presenter.GetStateManager().OutputWriter.WriteLine($"You are not {RoleType.ADMIN}");
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
            DbProperties properties = this.Presenter.GetStateManager().DbConnectionPropertiesManager.GetSettings();
            string infoMsg = properties.ToString();
            this.Presenter.GetStateManager().Push(new ErrorPresenter(this.Presenter.GetStateManager(), infoMsg));
        }
    }
}
