namespace SimpleWarehouse.Interfaces
{
    public interface IPresenter
    {
        ILoggable Loggable { get; }

        void Update();

        void Dispose();

        IStateManager GetStateManager();
    }
}