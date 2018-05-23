using SimpleWarehouse.Constants;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Presenter;
using SimpleWarehouse.Services.ProductSectionManagers;
using SimpleWarehouse.Services.RevenueRelated;
using SimpleWarehouse.Services.TransactionServices;
using SimpleWarehouse.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWarehouse.Services.RevisionRelated
{
    public class RevisionSection : IRevisionSection
    {
        private IHomeView Form { get; set; }
        private IMySqlManager SqlManager { get; set; }
        private ISession<IUser> LoggedUserSession { get; set; }

        public IRevisionGridViewManager GridViewManager { get; set; }
        public IProductsRepositoryManager ProductsRepository { get; set; }
        public ITransactionDbManager DeliveryTransactionDbManager { get; set; }
        public ITransactionDbManager SaleTransactioDbManager { get; set; }
        public IRevenueStreamDbManager RevenueStreamDbManager { get; set; }
        public IRevenueStreamDbManager ExpenseStreamDbManager { get; set; }

        public RevisionSection(HomePresenter presenter)
        {
            this.Form = presenter.Form;
            this.SqlManager = presenter.GetStateManager().SqlManager;
            this.LoggedUserSession = presenter.GetStateManager().UserSession;

            this.GridViewManager = new RevisionGridViewManager(presenter.Form.RevisionDataTable, this.Form, this);
            this.ProductsRepository = new ProductRepositoryManager(this.SqlManager);
            this.DeliveryTransactionDbManager = new DeliveryTransactionDbManager(this.SqlManager, this.LoggedUserSession.SessionEntity);
            this.SaleTransactioDbManager = new SalesTransactionDbManager(this.SqlManager, this.LoggedUserSession.SessionEntity);
            this.RevenueStreamDbManager = new RevenueDbManager(this.SqlManager);
            this.ExpenseStreamDbManager = new ExpensesDbManager(this.SqlManager);

        }

        public void CancelOperation()
        {
            this.ClearTextBoxValues();
            this.GridViewManager.ClearRows();
        }

        public void CommitRevisionAction()
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            this.GridViewManager.Initialize();
            this.GridViewManager.ClearRows();

        }

        public void RefreshGridAction()
        {
            throw new NotImplementedException();
        }

        public void UpdateTotalPriceAction(int rowId)
        {
            throw new NotImplementedException();
        }

        public void BeginRevision()
        {
            if (!this.VerifyUserRole())
                return;
            this.GridViewManager.ClearRows();
            this.GridViewManager.InsertProducts(this.ProductsRepository.FindAll().Where(p => p.IsVisible).ToList());
            this.FillRevenueStreamInfo();
        }

        //PRIVATE METHODS
        private bool VerifyUserRole()
        {
            if (!Roles.IsRequredRoleMet(this.LoggedUserSession.SessionEntity.Role, Config.USER_TYPICAL_ROLE))
            {
                this.Form.Log("Нямате права за тази операция!");
                return false;
            }
            return true;
        }

        private void FillRevenueStreamInfo()
        {
            List<RevenueStream> expenses = this.ExpenseStreamDbManager.FindAllNonRevisedEntities();
            List<RevenueStream> revenues = this.RevenueStreamDbManager.FindAllNonRevisedEntities();
            double expensesTotal = expenses.Sum(e => e.RevenueAmount);
            double revenuesTotal = revenues.Sum(e => e.RevenueAmount);
            List<RevenueStream> merged = new List<RevenueStream>();
            merged.AddRange(expenses);
            merged.AddRange(revenues);
            DateTime startDate = DateTime.Now;
            var oldestRevenueStream = merged.OrderBy(e => e.Date.Year).ThenBy(e => e.Date.Month).ThenBy(e => e.Date.Day).FirstOrDefault();
            if (oldestRevenueStream != null)
                startDate = oldestRevenueStream.Date;

            //inserting the data
            var exp  = $"{expensesTotal:F2}";
            var rev = $"{revenuesTotal:F2}";
            var stDate  = $"Начална дата: {startDate.ToString("dd-MM-yyyy")}";
            var subTot  = "0";
            var salesRev = "0";
            this.InsertTextBoxValues(exp, rev, stDate, subTot, salesRev);
        }

        private void ClearTextBoxValues()
        {
            this.InsertTextBoxValues(null, null, "Начална дата:", null, null);
        }

        private void InsertTextBoxValues(string expenses, string revenues, string startDate, string subTotal, string salesRevenue)
        {
            this.Form.RevisionExpenses = expenses;
            this.Form.RevisionRevenue = revenues;
            this.Form.RevisionStartDate = startDate;
            this.Form.RevisionSubTotal = subTotal;
            this.Form.RevisionSalesRevenue = salesRevenue;
        }
    }
}
