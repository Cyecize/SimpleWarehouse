using SimpleWarehouse.Interfaces;
using SimpleWarehouse.IO;
using SimpleWarehouse.Model;
using SimpleWarehouse.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Services.RevenueRelated
{
    public class RevenueDbManager : IRevenueStreamDbManager
    {
        private const string REVENUE_TABLE_NAME = "SELECT * FROM revenues_users_joined ";
        private const string REVENUE_TABLE_NAME_ONLY = "revenues_users_joined";

        private IMySqlManager SqlManager;
        private IEntityRepository<RevenueStream> RevenueRepo;

        public RevenueDbManager(IMySqlManager sqlManager)
        {
            this.SqlManager = sqlManager;
            this.RevenueRepo = new EntityRepo<RevenueStream>(sqlManager, new ConsoleWriter());
        }

        public void ArchiveEntities()
        {
            string query = "UPDATE revenues SET is_revised = 1 WHERE is_revised = 0";
            this.SqlManager.ExecuteQuery(query);
        }

        public long CreateEntity(RevenueStream revenue)
        {
            string query = $"INSERT INTO revenues VALUES (null, {revenue.UserId}, {revenue.RevenueAmount}, '{revenue.Date.ToString("yyyy-MM-dd hh:mm:ss")}', {revenue.IsRevised.ToString().ToUpper()})";
            return this.SqlManager.InsertQuery(query);
        }

        public List<RevenueStream> FindAllNonRevisedEntities()
        {
            return this.RevenueRepo.FindManyByQuery($"{REVENUE_TABLE_NAME} WHERE is_revised = 0 ORDER BY date ASC LIMIT 129");
        }

        public RevenueStream FindOneById(int id)
        {
            return this.RevenueRepo.FindOneBy(REVENUE_TABLE_NAME_ONLY, "id", id);
        }

        public RevenueStream FindOneByTransaction(int transactionId)
        {
            return this.RevenueRepo.FindOneByQuery($"SELECT * FROM {REVENUE_TABLE_NAME_ONLY} AS r INNER JOIN transactions_revenues AS tr ON tr.revenue_id = r.id WHERE transaction_id = {transactionId}");
        }

        public List<RevenueStream> FindRevisedEntitiesByDate(DateTime startDate, DateTime endDate)
        {
            string query = $"{REVENUE_TABLE_NAME} AS r WHERE r.date >= '{startDate.ToString("yyyy-MM-dd")}' AND r.date <= '{endDate.ToString("yyyy-MM-dd")}' AND is_revised = 1 ORDER BY r.date ASC;";
            return this.RevenueRepo.FindManyByQuery(query);
        }
    }
}
