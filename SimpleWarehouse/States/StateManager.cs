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

        public StateManager(IOutputWriter writer, IEventManager eventManager, IMySqlManager sqlManager, ISession<IUser> userSession)
        {
            this.OutputWriter = writer;
            this.Presenters = new Stack<IPresenter>();
            this.EventManager = eventManager;
            this.SqlManager = sqlManager;
            this.UserSession = userSession; 
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

        public void Update()
        {
            this.Presenters.Peek().Update();
        }

       
    }
}
