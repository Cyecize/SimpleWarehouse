using SimpleWarehouse.Interfaces;

namespace SimpleWarehouse.View
{
    public interface ILoginView : IView
    {
        string Username { get; set; }

        string Password { get; set; }

        string DbName { get; set; }
    }
}