using SimpleWarehouse.Model;
using SimpleWarehouse.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Constants
{
    public class Roles
    {
        public static bool IsRequiredRoleMet(List<Role> roles, RoleType desiredRole)
        {
            return roles.FirstOrDefault(r => r.RoleType == desiredRole) != null;
        }

        public static bool IsAdmin(List<Role> roles)
        {
            return roles.FirstOrDefault(r => r.RoleType == RoleType.ADMIN) != null;
        }
        public static bool IsStandard(List<Role> roles)
        {
            return roles.FirstOrDefault(r => r.RoleType == RoleType.STANDARD) != null;
        }
        public static bool IsWorker(List<Role> roles)
        {
            return roles.FirstOrDefault(r => r.RoleType == RoleType.WORKER) != null;
        }
    }
}
