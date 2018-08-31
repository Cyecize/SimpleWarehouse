using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWarehouse.Constants;
using SimpleWarehouse.Model;
using SimpleWarehouse.Model.Enum;
using SimpleWarehouse.Util;
using static SimpleWarehouse.App.ApplicationState;

namespace SimpleWarehouse.Services.Transactions
{
    public class SaleTransactionDbService : AbstractTransactionDbService
    {
        public SaleTransactionDbService(User loggedUser) : base(loggedUser)
        {
        }

        protected override Transaction InsertTransaction()
        {
            Transaction transaction = new Transaction()
            {
                TransactionType = TransactionType.SALE
            };
            Database.Transactions.Add(transaction);
            return transaction;
        }

        protected override void InsertRevenueStreamTransactionRelation(RevenueStream revenueStream, Transaction transaction)
        {
            Revenue revenue = new ModelMerger().Merge(revenueStream, new Revenue());
            Database.Revenues.Add(revenue);
            transaction.Revenue = revenue;
        }

        protected override bool IsUserAuthorized()
        {
            return Roles.IsWorker(base.LoggedUser.Roles);
        }

        protected override void UpdateProductsQuantities(List<TransactionProduct> products, bool isRollBack)
        {
            foreach (var prodTrans in products)
            {
                if (isRollBack)
                    prodTrans.Product.Quantity += prodTrans.ProductQuantity;
                else
                    prodTrans.Product.Quantity -= prodTrans.ProductQuantity;
                base.ProductsRepositoryManager.UpdateProduct(prodTrans.Product);
            }
        }
    }
}
