using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimpleWarehouse.Interfaces
{
    public interface IPresenter
    {
        void Update(); 

        void Dispose();

        IStateManager GetStateManager();
    }
}
