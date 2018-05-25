using SimpleWarehouse.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.View
{
    public interface IFirstRunView : IView
    {
        string Server { get; set; }

        string Port { get; set; }

        string Username { get; set; }

        string Password { get; set; }

        string SelectedDatabase { get; set; }

        string NewDatabaseName { get; set; }

        void SetDatabases(List<string> searchParameters);

        void SetUserBtnStatus(bool isEnabled);
    }
}
