using System.Collections.Generic;
using SimpleWarehouse.Interfaces;

namespace SimpleWarehouse.Presenter
{
    public abstract class AbstractPresenter : IPresenter
    {
        protected AbstractPresenter(IStateManager manager)
        {
            StateManager = manager;
            IsFormShown = false;
            EventIds = new List<int>();
        }

        protected IStateManager StateManager { get; set; }
        protected bool IsFormShown { get; set; }
        protected List<int> EventIds { get; set; }

        public abstract ILoggable Loggable { get; }

        public IStateManager GetStateManager()
        {
            return StateManager;
        }

        public abstract void Dispose();


        public abstract void Update();
    }
}