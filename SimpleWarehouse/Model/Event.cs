using SimpleWarehouse.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimpleWarehouse.Model
{
    public class Event : IEvent
    {
        private static int ID = 0;

        public delegate void WorkCompletedCallBack();
        private WorkCompletedCallBack Callback;
        private IEventManager Manager;

        private double AccumulatedTime;
        private long MaxCounterValue;
        private bool IsOneTimeOnly;


        public int Id { get; set; }


        public Event(int execTimeout, WorkCompletedCallBack callback, IEventManager manager, bool isOneTimeOnly)
        {
            this.Callback = callback;
            this.AccumulatedTime = 0;
            this.MaxCounterValue = execTimeout;
            this.Id = ++ID;
            this.IsOneTimeOnly = isOneTimeOnly;
            this.Manager = manager;

        }

        public void Update(double deltaTime)
        {
           
            this.AccumulatedTime+= deltaTime;
            if (this.AccumulatedTime >= this.MaxCounterValue)
            {
                this.AccumulatedTime = 0;
                this.Callback();
                if (this.IsOneTimeOnly)
                    this.Manager.RemoveEvent(this.Id);
            }
        }
    }
}
