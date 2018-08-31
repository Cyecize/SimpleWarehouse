using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWarehouse.Model;

namespace SimpleWarehouse.Services.Transactions
{
    public interface ITransactionViewService
    {
        void ClearRows();

        void InsertTransaction(Transaction transaction);
    }
}
