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
    public class RevenueViewManager : IRevenueViewManager
    {
        private string USERNAME = "Username";
        private string REVENUE_AMOUNT = "Amount";
        private string DATE = "Date";
        private string IS_REVISED = "IsRevised";

        private DataTable Table;
        private DataGridView ViewTable;

        public RevenueViewManager(DataGridView dataGridView, Dictionary<string,string> tableNames)
        {
            USERNAME = tableNames[RevenueDataTableNames.USERNAME];
            REVENUE_AMOUNT = tableNames[RevenueDataTableNames.REVENUE_AMOUNT];
            DATE = tableNames[RevenueDataTableNames.DATE];
            IS_REVISED = tableNames[RevenueDataTableNames.IS_REVISED];

            this.ViewTable = dataGridView;
            this.Table = new DataTable();
            this.Table.Columns.Add(USERNAME);
            this.Table.Columns.Add(REVENUE_AMOUNT);
            this.Table.Columns.Add(DATE);
            this.Table.Columns.Add(IS_REVISED);
        }

        public void DisplayRevenues(List<Revenue> revenues)
        {
            this.ViewTable.Rows.Clear();
            foreach (var rev in revenues)
            {
                this.AddRow(rev);
            }
            this.ViewTable.ClearSelection();
        }

        //private logic 

        private void AddRow(Revenue revenue)
        {
            int rowId = this.ViewTable.Rows.Add();
            this.ViewTable.CurrentCell = this.ViewTable.Rows[rowId].Cells[0];
            this.ViewTable.Rows[rowId].Cells[USERNAME].Value = revenue.Username;
            this.ViewTable.Rows[rowId].Cells[REVENUE_AMOUNT].Value = revenue.RevenueAmount;
            this.ViewTable.Rows[rowId].Cells[DATE].Value = revenue.Date;
            this.ViewTable.Rows[rowId].Cells[IS_REVISED].Value = revenue.IsRevised;

        }
    }
}
