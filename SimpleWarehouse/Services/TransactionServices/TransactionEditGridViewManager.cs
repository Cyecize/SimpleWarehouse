using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWarehouse.Services.TransactionServices
{
    public class TransactionEditGridViewManager : ITransactionEditGridViewManager
    {
        private const string TRANSACTION_ID = "TransactionId";

        private const string TRANSACTION_TYPE = "TransactionType";

        private const string TRANSACTION_DATE = "TransactionDate";

        private const string TRANSACTION_IS_REVISED = "TransactionIsRevised";

        private const string TRANSACTION_REVENUE = "TransactionRevenue";

        private const string TRANSACTION_USER = "TransactionUsername";

        private const string TRANSACTION_DELETE_BTN = "TransactionDeleteBtn";

        private EditTransactionSection EditTransactionSection { get; set; }

        private IView Form { get; set; }

        public DataGridView DataGrid { get; set; }

        public TransactionEditGridViewManager(DataGridView dataGrid, IView form, EditTransactionSection editTransactionSection)
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
            row.Cells[TRANSACTION_ID].Value = transaction.Id;
            row.Cells[TRANSACTION_TYPE].Value = transaction.TransactionType;
            row.Cells[TRANSACTION_DATE].Value = transaction.Date;
            row.Cells[TRANSACTION_USER].Value = transaction.Username;
            row.Cells[TRANSACTION_IS_REVISED].Value = transaction.IsRevised;
            row.Cells[TRANSACTION_REVENUE].Value = transaction.RevenueAmount;
            row.Cells[TRANSACTION_REVENUE].Value = transaction.RevenueAmount;
            row.Cells[TRANSACTION_DELETE_BTN].Value = "Х";
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
                                                  HeaderText = "No.",
                                                  Width = 30,
                                                  Name = TRANSACTION_ID,
                                                   ReadOnly = true
                                          },
                                           new DataGridViewTextBoxColumn
                                              {
                                                  ValueType = typeof (DateTime),
                                                  HeaderText = "Потребител",
                                                  Name = TRANSACTION_USER,
                                                  Width = 130
                                              },
                                          new DataGridViewTextBoxColumn
                                              {
                                                  ValueType = typeof (string),
                                                  HeaderText = "Вид транзакция",
                                                  Name = TRANSACTION_TYPE,
                                                  Width = 120
                                              },
                                           new DataGridViewTextBoxColumn
                                              {
                                                  ValueType = typeof (DateTime),
                                                  HeaderText = "Дата",
                                                  Name = TRANSACTION_DATE,
                                                  AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                                              },

                                              new DataGridViewTextBoxColumn
                                              {
                                                  ValueType = typeof (DateTime),
                                                  HeaderText = "Сума",
                                                  Name = TRANSACTION_REVENUE,
                                                  AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                                              },
                                              new DataGridViewButtonColumn
                                              {
                                                  HeaderText = "Изтриване",
                                                  Name = TRANSACTION_DELETE_BTN,
                                                  Width = 100
                                              },
                                                new DataGridViewTextBoxColumn
                                              {
                                                  ValueType = typeof (DateTime),
                                                  HeaderText = "Ревизиран",
                                                  Name = TRANSACTION_IS_REVISED,
                                                  Width = 100
                                              },
                                            
                                      });

            this.DataGrid.CellClick += this.OnCellClick;
        }

        //private logic

        private void OnCellClick(Object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.DataGrid.Columns[TRANSACTION_DELETE_BTN].Index && e.RowIndex >= 0)
            {
                this.EditTransactionSection.DeleteTransaction((int)this.DataGrid.Rows[e.RowIndex].Cells[TRANSACTION_ID].Value);
            }
        }
    }
}
