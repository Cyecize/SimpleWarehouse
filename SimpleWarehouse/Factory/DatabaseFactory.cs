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

namespace SimpleWarehouse.Factory
{
    public class DatabaseFactory
    {
        private DatabaseFactory() { }

        public static IMySqlManager CreateDatabase(DbProperties properties, string dbName)
        {
            dbName = Config.DATABASE_NAME_PREFIX + dbName;

            MySqlConnection conn = CreateConnection(properties);
            TestConnection(conn);

            MySqlCommand command = new MySqlCommand($"CREATE DATABASE `{dbName}` CHARACTER SET utf8 COLLATE utf8_unicode_ci", conn);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception e) { Console.WriteLine(e.Message); throw new ArgumentException("There was an error while creating the database."); }

            properties.DatabaseName = dbName;
            IMySqlManager newManager = new MySqlManager(properties);
            if (newManager.IsConnectionActive())
            {
                return newManager;
            }
            throw new ArgumentException("There was an error creating the database.");
        }

        public static void TestConnection(MySqlConnection connection)
        {
            try { connection.Open(); }
            catch (Exception) { throw new ArgumentException("Invalid db connection parameters."); }
        }

        public static MySqlConnection CreateConnection(DbProperties properties)
        {
            MySqlConnection conn = new MySqlConnection(properties.CreateConnectionString());
            return conn;
        }
    }
}
