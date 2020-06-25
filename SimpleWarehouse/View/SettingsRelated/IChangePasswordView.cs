using SimpleWarehouse.Interfaces;

namespace SimpleWarehouse.View.SettingsRelated
{
    public interface IChangePasswordView : IView
    {
        string OldPassword { get; set; }

        string NewPassword { get; set; }

        string NewPasswordConf { get; set; }
    }
}