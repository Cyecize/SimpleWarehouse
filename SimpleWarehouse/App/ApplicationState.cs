using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWarehouse.Repository;

namespace SimpleWarehouse.App
{
    public class ApplicationState
    {
        public static bool IsRunning { get; set; }

        public static DatabaseContext Database { get; set; }
    }
}
