using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Repository;
using SimpleWarehouse.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWarehouse.App;


namespace SimpleWarehouse.States
{
    public class StateManager : IStateManager
    {
        private Stack<IPresenter> Presenters { get; set; }
        public IOutputWriter OutputWriter { get; set; }
        public IEventManager EventManager { get; set; }
        public DatabaseContext Database { get=>ApplicationState.Database; set=>ApplicationState.Database = value; }
        public ISession<User> UserSession { get; set; }
        public IDbConnectionPropertiesStorageManager DbConnectionPropertiesManager { get; set; }
        public IDbConnectionManager ConnectionManager { get; set; }
        public IUserService UserService { get; set; }

        public StateManager(IOutputWriter writer, IEventManager eventManager,  ISession<User> userSession, IDbConnectionPropertiesStorageManager dbConnectionProperties, IDbConnectionManager connectionManager)
        {
            this.OutputWriter = writer;
            this.Presenters = new Stack<IPresenter>();
            this.EventManager = eventManager;
            this.UserSession = userSession;
            this.DbConnectionPropertiesManager = dbConnectionProperties;
            this.UserService = new UserService();
            this.ConnectionManager = connectionManager;
        }

        public void Pop()
        {
            this.Presenters.Pop().Dispose();
        }

        public void Push(IPresenter presenter)
        {
            this.Presenters.Push(presenter);
        }

        public void Set(IPresenter presenter)
        {
            this.Pop();
            this.Push(presenter);
        }

        public void SetAndFix(IPresenter presenter)
        {
            IPresenter thisPresenter = this.Peek();
            while (thisPresenter != presenter)
            {
                this.Pop();
                if (this.Presenters.Count < 1)
                    break;
                thisPresenter = this.Peek();
            }
            this.Database.Dispose();
            this.Database = new DatabaseContext(this.ConnectionManager.GetConnection(), false);
            this.Push(presenter);
        }

        public IPresenter Peek()
        {
            return this.Presenters.Peek();
        }

        public void Update()
        {
            this.Presenters.Peek().Update();
        }

        public bool IsPresenterActive(IPresenter presenter)
        {
            return this.Peek().GetType().Name == presenter.GetType().Name;
        }

        public bool IsPresenterPresent(IPresenter presenter)
        {
            return this.Presenters.Contains(presenter);
        }
    }
}
