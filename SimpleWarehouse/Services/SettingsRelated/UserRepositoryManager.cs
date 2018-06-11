using MySql.Data.MySqlClient;
using SimpleWarehouse.Constants;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Services.SettingsRelated
{
    public class UserRepositoryManager
    {
        private const string TABLE_JOIN_NAME = "user_auth_joined";

        private IOutputWriter Writer { get; set; }

        public IMySqlManager SqlManager { get; set; }

        public IEntityRepository<User> UserRepo { get; set; }

        public UserRepositoryManager(IMySqlManager sqlManager, IOutputWriter writer)
        {
            this.SqlManager = sqlManager;
            this.Writer = writer;
            this.UserRepo = new EntityRepo<User>(sqlManager, writer);
        }

        public User FindOneById(int id)
        {
            return this.UserRepo.FindOneBy("id", id);
        }

        public User FindOneByUsername(string username)
        {
            return this.UserRepo.FindOneBy("username", username);
        }

        public List<User> FindAll()
        {
            return this.UserRepo.FindManyByQuery($"SELECT * FROM {TABLE_JOIN_NAME}");
        }

        public List<User> FindAllExceptAdmins()
        {
            return this.FindAll().Where(u => !Roles.IsExactRole(u.Role, Config.USER_ADMIN_ROLE)).ToList();
        }

        public List<User> FindAllAdministrators()
        {
            return this.FindAll().Where(u => Roles.IsExactRole(u.Role, Config.USER_ADMIN_ROLE)).ToList();
        }

        public bool IsUserInfoValid(User user)
        {
            return user.Username != null && user.Username != string.Empty &&
                user.Password != null && user.Password.Length > 5 &&  user.Role != null && this.GetAuthId(Roles.GetRole(user.Role)) > -1;
        }

        public long CreateUser(string username, string password, string authType)
        {
            return this.CreateUser(new User { Username = username, Password = password, Role = authType });
        }

        public long CreateUser(User user)
        {
            if (!this.IsUserInfoValid(user))
                throw new ArgumentException("Invalid user info");
            int roleId = this.GetAuthId(Roles.GetRole(user.Role));
            return this.CreateUser(user.Username, user.Password, roleId);
        }

        public bool HasAdministrator()
        {
            return this.FindAllAdministrators().Count > 0;
        }

        //PRIVATE LOGIC
        private int GetAuthId(string auth)
        {
            string query = $"SELECT id FROM authentications AS a WHERE a.auth_type = '{Roles.HashRole(auth)}' LIMIT 1";
            MySqlDataReader reader = this.SqlManager.ExecuteQueryData(query);
            if (reader.HasRows)
            {
                reader.Read();
                int res = (int)reader["id"];
                reader.Close();
                return res;
            }
            reader.Close();
            return -1;
        }

        private long CreateUser(string username, string password, int authId)
        {
            username = this.SqlManager.EscapeString(username);
            password = this.SqlManager.EscapeString(password);
            password = PasswordEncoder.EncodeMd5(password);
            string query = $"INSERT INTO users VALUES(null, '{username}', '{password}', {authId}, now(), 1)";
            return this.SqlManager.InsertQuery(query);
        }
    }
}
