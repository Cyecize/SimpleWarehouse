namespace SimpleWarehouse.Interfaces
{
    public interface IOutputWriter : ILoggable
    {
        void WriteLine(object obj);
    }
}