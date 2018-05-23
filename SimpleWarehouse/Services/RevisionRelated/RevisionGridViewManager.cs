using SimpleWarehouse.Constants;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWarehouse.Services.RevisionRelated
{
    public class RevisionGridViewManager : IRevisionGridViewManager
    {
        private IRevisionSection RevisionSection { get; set; }
        private IView Form { get; set; }

        public DataGridView DataGrid { get; set; }
        public object RevisionDataGridColNames { get; private set; }

        public RevisionGridViewManager(DataGridView dataGridView, IView form, IRevisionSection revisionSection)
        {
            this.DataGrid = dataGridView;
            this.Form = form;
            this.RevisionSection = revisionSection;
        }

        public void ClearRows()
        {
            this.DataGrid.Rows.Clear();
        }

        public void Initialize()
        {
            this.DataGrid.Columns.AddRange(new DataGridViewColumn[]
                                      {
                                          new DataGridViewTextBoxColumn
                                              {
                                                  ValueType = typeof (int),
                                                  HeaderText = "Код на продукт",
                                                  Width = 70,
                                                  Name = RevisionDataGridViewColNames.PRODUCT_ID,
                                                  ReadOnly = true
                                              },
                                          new DataGridViewTextBoxColumn
                                              {
                                                  ValueType = typeof (string),
                                                  HeaderText = "Категория",
                                                  Name = RevisionDataGridViewColNames.CATEGORY_NAME,
                                                  Width= 100,
                                                  ReadOnly = true,
                                              },
                                          new DataGridViewTextBoxColumn
                                              {
                                                  ValueType = typeof (string),
                                                  HeaderText = "Продукт",
                                                  AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                                                  Name = RevisionDataGridViewColNames.PRODUCT_NAME,
                                                  ReadOnly = true,
                                              },
                                           new DataGridViewTextBoxColumn
                                              {
                                                  ValueType = typeof (double),
                                                  HeaderText = "Наличен брой",
                                                  Width = 80,
                                                  AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                                                  Name = RevisionDataGridViewColNames.ACTUAL_QUANTITY

                                              },
                                           new DataGridViewTextBoxColumn
                                              {
                                                  ValueType = typeof (double),
                                                  HeaderText = "Наличен брой в базата",
                                                  Width = 100,
                                                  AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                                                  ReadOnly = true,
                                                  Name = RevisionDataGridViewColNames.AVAILABLE_QUANTITY

                                              },

                                          new DataGridViewTextBoxColumn
                                              {
                                                  ValueType = typeof (double),
                                                  HeaderText = "Цена",
                                                  Width = 80,
                                                  AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                                                  ReadOnly = true,
                                                  Name = RevisionDataGridViewColNames.SELL_PRICE
                                              },

                                           new DataGridViewTextBoxColumn
                                              {
                                                  ValueType = typeof (double),
                                                  HeaderText = "Общо",
                                                  Width = 80,
                                                  AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                                                  ReadOnly = true,
                                                  Name = RevisionDataGridViewColNames.SUB_TOTAL
                                              }

                                      });
            this.DataGrid.DataError += this.grid_DataError;
            this.DataGrid.AllowUserToAddRows = false;
        }

        public void InsertProducts(List<Product> products)
        {
            foreach (var prod in products)
            {
                this.AddProduct(prod);
            }
        }

        //private methods

        private void AddProduct(Product product)
        {
            var row = this.AddRow();
            row.Cells[RevisionDataGridViewColNames.PRODUCT_ID].Value = product.Id;
            row.Cells[RevisionDataGridViewColNames.CATEGORY_NAME].Value = product.CategoryName;
            row.Cells[RevisionDataGridViewColNames.PRODUCT_NAME].Value = product.ProductName;
            row.Cells[RevisionDataGridViewColNames.AVAILABLE_QUANTITY].Value = product.Quantity;
            row.Cells[RevisionDataGridViewColNames.SELL_PRICE].Value = $"{product.SellPrice:F2}";
            row.Cells[RevisionDataGridViewColNames.ACTUAL_QUANTITY].Value = -1;
        }

        private DataGridViewRow AddRow()
        {
            var rowid =this.DataGrid.Rows.Add();
            return this.DataGrid.Rows[rowid];
        }

        private void grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
            this.Form.Log($"Грешна информация на ред {e.RowIndex + 1}");
        }
    }
}
