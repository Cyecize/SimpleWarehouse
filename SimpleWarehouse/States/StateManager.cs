using SimpleWarehouse.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimpleWarehouse.States
{
    public class StateManager : IStateManager
    {

        private Stack<IPresenter> Presenters { get; set; }

        public IOutputWriter OutputWriter { get; set; }
        public IEventManager EventManager { get; set; }
        public IMySqlManager SqlManager { get ; set; }
        public ISession<IUser> UserSession { get; set; }
        public IDbConnectionPropertiesStorageManager DbConnectionPropertiesManager { get ; set ; }

        public StateManager(IOutputWriter writer, IEventManager eventManager, IMySqlManager sqlManager, ISession<IUser> userSession, IDbConnectionPropertiesStorageManager dbConnectionProperties)
        {
            this.OutputWriter = writer;
            this.Presenters = new Stack<IPresenter>();
            this.EventManager = eventManager;
            this.SqlManager = sqlManager;
            this.UserSession = userSession;
            this.DbConnectionPropertiesManager = dbConnectionProperties;
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
    }
}
