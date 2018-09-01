using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWarehouse.IO;
using SimpleWarehouse.Model;
using SimpleWarehouse.Model.Enum;
using SimpleWarehouse.Services.Products;
using SimpleWarehouse.Services.Revenues;
using static SimpleWarehouse.App.ApplicationState;

namespace SimpleWarehouse.Services.Transactions
{
    public abstract class AbstractTransactionDbService : ITransactionDbService
    {
        private const string UnauthorizedMsg = "Нямате права за тази операция";
        private const string TransactionIsNullMsg = "Невалидна транзакция (null)";
        private const string TransactionCannotBeRemovedMsg = "Транзакцията не може да бъде изтрина (вече е ревизирана)";

        protected User LoggedUser { get; set; }
       
        protected IProductDbService ProductDbService { get; set; }

        protected AbstractTransactionDbService(User loggedUser)
        {
            this.ProductDbService = new ProductDbService();
            this.LoggedUser = loggedUser;
        }

        public void AddTransaction(List<TransactionProduct> products)
        {
            if (!this.IsUserAuthorized())
                throw new ArgumentException(UnauthorizedMsg);
            Transaction transaction = this.InsertTransaction();
            this.InsertProductTransactionRelation(products, transaction);
            double totalRevenueAmount = products.Sum(p => p.SubTotalPrice);
            RevenueStream revenueStream = new RevenueStream
            {
                Date = DateTime.Now,
                IsRevised = false,
                RevenueAmount = totalRevenueAmount,
                UserId = this.LoggedUser.Id,
                Comment = transaction.TransactionType.ToString()
            };
            this.InsertRevenueStreamTransactionRelation(revenueStream, transaction);
            this.UpdateProductsQuantities(products, false);

            Database.SaveChanges();
        }

        public void RollBack(int transactionId)
        {
            this.RollBack(this.FindById(transactionId));
        }

        public void RollBack(Transaction transaction)
        {
            if (transaction == null)
                throw new ArgumentException(TransactionIsNullMsg);
            if (transaction.IsRevised)
                throw new ArgumentException(TransactionCannotBeRemovedMsg);
            List<TransactionProduct> products = this.FindAllRelatedProductTransactions(transaction);
            this.UpdateProductsQuantities(products, true);

            Database.TransactionProducts.RemoveRange(transaction.TransactionProducts);
            if (transaction.Expense != null)
                Database.Expenses.Remove(transaction.Expense);
            if (transaction.Revenue != null)
                Database.Revenues.Remove(transaction.Revenue);
            Database.Transactions.Remove(transaction);
            Database.SaveChanges();
        }

        public void ArchiveTransactions()
        {
            foreach (var transaction in Database.Transactions)
                transaction.IsRevised = true;
            Database.SaveChanges(); 
        }

        public Transaction FindById(int id)
        {
            return Database.Transactions.FirstOrDefault(tr => tr.Id == id);
        }

        public List<Transaction> FindAllRevised()
        {
            return new List<Transaction>(Database.Transactions.Where(tr => tr.IsRevised));
        }

        public List<Transaction> FindAllNonRevised()
        {
            return new List<Transaction>(Database.Transactions.Where(tr => !tr.IsRevised));
        }

        public List<Transaction> FindByType(TransactionType transactionType)
        {
            return new List<Transaction>(Database.Transactions.Where(tr => tr.TransactionType == transactionType));
        }

        public List<Transaction> FindByDateTypeAndRevisionStatus(DateTime startDate, DateTime endDate, TransactionType transactionType, bool isRevised)
        {
            return new List<Transaction>(Database.Transactions
                .Where(tr => tr.Date >= startDate && tr.Date <= endDate && tr.TransactionType == transactionType && tr.IsRevised == isRevised));
        }

        protected abstract Transaction InsertTransaction();

        protected abstract void InsertRevenueStreamTransactionRelation(RevenueStream revenueStream, Transaction transaction);

        protected abstract bool IsUserAuthorized();

        protected abstract void UpdateProductsQuantities(List<TransactionProduct> products, bool isRollBack);

        private List<TransactionProduct> FindAllRelatedProductTransactions(Transaction transaction)
        {
            return new List<TransactionProduct>(Database.TransactionProducts.Where(tp => tp.Transaction.Id == transaction.Id));
        }

        private void InsertProductTransactionRelation(List<TransactionProduct> products, Transaction transaction)
        {
            foreach (var p in products)
            {
                p.Transaction = transaction;
            }
            Database.TransactionProducts.AddRange(products);
        }
    }
}
