using System;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SimpleWarehouse.App;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Repository;
using SimpleWarehouse.Services;
using SimpleWarehouse.View;

namespace SimpleWarehouse.Presenter.Other
{
    public class SwitchDatabasePresenter : AbstractPresenter, ISubmitablePresenter
    {
        private const string CannotSelectThisDb = "Cannot select this db!";

        private ISwitchDatabaseView Form { get; set; }

        private IDbConnectionManager DbConnectionManager { get; set; }

        public override ILoggable Loggable => this.Form;

        public SwitchDatabasePresenter(IStateManager stateManager) : base(stateManager)
        {
            this.Form = (ISwitchDatabaseView) FormFactory.CreateForm("SwitchDatabaseForm", new object[] {this});
            ((Form) this.Form).FormClosing += (o, e) => App.ApplicationState.IsRunning = false;
            this.DbConnectionManager = new DbMySqlConnectionManager(
                this.Form,
                (MySqlConnection) base.StateManager.ConnectionManager.GetConnection(),
                base.StateManager.DbConnectionPropertiesManager.GetSettings());

            this.Form.DisplayDatabases(this.DbConnectionManager.GetDatabases());
        }

        public override void Dispose()
        {
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

        public void Submit()
        {
            string selectedDb = this.Form.GetSelectedDatabase();
            if (!this.DbConnectionManager.SelectDatabase(selectedDb))
                return;
            DatabaseContext db = new DatabaseContext(this.DbConnectionManager.GetConnection(), false);
            try
            {
                db.Roles.ToList();
                db.Products.ToList();
                DbProperties properties = this.DbConnectionManager.GetDbProperties();
                base.StateManager.DbConnectionPropertiesManager.SaveSettings(properties);
                this.Dispose();
                ApplicationState.IsRestartRequested = true;
            }
            catch (Exception)
            {
                this.Form.Log(CannotSelectThisDb);
            }
        }

        public void Cancel()
        {
            this.Dispose();
            ApplicationState.IsRestartRequested = true;
        }
    }
}