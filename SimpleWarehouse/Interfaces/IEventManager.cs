using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Interfaces
{
    public interface IEventManager
    {
        int AddEvent(IEvent customEvent);

        void UpdateEvents(double deltaTime);

        void RemoveEvent(int id); 
    }
}
