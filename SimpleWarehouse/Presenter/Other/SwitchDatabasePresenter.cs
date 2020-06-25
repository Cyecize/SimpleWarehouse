using System;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SimpleWarehouse.App;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Repository;
using SimpleWarehouse.Services;
using SimpleWarehouse.View;

namespace SimpleWarehouse.Presenter.Other
{
    public class SwitchDatabasePresenter : AbstractPresenter, ISubmitablePresenter
    {
        private const string CannotSelectThisDb = "Cannot select this db!";

        public SwitchDatabasePresenter(IStateManager stateManager) : base(stateManager)
        {
            Form = (ISwitchDatabaseView) FormFactory.CreateForm("SwitchDatabaseForm", new object[] {this});
            ((Form) Form).FormClosing += (o, e) => ApplicationState.IsRunning = false;
            DbConnectionManager = new DbMySqlConnectionManager(
                Form,
                (MySqlConnection) StateManager.ConnectionManager.GetConnection(),
                StateManager.DbConnectionPropertiesManager.GetSettings());

            Form.DisplayDatabases(DbConnectionManager.GetDatabases());
        }

        private ISwitchDatabaseView Form { get; }

        private IDbConnectionManager DbConnectionManager { get; }

        public override ILoggable Loggable => Form;

        public void Submit()
        {
            var selectedDb = Form.GetSelectedDatabase();
            if (!DbConnectionManager.SelectDatabase(selectedDb))
                return;
            var db = new DatabaseContext(DbConnectionManager.GetConnection(), false);
            try
            {
                db.Roles.ToList();
                db.Products.ToList();
                var properties = DbConnectionManager.GetDbProperties();
                StateManager.DbConnectionPropertiesManager.SaveSettings(properties);
                Dispose();
                ApplicationState.IsRestartRequested = true;
            }
            catch (Exception)
            {
                Form.Log(CannotSelectThisDb);
            }
        }

        public void Cancel()
        {
            Dispose();
            ApplicationState.IsRestartRequested = true;
        }

        public override void Dispose()
        {
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
    }
}