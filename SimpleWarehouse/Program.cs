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
using System.IO;
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

            DbProperties properties = new DbProperties { Server = "localhostt", Port = "33063", Password = "", Username = "root" }; 

            //creating dependencies
            IMySqlManager mySqlManager = new MySqlManager(properties);
            IEventManager eventManager = new EventManager();
            ISession<IUser> userSession = new Session<IUser>();
            IOutputWriter writer = new ConsoleWriter();

            //Injecting dependencies 
            FormFactory.SqlManager = mySqlManager;

            //creating business classes
            IStateManager stateManager = new StateManager(writer, eventManager, mySqlManager, userSession);
            //stateManager.Push(new HomePresenter(stateManager));

            stateManager.Push(new FirstRunPresenter(stateManager));
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
