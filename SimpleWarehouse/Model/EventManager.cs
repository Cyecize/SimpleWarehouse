using SimpleWarehouse.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimpleWarehouse.Model
{
    public class EventManager : IEventManager
    {
        private List<IEvent> Events { get; set; }


        public EventManager()
        {
            this.Events = new List<IEvent>();
        }

        public int AddEvent(IEvent customEvent)
        {
            this.Events.Add(customEvent);
            return customEvent.Id;
        }

        public void RemoveEvent(int id)
        {
            this.Events = this.Events.Where(e => e.Id != id).ToList();
        }

        public void UpdateEvents(double deltaTime)
        {
            try
            {
                foreach (var eventt in Events)
                {
                    eventt.Update(deltaTime);
                }
            }
            catch (InvalidOperationException)
            {
                this.Events = new List<IEvent>();
            }
        }
    }
}
