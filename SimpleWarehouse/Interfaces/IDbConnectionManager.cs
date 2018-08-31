using SimpleWarehouse.Model;
using SimpleWarehouse.Repository;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Interfaces
{
    public interface IDbConnectionManager : IDisposable
    {

        bool SelectDatabase(string dbName);

        bool TestConnection();

        bool IsConnectionActive();

        DbProperties CreateConnection(string server, string port, string username, string password);

        DbProperties CreateConnection(string server, string port, string username, string password, string dbName);

        DbProperties GetDbProperties();

        DbConnection InitConnection(DbProperties dbProperties);

        DbConnection GetConnection();

        DatabaseContext CreateDatabase(string dbName);

        List<string> GetDatabases();      
    }
}
