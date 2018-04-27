using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Interfaces
{
    public interface ISession<T>
    {
        bool IsActive { get; set; }

        T SessionEntity { get; set; }

        void UnsetSession(); 
    }
}
