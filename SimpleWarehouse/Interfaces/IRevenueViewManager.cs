using SimpleWarehouse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Interfaces
{
    public interface IRevenueViewManager
    {
        void DisplayRevenues(List<Revenue> revenues);
    }
}
