using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using MySql.Data.Entity;
using SimpleWarehouse.App;
using SimpleWarehouse.Constants;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.IO;
using SimpleWarehouse.Model;
using SimpleWarehouse.Presenter;
using SimpleWarehouse.Presenter.Other;
using SimpleWarehouse.Repository;
using SimpleWarehouse.Services;
using SimpleWarehouse.States;

namespace SimpleWarehouse
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            //set up delimiter to prevent MySql exceptions for BG machines
            var customCulture =
                (CultureInfo) Thread.CurrentThread.CurrentCulture.Clone();
            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture = customCulture;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            lblStartProgram:
            //measuring time
            var stopwatch = new Stopwatch();

            //creating dependencies
            IOutputWriter writer = new ConsoleWriter();
            IDbConnectionPropertiesStorageManager dbConnectionProperties = new DbConnectionStorageManager();
            IDbConnectionManager connectionManager = new DbMySqlConnectionManager(writer);
            IEventManager eventManager = new EventManager();
            ISession<User> userSession = new Session<User>();
            var connection = connectionManager.InitConnection(dbConnectionProperties.GetSettings());
            var database = connection != null ? new DatabaseContext(connection, false) : null;

            //Injecting dependencies 
            ApplicationState.Database = database;
            IStateManager stateManager = new StateManager(writer, eventManager, userSession, dbConnectionProperties,
                connectionManager);

            //creating business classes
            if (database != null) stateManager.Push(new HomePresenter(stateManager));
            else stateManager.Push(new FirstRunPresenter(stateManager, dbConnectionProperties));

            //application loop
            ApplicationState.IsRunning = true;
            ApplicationState.IsRestartRequested = false;
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

                Thread.Sleep(Config.EventListenerImmediate); //1ms
                stopwatch.Stop();
                double ticks = stopwatch.ElapsedTicks;
                deltaTimeSeconds = ticks / Stopwatch.Frequency * 1000;
                stopwatch.Reset();
                if (ApplicationState.IsRestartRequested)
                    goto lblStartProgram;
            }

            //aftermath (testing along the way)
        }
    }
}