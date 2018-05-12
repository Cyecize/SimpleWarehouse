using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Interfaces
{
    public interface ITransactionSection
    {
        ITransactionGridViewManager TransactionGridManager { get; set; }

        ITransactionDbManager TransactionDbManager { get; set; }

        void CancelOperation();

        void Initialize();

        void PickAProductRequest();

        void UpdateTotalPriceAction(int rowId);

        void RefreshGridAction();
    }
}
