using SimpleWarehouse.Attributes;
using SimpleWarehouse.Constants;
using SimpleWarehouse.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SimpleWarehouse.Model
{
    [DbTableNameReference(name: "user_auth_joined")]
    public class User : IUser
    {
        private string _roleHash;

        [DbNameReference(name: "id")]
        public int Id { get; set; }

        [DbNameReference(name: "username")]
        public string Username { get; set; }

        
        [DbNameReference(name: "password")]
        public string Password { get; set; }

        [DbNameReference(name:"date_registered")]
        public DateTime DateRegistered { get; set; }

        [DbNameReference(name:("auth_type"))]
        public string Role { get => Roles.GetRole(_roleHash) ; set => _roleHash = value; }

        [DbNameReference(name: "is_enabled")]
        public bool IsActive { get; set ; }

        public User()
        {

        }

        public User(int id)
        {
            this.Id = id;
        }

        public User(int id, string username) : this(id)
        {
            this.Username = username;

        }

        public User(int id, string username, DateTime date) : this(id, username)
        {
            this.DateRegistered = date;
        }

        public override string ToString()
        {
            return this.Username;
        }

    }
}
