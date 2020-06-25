using System.Collections.Generic;
using SimpleWarehouse.Interfaces;

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