using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Model
{
    public class DbProperties
    {
        public string Server { get; set; }

        public string Port { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Databasename { get; set; }

        public string CreateConnectionString()
        {
            string pass = this.Password != "" ? $"Password={this.Password};" : "";
            string dbName = this.Databasename != "" ? $"Database={this.Databasename};" : "";

            return $"Server={this.Server};Port={this.Port};{dbName}Uid={this.Username};{pass}SslMode=none;Charset=utf8";
        }
    }
}
