using SimpleWarehouse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Interfaces
{
    public interface IRevenueStreamDbManager
    {
        List<RevenueStream> FindAllNonRevisedEntities();

        RevenueStream FindOneByTransaction(int transactionId);

        List<RevenueStream> FindRevisedEntitiesByDate(DateTime startDate, DateTime endDate);

        RevenueStream FindOneById(int id);

        long CreateEntity(RevenueStream revenue);

        void ArchiveEntities();

    }
}
