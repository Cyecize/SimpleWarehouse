using SimpleWarehouse.Interfaces;
using SimpleWarehouse.IO;
using SimpleWarehouse.Model;
using SimpleWarehouse.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Services.RevenueRelated
{
    class InvoiceDbManager : IInvoiceDbManager
    {
        private const string INVOICE_TABLE_NAME = "SELECT * FROM invoices_users_joined ";

        private IMySqlManager SqlManager;
        private IEntityRepository<Invoice> InvoiceRepo;

        public InvoiceDbManager(IMySqlManager sqlManager)
        {
            this.SqlManager = sqlManager;
            this.InvoiceRepo = new EntityRepo<Invoice>(sqlManager, new ConsoleWriter());
        }

        public void CreateInvoice(Invoice invoice)
        {
            string query = $"INSERT INTO invoices VALUES (null, {invoice.UserId}, {invoice.RevenueAmount}, '{invoice.Date.ToString("yyyy-MM-dd hh:mm:ss")}', '{this.SqlManager.EscapeString(invoice.Comment)}')";
            this.SqlManager.ExecuteQuery(query);
        }


        public List<Invoice> FindInvoicesByDate(DateTime startDate, DateTime endDate)
        {
            string query = $"{INVOICE_TABLE_NAME} AS r WHERE r.date >= '{startDate.ToString("yyyy-MM-dd")}' AND r.date <= '{endDate.ToString("yyyy-MM-dd")}' ORDER BY r.date ASC;";
            return this.InvoiceRepo.FindManyByQuery(query);
        }
    }
}
