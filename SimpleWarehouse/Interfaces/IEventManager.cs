namespace SimpleWarehouse.Interfaces
{
    public interface IEventManager
    {
        int AddEvent(IEvent customEvent);

        void UpdateEvents(double deltaTime);

        void RemoveEvent(int id);
    }
}