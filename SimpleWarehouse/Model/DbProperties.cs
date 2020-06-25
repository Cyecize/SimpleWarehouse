using System;

namespace SimpleWarehouse.Model
{
    public class DbProperties
    {
        public string Server { get; set; }

        public string Port { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string DatabaseName { get; set; }

        public string CreateConnectionString()
        {
            var pass = Password != "" ? $"Password={Password};" : "";
            var dbName = DatabaseName != "" ? $"Database={DatabaseName};" : "";

            return $"Server={Server};Port={Port};{dbName}Uid={Username};{pass}SslMode=none;Charset=utf8";
        }

        public override string ToString()
        {
            return $"Server: {Server}{Environment.NewLine}Port: {Port}{Environment.NewLine}Database: {DatabaseName}\n";
        }
    }
}