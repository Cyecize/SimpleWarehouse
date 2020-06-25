using SimpleWarehouse.Interfaces;

namespace SimpleWarehouse.View
{
    public interface IConfirmActionView : IView
    {
        string ConfirmTextContent { get; set; }
    }
}