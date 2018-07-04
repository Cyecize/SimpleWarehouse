using SimpleWarehouse.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.View.SettingsRelated
{
    public interface IChangePasswordView : IView
    {
        string OldPassword { get; set; }

        string NewPassword { get; set; }

        string NewPasswordConf { get; set; }
    }
}
