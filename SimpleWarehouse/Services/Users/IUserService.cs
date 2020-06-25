using System.Collections.Generic;
using SimpleWarehouse.Model;
using SimpleWarehouse.Model.Enum;

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