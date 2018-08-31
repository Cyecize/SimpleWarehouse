using SimpleWarehouse.Services.Operations;
using SimpleWarehouse.Services.Transactions;

namespace SimpleWarehouse.Sections.Operations
{
    public interface IOperationsSection
    {
        IOperationsViewService OperationsViewService { get; set; }

        ITransactionDbService TransactionDbService { get; set; }

        void CancelOperation();

        void Initialize();

        void PickAProductRequest();

        void UpdateTotalPriceAction(int rowId);

        void RefreshGridAction();

        void CreateTransactionAction();
    }
}
