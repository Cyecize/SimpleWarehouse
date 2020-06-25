using System;
using System.Collections.Generic;
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


        public OperationViewService(TabPage tab, DataGridView dataGridView, ILoggable loggable,
            IOperationsSection operationSection)
        {
            Counter = 0;
            TabPage = tab;
            DataGrid = dataGridView;
            Loggable = loggable;
            OperationSection = operationSection;
        }

        private int Counter { get; set; }
        private ILoggable Loggable { get; }

        public TabPage TabPage { get; set; }
        public DataGridView DataGrid { get; set; }
        public IOperationsSection OperationSection { get; set; }

        public void ClearRows()
        {
            DataGrid.Rows.Clear();
            Counter = 0;
        }

        public void SetDataAtRow(int rowId, string cellName, object value)
        {
            DataGrid.Rows[rowId].Cells[cellName].Value = value;
        }

        public void Initialize()
        {
            DataGrid.Columns.AddRange(new DataGridViewTextBoxColumn
            {
                ValueType = typeof(int),
                HeaderText = @"No.",
                Width = 30,
                Name = TransactionDataTableNames.TransactionNumber
            }, new DataGridViewTextButtonColumn
            {
                ValueType = typeof(string),
                HeaderText = @"Продукт",
                ButtonClickHandler = OnBtnClick,
                Name = TransactionDataTableNames.ProductName,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            }, new DataGridViewTextBoxColumn
            {
                ValueType = typeof(double),
                HeaderText = @"Количесто",
                Width = 100,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                Name = TransactionDataTableNames.ProductQuantity
            }, new DataGridViewTextBoxColumn
            {
                ValueType = typeof(double),
                HeaderText = @"Наличен брой",
                Width = 100,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                ReadOnly = true,
                Name = TransactionDataTableNames.ProductAvailableQuantity
            }, new DataGridViewTextBoxColumn
            {
                ValueType = typeof(double),
                HeaderText = @"Доставна цена",
                Width = 100,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                ReadOnly = true,
                Name = TransactionDataTableNames.ProductImportPrice
            }, new DataGridViewTextBoxColumn
            {
                ValueType = typeof(double),
                HeaderText = @"Продажна цена",
                Width = 100,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                ReadOnly = true,
                Name = TransactionDataTableNames.ProductSellPrice
            }, new DataGridViewTextBoxColumn
            {
                ValueType = typeof(double),
                HeaderText = @"Общо",
                Width = 100,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                ReadOnly = true,
                Name = TransactionDataTableNames.TransactionTotalValue
            }, new DataGridViewTextBoxColumn
            {
                ValueType = typeof(int),
                Visible = false,
                Name = TransactionDataTableNames.ProductId
            });
            DataGrid.DefaultValuesNeeded += dataGridView1_DefaultValuesNeeded;
            DataGrid.DataError += grid_DataError;
            DataGrid.CellValueChanged += OnColumnValueChange;
            DataGrid.CellClick += (o, e) => OperationSection.RefreshGridAction();
        }

        public void AddSelectedProduct(DataGridViewRow row, Product product)
        {
            row.Cells[TransactionDataTableNames.ProductName].Value = product.ProductName;
            row.Cells[TransactionDataTableNames.ProductImportPrice].Value = product.ImportPrice;
            row.Cells[TransactionDataTableNames.ProductSellPrice].Value = product.SellPrice;
            row.Cells[TransactionDataTableNames.ProductAvailableQuantity].Value = product.Quantity;
            row.Cells[TransactionDataTableNames.ProductId].Value = product.Id;
            DataGrid.EndEdit();
        }

        public int GetRowsCount()
        {
            return DataGrid.RowCount;
        }

        public object GetDataAtRow(int rowId, string cellName)
        {
            return DataGrid.Rows[rowId].Cells[cellName].Value;
        }

        public DataGridViewRow GetCurrentRow()
        {
            return DataGrid.CurrentRow;
        }

        public List<int> GetAllProductIds()
        {
            var res = new List<int>();
            for (var i = 0; i < DataGrid.RowCount; i++)
            {
                var row = DataGrid.Rows[i];
                var prodId = row.Cells[TransactionDataTableNames.ProductId].Value;
                if (prodId != null)
                    res.Add((int) prodId);
            }

            return res;
        }

        public double RefreshGrid()
        {
            var total = 0.0;
            for (var i = 0; i < DataGrid.Rows.Count; i++)
            {
                OperationSection.UpdateTotalPriceAction(i);
                var row = DataGrid.Rows[i];
                try
                {
                    total += double.Parse(row.Cells[TransactionDataTableNames.TransactionTotalValue].Value.ToString());
                }
                catch (Exception)
                {
                }
            }

            DataGrid.EndEdit();
            return total;
        }

        //private logic 

        //events
        private void OnBtnClick(object sender, EventArgs e)
        {
            OperationSection.PickAProductRequest();
        }

        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            Counter++;
            e.Row.Cells[TransactionDataTableNames.ProductQuantity].Value = 0;
            var row = e.Row;
            if (row.Cells[TransactionDataTableNames.TransactionNumber].Value == null)
                e.Row.Cells[TransactionDataTableNames.TransactionNumber].Value = Counter;
        }

        private void grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
            Loggable.Log(ErrorOnRow + (e.RowIndex + 1));
        }

        private void OnColumnValueChange(object sender, DataGridViewCellEventArgs e)
        {
            var row = DataGrid.Rows[e.RowIndex];
            if (DataGrid.Columns[e.ColumnIndex].Name == TransactionDataTableNames.ProductQuantity)
                OperationSection.UpdateTotalPriceAction(e.RowIndex);
        }
    }
}