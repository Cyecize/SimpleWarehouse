using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.View.SettingsRelated
{
    public interface IDisableUserView : IView
    {
        string SelectedUsername { get; set; }

        bool IsEnabled { get; set; }

        void AddUsers(List<User> users);
    }
}
