using System;
using System.Windows.Forms;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Sections.Transactions;

namespace SimpleWarehouse.Services.Transactions
{
    public class TransactionViewService : ITransactionViewService
    {
        private const string TransactionId = "TransactionId";

        private const string TransactionType = "TransactionType";

        private const string TransactionDate = "TransactionDate";

        private const string TransactionIsRevised = "TransactionIsRevised";

        private const string TransactionRevenue = "TransactionRevenue";

        private const string TransactionUser = "TransactionUsername";

        private const string TransactionDeleteBtn = "TransactionDeleteBtn";

        private const string TransactionDetailsBtn = "TransactionDetailsBtn";

        public TransactionViewService(DataGridView dataGrid, IView form, EditTransactionSection editTransactionSection)
        {
            DataGrid = dataGrid;
            Form = form;
            EditTransactionSection = editTransactionSection;
            Initialize();
        }

        private EditTransactionSection EditTransactionSection { get; }

        private IView Form { get; }

        public DataGridView DataGrid { get; set; }

        public void ClearRows()
        {
            DataGrid.Rows.Clear();
        }

        public void InsertTransaction(Transaction transaction)
        {
            var rowId = DataGrid.Rows.Add();
            var row = DataGrid.Rows[rowId];
            row.ReadOnly = true;
            row.Cells[TransactionId].Value = transaction.Id;
            row.Cells[TransactionType].Value = transaction.TransactionType;
            row.Cells[TransactionDate].Value = transaction.Date;
            row.Cells[TransactionUser].Value = transaction.User?.Username;
            row.Cells[TransactionIsRevised].Value = transaction.IsRevised;
            row.Cells[TransactionRevenue].Value = transaction.RevenueAmount;
            row.Cells[TransactionRevenue].Value = transaction.RevenueAmount;
            row.Cells[TransactionDeleteBtn].Value = "Х";
            row.Cells[TransactionDetailsBtn].Value = "Детайли";
        }

        //PRIVATE LOGIC

        private void Initialize()
        {
            DataGrid.ReadOnly = true;
            DataGrid.AllowUserToAddRows = false;
            DataGrid.Columns.AddRange(new DataGridViewTextBoxColumn
            {
                ValueType = typeof(int),
                HeaderText = @"No.",
                Width = 30,
                Name = TransactionId,
                ReadOnly = true
            }, new DataGridViewTextBoxColumn
            {
                ValueType = typeof(DateTime),
                HeaderText = @"Потребител",
                Name = TransactionUser,
                Width = 130
            }, new DataGridViewTextBoxColumn
            {
                ValueType = typeof(string),
                HeaderText = @"Вид транзакция",
                Name = TransactionType,
                Width = 120
            }, new DataGridViewTextBoxColumn
            {
                ValueType = typeof(DateTime),
                HeaderText = @"Дата",
                Name = TransactionDate,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            }, new DataGridViewTextBoxColumn
            {
                ValueType = typeof(DateTime),
                HeaderText = @"Сума",
                Name = TransactionRevenue,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            }, new DataGridViewButtonColumn
            {
                HeaderText = @"Изтриване",
                Name = TransactionDeleteBtn,
                Width = 100
            }, new DataGridViewButtonColumn
            {
                HeaderText = @"Детайли",
                Name = TransactionDetailsBtn
            }, new DataGridViewTextBoxColumn
            {
                ValueType = typeof(DateTime),
                HeaderText = @"Ревизиран",
                Name = TransactionIsRevised,
                Width = 100
            });

            DataGrid.CellClick += OnCellClick;
        }

        //private logic

        private void OnCellClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRowProductId = (int) DataGrid.Rows[e.RowIndex].Cells[TransactionId].Value;

            if (e.ColumnIndex == DataGrid.Columns[TransactionDeleteBtn].Index && e.RowIndex >= 0)
                EditTransactionSection.DeleteTransaction(selectedRowProductId);
            if (e.ColumnIndex == DataGrid.Columns[TransactionDetailsBtn].Index && e.RowIndex >= 0)
                EditTransactionSection.ShowTransaction(selectedRowProductId);
        }
    }
}