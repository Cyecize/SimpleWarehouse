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
    public class RevenueDbManager : IRevenueDbManager
    {
        private const string REVENUE_TABLE_NAME = "SELECT * FROM revenues_users_joined ";
        private const string REVENUE_ARCHIVES_TABLE_NAME = "SELECT * FROM revenue_archives_users_joined ";
        private IMySqlManager SqlManager;
        private IEntityRepository<Revenue> RevenueRepo;

        public RevenueDbManager(IMySqlManager sqlManager)
        {
            this.SqlManager = sqlManager;
            this.RevenueRepo = new EntityRepo<Revenue>(sqlManager, new ConsoleWriter());
        }

        public void ArchiveRevenues()
        {
            string query = "INSERT INTO revenue_archives (user_id, revenue_amount, date, is_revised) SELECT r.user_id, r.revenue_amount, r.date, TRUE FROM revenues AS r;";
            string query2 = "TRUNCATE TABLE revenues;";
            this.SqlManager.ExecuteQuery(query);
            this.SqlManager.ExecuteQuery(query2);
        }

        public void CreateRevenue(Revenue revenue)
        {
            string query = $"INSERT INTO revenues VALUES (null, {revenue.UserId}, {revenue.RevenueAmount}, '{revenue.Date.ToString("yyyy-MM-dd hh:mm:ss")}', {revenue.IsRevised.ToString().ToUpper()})";
            this.SqlManager.ExecuteQuery(query);
        }

        public List<Revenue> FindAllNonRevisedRevenues()
        {
            return this.RevenueRepo.FindManyByQuery($"{REVENUE_TABLE_NAME} WHERE is_revised = 0 ORDER BY date ASC LIMIT 129");
        }

        public List<Revenue> FindRevisedRevenuesByDate(DateTime startDate, DateTime endDate)
        {
            string query = $"{REVENUE_ARCHIVES_TABLE_NAME} AS r WHERE r.date >= '{startDate.ToString("yyyy-MM-dd")}' AND r.date <= '{endDate.ToString("yyyy-MM-dd")}' ORDER BY r.date ASC;";
            return this.RevenueRepo.FindManyByQuery(query);
        }
    }
}
