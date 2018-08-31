using System;
using System.Collections.Generic;
using SimpleWarehouse.Model;
using SimpleWarehouse.Model.Enum;

namespace SimpleWarehouse.Services.Transactions
{
    public interface ITransactionDbService
    {
        void AddTransaction(List<TransactionProduct> products);

        void RollBack(int transactionId);

        void RollBack(Transaction transaction);

        void ArchiveTransactions();

        Transaction FindById(int id);

        List<Transaction> FindAllRevised();

        List<Transaction> FindAllNonRevised();

        List<Transaction> FindByType(TransactionType transactionType);

        List<Transaction> FindByDateTypeAndRevisionStatus(DateTime startDate, DateTime endDate, TransactionType transactionType, bool isRevised);

    }
}
