using SimpleWarehouse.Constants;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.IO;
using SimpleWarehouse.Model;
using SimpleWarehouse.Service;
using SimpleWarehouse.Services.ProductSectionManagers;
using SimpleWarehouse.Services.RevenueRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Services.TransactionServices
{
    public abstract class AbstractTransactionDbManager : ITransactionDbManager
    {
        private const string TRANSACTIONS_TABLE_NAME = "transactions";

        protected IUser LoggedUser { get; set; }
        protected IMySqlManager SqlManager { get; set; }
        protected IRevenueStreamDbManager RevenueManager { get; set; }
        protected IRevenueStreamDbManager ExpenseManager { get; set; }
        protected IEntityRepository<Transaction> TransactionRepository { get; set; }
        protected IProductsRepositoryManager ProductsRepositoryManager { get; set; }

        protected AbstractTransactionDbManager(IMySqlManager sqlManager, IUser loggedUser)
        {
            this.RevenueManager = new RevenueDbManager(sqlManager);
            this.ExpenseManager = new ExpensesDbManager(sqlManager);
            this.TransactionRepository = new EntityRepo<Transaction>(sqlManager, new ConsoleWriter());
            this.LoggedUser = loggedUser;
            this.SqlManager = sqlManager;
            this.ProductsRepositoryManager = new ProductRepositoryManager(this.SqlManager); ;
        }

        public void AddTransaction(List<ProductTransaction> products)
        {
            if (!this.IsUserAuthorized())
                throw new ArgumentException("Нямате права за тази операция");
            Transaction transaction = this.TransactionRepository.FindOneBy("transactions", "id", this.InsertTransaction());
            this.InsertProductTransactionRelation(products, transaction);
            double totalRevenueAmount = products.Sum(p => p.SubTotalPrice);
            RevenueStream revenueStream = new RevenueStream
            {
                Date = DateTime.Now,
                IsRevised = false,
                RevenueAmount = totalRevenueAmount,
                UserId = this.LoggedUser.Id
            };
            revenueStream = this.InsertRevenueStream(revenueStream);
            this.InsertRevenueStreamTransactionRelation(revenueStream, transaction);
            this.UpdateProductsQuantities(products, false);
        }

        public Transaction FindOneById(int id)
        {
            return this.TransactionRepository.FindOneBy(TRANSACTIONS_TABLE_NAME, "id", id);
        }

        public List<Transaction> FindAllRevised()
        {
            return this.FindByRevisedStatus(true);
        }

        public List<Transaction> FindAllNonRevised()
        {
            return this.FindByRevisedStatus(false);
        }

        public List<Transaction> FindByType(TransactionTypes transactionType)
        {
            Console.WriteLine(transactionType.ToString());
            throw new NotImplementedException();
        }

        public void RollBack(int transactionId)
        {
            throw new NotImplementedException();
        }

        public void RollBack(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        protected abstract RevenueStream InsertRevenueStream(RevenueStream revenueStream);
        protected abstract int InsertTransaction();
        protected abstract void InsertRevenueStreamTransactionRelation(RevenueStream revenueStream, Transaction transaction);
        protected abstract bool IsUserAuthorized();
        protected abstract void UpdateProductsQuantities(List<ProductTransaction> products, bool isRollBack);

        private void InsertProductTransactionRelation(List<ProductTransaction> products, Transaction transaction)
        {
            foreach (var p in products)
            {
                string query = $"INSERT INTO products_transactions VALUES({p.ProductId}, {transaction.Id}, {p.ProductQuantity})";
                this.SqlManager.ExecuteQuery(query);
            }
        }

        private List<Transaction> FindByRevisedStatus(bool isRevised)
        {
            return this.TransactionRepository.FindBy("is_revised", isRevised);
        }

    }
}
