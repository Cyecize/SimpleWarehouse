using DataGridViewTextButton.DataGridViewElements;
using SimpleWarehouse.Constants;
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
    public class TransactionGridViewManager : ITransactionGridViewManager
    {
        private int COUNTER { get; set; }
        private IView Form { get; set; }

        public TabPage TabPage { get; set; }
        public DataGridView DataGrid { get; set; }
        public ITransactionSection TransactionSection { get; set; }


        public TransactionGridViewManager(TabPage tab, DataGridView dataGridView, IView form, ITransactionSection transactionSection)
        {
            this.COUNTER = 0;
            this.TabPage = tab;
            this.DataGrid = dataGridView;
            this.Form = form;
            this.TransactionSection = transactionSection;
        }


        public void ClearRows()
        {

            this.DataGrid.Rows.Clear();
            this.COUNTER = 0;
        }

        public void Initialize()
        {
            this.DataGrid.Columns.AddRange(new DataGridViewColumn[]
                                      {
                                          new DataGridViewTextBoxColumn
                                              {
                                                  ValueType = typeof (int),
                                                  HeaderText = "No.",
                                                  Width = 30,
                                                  Name = TransactionDataTableNames.TRANSACTION_NUMBER
                                              },
                                          new DataGridViewTextButtonColumn
                                              {
                                                  ValueType = typeof (string),
                                                  HeaderText = "Продукт",
                                                  ButtonClickHandler = this.OnBtnClick,
                                                  Name = TransactionDataTableNames.PRODUCT_NAME,
                                                  AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                                              },
                                          new DataGridViewTextBoxColumn
                                              {
                                                  ValueType = typeof (double),
                                                  HeaderText = "Количесто",
                                                  Width = 100,
                                                  AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                                                  Name = TransactionDataTableNames.PRODUCT_QUANTITY,
                                              },
                                           new DataGridViewTextBoxColumn
                                              {
                                                  ValueType = typeof (double),
                                                  HeaderText = "Наличен брой",
                                                  Width = 100,
                                                  AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                                                  ReadOnly = true,
                                                  Name = TransactionDataTableNames.PRODUCT_AVAILABLE_QUANTITY

                                              },

                                          new DataGridViewTextBoxColumn
                                              {
                                                  ValueType = typeof (double),
                                                  HeaderText = "Доставна цена",
                                                  Width = 100,
                                                  AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                                                  ReadOnly = true,
                                                  Name = TransactionDataTableNames.PRODUCT_IMPORT_PRICE
                                              },
                                          new DataGridViewTextBoxColumn
                                              {
                                                  ValueType = typeof (double),
                                                  HeaderText = "Продажна цена",
                                                  Width = 100,
                                                  AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                                                  ReadOnly = true,
                                                  Name = TransactionDataTableNames.PRODUCT_SELL_PRICE
                                              },
                                           new DataGridViewTextBoxColumn
                                              {
                                                  ValueType = typeof (double),
                                                  HeaderText = "Общо",
                                                  Width = 100,
                                                  AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                                                  ReadOnly = true,
                                                  Name = TransactionDataTableNames.TRANSACTION_TOTAL_VALUE
                                              },
                                           new DataGridViewTextBoxColumn
                                           {
                                               ValueType = typeof(int),
                                               Visible = false,
                                               Name = TransactionDataTableNames.PRODUCT_ID
                                           }

                                      });
            this.DataGrid.DefaultValuesNeeded += this.dataGridView1_DefaultValuesNeeded;
            this.DataGrid.DataError += this.grid_DataError;
            this.DataGrid.CellValueChanged += this.OnColumnValueChange;
            this.DataGrid.CellClick += (o, e) => this.TransactionSection.RefreshGridAction();
        }

        public void AddSelectedProduct(DataGridViewRow row, Product product)
        {
            row.Cells[TransactionDataTableNames.PRODUCT_NAME].Value = product.ProductName;
            row.Cells[TransactionDataTableNames.PRODUCT_IMPORT_PRICE].Value = product.ImportPrice;
            row.Cells[TransactionDataTableNames.PRODUCT_SELL_PRICE].Value = product.SellPrice;
            row.Cells[TransactionDataTableNames.PRODUCT_AVAILABLE_QUANTITY].Value = product.Quantity;
            row.Cells[TransactionDataTableNames.PRODUCT_ID].Value = product.Id;
        }

        public List<int> GetAllProductIds()
        {
            List<int> res = new List<int>();
            for (int i = 0; i < this.DataGrid.RowCount; i++)
            {
                var row = this.DataGrid.Rows[i];
                object prodId = row.Cells[TransactionDataTableNames.PRODUCT_ID].Value;
                if (prodId != null)
                    res.Add((int)prodId); 
            }
            return res;
        }


        //private logic 

        //events
        private void OnBtnClick(object sender, EventArgs e)
        {
            this.TransactionSection.PickAProductRequest();
        }

        private void dataGridView1_DefaultValuesNeeded(object sender, System.Windows.Forms.DataGridViewRowEventArgs e)
        {
            this.COUNTER++;
            e.Row.Cells[TransactionDataTableNames.TRANSACTION_NUMBER].Value = this.COUNTER;
            e.Row.Cells[TransactionDataTableNames.PRODUCT_QUANTITY].Value = 0;
        }

        private void grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
            this.Form.Log("Error with data");
            // MessageBox.Show(this, "Грешна информация: " + this.DataGrid[e.ColumnIndex, e.RowIndex].EditedFormattedValue, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void OnColumnValueChange(Object sender, DataGridViewCellEventArgs e)
        {
            var row = this.DataGrid.Rows[e.RowIndex];
            if (this.DataGrid.Columns[e.ColumnIndex].Name == TransactionDataTableNames.PRODUCT_QUANTITY)
                this.TransactionSection.UpdateTotalPriceAction(e.RowIndex);
        }


    }
}
