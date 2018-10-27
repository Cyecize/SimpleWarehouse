using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWarehouse.Interfaces;

namespace SimpleWarehouse.View
{
    public interface ISwitchDatabaseView : IView
    {
        void DisplayDatabases(List<string> databases);

        string GetSelectedDatabase();
    }
}
