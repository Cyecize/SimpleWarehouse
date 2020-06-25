using SimpleWarehouse.Model;

namespace SimpleWarehouse.Services.Transactions
{
    public interface ITransactionViewService
    {
        void ClearRows();

        void InsertTransaction(Transaction transaction);
    }
}