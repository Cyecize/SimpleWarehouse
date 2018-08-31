using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWarehouse.Constants;
using SimpleWarehouse.Model;
using SimpleWarehouse.Model.Enum;
using SimpleWarehouse.Services.Revenues;
using SimpleWarehouse.Util;
using static SimpleWarehouse.App.ApplicationState;

namespace SimpleWarehouse.Services.Transactions
{
    public class DeliveryTransactionDbService : AbstractTransactionDbService
    {
        public DeliveryTransactionDbService(User loggedUser) : base(loggedUser)
        {
           
        }

        
        protected override Transaction InsertTransaction()
        {
            Transaction transaction = new Transaction()
            {
                TransactionType =  TransactionType.DELIVERY
            };
            Database.Transactions.Add(transaction);
            return transaction;
        }

        protected override void InsertRevenueStreamTransactionRelation(RevenueStream revenueStream, Transaction transaction)
        {
            Expense expense = new ModelMerger().Merge(revenueStream, new Expense());
            Database.Expenses.Add(expense);
            transaction.Expense = expense;
        }

        protected override bool IsUserAuthorized()
        {
            return Roles.IsStandard(base.LoggedUser.Roles);
        }

        protected override void UpdateProductsQuantities(List<TransactionProduct> products, bool isRollBack)
        {
            foreach (var prodTrans in products)
            {   
                if (isRollBack)
                    prodTrans.Product.Quantity -= prodTrans.ProductQuantity;
                else
                    prodTrans.Product.Quantity += prodTrans.ProductQuantity;
                base.ProductsRepositoryManager.UpdateProduct(prodTrans.Product);
            }
        }
    }
}
