using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;
using SimpleWarehouse.Constants;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Repository;

namespace SimpleWarehouse.Services
{
    public class DbMySqlConnectionManager : IDbConnectionManager
    {
        private const string ConnectionSuccess = "OK";
        private const string ConnectionNotOpenMsg = "Connection is closed, please test connection first.";
        private const string InvalidDatabase = "Invalid Database";
        private const string ErrorCreatingDb = "Error creating database";

        public DbMySqlConnectionManager(ILoggable loggable)
        {
            Loggable = loggable;
        }

        public DbMySqlConnectionManager(ILoggable loggable, MySqlConnection connection, DbProperties properties) :
            this(loggable)
        {
            Connection = connection;
            DbProperties = properties;
        }

        private ILoggable Loggable { get; }

        private MySqlConnection Connection { get; set; }

        private DbProperties DbProperties { get; set; }

        public void CloseConnection()
        {
            if (TestConnection())
            {
                Connection.Close();
                Connection.Dispose();
            }
        }

        public DbProperties CreateConnection(string server, string port, string username, string password)
        {
            return CreateConnection(server, port, username, password, null);
        }

        public DbProperties CreateConnection(string server, string port, string username, string password,
            string dbName)
        {
            var properties = new DbProperties
                {Server = server, Port = port, Username = username, Password = password, DatabaseName = dbName};
            DbProperties = properties;
            Connection = DatabaseFactory.CreateConnection(properties);
            return properties;
        }

        public bool SelectDatabase(string dbName)
        {
            if (Connection == null || Connection.State != ConnectionState.Open)
            {
                Loggable.Log(ConnectionNotOpenMsg);
                return false;
            }

            if (string.IsNullOrEmpty(dbName) || !dbName.Contains(Config.DatabaseNamePrefix))
            {
                Loggable.Log(InvalidDatabase);
                return false;
            }

            DbProperties.DatabaseName = dbName;
            Connection.Close();
            return InitConnection(DbProperties) != null;
        }

        public bool TestConnection()
        {
            try
            {
                DatabaseFactory.TestConnection(Connection);
                Loggable.Log(ConnectionSuccess);
                return true;
            }
            catch (ArgumentException e)
            {
                Loggable.Log(e.Message);
            }

            return false;
        }

        public DbConnection InitConnection(DbProperties dbProperties)
        {
            Connection = DatabaseFactory.CreateConnection(dbProperties);
            if (TestConnection() && dbProperties.DatabaseName != null)
                return Connection;
            return null;
        }

        public bool IsConnectionActive()
        {
            try
            {
                DatabaseFactory.TestConnection(Connection);
                return true;
            }
            catch (Exception)
            {
            }

            return false;
        }

        public List<string> GetDatabases()
        {
            if (Connection == null || Connection.State != ConnectionState.Open)
            {
                Loggable.Log(ConnectionNotOpenMsg);
                return new List<string>();
            }

            var cmd = new MySqlCommand("SHOW DATABASES", Connection);
            var reader = cmd.ExecuteReader();
            var databases = new List<string>();
            while (reader.Read())
            {
                var dbName = reader["Database"].ToString();
                if (dbName.Contains(Config.DatabaseNamePrefix))
                    databases.Add(dbName);
            }

            reader.Close();
            return databases;
        }

        public DbConnection GetConnection()
        {
            if (Connection != null && Connection.State == ConnectionState.Open)
                return Connection;
            throw new Exception(ConnectionNotOpenMsg);
        }

        public DatabaseContext CreateDatabase(string dbName)
        {
            if (!IsConnectionActive())
                throw new Exception(ConnectionNotOpenMsg);
            if (string.IsNullOrEmpty(dbName) || GetDatabases().Contains(dbName))
                throw new Exception(InvalidDatabase);
            Connection.Close();
            DbProperties.DatabaseName = Config.DatabaseNamePrefix + dbName;
            Connection = DatabaseFactory.CreateConnection(DbProperties);
            try
            {
                return DatabaseFactory.CreateDatabase(Connection);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(ErrorCreatingDb);
            }
        }

        public void Dispose()
        {
            if (IsConnectionActive())
            {
                Console.WriteLine(@"Connection Manager was disposed");
                Connection.Close();
                Connection.Dispose();
            }
        }

        public DbProperties GetDbProperties()
        {
            return DbProperties;
        }
    }
}