using SimpleWarehouse.Repository;

namespace SimpleWarehouse.App
{
    public class ApplicationState
    {
        public static bool IsRunning { get; set; }

        public static bool IsRestartRequested { get; set; }

        public static DatabaseContext Database { get; set; }
    }
}