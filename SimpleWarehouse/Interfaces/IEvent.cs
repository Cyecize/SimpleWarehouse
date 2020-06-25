namespace SimpleWarehouse.Interfaces
{
    public interface IEvent
    {
        int Id { get; set; }

        void Update(double deltaTime);
    }
}