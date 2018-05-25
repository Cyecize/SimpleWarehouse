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
        private MySqlConnection Connection { get; set; }
        private MySqlDataReader DataReader { get; set; }
        private string ConnectionStr { get; set; }
        private bool isConnAvailable { get; set; }
        public DbProperties ConnectionProperties { get ; set ; }

        public MySqlManager(DbProperties dbProperties)
        {
            this.ConnectionStr = dbProperties.CreateConnectionString();
            this.ConnectionProperties = dbProperties;

            this.Connection = new MySqlConnection(this.ConnectionStr);
            this.isConnAvailable = this.OpenAndTestConnection();//open the connection 
        }

        public int ExecuteQuery(string query)
        {
            if (!this.isConnAvailable)
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
                this.CloseConnection();
                Console.WriteLine("There was an error with the MySql manager at ExecuteQuery");
                Console.WriteLine(e.Message);
                return 0;
            }
        }

        public long InsertQuery(string query)
        {
            if (!this.isConnAvailable)
                this.OpenAndTestConnection();
            this.CloseDataReader();
            try
            {

                MySqlCommand command = new MySqlCommand(query, this.Connection);
                int rowsAffected = command.ExecuteNonQuery();
                return command.LastInsertedId;
            }
            catch (Exception)
            {
                this.CloseConnection();
                Console.WriteLine("There was an error with the MySql manager at InsertQuery");
                //Console.WriteLine(e.Message);
                return 0;
            }
        }

        public MySqlDataReader ExecuteQueryData(string query)
        {
            if (!this.isConnAvailable)
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
                this.CloseConnection();
                Console.WriteLine("There was exception with the Db");
                Console.WriteLine($" --> DataReader state before before: {this.DataReader == null}");
                Console.WriteLine($" --> Msg: {ex.Message}");
                Console.WriteLine(query);
                this.CloseConnection();
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
            //if (this.connection.State.ToString() == "Open")
            //this.connection.Close();
            this.CloseDataReader();

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
                this.isConnAvailable = true;
                return true;
            }
            catch (Exception)
            {
                //ApplicationState.IsRunning = false;
                this.isConnAvailable = false;
                Console.WriteLine("Connection to MySql Database was not established");
                return false;

                // throw new Exception("Connection to MySql Database was not established");
            }
        }

        private void CloseDataReader()
        {
            if (this.DataReader != null)
            {
                this.DataReader.Close();
                this.DataReader = null;
            }
        }

    }
}

