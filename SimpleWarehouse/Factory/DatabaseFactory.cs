using MySql.Data.MySqlClient;
using SimpleWarehouse.Constants;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWarehouse.Model.Enum;
using SimpleWarehouse.Repository;

namespace SimpleWarehouse.Factory
{
    public class DatabaseFactory
    {
        private const string InvalidCredentialsMsg = "Invalid db connection parameters.";
        private const string ErrorCreatingDatabaseMsg = "Invalid db connection parameters.";

        private DatabaseFactory() { }


        public static DatabaseContext CreateDatabase(DbConnection dbConnection)
        {
            DatabaseContext databaseContext = new DatabaseContext(dbConnection, false);
            databaseContext.Database.CreateIfNotExists();
            AddSearchParameters(databaseContext);
            return databaseContext;
        }

        public static void TestConnection(MySqlConnection connection)
        {
            if (connection.State == ConnectionState.Open)
                return;
            try { connection.Open(); }
            catch (Exception) { throw new ArgumentException(InvalidCredentialsMsg); }
        }

        public static MySqlConnection CreateConnection(DbProperties properties)
        {
            MySqlConnection conn = new MySqlConnection(properties.CreateConnectionString());
            return conn;
        }

        private static void AddSearchParameters(DatabaseContext database)
        {
            if (database.SearchParameters.Any())
                return;
            database.SearchParameters.Add(new SearchParameter() { DisplayName = "Прод. име", SearchType = SearchType.ProductName });
            database.SearchParameters.Add(new SearchParameter() { DisplayName = "Категория", SearchType = SearchType.CategoryName });
            database.SearchParameters.Add(new SearchParameter() { DisplayName = "Прод. код", SearchType = SearchType.ProductId });
            database.SaveChanges();
        }
    }
}
