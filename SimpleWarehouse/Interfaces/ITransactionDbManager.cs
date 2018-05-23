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
        void AddTransaction(List<ProductTransaction> products);

        Transaction FindOneById(int id);

        List<Transaction> FindAllRevised();

        List<Transaction> FindAllNonRevised();

        List<Transaction> FindByType(TransactionTypes transactionType);

        void RollBack(int transactionId);

        void RollBack(Transaction transaction);
    }
}
