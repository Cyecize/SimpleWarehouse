using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWarehouse.Model;

namespace SimpleWarehouse.Services.Revenues
{
    public interface IRevenueStreamViewManager
    {
        void DisplayRevenues(List<RevenueStream> revenues);
    }
}
