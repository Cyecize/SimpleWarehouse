using MySql.Data.MySqlClient;
using SimpleWarehouse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Interfaces
{
    public interface IMySqlManager
    {
        MySqlDataReader ExecuteQueryData(string query);

        DbProperties ConnectionProperties { get; set; }

        MySqlConnection Connection { get; set; }

        int ExecuteQuery(string query);

        void CloseDataReader();

        void CloseConnection();

        string EscapeString(string str);

        long InsertQuery(string query);

        bool IsConnectionActive();

    }
}
