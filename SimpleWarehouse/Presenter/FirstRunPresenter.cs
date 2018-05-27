using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SimpleWarehouse.Constants;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Service;
using SimpleWarehouse.View;

namespace SimpleWarehouse.Presenter
{
    public class FirstRunPresenter : AbstractPresenter
    {
        private IFirstRunView Form;

        private MySqlConnection CurrentConnection { get; set; }

        private DbProperties ConnectionProperties { get; set; }

        private IMySqlManager SelectedDatabase { get; set; }

        private const string CONNECTION_NOT_OPEN_MSG = "Connection is closed, please test connection first.";

        private IDbConnectionPropertiesStorageManager DbConnectionPropertiesManager { get; set; }

        public FirstRunPresenter(IStateManager manager, IDbConnectionPropertiesStorageManager dbConnectionProperties) : base(manager)
        {
            this.Form = (IFirstRunView)FormFactory.CreateForm("FirstRunForm", new object[] { this });
            ((Form)this.Form).FormClosing += (o, e) =>  App.ApplicationState.IsRunning = false; 
            this.DisplayConnectionString(base.StateManager.SqlManager.ConnectionProperties);
            this.Form.Text = "Първо стартиране";
            this.DbConnectionPropertiesManager = dbConnectionProperties;
        }

        public void ShowDatabasesAction()
        {
            if (this.CurrentConnection == null || this.CurrentConnection.State != System.Data.ConnectionState.Open)
            {
                this.Form.Log(CONNECTION_NOT_OPEN_MSG);
                return;
            }
            MySqlCommand cmd = new MySqlCommand("SHOW DATABASES", this.CurrentConnection);
            MySqlDataReader reader = cmd.ExecuteReader();
            List<string> databases = new List<string>();
            while (reader.Read())
            {
                string dbName = reader["Database"].ToString();
                if (dbName.StartsWith(Config.DATABASE_NAME_PREFIX))
                    databases.Add(dbName);
            }
            reader.Close();
            this.Form.SetDatabases(databases);
            this.Form.Log($"Displayed {databases.Count} databases");
        }

        public void TestConnectionAction()
        {
            DbProperties properties = new DbProperties { Server = this.Form.Server, Port = this.Form.Port, Username = this.Form.Username, Password = this.Form.Password };
            this.CurrentConnection = DatabaseFactory.CreateConnection(properties);
            try
            {
                DatabaseFactory.TestConnection(this.CurrentConnection);
                this.Form.Log("OK");
                this.ConnectionProperties = properties;
            }
            catch (ArgumentException e) { this.Form.Log(e.Message); }
        }

        public void SelectDatabaseAction()
        {
            if (this.CurrentConnection == null || this.CurrentConnection.State != System.Data.ConnectionState.Open)
            {
                this.Form.Log(CONNECTION_NOT_OPEN_MSG);
                return;
            }
            string dbName = this.Form.SelectedDatabase;
            if (dbName == null || dbName == "" || !dbName.StartsWith(Config.DATABASE_NAME_PREFIX))
            {
                this.Form.Log("Invalid Database");
                return;
            }
            this.ConnectionProperties.DatabaseName = dbName;
            this.SelectedDatabase = new MySqlManager(this.ConnectionProperties);
            if (!this.HasAdministrator())
                this.Form.SetUserBtnStatus(true);
            else
                this.Form.SetUserBtnStatus(false);
        }

        public void CreateAdministratorAction(string username, string password, string confPassword)
        {
            if (this.SelectedDatabase == null || !this.SelectedDatabase.IsConnectionActive())
            {
                this.Form.Log(CONNECTION_NOT_OPEN_MSG);
                return;
            }
            if(username == "" || username == null || password != confPassword || password.Length < 5)
            {
                this.Form.Log("Invalid values, check password lenght and username");
                return;
            }
            username = this.SelectedDatabase.EscapeString(username);
            password = this.SelectedDatabase.EscapeString(password);
            password = PasswordEncoder.EncodeMd5(password);
            string query = $"INSERT INTO users VALUES(null, '{username}', '{password}', {this.GetAuthId(Config.USER_ADMIN_ROLE)}, now())";
            this.SelectedDatabase.ExecuteQuery(query);
            this.SelectDatabaseAction();
        }

        public void CreateDatabaseAction()
        {
            if (this.CurrentConnection == null || this.CurrentConnection.State != System.Data.ConnectionState.Open)
            {
                this.Form.Log(CONNECTION_NOT_OPEN_MSG);
                return;
            }
            string dbName = this.Form.NewDatabaseName;
            if (dbName == null || dbName == "")
            {
                this.Form.Log("Invalid Database name.");
                return;
            }
            try
            {
                IMySqlManager manager = DatabaseFactory.CreateDatabase(this.ConnectionProperties, dbName);
                manager.ExecuteQuery(Properties.Resources.WarehouseSchema);
                manager.ExecuteQuery(Properties.Resources.WarehouseTransactionTriggers);
                manager.ExecuteQuery(Properties.Resources.WarehouseInitialInserts);
                this.ShowDatabasesAction();
            }
            catch (ArgumentException e) { this.Form.Log(e.Message); }
        }

        public void FinalizeSetupAction()
        {
            if(this.SelectedDatabase == null || !this.SelectedDatabase.IsConnectionActive())
            {
                this.Form.Log(CONNECTION_NOT_OPEN_MSG);
                return;
            }
            if (!this.HasAdministrator())
            {
                this.Form.Log("Please create an administrator");
                return;
            }
            base.StateManager.SqlManager.CloseConnection();
            base.StateManager.SqlManager.Connection = this.SelectedDatabase.Connection;
            base.StateManager.SqlManager.CloseConnection();
            base.StateManager.SqlManager.ConnectionProperties = this.ConnectionProperties;
            this.DbConnectionPropertiesManager.SaveSettions(base.StateManager.SqlManager.ConnectionProperties);
            base.StateManager.Set(new HomePresenter(base.StateManager));
        }

        public override void Dispose()
        {
            if (this.CurrentConnection != null)
                this.CurrentConnection.Close();
            this.Form.HideAndDispose();
        }

        public override void Update()
        {
            if (!base.IsFormShown)
            {
                this.Form.Show();
                base.IsFormShown = true;
            }
        }

        //private methods
        private void DisplayConnectionString(DbProperties properties)
        {
            this.Form.Server = properties.Server;
            this.Form.Port = properties.Port;
            this.Form.Username = properties.Username;
            this.Form.Password = properties.Password;
        }

        private bool HasAdministrator()
        {
            string query = $"SELECT * FROM users AS u  WHERE auth_id = {this.GetAuthId(Config.USER_ADMIN_ROLE)}";
            MySqlDataReader reader = this.SelectedDatabase.ExecuteQueryData(query);
            if (reader.HasRows)
                return true;
            return false;
        }

        private int GetAuthId(string auth)
        {
            string query = $"SELECT id FROM authentications AS a WHERE a.auth_type = '{Roles.HashRole(auth)}' LIMIT 1";
            MySqlDataReader reader = this.SelectedDatabase.ExecuteQueryData(query);
            if (reader.HasRows)
            {
                reader.Read();
                return (int)reader["id"];
            }              
            return -1;
        }
    }
}
