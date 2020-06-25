using System.Collections.Generic;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;

namespace SimpleWarehouse.View.SettingsRelated
{
    public interface IDisableUserView : IView
    {
        string SelectedUsername { get; set; }

        bool IsEnabled { get; set; }

        void AddUsers(List<User> users);
    }
}