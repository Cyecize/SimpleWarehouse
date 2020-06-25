namespace SimpleWarehouse.Interfaces
{
    public interface ISession<T>
    {
        bool IsActive { get; set; }

        T SessionEntity { get; set; }

        void UnsetSession();
    }
}