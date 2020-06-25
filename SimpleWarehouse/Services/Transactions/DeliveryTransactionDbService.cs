using System.Collections.Generic;
using SimpleWarehouse.Constants;
using SimpleWarehouse.Model;
using SimpleWarehouse.Model.Enum;
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
            var transaction = new Transaction
            {
                TransactionType = TransactionType.DELIVERY
            };
            Database.Transactions.Add(transaction);
            return transaction;
        }

        protected override void InsertRevenueStreamTransactionRelation(RevenueStream revenueStream,
            Transaction transaction)
        {
            var expense = new ModelMerger().Merge(revenueStream, new Expense());
            Database.Expenses.Add(expense);
            transaction.Expense = expense;
        }

        protected override bool IsUserAuthorized()
        {
            return Roles.IsStandard(LoggedUser.Roles);
        }

        protected override void UpdateProductsQuantities(List<TransactionProduct> products, bool isRollBack)
        {
            foreach (var prodTrans in products)
            {
                var product = ProductDbService.FindById(prodTrans.ProductId);
                if (isRollBack)
                    product.Quantity -= prodTrans.ProductQuantity;
                else
                    product.Quantity += prodTrans.ProductQuantity;
                ProductDbService.UpdateProduct(product);
            }
        }
    }
}