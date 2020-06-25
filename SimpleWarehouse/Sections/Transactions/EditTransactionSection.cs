using System;
using System.Linq;
using System.Text;
using SimpleWarehouse.Constants;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model.Enum;
using SimpleWarehouse.Presenter.Other;
using SimpleWarehouse.Services.Transactions;
using SimpleWarehouse.View;

namespace SimpleWarehouse.Sections.Transactions
{
    public class EditTransactionSection
    {
        private const string InvalidTransactionId = "Невалидно ID на транзакция!";
        private const string TransactionDoesNotBelongToUserMsg = "Тази транзакция е извършена от друг потребител!";

        private int _transactionToRemove;

        public EditTransactionSection(IPresenter presenter, ITransactionView transactionView)
        {
            _transactionToRemove = -1;
            Presenter = presenter;
            Form = transactionView;
            GridViewManager = new TransactionViewService(Form.TransactionGrid, Form, this);
            InitTransactionDbManagers();
        }

        private ITransactionDbService SaleTransactionDbService { get; set; }

        private ITransactionDbService DeliveryTransactionDbService { get; set; }

        private ITransactionViewService GridViewManager { get; }

        public IPresenter Presenter { get; set; }

        public ITransactionView Form { get; set; }

        public void Search()
        {
            if (!Roles.IsStandard(Presenter.GetStateManager().UserSession.SessionEntity.Roles))
            {
                Form.Log(Messages.NotAuthorizedMsg);
                return;
            }

            var isRevised = Form.IsTransactionRevised;
            var startDate = Form.TransactionStartDate;
            var endDate = Form.TransactionEndtDate;
            var transactionType = Form.SelectedTransactionType;
            var transactions =
                SaleTransactionDbService.FindByDateTypeAndRevisionStatus(startDate, endDate, transactionType,
                    isRevised);
            GridViewManager.ClearRows();
            transactions.ForEach(GridViewManager.InsertTransaction);
            var totalSum = transactions.Sum(tr => tr.RevenueAmount);
            Form.Log($"Показани са {transactions.Count} транзакции. Обща сума: {totalSum:F2}.");
        }

        public void DeleteTransaction(int transactionId)
        {
            _transactionToRemove = transactionId;
            Presenter.GetStateManager().Push(new ConfirmActionPresenter(Presenter.GetStateManager(),
                OnRemoveTransactionConfirmed, $"Изтриване на транзакция с Номер {transactionId}?"));
            Search();
        }

        public void ShowTransaction(int transactionId)
        {
            var transaction = DeliveryTransactionDbService.FindById(transactionId);
            var sb = new StringBuilder();
            var transactionProducts = transaction.TransactionProducts;
            sb.AppendLine($"Транзакция: {transaction.Id}, тип: {transaction.TransactionType}");
            sb.AppendLine($"Обща сума: {transaction.RevenueAmount}");
            sb.AppendLine($"Общо продукти: {transactionProducts.Count}");

            foreach (var transProd in transactionProducts)
                sb.AppendLine($"кол.: {transProd.ProductQuantity}, пр.: {transProd.Product.ProductName}");

            Presenter.GetStateManager().Push(new ErrorPresenter(Presenter.GetStateManager(), sb.ToString()));
        }

        //PRIVATE LOGIC
        private void InitTransactionDbManagers()
        {
            SaleTransactionDbService =
                new SaleTransactionDbService(Presenter.GetStateManager().UserSession.SessionEntity);
            DeliveryTransactionDbService =
                new DeliveryTransactionDbService(Presenter.GetStateManager().UserSession.SessionEntity);
        }

        private void OnRemoveTransactionConfirmed(bool isConfirmed)
        {
            if (isConfirmed)
                try
                {
                    var transaction = SaleTransactionDbService.FindById(_transactionToRemove);
                    if (transaction == null)
                    {
                        Form.Log(InvalidTransactionId);
                        return;
                    }

                    if (transaction.User.Id != Presenter.GetStateManager().UserSession.SessionEntity.Id)
                        if (!Roles.IsAdmin(Presenter.GetStateManager().UserSession.SessionEntity.Roles))
                        {
                            Form.Log(TransactionDoesNotBelongToUserMsg);
                            return;
                        }

                    switch (transaction.TransactionType)
                    {
                        case TransactionType.DELIVERY:
                            DeliveryTransactionDbService.RollBack(transaction);
                            break;
                        case TransactionType.SALE:
                            SaleTransactionDbService.RollBack(_transactionToRemove);
                            break;
                    }

                    Search();
                    Form.Log($"Изтрита е транзакция с номер: {_transactionToRemove}");
                    _transactionToRemove = -1;
                }
                catch (Exception e)
                {
                    Form.Log(e.Message);
                }
        }
    }
}