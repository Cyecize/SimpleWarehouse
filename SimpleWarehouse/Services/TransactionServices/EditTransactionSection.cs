using SimpleWarehouse.Constants;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Presenter;
using SimpleWarehouse.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Services.TransactionServices
{
    public class EditTransactionSection
    {


        private IUser LoggedUser { get; set; }

        private ITransactionDbManager SalesDbManager { get; set; }

        private ITransactionEditGridViewManager GridViewManager { get; set; }

        private int TransactionToRemove;

        private ITransactionDbManager DeliveriesDbManager { get; set; }

        public IPresenter Presenter { get; set; }

        public ITransactionView Form { get; set; }

        public EditTransactionSection(IPresenter presenter, ITransactionView transactionView)
        {
            this.TransactionToRemove = -1;
            this.Presenter = presenter;
            this.Form = transactionView;
            this.LoggedUser = presenter.GetStateManager().UserSession.SessionEntity;
            this.GridViewManager = new TransactionEditGridViewManager(this.Form.TransactionGrid, this.Form, this);
            this.InitTransactionDbManagers();

        }

        public void Search()
        {
            if (!Roles.IsRequredRoleMet(this.LoggedUser.Role, Config.USER_TYPICAL_ROLE))
            {
                this.Form.Log("Нямате права за тази операция!");
                return;
            }
            bool isRevised = this.Form.IsTransactionRevised;
            DateTime startDate = this.Form.TransactionStartDate;
            DateTime endDate = this.Form.TransactionEndtDate;
            TransactionTypes transactionType = this.Form.SelectedTransactionType;
            List<Transaction> transactions = this.SalesDbManager.FindByDateTypeAndRevisionStatus(startDate, endDate, transactionType, isRevised);
            this.GridViewManager.ClearRows();
            transactions.ForEach(this.GridViewManager.InsertTransaction);
            double totalSum = transactions.Sum(tr => tr.RevenueAmount);
            this.Form.Log($"Показани са {transactions.Count} транзакции. Обща сума: {totalSum:F2}.");
        }


        public void DeleteTransaction(int transactionId)
        {
            this.TransactionToRemove = transactionId;
            this.Presenter.GetStateManager().Push(new ConfirmActionPresenter(this.Presenter.GetStateManager(), this.OnActionConfirmed, $"Изтриване на транзакция с Номер {transactionId}?"));
            this.Search();
        }

        //PRIVATE LOGIC
        private void InitTransactionDbManagers()
        {
            IMySqlManager sqlManager = this.Presenter.GetStateManager().SqlManager;
            this.SalesDbManager = new SalesTransactionDbManager(sqlManager, this.LoggedUser);
            this.DeliveriesDbManager = new DeliveryTransactionDbManager(sqlManager, this.LoggedUser);
        }

        private void OnActionConfirmed(bool isConfirmed)
        {
            if (isConfirmed)
            {
                try
                {
                    Transaction transaction = this.SalesDbManager.FindOneById(this.TransactionToRemove);
                    if(transaction == null)
                    {
                        this.Form.Log("Невалидно ID на транзакция!");
                        return;
                    }
                    switch(Enum.Parse(typeof(TransactionTypes), transaction.TransactionType))
                    {
                        case TransactionTypes.Delivery:
                            this.DeliveriesDbManager.RollBack(transaction);
                            break;
                        case TransactionTypes.Sale:
                            this.SalesDbManager.RollBack(this.TransactionToRemove);
                            break;
                    }
                    this.Search();
                    this.Form.Log($"Изтрита е транзакция с номер: {this.TransactionToRemove}");
                    this.TransactionToRemove = -1;
                }
                catch (Exception e) { this.Form.Log(e.Message); }
            }
        }
    }
}
