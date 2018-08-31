using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleWarehouse.Constants;
using SimpleWarehouse.Model;

namespace SimpleWarehouse.Services.Revenues
{
    public class RevenueStreamViewManager : IRevenueStreamViewManager
    {
        private readonly string _username;
        private readonly string _revenueAmount;
        private readonly string _date;
        private readonly string _isRevised;
        private readonly string _comment;

        private DataTable Table { get; set; }
        private DataGridView ViewTable { get; set; }

        public RevenueStreamViewManager(DataGridView dataGridView, Dictionary<string, string> tableNames)
        {
            _username = tableNames[RevenueDataTableNames.USERNAME];
            _revenueAmount = tableNames[RevenueDataTableNames.REVENUE_AMOUNT];
            _date = tableNames[RevenueDataTableNames.DATE];
            _isRevised = tableNames[RevenueDataTableNames.IS_REVISED];
            _comment = tableNames[RevenueDataTableNames.COMMENT];

            this.ViewTable = dataGridView;
            this.Table = new DataTable();
            this.Table.Columns.Add(_username);
            this.Table.Columns.Add(_revenueAmount);
            this.Table.Columns.Add(_date);
            this.Table.Columns.Add(_isRevised);
            this.Table.Columns.Add(_comment);
        }

        public void DisplayRevenues(List<RevenueStream> revenues)
        {
            this.ViewTable.Rows.Clear();
            foreach (var rev in revenues)
            {
                this.AddRow(rev);
            }
            this.ViewTable.ClearSelection();
        }

        //private logic 

        private void AddRow(RevenueStream revenue)
        {
            if(revenue == null)
                return;
            int rowId = this.ViewTable.Rows.Add();
            this.ViewTable.CurrentCell = this.ViewTable.Rows[rowId].Cells[0];
            this.ViewTable.Rows[rowId].Cells[_username].Value = revenue.User.Username;
            this.ViewTable.Rows[rowId].Cells[_revenueAmount].Value = revenue.RevenueAmount;
            this.ViewTable.Rows[rowId].Cells[_date].Value = revenue.Date;
            this.ViewTable.Rows[rowId].Cells[_isRevised].Value = revenue.IsRevised;
            this.ViewTable.Rows[rowId].Cells[_comment].Value = revenue.Comment;

        }
    }
}
