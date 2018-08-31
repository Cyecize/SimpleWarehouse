using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWarehouse.Constants;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Model.Enum;
using SimpleWarehouse.Presenter.Other;
using SimpleWarehouse.Services.Transactions;
using SimpleWarehouse.View;

namespace SimpleWarehouse.Sections.Transactions
{
    public class EditTransactionSection
    {
        private const string InvalidTransactionId = "Невалидно ID на транзакция!";
        private ITransactionDbService SaleTransactionDbService { get; set; }

        private ITransactionDbService DeliveryTransactionDbService { get; set; }

        private ITransactionViewService GridViewManager { get; set; }

        private int _transactionToRemove;

        public IPresenter Presenter { get; set; }

        public ITransactionView Form { get; set; }

        public EditTransactionSection(IPresenter presenter, ITransactionView transactionView)
        {
            this._transactionToRemove = -1;
            this.Presenter = presenter;
            this.Form = transactionView;
            this.GridViewManager = new TransactionViewService(this.Form.TransactionGrid, this.Form, this);
            this.InitTransactionDbManagers();
        }

        public void Search()
        {
            if (!Roles.IsStandard(this.Presenter.GetStateManager().UserSession.SessionEntity.Roles))
            {
                this.Form.Log(Messages.NotAuthorizedMsg);
                return;
            }
            var isRevised = this.Form.IsTransactionRevised;
            var startDate = this.Form.TransactionStartDate;
            var endDate = this.Form.TransactionEndtDate;
            var transactionType = this.Form.SelectedTransactionType;
            var transactions = this.SaleTransactionDbService.FindByDateTypeAndRevisionStatus(startDate, endDate, transactionType, isRevised);
            this.GridViewManager.ClearRows();
            transactions.ForEach(this.GridViewManager.InsertTransaction);
            var totalSum = transactions.Sum(tr => tr.RevenueAmount);
            this.Form.Log($"Показани са {transactions.Count} транзакции. Обща сума: {totalSum:F2}.");
        }


        public void DeleteTransaction(int transactionId)
        {
            this._transactionToRemove = transactionId;
            this.Presenter.GetStateManager().Push(new ConfirmActionPresenter(this.Presenter.GetStateManager(), this.OnActionConfirmed, $"Изтриване на транзакция с Номер {transactionId}?"));
            this.Search();
        }

        //PRIVATE LOGIC
        private void InitTransactionDbManagers()
        {
            this.SaleTransactionDbService = new SaleTransactionDbService(this.Presenter.GetStateManager().UserSession.SessionEntity);
            this.DeliveryTransactionDbService = new DeliveryTransactionDbService(this.Presenter.GetStateManager().UserSession.SessionEntity);
        }

        private void OnActionConfirmed(bool isConfirmed)
        {
            if (isConfirmed)
            {
                try
                {
                    Transaction transaction = this.SaleTransactionDbService.FindById(this._transactionToRemove);
                    if (transaction == null)
                    {
                        this.Form.Log(InvalidTransactionId);
                        return;
                    }
                    switch (transaction.TransactionType)
                    {
                        case TransactionType.DELIVERY:
                            this.DeliveryTransactionDbService.RollBack(transaction);
                            break;
                        case TransactionType.SALE:
                            this.SaleTransactionDbService.RollBack(this._transactionToRemove);
                            break;
                    }
                    this.Search();
                    this.Form.Log($"Изтрита е транзакция с номер: {this._transactionToRemove}");
                    this._transactionToRemove = -1;
                }
                catch (Exception e) { this.Form.Log(e.Message); }
            }
        }
    }
}
