using System;
using System.Collections.Generic;
using System.Linq;
using SimpleWarehouse.Interfaces;

namespace SimpleWarehouse.Model
{
    public class EventManager : IEventManager
    {
        public EventManager()
        {
            Events = new List<IEvent>();
        }

        private List<IEvent> Events { get; set; }

        public int AddEvent(IEvent customEvent)
        {
            Events.Add(customEvent);
            return customEvent.Id;
        }

        public void RemoveEvent(int id)
        {
            Events = Events.Where(e => e.Id != id).ToList();
        }

        public void UpdateEvents(double deltaTime)
        {
            try
            {
                foreach (var eventt in Events) eventt.Update(deltaTime);
            }
            catch (InvalidOperationException)
            {
                Events = new List<IEvent>();
            }
        }
    }
}