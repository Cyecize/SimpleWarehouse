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
    public class ExpensesDbManager : IRevenueStreamDbManager
    {
        private const string EXPENSE_TABLE_NAME = "SELECT * FROM expenses_users_joined ";
        private const string EXPENSE_ARCHIVES_TABLE_NAME = "SELECT * FROM expense_archives_users_joined ";
        private IMySqlManager SqlManager;
        private IEntityRepository<RevenueStream> RevenueRepo;

        public ExpensesDbManager(IMySqlManager sqlManager)
        {
            this.SqlManager = sqlManager;
            this.RevenueRepo = new EntityRepo<RevenueStream>(sqlManager, new ConsoleWriter());
        }

        public void ArchiveEntities()
        {
            string query = "INSERT INTO expense_archives (user_id, revenue_amount, date, is_revised) SELECT r.user_id, r.revenue_amount, r.date, TRUE FROM expenses AS r;";
            string query2 = "DELETE FROM expenses;";
            this.SqlManager.ExecuteQuery(query);
            this.SqlManager.ExecuteQuery(query2);
        }

        public void CreateEntity(RevenueStream revenue)
        {
            string query = $"INSERT INTO expenses VALUES (null, {revenue.UserId}, {revenue.RevenueAmount}, '{revenue.Date.ToString("yyyy-MM-dd hh:mm:ss")}', {revenue.IsRevised.ToString().ToUpper()})";
            this.SqlManager.ExecuteQuery(query);
        }

        public List<RevenueStream> FindAllNonRevisedEntities()
        {
            return this.RevenueRepo.FindManyByQuery($"{EXPENSE_TABLE_NAME} WHERE is_revised = 0 ORDER BY date ASC LIMIT 129");
        }

        public List<RevenueStream> FindRevisedEntitiesByDate(DateTime startDate, DateTime endDate)
        {
            string query = $"{EXPENSE_ARCHIVES_TABLE_NAME} AS r WHERE r.date >= '{startDate.ToString("yyyy-MM-dd")}' AND r.date <= '{endDate.ToString("yyyy-MM-dd")}' ORDER BY r.date ASC;";
            return this.RevenueRepo.FindManyByQuery(query);
        }
    }
}
