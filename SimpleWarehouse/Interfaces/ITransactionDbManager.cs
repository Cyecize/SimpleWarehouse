using SimpleWarehouse.Constants;
using SimpleWarehouse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Interfaces
{
    public interface ITransactionDbManager
    {
        
        Transaction FindOneById(int id);

        List<Transaction> FindAllRevised();

        List<Transaction> FindAllNonRevised();

        List<Transaction> FindByType(TransactionTypes transactionType);

        List<Transaction> FindByDateTypeAndRevisionStatus(DateTime startDate, DateTime endDate, TransactionTypes transactionType, bool isRevised);

        void AddTransaction(List<ProductTransaction> products);

        void RollBack(int transactionId);

        void RollBack(Transaction transaction);

        void ArchiveTransactions();
    }
}
