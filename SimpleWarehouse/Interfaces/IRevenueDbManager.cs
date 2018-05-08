using SimpleWarehouse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Interfaces
{
    public interface IRevenueDbManager
    {
        List<Revenue> FindAllNonRevisedRevenues();

        List<Revenue> FindRevisedRevenuesByDate(DateTime startDate, DateTime endDate); 

        void CreateRevenue(Revenue revenue);

        void ArchiveRevenues();

    }
}
