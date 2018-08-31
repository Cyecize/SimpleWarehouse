using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataGridViewTextButton.DataGridViewElements;
using SimpleWarehouse.Constants;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Sections.Operations;

namespace SimpleWarehouse.Services.Operations
{
    public class OperationViewService : IOperationsViewService
    {
        private const string ErrorOnRow = "Грешка на ред ";

        private int Counter { get; set; }
        private ILoggable Loggable { get; set; }

        public TabPage TabPage { get; set; }
        public DataGridView DataGrid { get; set; }
        public IOperationsSection OperationSection { get; set; }


        public OperationViewService(TabPage tab, DataGridView dataGridView, ILoggable loggable, IOperationsSection operationSection)
        {
            this.Counter = 0;
            this.TabPage = tab;
            this.DataGrid = dataGridView;
            this.Loggable = loggable;
            this.OperationSection = operationSection;
        }

        public void ClearRows()
        {
            this.DataGrid.Rows.Clear();
            this.Counter = 0;
        }

        public void SetDataAtRow(int rowId, string cellName, object value)
        {
            this.DataGrid.Rows[rowId].Cells[cellName].Value = value; 
        }

        public void Initialize()
        {
            this.DataGrid.Columns.AddRange(new DataGridViewColumn[]
                                      {
                                          new DataGridViewTextBoxColumn
                                              {
                                                  ValueType = typeof (int),
                                                  HeaderText = @"No.",
                                                  Width = 30,
                                                  Name = TransactionDataTableNames.TransactionNumber
                                              },
                                          new DataGridViewTextButtonColumn
                                              {
                                                  ValueType = typeof (string),
                                                  HeaderText = @"Продукт",
                                                  ButtonClickHandler = this.OnBtnClick,
                                                  Name = TransactionDataTableNames.ProductName,
                                                  AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                                              },
                                          new DataGridViewTextBoxColumn
                                              {
                                                  ValueType = typeof (double),
                                                  HeaderText = @"Количесто",
                                                  Width = 100,
                                                  AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                                                  Name = TransactionDataTableNames.ProductQuantity,
                                              },
                                           new DataGridViewTextBoxColumn
                                              {
                                                  ValueType = typeof (double),
                                                  HeaderText = @"Наличен брой",
                                                  Width = 100,
                                                  AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                                                  ReadOnly = true,
                                                  Name = TransactionDataTableNames.ProductAvailableQuantity

                                              },

                                          new DataGridViewTextBoxColumn
                                              {
                                                  ValueType = typeof (double),
                                                  HeaderText = @"Доставна цена",
                                                  Width = 100,
                                                  AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                                                  ReadOnly = true,
                                                  Name = TransactionDataTableNames.ProductImportPrice
                                              },
                                          new DataGridViewTextBoxColumn
                                              {
                                                  ValueType = typeof (double),
                                                  HeaderText = @"Продажна цена",
                                                  Width = 100,
                                                  AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                                                  ReadOnly = true,
                                                  Name = TransactionDataTableNames.ProductSellPrice
                                              },
                                           new DataGridViewTextBoxColumn
                                              {
                                                  ValueType = typeof (double),
                                                  HeaderText = @"Общо",
                                                  Width = 100,
                                                  AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                                                  ReadOnly = true,
                                                  Name = TransactionDataTableNames.TransactionTotalValue
                                              },
                                           new DataGridViewTextBoxColumn
                                           {
                                               ValueType = typeof(int),
                                               Visible = false,
                                               Name = TransactionDataTableNames.ProductId
                                           }

                                      });
            this.DataGrid.DefaultValuesNeeded += this.dataGridView1_DefaultValuesNeeded;
            this.DataGrid.DataError += this.grid_DataError;
            this.DataGrid.CellValueChanged += this.OnColumnValueChange;
            this.DataGrid.CellClick += (o, e) => this.OperationSection.RefreshGridAction();
        }

        public void AddSelectedProduct(DataGridViewRow row, Product product)
        {
            row.Cells[TransactionDataTableNames.ProductName].Value = product.ProductName;
            row.Cells[TransactionDataTableNames.ProductImportPrice].Value = product.ImportPrice;
            row.Cells[TransactionDataTableNames.ProductSellPrice].Value = product.SellPrice;
            row.Cells[TransactionDataTableNames.ProductAvailableQuantity].Value = product.Quantity;
            row.Cells[TransactionDataTableNames.ProductId].Value = product.Id;
            this.DataGrid.EndEdit();
        }

        public int GetRowsCount()
        {
            return this.DataGrid.RowCount;
        }

        public object GetDataAtRow(int rowId, string cellName)
        {
            return this.DataGrid.Rows[rowId].Cells[cellName].Value;
        }

        public DataGridViewRow GetCurrentRow()
        {
            return this.DataGrid.CurrentRow;
        }

        public List<int> GetAllProductIds()
        {
            List<int> res = new List<int>();
            for (int i = 0; i < this.DataGrid.RowCount; i++)
            {
                var row = this.DataGrid.Rows[i];
                object prodId = row.Cells[TransactionDataTableNames.ProductId].Value;
                if (prodId != null)
                    res.Add((int)prodId);
            }
            return res;
        }

        public double RefreshGrid()
        {
            double total = 0.0;
            for (int i = 0; i < this.DataGrid.Rows.Count; i++)
            {
                this.OperationSection.UpdateTotalPriceAction(i);
                var row = this.DataGrid.Rows[i];
                try
                {
                    total += double.Parse(row.Cells[TransactionDataTableNames.TransactionTotalValue].Value.ToString());
                }
                catch (Exception) { }
            }
            this.DataGrid.EndEdit();
            return total;
        }

        //private logic 

        //events
        private void OnBtnClick(object sender, EventArgs e)
        {
            this.OperationSection.PickAProductRequest();
        }

        private void dataGridView1_DefaultValuesNeeded(object sender, System.Windows.Forms.DataGridViewRowEventArgs e)
        {
            this.Counter++;
            e.Row.Cells[TransactionDataTableNames.ProductQuantity].Value = 0;
            var row = e.Row;
            if (row.Cells[TransactionDataTableNames.TransactionNumber].Value == null)
                e.Row.Cells[TransactionDataTableNames.TransactionNumber].Value = this.Counter;
        }

        private void grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
            this.Loggable.Log(ErrorOnRow + (e.RowIndex + 1));
        }

        private void OnColumnValueChange(Object sender, DataGridViewCellEventArgs e)
        {
            var row = this.DataGrid.Rows[e.RowIndex];
            if (this.DataGrid.Columns[e.ColumnIndex].Name == TransactionDataTableNames.ProductQuantity)
                this.OperationSection.UpdateTotalPriceAction(e.RowIndex);
        }
    }
}
