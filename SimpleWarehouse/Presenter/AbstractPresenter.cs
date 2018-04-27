using SimpleWarehouse.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimpleWarehouse.Presenter
{
    public abstract class AbstractPresenter : IPresenter
    {
        protected IStateManager StateManager { get; set; }
        protected bool IsFormShown { get; set; }
        protected List<int> EventIds { get; set; }

        protected AbstractPresenter(IStateManager manager)
        {
            this.StateManager = manager;
            this.IsFormShown = false;
            this.EventIds = new List<int>(); 
        }

        public IStateManager GetStateManager()
        {
            return this.StateManager;
        }

        public abstract void Dispose();
       
        public abstract void Update();
    }
}
