using MySql.Data.Entity;
using SimpleWarehouse.App;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.IO;
using SimpleWarehouse.Model;
using SimpleWarehouse.Presenter;
using SimpleWarehouse.Repository;
using SimpleWarehouse.Services;
using SimpleWarehouse.Services.Users;
using SimpleWarehouse.States;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleWarehouse.Presenter.Other;

namespace SimpleWarehouse
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //set up delimiter to prevent MySql exceptions for BG machines
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //measuring time
            Stopwatch stopwatch = new Stopwatch();

            //creating dependencies
            IOutputWriter writer = new ConsoleWriter();
            IDbConnectionPropertiesStorageManager dbConnectionProperties = new DbConnectionStorageManager();
            IDbConnectionManager connectionManager = new DbMySqlConnectionManager(writer);
            IEventManager eventManager = new EventManager();
            ISession<User> userSession = new Session<User>();
            DbConnection connection = connectionManager.InitConnection(dbConnectionProperties.GetSettings());
            DatabaseContext database = connection != null ? new DatabaseContext(connection, false) : null;

            //Injecting dependencies 
            ApplicationState.Database = database;
            IStateManager stateManager = new StateManager(writer, eventManager, userSession, dbConnectionProperties, connectionManager);

            //creating business classes
            if (database != null) stateManager.Push(new HomePresenter(stateManager));
            else stateManager.Push(new FirstRunPresenter(stateManager, dbConnectionProperties));

            //application loop
            ApplicationState.IsRunning = true;
            double deltaTimeSeconds = 0;
            while (true)
            {
                stopwatch.Start();
                Application.DoEvents();
                eventManager.UpdateEvents(deltaTimeSeconds);
                if (ApplicationState.IsRunning)
                    stateManager.Update();
                else
                    break;

                System.Threading.Thread.Sleep(Constants.Config.EventListenerImmediate);//1ms
                stopwatch.Stop();
                double ticks = stopwatch.ElapsedTicks;
                deltaTimeSeconds = ticks / Stopwatch.Frequency * 1000;
                stopwatch.Reset();
            }
            //aftermath (testing along the way)
           
        }
    }
}
