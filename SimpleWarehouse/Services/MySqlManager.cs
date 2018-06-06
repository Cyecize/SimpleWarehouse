using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;

namespace SimpleWarehouse.Service
{
    public class MySqlManager : IMySqlManager
    {
        private MySqlConnection _conn;
        private MySqlDataReader DataReader { get; set; }
        private string ConnectionStr { get; set; }
        private bool IsConnAvailable { get; set; }
        public DbProperties ConnectionProperties { get; set; }

        public MySqlConnection Connection { get => this._conn; set { this.CloseConnection(); this._conn = value; this.OpenAndTestConnection(); } }

        public MySqlManager(DbProperties dbProperties)
        {
            this.ConnectionStr = dbProperties.CreateConnectionString();
            this.ConnectionProperties = dbProperties;

            this.Connection = new MySqlConnection(this.ConnectionStr);
            this.IsConnAvailable = this.OpenAndTestConnection();//open the connection 
        }

        public int ExecuteQuery(string query)
        {
            if (!this.IsConnAvailable)
                this.OpenAndTestConnection();
            this.CloseDataReader();
            try
            {

                MySqlCommand command = new MySqlCommand(query, this.Connection);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected;
            }
            catch (Exception e)
            {
                this.CloseDataReader();
                Console.WriteLine("There was an error with the MySql manager at ExecuteQuery");
                Console.WriteLine(e.Message);
                return 0;
            }
        }

        public long InsertQuery(string query)
        {
            if (!this.IsConnAvailable)
                this.OpenAndTestConnection();
            this.CloseDataReader();
            try
            {

                MySqlCommand command = new MySqlCommand(query, this.Connection);
                int rowsAffected = command.ExecuteNonQuery();
                return command.LastInsertedId;
            }
            catch (Exception е)
            {
                this.CloseDataReader();
                Console.WriteLine("There was an error with the MySql manager at InsertQuery");
                Console.WriteLine(е.Message);
                Console.WriteLine(query);
                return 0;
            }
        }

        public MySqlDataReader ExecuteQueryData(string query)
        {
            if (!this.IsConnAvailable)
                this.OpenAndTestConnection();
            this.CloseDataReader();
            try
            {

                MySqlCommand command = new MySqlCommand(query, this.Connection);
                command.CommandText = query;
                this.DataReader = command.ExecuteReader();
                return this.DataReader;
            }
            catch (Exception ex)
            {
                this.CloseDataReader();
                Console.WriteLine("There was exception with the Db");
                Console.WriteLine($" --> DataReader state before before: {this.DataReader == null}");
                Console.WriteLine($" --> Msg: {ex.Message}");
                Console.WriteLine(query);
                this.CloseDataReader();
                Console.WriteLine($" --> DataReader state after: {this.DataReader == null}");
                return null;
            }
        }

        public string EscapeString(string str)
        {
            return MySqlHelper.EscapeString(str);
        }

        //close SQL connection if it is Open
        public void CloseConnection()
        {
            if (this.Connection != null && this.Connection.State != ConnectionState.Closed)
            {
                this.Connection.Close();
                this.CloseDataReader();
                this.IsConnAvailable = false;
            }
        }

        public bool IsConnectionActive()
        {
            return ConnectionState.Open == this.Connection.State;
        }

        //private logic
        /*
            Open SQL connection and return true or throw an Exception!
        */
        private bool OpenAndTestConnection()
        {
            try
            {
                if (this.Connection.State.ToString() == "Closed")
                    this.Connection.Open();
                this.IsConnAvailable = true;
                return true;
            }
            catch (Exception)
            {
                //ApplicationState.IsRunning = false;
                this.IsConnAvailable = false;
                Console.WriteLine("Connection to MySql Database was not established");
                return false;

                // throw new Exception("Connection to MySql Database was not established");
            }
        }

        public void CloseDataReader()
        {
            if (this.DataReader != null)
            {
                this.DataReader.Close();
                this.DataReader = null;
            }
        }
    }
}

