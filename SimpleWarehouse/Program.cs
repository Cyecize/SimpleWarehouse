using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using SimpleWarehouse.App;
using SimpleWarehouse.Constants;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.IO;
using SimpleWarehouse.Model;
using SimpleWarehouse.Presenter;
using SimpleWarehouse.Service;
using SimpleWarehouse.Services;
using SimpleWarehouse.States;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //measuring time
            Stopwatch stopwatch = new Stopwatch();

            //creating dependencies
            IDbConnectionPropertiesStorageManager dbConnectionProperties = new DbConnectionStorageManager();
            IMySqlManager mySqlManager = new MySqlManager(dbConnectionProperties.GetSettings());
            IEventManager eventManager = new EventManager();
            ISession<IUser> userSession = new Session<IUser>();
            IOutputWriter writer = new ConsoleWriter();

            //Injecting dependencies 
            FormFactory.SqlManager = mySqlManager;

            //creating business classes
            IStateManager stateManager = new StateManager(writer, eventManager, mySqlManager, userSession, dbConnectionProperties);
            if (mySqlManager.IsConnectionActive()) stateManager.Push(new HomePresenter(stateManager));
            else stateManager.Push(new FirstRunPresenter(stateManager, dbConnectionProperties));

            //application loop
            ApplicationState.IsRunning = true;
            double deltaTimeSeconds = 0;
            double ticks;

            while (true)
            {
                stopwatch.Start();
                Application.DoEvents();
                eventManager.UpdateEvents(deltaTimeSeconds);
                if (ApplicationState.IsRunning)
                    stateManager.Update();
                else
                    break;

                System.Threading.Thread.Sleep(Constants.Config.EVENT_LISTENER_IMMEDIEATE);//1ms
                stopwatch.Stop();
                ticks = stopwatch.ElapsedTicks;
                deltaTimeSeconds = ticks / Stopwatch.Frequency * 1000;
                stopwatch.Reset();
            }

            //aftermath (testing along the way)
            mySqlManager.CloseConnection(); 
        }
    }
}
