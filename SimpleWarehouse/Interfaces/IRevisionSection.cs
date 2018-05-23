using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Interfaces
{
    public interface IRevisionSection
    {
        IRevisionGridViewManager GridViewManager { get; set; }

        IProductsRepositoryManager ProductsRepository { get; set; }

        ITransactionDbManager DeliveryTransactionDbManager { get; set; }

        ITransactionDbManager SaleTransactioDbManager { get; set; }

        IRevenueStreamDbManager RevenueStreamDbManager { get; set; }

        IRevenueStreamDbManager ExpenseStreamDbManager { get; set; }

        void CancelOperation();

        void Initialize();

        void BeginRevision();

        void UpdateTotalPriceAction(int rowId);

        void RefreshGridAction();

        void CommitRevisionAction();
    }
}
