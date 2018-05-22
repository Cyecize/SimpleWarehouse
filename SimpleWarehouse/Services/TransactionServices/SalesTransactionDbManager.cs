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
    public class SalesTransactionDbManager : AbstractTransactionDbManager
    {
        public  SalesTransactionDbManager(IMySqlManager sqlManager, IUser loggedUser) : base(sqlManager, loggedUser)
        {

        }

        protected override RevenueStream InsertRevenueStream(RevenueStream revenueStream)
        {
            int revenueId = (int)base.RevenueManager.CreateEntity(revenueStream);
            return base.RevenueManager.FindOneById(revenueId);
        }

        protected override void InsertRevenueStreamTransactionRelation(RevenueStream revenueStream, Transaction transaction)
        {
            string query = $"INSERT INTO transactions_revenues VALUES ({transaction.Id}, {revenueStream.Id})";
            base.SqlManager.ExecuteQuery(query);
        }

        protected override int InsertTransaction()
        {
            string query = $"INSERT INTO transactions VALUES(NULL, CURRENT_TIMESTAMP, '{TransactionTypes.Sale}', FALSE)";
            return (int)base.SqlManager.InsertQuery(query);
        }

        protected override bool IsUserAuthorized()
        {
            return Roles.IsRequredRoleMet(base.LoggedUser.Role, Config.USER_LIMITED_ROLE); 
        }

        protected override void UpdateProductsQuantities(List<ProductTransaction> products, bool isRollBack)
        {
            foreach (var prodTrans in products)
            {
                Product product = base.ProductsRepositoryManager.FindProductById(prodTrans.ProductId);
                if (isRollBack)
                    product.Quantity += prodTrans.ProductQuantity;
                else
                    product.Quantity -= prodTrans.ProductQuantity;
                base.ProductsRepositoryManager.UpdateProduct(product, false);
            }
        }
    }
}
