using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SimpleWarehouse.Interfaces;

namespace SimpleWarehouse.Service
{
    public class MySqlManager : IMySqlManager
    {
        private MySqlConnection Connection;
        private MySqlDataReader DataReader;
        private string ConnectionStr;
        private bool isConnAvailable;

        public MySqlManager(string connectionStr)
        {
            this.ConnectionStr = connectionStr;

            this.Connection = new MySqlConnection(connectionStr);
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
            catch (Exception)
            {
                this.CloseConnection();
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

        //close SQL connection if it is Open
        public void CloseConnection()
        {
            //if (this.connection.State.ToString() == "Open")
            //this.connection.Close();
            this.CloseDataReader();

        }

        /**
         * Open SQL connection and return true or throw an Exception!
         * /*/
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

        public string EscapeString(string str)
        {
            return MySqlHelper.EscapeString(str);
        }
    }
}

