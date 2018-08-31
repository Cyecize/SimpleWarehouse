using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Sections.Revisions;
using static SimpleWarehouse.Constants.RevisionDataGridViewColNames;

namespace SimpleWarehouse.Services.Revisions
{
    public class RevisionViewService : IRevisionViewService
    {
        private const string WrongInfoOnRow = "Грешна информация на ред ";

        private IRevisionSection RevisionSection { get; set; }
        private IView Form { get; set; }

        public DataGridView DataGrid { get; set; }
        public object RevisionDataGridColNames { get; private set; }

        public RevisionViewService(DataGridView dataGridView, IView form, IRevisionSection revisionSection)
        {
            this.DataGrid = dataGridView;
            this.Form = form;
            this.RevisionSection = revisionSection;
        }

        public void ClearRows()
        {
            this.DataGrid.Rows.Clear();
        }

        public void EndEdit()
        {
            this.DataGrid.EndEdit();
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
                                                  HeaderText = @"Код на продукт",
                                                  Width = 70,
                                                  Name = ProductId,
                                                  ReadOnly = true
                                              },
                                          new DataGridViewTextBoxColumn
                                              {
                                                  ValueType = typeof (string),
                                                  HeaderText = @"Категория",
                                                  Name = CategoryName,
                                                  Width= 100,
                                                  ReadOnly = true,
                                              },
                                          new DataGridViewTextBoxColumn
                                              {
                                                  ValueType = typeof (string),
                                                  HeaderText = @"Продукт",
                                                  AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                                                  Name = ProductName,
                                                  ReadOnly = true,
                                              },
                                           new DataGridViewTextBoxColumn
                                              {
                                                  ValueType = typeof (double),
                                                  HeaderText = @"Наличен брой",
                                                  Width = 80,
                                                  AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                                                  Name = ActualQuantity

                                              },
                                           new DataGridViewTextBoxColumn
                                              {
                                                  ValueType = typeof (double),
                                                  HeaderText = @"Наличен брой в базата",
                                                  Width = 100,
                                                  AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                                                  ReadOnly = true,
                                                  Name = AvailableQuantity

                                              },

                                          new DataGridViewTextBoxColumn
                                              {
                                                  ValueType = typeof (string),
                                                  HeaderText = @"Цена",
                                                  Width = 80,
                                                  AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                                                  ReadOnly = true,
                                                  Name = SellPrice
                                              },

                                           new DataGridViewTextBoxColumn
                                              {
                                                  ValueType = typeof (double),
                                                  HeaderText = @"Общо",
                                                  Width = 80,
                                                  AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                                                  ReadOnly = true,
                                                  Name = SubTotal
                                              }

                                      });
            this.DataGrid.DataError += this.grid_DataError;
            this.DataGrid.AllowUserToAddRows = false;
            this.DataGrid.CellValueChanged += this.OnColumnValueChange;
        }

        public void InsertProducts(List<Product> products)
        {
            foreach (var prod in products)
            {
                this.AddProduct(prod);
            }
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

        //private methods

        private void AddProduct(Product product)
        {
            var row = this.AddRow();
            row.Cells[ProductId].Value = product.Id;
            row.Cells[CategoryName].Value = product.Category.CategoryName;
            row.Cells[ProductName].Value = product.ProductName;
            row.Cells[AvailableQuantity].Value = product.Quantity;
            row.Cells[SellPrice].Value = $"{product.SellPrice:F2}";
            row.Cells[ActualQuantity].Value = -1.0;
        }

        private DataGridViewRow AddRow()
        {
            var rowId = this.DataGrid.Rows.Add();
            return this.DataGrid.Rows[rowId];
        }

        private void grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
            this.Form.Log($"{WrongInfoOnRow} {e.RowIndex + 1}");
        }

        //events
        private void OnColumnValueChange(object sender, DataGridViewCellEventArgs e)
        {
            var row = this.DataGrid.Rows[e.RowIndex];
            if (this.DataGrid.Columns[e.ColumnIndex].Name == ActualQuantity)
                this.RevisionSection.UpdateTotalPriceAction(e.RowIndex);
        }
    }
}
