using System.Collections.Generic;
using SimpleWarehouse.Interfaces;

namespace SimpleWarehouse.View
{
    public interface ISwitchDatabaseView : IView
    {
        void DisplayDatabases(List<string> databases);

        string GetSelectedDatabase();
    }
}