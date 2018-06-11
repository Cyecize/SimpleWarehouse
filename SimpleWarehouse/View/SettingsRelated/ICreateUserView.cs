using SimpleWarehouse.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
