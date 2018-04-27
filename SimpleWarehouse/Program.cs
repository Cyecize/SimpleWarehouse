using MySql.Data.MySqlClient;
using SimpleWarehouse.App;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.IO;
using SimpleWarehouse.Model;
using SimpleWarehouse.Presenter;
using SimpleWarehouse.Service;
using SimpleWarehouse.States;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Diagnostics;
using System.Linq;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //measuring time
            Stopwatch stopwatch = new Stopwatch();

            //creating dependencies
            IMySqlManager mySqlManager = new MySqlManager(Constants.Config.MY_SQL_CONNECTION);
            IEventManager eventManager = new EventManager();
            ISession<IUser> userSession = new Session<IUser>();
            IOutputWriter writer = new ConsoleWriter();

            //Injecting dependencies 
            FormFactory.SqlManager = mySqlManager;

            //creating business classes
            IStateManager stateManager = new StateManager(writer, eventManager, mySqlManager, userSession);
            stateManager.Push(new HomePresenter(stateManager));

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

                System.Threading.Thread.Sleep(Constants.Config.EVENT_LISTENER_IMMEDIEATE);
                stopwatch.Stop();
                ticks = stopwatch.ElapsedTicks;
                deltaTimeSeconds = ticks / Stopwatch.Frequency * 1000;
                stopwatch.Reset();

            }

            //aftermath (testing along the way)
        }
    }
}
