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
        private const string EXPENSE_TABLE_NAME_ONLY = "expenses_users_joined ";

        private IMySqlManager SqlManager;
        private IEntityRepository<RevenueStream> RevenueRepo;

        public ExpensesDbManager(IMySqlManager sqlManager)
        {
            this.SqlManager = sqlManager;
            this.RevenueRepo = new EntityRepo<RevenueStream>(sqlManager, new ConsoleWriter());
        }

        public void ArchiveEntities()
        {
            string query = "UPDATE expenses SET is_revised = 1 WHERE is_revised = 0";
            this.SqlManager.ExecuteQuery(query);
        }

        public long CreateEntity(RevenueStream revenue)
        {
            string query = $"INSERT INTO expenses VALUES (null, {revenue.UserId}, {revenue.RevenueAmount}, '{revenue.Date.ToString("yyyy-MM-dd hh:mm:ss")}', {revenue.IsRevised.ToString().ToUpper()} , '{this.SqlManager.EscapeString(revenue.Comment)}' )";
            return this.SqlManager.InsertQuery(query);
        }

        public List<RevenueStream> FindAllNonRevisedEntities()
        {
            return this.RevenueRepo.FindManyByQuery($"{EXPENSE_TABLE_NAME} WHERE is_revised = 0 ORDER BY date ASC LIMIT 129");
        }

        public RevenueStream FindOneByTransaction(int transactionId)
        {
            return this.RevenueRepo.FindOneByQuery($"SELECT * FROM {EXPENSE_TABLE_NAME_ONLY} AS e INNER JOIN transactions_expenses AS te ON te.expense_id = e.id WHERE transaction_id = {transactionId}");
        }

        public RevenueStream FindOneById(int id)
        {
            return this.RevenueRepo.FindOneBy(EXPENSE_TABLE_NAME_ONLY, "id", id);
        }

        public List<RevenueStream> FindRevisedEntitiesByDate(DateTime startDate, DateTime endDate)
        {
            string query = $"{EXPENSE_TABLE_NAME} AS r WHERE r.date >= '{startDate.ToString("yyyy-MM-dd")}' AND r.date <= '{endDate.ToString("yyyy-MM-dd")}' AND is_revised = 1 ORDER BY r.date ASC;";
            return this.RevenueRepo.FindManyByQuery(query);
        }
    }
}
