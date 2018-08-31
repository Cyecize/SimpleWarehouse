using MySql.Data.MySqlClient;
using SimpleWarehouse.Constants;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Repository;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Services
{
    public class DbMySqlConnectionManager : IDbConnectionManager
    {
        private const string ConnectionSuccess = "OK";
        private const string ConnectionNotOpenMsg = "Connection is closed, please test connection first.";
        private const string InvalidDatabase = "Invalid Database";
        private const string ErrorCreatingDb = "Error creating database";

        private ILoggable Loggable { get; set; }

        private MySqlConnection Connection { get; set; }

        private DbProperties DbProperties { get; set; }

        public DbMySqlConnectionManager(ILoggable loggable)
        {
            this.Loggable = loggable;
        }

        public DbProperties CreateConnection(string server, string port, string username, string password)
        {
            return this.CreateConnection(server, port, username, password, null);
        }

        public DbProperties CreateConnection(string server, string port, string username, string password, string dbName)
        {
            DbProperties properties = new DbProperties { Server = server, Port = port, Username = username, Password = password, DatabaseName = dbName };
            this.DbProperties = properties;
            this.Connection = DatabaseFactory.CreateConnection(properties);
            return properties;
        }

        public bool SelectDatabase(string dbName)
        {
            if (this.Connection == null || this.Connection.State != System.Data.ConnectionState.Open)
            {
                this.Loggable.Log(ConnectionNotOpenMsg);
                return false;
            }

            if (string.IsNullOrEmpty(dbName) || !dbName.Contains(Config.DatabaseNamePrefix))
            {
                this.Loggable.Log(InvalidDatabase);
                return false;
            }
            this.DbProperties.DatabaseName = dbName;
            this.Connection.Close();
            return this.InitConnection(this.DbProperties) != null;
        }

        public bool TestConnection()
        {
            try
            {
                DatabaseFactory.TestConnection(this.Connection);
                this.Loggable.Log(ConnectionSuccess);
                return true;
            }
            catch (ArgumentException e) { this.Loggable.Log(e.Message); }
            return false;
        }

        public DbConnection InitConnection(DbProperties dbProperties)
        {
            this.Connection = DatabaseFactory.CreateConnection(dbProperties);
            if (this.TestConnection() && dbProperties.DatabaseName != null)
                return this.Connection;
            return null;
        }

        public bool IsConnectionActive()
        {
            try
            {
                DatabaseFactory.TestConnection(this.Connection);
                return true;
            }
            catch (Exception) { }
            return false;
        }

        public List<string> GetDatabases()
        {
            if (this.Connection == null || this.Connection.State != System.Data.ConnectionState.Open)
            {
                this.Loggable.Log(ConnectionNotOpenMsg);
                return new List<string>();
            }
            MySqlCommand cmd = new MySqlCommand("SHOW DATABASES", this.Connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            List<string> databases = new List<string>();
            while (reader.Read())
            {
                string dbName = reader["Database"].ToString();
                if (dbName.Contains(Config.DatabaseNamePrefix))
                    databases.Add(dbName);
            }
            reader.Close();
            return databases;
        }

        public DbConnection GetConnection()
        {
            if (!this.TestConnection())
                throw new Exception(ConnectionNotOpenMsg);
            return this.Connection;
        }

        public DatabaseContext CreateDatabase(string dbName)
        {
            if (!this.IsConnectionActive())
                throw new Exception(ConnectionNotOpenMsg);
            if (string.IsNullOrEmpty(dbName) || this.GetDatabases().Contains(dbName))
                throw new Exception(InvalidDatabase);
            this.Connection.Close();
            this.DbProperties.DatabaseName = Config.DatabaseNamePrefix +  dbName;
            this.Connection = DatabaseFactory.CreateConnection(this.DbProperties);
            try
            {   
                return DatabaseFactory.CreateDatabase(this.Connection);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(ErrorCreatingDb);
            }
        }

        public void Dispose()
        {
            if (this.IsConnectionActive())
            {
                Console.WriteLine(@"Connection Manager was disposed");
                this.Connection.Close();
                this.Connection.Dispose();
            }
        }

        public DbProperties GetDbProperties()
        {
            return this.DbProperties;
        }       
    }
}
