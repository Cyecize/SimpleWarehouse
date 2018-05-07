using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimpleWarehouse.Interfaces
{
    public interface IStateManager
    {
        IOutputWriter OutputWriter { get; set; }

        IEventManager EventManager { get; set; }

        IMySqlManager SqlManager { get; set; }

        ISession<IUser> UserSession { get; set; }

        void Push(IPresenter presenter);

        void Pop();

        void Set(IPresenter presenter);

        IPresenter Peek();

        void Update();

        bool IsPresenterActive(IPresenter presenter);

    }
}
