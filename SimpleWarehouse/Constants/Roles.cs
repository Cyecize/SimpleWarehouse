using SimpleWarehouse.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Constants
{
    public class Roles
    {
        private static List<string> ROLES = new List<string>() { Config.USER_LIMITED_ROLE, Config.USER_TYPICAL_ROLE, Config.USER_ADMIN_ROLE }; 

        public static string GetRole(string hashed)
        {
            if (PasswordEncoder.EncodeMd5(Config.USER_ADMIN_ROLE) == hashed)
                return Config.USER_ADMIN_ROLE;
            if (PasswordEncoder.EncodeMd5(Config.USER_TYPICAL_ROLE) == hashed)
                return Config.USER_TYPICAL_ROLE;
            return Config.USER_LIMITED_ROLE;
        }

        public static bool IsExactRole(string role, string desiredRole)
        {
            return role == desiredRole; 
        }

        public static bool IsRequredRoleMet(string role, string desiredRole)
        {
            int roleId = ROLES.IndexOf(role);
            int desiredRoleId = ROLES.IndexOf(desiredRole);
            return roleId >= desiredRoleId;
        }
    }
}
