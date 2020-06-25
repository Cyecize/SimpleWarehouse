using System.Collections.Generic;
using SimpleWarehouse.Model;

namespace SimpleWarehouse.Services.Revenues
{
    public interface IRevenueStreamViewManager
    {
        void DisplayRevenues(List<RevenueStream> revenues);
    }
}