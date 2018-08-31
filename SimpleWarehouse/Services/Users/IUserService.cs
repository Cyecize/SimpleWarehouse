using SimpleWarehouse.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWarehouse.Model;
using SimpleWarehouse.Repository;

namespace SimpleWarehouse.Services.Users
{
    public interface IUserService
    {
        void Save(User user);

        bool CreateUser(string username, string password, RoleType roleType);

        bool IsInfoValid(string username, string password);

        User FindByUsername(string username);

        User FindById(int id);

        List<User> FindAll();

        List<User> FindByRole(RoleType roleType);

        List<User> FindAllExceptAdmins();
    }
}
