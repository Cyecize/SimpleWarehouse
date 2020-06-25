using SimpleWarehouse.Model;
using SimpleWarehouse.Repository;
using SimpleWarehouse.Services.Users;

namespace SimpleWarehouse.Interfaces
{
    public interface IStateManager
    {
        IOutputWriter OutputWriter { get; set; }

        IEventManager EventManager { get; set; }

        DatabaseContext Database { get; set; }

        ISession<User> UserSession { get; set; }

        IDbConnectionPropertiesStorageManager DbConnectionPropertiesManager { get; set; }

        IDbConnectionManager ConnectionManager { get; set; }

        IUserService UserService { get; set; }

        void Push(IPresenter presenter);

        void Pop();

        void Set(IPresenter presenter);

        void SetAndFix(IPresenter presenter);

        IPresenter Peek();

        void Update();

        bool IsPresenterActive(IPresenter presenter);

        bool IsPresenterPresent(IPresenter presenter);
    }
}