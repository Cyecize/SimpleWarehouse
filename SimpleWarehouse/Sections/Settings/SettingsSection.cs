using SimpleWarehouse.Constants;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model.Enum;
using SimpleWarehouse.Presenter.Other;
using SimpleWarehouse.Presenter.Settings;

namespace SimpleWarehouse.Sections.Settings
{
    public class SettingsSection
    {
        public SettingsSection(IPresenter presenter)
        {
            Presenter = presenter;
        }

        public IPresenter Presenter { get; set; }

        public void CreateUserRequest()
        {
            if (!Roles.IsStandard(Presenter.GetStateManager().UserSession.SessionEntity.Roles))
            {
                Presenter.GetStateManager().OutputWriter.WriteLine($"You need to be at least {RoleType.STANDARD}");
                return;
            }

            Presenter.GetStateManager().Push(new CreateUserPresenter(Presenter.GetStateManager()));
        }

        public void DisableUserRequest()
        {
            if (!Roles.IsAdmin(Presenter.GetStateManager().UserSession.SessionEntity.Roles))
            {
                Presenter.GetStateManager().OutputWriter.WriteLine($"You are not {RoleType.ADMIN}");
                return;
            }

            Presenter.GetStateManager().Push(new DisableUserPresenter(Presenter.GetStateManager()));
        }

        public void ChangePasswordRequest()
        {
            Presenter.GetStateManager().Push(new ChangePasswordPresenter(Presenter.GetStateManager()));
        }

        public void ShowDbInfoAction()
        {
            var properties = Presenter.GetStateManager().DbConnectionPropertiesManager.GetSettings();
            var infoMsg = properties.ToString();
            Presenter.GetStateManager().Push(new ErrorPresenter(Presenter.GetStateManager(), infoMsg));
        }
    }
}