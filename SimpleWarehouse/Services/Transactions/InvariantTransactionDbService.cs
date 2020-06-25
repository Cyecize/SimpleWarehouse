using System;
using System.Collections.Generic;
using SimpleWarehouse.Model;

namespace SimpleWarehouse.Services.Transactions
{
    public class InvariantTransactionDbService : AbstractTransactionDbService
    {
        public InvariantTransactionDbService(User loggedUser) : base(loggedUser)
        {
        }

        protected override Transaction InsertTransaction()
        {
            throw new NotImplementedException();
        }

        protected override void InsertRevenueStreamTransactionRelation(RevenueStream revenueStream,
            Transaction transaction)
        {
            throw new NotImplementedException();
        }

        protected override bool IsUserAuthorized()
        {
            throw new NotImplementedException();
        }

        protected override void UpdateProductsQuantities(List<TransactionProduct> products, bool isRollBack)
        {
            throw new NotImplementedException();
        }
    }
}