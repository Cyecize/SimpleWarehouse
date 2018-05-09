using SimpleWarehouse.Constants;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWarehouse.Services.RevenueRelated
{
    public class InvoiceViewManager : IInvoiceViewManager
    {
        private string USERNAME = "Username";
        private string REVENUE_AMOUNT = "Amount";
        private string DATE = "Date";

        private DataTable Table;
        private DataGridView ViewTable;

        public InvoiceViewManager(DataGridView dataGridView, Dictionary<string, string> tableNames)
        {
            USERNAME = tableNames[RevenueDataTableNames.USERNAME];
            REVENUE_AMOUNT = tableNames[RevenueDataTableNames.REVENUE_AMOUNT];
            DATE = tableNames[RevenueDataTableNames.DATE];

            this.ViewTable = dataGridView;
            this.Table = new DataTable();
            this.Table.Columns.Add(USERNAME);
            this.Table.Columns.Add(REVENUE_AMOUNT);
            this.Table.Columns.Add(DATE);
        }

        public void DisplayInvoices(List<Invoice> invoices)
        {
            this.ViewTable.Rows.Clear();
            foreach (var inv in invoices)
            {
                this.AddRow(inv);
            }
            this.ViewTable.ClearSelection();
        }

        //private logic 

        private void AddRow(Invoice invoice)
        {
            int rowId = this.ViewTable.Rows.Add();
            this.ViewTable.CurrentCell = this.ViewTable.Rows[rowId].Cells[0];
            this.ViewTable.Rows[rowId].Cells[USERNAME].Value = invoice.Username;
            this.ViewTable.Rows[rowId].Cells[REVENUE_AMOUNT].Value = invoice.RevenueAmount;
            this.ViewTable.Rows[rowId].Cells[DATE].Value = invoice.Date;
        }
    }
}
