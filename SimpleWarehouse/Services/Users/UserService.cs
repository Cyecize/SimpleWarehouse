﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using SimpleWarehouse.Model;
using SimpleWarehouse.Model.Enum;
using SimpleWarehouse.Util;
using static SimpleWarehouse.App.ApplicationState;

namespace SimpleWarehouse.Services.Users
{
    public class UserService : IUserService
    {
        public void Save(User user)
        {
            Database.Users.AddOrUpdate(user);
            Database.SaveChanges();
        }

        public bool CreateUser(string username, string password, RoleType roleType)
        {
            AddRoles();
            var user = new User
            {
                Username = username,
                Password = PasswordEncoder.EncodeMd5(password)
            };
            switch (roleType)
            {
                case RoleType.ADMIN:
                    user.Roles.Add(FindRoleBy(RoleType.ADMIN));
                    user.Roles.Add(FindRoleBy(RoleType.STANDARD));
                    break;
                case RoleType.STANDARD:
                    user.Roles.Add(FindRoleBy(RoleType.STANDARD));
                    break;
            }

            user.Roles.Add(FindRoleBy(RoleType.WORKER));
            try
            {
                Database.Users.Add(user);
                Database.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

        public User FindByUsername(string username)
        {
            return Database.Users.FirstOrDefault(u => u.Username.ToLower() == username.ToLower());
        }

        public User FindById(int id)
        {
            return Database.Users.FirstOrDefault(u => u.Id == id);
        }

        public List<User> FindAll()
        {
            return new List<User>(Database.Users);
        }

        public List<User> FindByRole(RoleType roleType)
        {
            var db = Database;
            Console.WriteLine(db.Database.Connection.Database);

            return Database.Users.Where(u => u.Roles.Where(r => r.RoleType == roleType).ToList().Count > 0).ToList();
        }

        public List<User> FindAllExceptAdmins()
        {
            return new List<User>(Database.Users.Where(u =>
                u.Roles.FirstOrDefault(r => r.RoleType == RoleType.ADMIN) == null));
        }

        public bool IsInfoValid(string username, string password)
        {
            return !string.IsNullOrEmpty(username) && password != null && password.Length >= 6;
        }

        //PRIVATE LOGIC
        private void AddRoles()
        {
            if (Database.Roles.Any())
                return;
            Database.Roles.Add(new Role {RoleType = RoleType.ADMIN});
            Database.Roles.Add(new Role {RoleType = RoleType.STANDARD});
            Database.Roles.Add(new Role {RoleType = RoleType.WORKER});
            Database.SaveChanges();
        }

        private Role FindRoleBy(RoleType roleType)
        {
            return Database.Roles.FirstOrDefault(r => r.RoleType == roleType);
        }
    }
}