using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private EditTransactionSection EditTransactionSection { get; set; }

        private IView Form { get; set; }

        public DataGridView DataGrid { get; set; }

        public TransactionViewService(DataGridView dataGrid, IView form, EditTransactionSection editTransactionSection)
        {
            this.DataGrid = dataGrid;
            this.Form = form;
            this.EditTransactionSection = editTransactionSection;
            this.Initialize();
        }

        public void ClearRows()
        {
            this.DataGrid.Rows.Clear();
        }

        public void InsertTransaction(Transaction transaction)
        {
            int rowId = this.DataGrid.Rows.Add();
            var row = this.DataGrid.Rows[rowId];
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
            this.DataGrid.ReadOnly = true;
            this.DataGrid.AllowUserToAddRows = false;
            this.DataGrid.Columns.AddRange(new DataGridViewColumn[]
                                      {
                                          new DataGridViewTextBoxColumn{
                                                  ValueType = typeof (int),
                                                  HeaderText = @"No.",
                                                  Width = 30,
                                                  Name = TransactionId,
                                                   ReadOnly = true
                                          },
                                           new DataGridViewTextBoxColumn
                                              {
                                                  ValueType = typeof (DateTime),
                                                  HeaderText = @"Потребител",
                                                  Name = TransactionUser,
                                                  Width = 130
                                              },
                                          new DataGridViewTextBoxColumn
                                              {
                                                  ValueType = typeof (string),
                                                  HeaderText = @"Вид транзакция",
                                                  Name = TransactionType,
                                                  Width = 120
                                              },
                                           new DataGridViewTextBoxColumn
                                              {
                                                  ValueType = typeof (DateTime),
                                                  HeaderText = @"Дата",
                                                  Name = TransactionDate,
                                                  AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                                              },

                                              new DataGridViewTextBoxColumn
                                              {
                                                  ValueType = typeof (DateTime),
                                                  HeaderText = @"Сума",
                                                  Name = TransactionRevenue,
                                                  AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                                              },
                                              new DataGridViewButtonColumn
                                              {
                                                  HeaderText = @"Изтриване",
                                                  Name = TransactionDeleteBtn,
                                                  Width = 100
                                              },
                                                new DataGridViewButtonColumn
                                              {
                                                  HeaderText = @"Детайли",
                                                  Name = TransactionDetailsBtn,
                                              },
                                                new DataGridViewTextBoxColumn
                                              {
                                                  ValueType = typeof (DateTime),
                                                  HeaderText = @"Ревизиран",
                                                  Name = TransactionIsRevised,
                                                  Width = 100
                                              },

                                      });

            this.DataGrid.CellClick += this.OnCellClick;
        }

        //private logic

        private void OnCellClick(Object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.DataGrid.Columns[TransactionDeleteBtn].Index && e.RowIndex >= 0)
            {
                this.EditTransactionSection.DeleteTransaction((int)this.DataGrid.Rows[e.RowIndex].Cells[TransactionId].Value);
            }
        }
    }
}
