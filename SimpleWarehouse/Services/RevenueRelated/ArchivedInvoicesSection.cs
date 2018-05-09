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
    class ArchivedInvoicesSection : IArchivedEntitiesSection
    {

        public InvoicesPresenter Presenter { get; set; }
        public IInvoiceViewManager ViewManager { get; set; }
        public IInvoiceDbManager DbManager { get; set; }

        public ArchivedInvoicesSection(InvoicesPresenter presenter)
        {
            this.Presenter = presenter;
            this.ViewManager = new InvoiceViewManager(this.Presenter.Form.ArchiveDataTable, RevenueDataTableNames.GetNamesForArchivedRevenues());
            this.DbManager = new InvoiceDbManager(presenter.GetStateManager().SqlManager);
        }

        public void DisplayArchivedEntities()
        {
            var start = this.Presenter.Form.ArchivedEntitiesStartDate;
            var end = this.Presenter.Form.ArchivedEntitiesEndDate;
            List<Invoice> invoices = this.DbManager.FindInvoicesByDate(start, end);
            this.ViewManager.DisplayInvoices(invoices);
            this.Presenter.Form.TotalArchivedEntitiesRows = $"{invoices.Count}";
            this.Presenter.Form.TotalArchivedEntitiesPrice = $"{invoices.Sum((x) => x.RevenueAmount):F2}";
        }
    }
}
