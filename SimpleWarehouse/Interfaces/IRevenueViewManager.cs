using System.Collections.Generic;
using SimpleWarehouse.Model;

namespace SimpleWarehouse.Interfaces
{
    public interface IRevenueViewManager
    {
        void DisplayRevenues(List<RevenueStream> revenues);
    }
}