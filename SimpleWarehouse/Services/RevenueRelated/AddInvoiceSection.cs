using SimpleWarehouse.Constants;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Presenter.RevenueRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Services.RevenueRelated
{
    public class AddInvoiceSection : IAddEntitySection
    {
        private InvoicesPresenter Presenter { get; set; }
        public IInvoiceDbManager InvoiceDbManager { get; set; }
        public IInvoiceViewManager InvoiceViewManager { get; set; }

        public AddInvoiceSection(InvoicesPresenter presenter)
        {
            this.Presenter = presenter;
            this.InvoiceDbManager = new InvoiceDbManager(presenter.GetStateManager().SqlManager);
            this.InvoiceViewManager = new InvoiceViewManager(this.Presenter.Form.NotRevisedDataTable, RevenueDataTableNames.GetNamesForAddRevenue());
        }


        public void AddEntityAction()
        {
            DateTime revenueDate = this.Presenter.Form.NewEntityDate;
            double amount = this.Presenter.Form.NewEntityAmount;
            string comment = this.Presenter.Form.CommentText;
            Invoice invoice = new Invoice()
            {
                Date = revenueDate,
                RevenueAmount = amount,
                UserId = this.Presenter.GetStateManager().UserSession.SessionEntity.Id,
                Comment = comment,
            };
            if (invoice.RevenueAmount <= 0)
            {
                this.Presenter.Form.Log("Невалидна стойност!");
                return;
            }
            try
            {
                this.InvoiceDbManager.CreateInvoice(invoice);
                this.UpdateNonRevisedEntities();
                this.Presenter.Form.NewEntityAmount = 0;
            }
            catch (ArgumentException e)
            {
                this.Presenter.Form.Log(e.Message);
            }
        }

        public void UpdateNonRevisedEntities()
        {
            var today = DateTime.Now;
            var startOfTheMonth = new DateTime(today.Year, today.Month, 1);
            List<Invoice> invoices = this.InvoiceDbManager.FindInvoicesByDate(startOfTheMonth, today.AddDays(1));
            this.InvoiceViewManager.DisplayInvoices(invoices);
        }
    }
}
