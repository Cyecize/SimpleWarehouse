using System.Collections.Generic;
using SimpleWarehouse.App;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Repository;
using SimpleWarehouse.Services.Users;

namespace SimpleWarehouse.States
{
    public class StateManager : IStateManager
    {
        public StateManager(IOutputWriter writer, IEventManager eventManager, ISession<User> userSession,
            IDbConnectionPropertiesStorageManager dbConnectionProperties, IDbConnectionManager connectionManager)
        {
            OutputWriter = writer;
            Presenters = new Stack<IPresenter>();
            EventManager = eventManager;
            UserSession = userSession;
            DbConnectionPropertiesManager = dbConnectionProperties;
            UserService = new UserService();
            ConnectionManager = connectionManager;
        }

        private Stack<IPresenter> Presenters { get; }
        public IOutputWriter OutputWriter { get; set; }
        public IEventManager EventManager { get; set; }

        public DatabaseContext Database
        {
            get => ApplicationState.Database;
            set => ApplicationState.Database = value;
        }

        public ISession<User> UserSession { get; set; }
        public IDbConnectionPropertiesStorageManager DbConnectionPropertiesManager { get; set; }
        public IDbConnectionManager ConnectionManager { get; set; }
        public IUserService UserService { get; set; }

        public void Pop()
        {
            Presenters.Pop().Dispose();
        }

        public void Push(IPresenter presenter)
        {
            Presenters.Push(presenter);
        }

        public void Set(IPresenter presenter)
        {
            Pop();
            Push(presenter);
        }

        public void SetAndFix(IPresenter presenter)
        {
            var thisPresenter = Peek();
            while (thisPresenter != presenter)
            {
                Pop();
                if (Presenters.Count < 1)
                    break;
                thisPresenter = Peek();
            }

            Push(presenter);
        }

        public IPresenter Peek()
        {
            return Presenters.Peek();
        }

        public void Update()
        {
            Presenters.Peek().Update();
        }

        public bool IsPresenterActive(IPresenter presenter)
        {
            return Peek().GetType().Name == presenter.GetType().Name;
        }

        public bool IsPresenterPresent(IPresenter presenter)
        {
            return Presenters.Contains(presenter);
        }
    }
}