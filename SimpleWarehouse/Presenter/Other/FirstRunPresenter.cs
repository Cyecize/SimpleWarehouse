using System;
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

        public FirstRunPresenter(IStateManager manager, IDbConnectionPropertiesStorageManager dbConnectionProperties) :
            base(manager)
        {
            Form = (IFirstRunView) FormFactory.CreateForm("FirstRunForm", new object[] {this});
            ((Form) Form).FormClosing += (o, e) => ApplicationState.IsRunning = false;
            DisplayConnectionString(StateManager.DbConnectionPropertiesManager.GetSettings());
            Form.Text = @"Първо стартиране";
            DbConnectionPropertiesManager = dbConnectionProperties;
            DbConnectionManager = new DbMySqlConnectionManager(Form);
        }

        private IFirstRunView Form { get; }

        private IDbConnectionPropertiesStorageManager DbConnectionPropertiesManager { get; }

        public override ILoggable Loggable => Form;

        public IDbConnectionManager DbConnectionManager { get; set; }

        public void ShowDatabasesAction()
        {
            var databases = DbConnectionManager.GetDatabases();
            Form.SetDatabases(databases);
            if (databases.Count > 0)
                Form.Log($"Displayed {databases.Count} databases");
        }

        public void TestConnectionAction()
        {
            DbConnectionManager.CreateConnection(Form.Server, Form.Port, Form.Username,
                Form.Password);
            DbConnectionManager.TestConnection();
        }

        public void SelectDatabaseAction()
        {
            if (!DbConnectionManager.SelectDatabase(Form.SelectedDatabase))
                return;
            var db = new DatabaseContext(DbConnectionManager.GetConnection(), false);
            try
            {
                db.Roles.ToList();
                db.Products.ToList();
            }
            catch (Exception)
            {
                Form.Log(CannotSelectThisDb);
                return;
            }

            UpdateDatabase(db, DbConnectionManager);
            EnableOrDisableCreateUserBtn();
        }

        public void CreateAdministratorAction(string username, string password, string confPassword)
        {
            if (!DbConnectionManager.IsConnectionActive())
            {
                Form.Log(ConnectionNotSet);
                return;
            }

            if (password != confPassword || !StateManager.UserService.IsInfoValid(username, password))
            {
                Form.Log(InvalidValuesMessage);
                return;
            }

            StateManager.UserService.CreateUser(username, password, RoleType.ADMIN);
            EnableOrDisableCreateUserBtn();
        }

        public void CreateDatabaseAction()
        {
            if (!DbConnectionManager.IsConnectionActive())
            {
                Form.Log(ConnectionNotSet);
                return;
            }

            var dbName = Form.NewDatabaseName;
            if (string.IsNullOrEmpty(dbName))
            {
                Form.Log("Invalid Database name.");
                return;
            }

            try
            {
                UpdateDatabase(DbConnectionManager.CreateDatabase(dbName), DbConnectionManager);
                Form.Log(CreatedDatabaseMessage);
            }
            catch (Exception e)
            {
                Form.Log(e.Message);
            }
        }

        public void FinalizeSetupAction()
        {
            if (!DbConnectionManager.IsConnectionActive())
            {
                Form.Log(ConnectionNotSet);
                return;
            }

            if (StateManager.UserService.FindByRole(RoleType.ADMIN).Count < 1)
            {
                Form.Log(PleaseCreateAdminMsg);
                return;
            }

            ApplicationState.IsRestartRequested = true;
        }

        public override void Dispose()
        {
            DbConnectionManager.Dispose();
            Form.HideAndDispose();
        }

        public override void Update()
        {
            if (!IsFormShown)
            {
                Form.Show();
                IsFormShown = true;
            }
        }

        //private methods
        private void DisplayConnectionString(DbProperties properties)
        {
            Form.Server = properties.Server;
            Form.Port = properties.Port;
            Form.Username = properties.Username;
            Form.Password = properties.Password;
        }

        private void EnableOrDisableCreateUserBtn()
        {
            if (StateManager.UserService.FindByRole(RoleType.ADMIN).Count < 1)
                Form.SetUserBtnStatus(true);
            else
                Form.SetUserBtnStatus(false);
        }

        private void UpdateDatabase(DatabaseContext database, IDbConnectionManager connectionManager)
        {
            StateManager.ConnectionManager = connectionManager;
            StateManager.DbConnectionPropertiesManager.SaveSettings(connectionManager.GetDbProperties());
            StateManager.Database = database;
        }
    }
}