using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SimpleWarehouse.App;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Model.Enum;
using SimpleWarehouse.Repository;
using SimpleWarehouse.Services;
using SimpleWarehouse.View;

namespace SimpleWarehouse.Presenter.Other
{
    public class FirstRunPresenter : AbstractPresenter
    {
        private const string ConnectionNotSet = "Connection is not set up!";
        private const string InvalidValuesMessage = "Invalid values, check password lenght and username";
        private const string CreatedDatabaseMessage = "Created database!";
        private const string CannotSelectThisDb = "Cannot select this db!";
        private const string PleaseCreateAdminMsg = "Please create an administrator";

        private IFirstRunView Form { get; set; }

        private IDbConnectionPropertiesStorageManager DbConnectionPropertiesManager { get; set; }

        public override ILoggable Loggable => this.Form;
        
        public IDbConnectionManager DbConnectionManager { get; set; }

        public FirstRunPresenter(IStateManager manager, IDbConnectionPropertiesStorageManager dbConnectionProperties) :
            base(manager)
        {
            this.Form = (IFirstRunView) FormFactory.CreateForm("FirstRunForm", new object[] {this});
            ((Form) this.Form).FormClosing += (o, e) => App.ApplicationState.IsRunning = false;
            this.DisplayConnectionString(base.StateManager.DbConnectionPropertiesManager.GetSettings());
            this.Form.Text = @"Първо стартиране";
            this.DbConnectionPropertiesManager = dbConnectionProperties;
            this.DbConnectionManager = new DbMySqlConnectionManager(this.Form);
        }

        public void ShowDatabasesAction()
        {
            List<string> databases = this.DbConnectionManager.GetDatabases();
            this.Form.SetDatabases(databases);
            if (databases.Count > 0)
                this.Form.Log($"Displayed {databases.Count} databases");
        }

        public void TestConnectionAction()
        {
            this.DbConnectionManager.CreateConnection(this.Form.Server, this.Form.Port, this.Form.Username,
                this.Form.Password);
            this.DbConnectionManager.TestConnection();
        }

        public void SelectDatabaseAction()
        {
            if (!this.DbConnectionManager.SelectDatabase(this.Form.SelectedDatabase))
                return;
            DatabaseContext db = new DatabaseContext(this.DbConnectionManager.GetConnection(), false);
            try
            {
                db.Roles.ToList();
                db.Products.ToList();
            }
            catch (Exception)
            {
                this.Form.Log(CannotSelectThisDb);
                return;
            }

            this.UpdateDatabase(db, this.DbConnectionManager);
            this.EnableOrDisableCreateUserBtn();
        }

        public void CreateAdministratorAction(string username, string password, string confPassword)
        {
            if (!this.DbConnectionManager.IsConnectionActive())
            {
                this.Form.Log(ConnectionNotSet);
                return;
            }

            if (password != confPassword || !base.StateManager.UserService.IsInfoValid(username, password))
            {
                this.Form.Log(InvalidValuesMessage);
                return;
            }

            base.StateManager.UserService.CreateUser(username, password, RoleType.ADMIN);
            this.EnableOrDisableCreateUserBtn();
        }

        public void CreateDatabaseAction()
        {
            if (!this.DbConnectionManager.IsConnectionActive())
            {
                this.Form.Log(ConnectionNotSet);
                return;
            }

            string dbName = this.Form.NewDatabaseName;
            if (string.IsNullOrEmpty(dbName))
            {
                this.Form.Log("Invalid Database name.");
                return;
            }

            try
            {
                this.UpdateDatabase(this.DbConnectionManager.CreateDatabase(dbName), this.DbConnectionManager);
                this.Form.Log(CreatedDatabaseMessage);
            }
            catch (Exception e)
            {
                this.Form.Log(e.Message);
            }
        }

        public void FinalizeSetupAction()
        {
            if (!this.DbConnectionManager.IsConnectionActive())
            {
                this.Form.Log(ConnectionNotSet);
                return;
            }

            if (base.StateManager.UserService.FindByRole(RoleType.ADMIN).Count < 1)
            {
                this.Form.Log(PleaseCreateAdminMsg);
                return;
            }

            ApplicationState.IsRestartRequested = true;
        }

        public override void Dispose()
        {
            this.DbConnectionManager.Dispose();
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

        private void EnableOrDisableCreateUserBtn()
        {
            if (base.StateManager.UserService.FindByRole(RoleType.ADMIN).Count < 1)
                this.Form.SetUserBtnStatus(true);
            else
                this.Form.SetUserBtnStatus(false);
        }

        private void UpdateDatabase(DatabaseContext database, IDbConnectionManager connectionManager)
        {
            base.StateManager.ConnectionManager = connectionManager;
            base.StateManager.DbConnectionPropertiesManager.SaveSettings(connectionManager.GetDbProperties());
            base.StateManager.Database = database;
        }
    }
}