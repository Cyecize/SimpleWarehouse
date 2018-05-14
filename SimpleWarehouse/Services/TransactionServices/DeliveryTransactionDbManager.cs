using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWarehouse.Constants;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;

namespace SimpleWarehouse.Services.TransactionServices
{
    public class DeliveryTransactionDbManager : AbstractTransactionDbManager
    {
        public  DeliveryTransactionDbManager(IMySqlManager sqlManager, IUser loggedUser) : base(sqlManager, loggedUser)
        {

        }

        protected override RevenueStream InsertRevenueStream(RevenueStream revenueStream)
        {
            int expenseId =  (int)base.ExpenseManager.CreateEntity(revenueStream);
            return base.ExpenseManager.FindOneById(expenseId);
        }

        protected override void InsertRevenueStreamTransactionRelation(RevenueStream revenueStream, Transaction transaction)
        {
            string query = $"INSERT INTO transactions_expenses VALUES ({transaction.Id}, {revenueStream.Id})";
            base.SqlManager.ExecuteQuery(query);
        }

        protected override int InsertTransaction()
        {
            string query = $"INSERT INTO transactions VALUES(NULL, CURRENT_TIMESTAMP, 'Delivery', FALSE)";
            return (int)base.SqlManager.InsertQuery(query);
        }

        protected override bool IsUserAuthorized()
        {
            return Roles.IsRequredRoleMet(base.LoggedUser.Role, Config.USER_TYPICAL_ROLE);
        }
    }
}
