using SimpleWarehouse.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Constants
{
    public class Config
    {
        public const string DATABASE_NAME_PREFIX = "wh_";
        //db connection 
        public const string MY_SQL_CONNECTION = "Server=localhost;Port=3306;Database=warehouse;Uid=root;Password=toor;SslMode=none";

        public const string PATH_TO_FORMS = "SimpleWarehouse.Forms.";

        public const int EVENT_LISTENER_IMMEDIEATE = 1;

        public const int USER_SESSION_CHECK_INTERVAL = 1000;

        public const int MAX_TEXT_LEN = 44;

        public const string USER_ADMIN_ROLE = "Admin";

        public const string USER_TYPICAL_ROLE = "Standard";

        public const string USER_LIMITED_ROLE = "Worker";

        public const string DATE_TIME_FORMAT_DB = "yyyy-MM-dd";

        public const int LIMIT_FOR_DB_PRODUCTS = 200;
    }
}
