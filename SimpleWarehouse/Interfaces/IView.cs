namespace SimpleWarehouse.Interfaces
{
    public interface IView : ILoggable
    {
        string Text { get; set; }

        void HideAndDispose();

        void Show();

        void ShowAsDialog();
    }
}