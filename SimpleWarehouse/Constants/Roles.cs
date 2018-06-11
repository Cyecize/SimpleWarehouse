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
            if (!IsHashed(hashed))
                return hashed;
            if (PasswordEncoder.EncodeMd5(Config.USER_ADMIN_ROLE) == hashed)
                return Config.USER_ADMIN_ROLE;
            if (PasswordEncoder.EncodeMd5(Config.USER_TYPICAL_ROLE) == hashed)
                return Config.USER_TYPICAL_ROLE;
            return Config.USER_LIMITED_ROLE;
        }

        public static string HashRole(string planeTextRole)
        {
            if (IsHashed(planeTextRole))
                return planeTextRole;
            return PasswordEncoder.EncodeMd5(planeTextRole);
        }

        public static bool IsExactRole(string role, string desiredRole)
        {
            return role == GetRole(desiredRole);
        }

        public static bool IsRequredRoleMet(string role, string desiredRole)
        {
            int roleId = ROLES.IndexOf(GetRole(role));
            int desiredRoleId = ROLES.IndexOf(GetRole(desiredRole));
            return roleId >= desiredRoleId;
        }

        public static bool IsHashed(string role)
        {
            return !ROLES.Contains(role);
        }
    }
}
