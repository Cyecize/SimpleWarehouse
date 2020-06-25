using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using SimpleWarehouse.Constants;
using SimpleWarehouse.Model;

namespace SimpleWarehouse.Services.Revenues
{
    public class RevenueStreamViewManager : IRevenueStreamViewManager
    {
        private readonly string _comment;
        private readonly string _date;
        private readonly string _isRevised;
        private readonly string _revenueAmount;
        private readonly string _username;

        public RevenueStreamViewManager(DataGridView dataGridView, Dictionary<string, string> tableNames)
        {
            _username = tableNames[RevenueDataTableNames.USERNAME];
            _revenueAmount = tableNames[RevenueDataTableNames.REVENUE_AMOUNT];
            _date = tableNames[RevenueDataTableNames.DATE];
            _isRevised = tableNames[RevenueDataTableNames.IS_REVISED];
            _comment = tableNames[RevenueDataTableNames.COMMENT];

            ViewTable = dataGridView;
            Table = new DataTable();
            Table.Columns.Add(_username);
            Table.Columns.Add(_revenueAmount);
            Table.Columns.Add(_date);
            Table.Columns.Add(_isRevised);
            Table.Columns.Add(_comment);
        }

        private DataTable Table { get; }
        private DataGridView ViewTable { get; }

        public void DisplayRevenues(List<RevenueStream> revenues)
        {
            ViewTable.Rows.Clear();
            foreach (var rev in revenues) AddRow(rev);
            ViewTable.ClearSelection();
        }

        //private logic 

        private void AddRow(RevenueStream revenue)
        {
            if (revenue == null)
                return;
            var rowId = ViewTable.Rows.Add();
            ViewTable.CurrentCell = ViewTable.Rows[rowId].Cells[0];
            ViewTable.Rows[rowId].Cells[_username].Value = revenue.User.Username;
            ViewTable.Rows[rowId].Cells[_revenueAmount].Value = revenue.RevenueAmount;
            ViewTable.Rows[rowId].Cells[_date].Value = revenue.Date;
            ViewTable.Rows[rowId].Cells[_isRevised].Value = revenue.IsRevised;
            ViewTable.Rows[rowId].Cells[_comment].Value = revenue.Comment;
        }
    }
}