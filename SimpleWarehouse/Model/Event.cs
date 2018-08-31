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
        private WorkCompletedCallBack Callback { get; set; }
        private IEventManager Manager { get; set; }

        private double _accumulatedTime;
        private readonly long _maxCounterValue;
        private readonly bool _isOneTimeOnly;


        public int Id { get; set; }


        public Event(int execTimeout, WorkCompletedCallBack callback, IEventManager manager, bool isOneTimeOnly)
        {
            this.Callback = callback;
            this._accumulatedTime = 0;
            this._maxCounterValue = execTimeout;
            this.Id = ++ID;
            this._isOneTimeOnly = isOneTimeOnly;
            this.Manager = manager;

        }

        public void Update(double deltaTime)
        {
            this._accumulatedTime+= deltaTime;
            if (this._accumulatedTime >= this._maxCounterValue)
            {
                this._accumulatedTime = 0;
                this.Callback();
                if (this._isOneTimeOnly)
                    this.Manager.RemoveEvent(this.Id);
            }
        }
    }
}
