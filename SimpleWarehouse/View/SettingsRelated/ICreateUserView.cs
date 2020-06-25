using SimpleWarehouse.Interfaces;

namespace SimpleWarehouse.View.SettingsRelated
{
    public interface ICreateUserView : IView
    {
        string NewUsername { get; set; }

        string NewPassword { get; set; }

        string Role { get; set; }

        void AddRole(string role);
    }
}