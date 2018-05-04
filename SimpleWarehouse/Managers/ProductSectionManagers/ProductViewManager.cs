using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWarehouse.Managers.ProductSectionManagers
{
    public class ProductViewManager : IProductViewManager
    {
        private const string PRODUCT_ID = "ProductId";
        private const string CATEGORY_NAME = "Category";
        private const string PRODUCT_NAME = "ProductName";
        private const string PRODUCT_QUANTITY = "Quantity";
        private const string IMPORT_PRICE = "ImportPrice";
        private const string SELL_PRICE = "SellPrice";
        private const string IS_VISIBLE = "Visible";

        private DataTable Table;
        private DataGridView ViewTable;
        private DataGridViewRow SelectedRow;

        public SearchParameter SearchParam { get; set; }
       
        public ProductViewManager(DataGridView dataGridView)
        {
            this.Table = new DataTable();
            this.Table.Columns.Add(PRODUCT_ID);
            this.Table.Columns.Add(CATEGORY_NAME);
            this.Table.Columns.Add(PRODUCT_NAME);
            this.Table.Columns.Add(PRODUCT_QUANTITY);
            this.Table.Columns.Add(IMPORT_PRICE);
            this.Table.Columns.Add(SELL_PRICE);
            this.Table.Columns.Add(IS_VISIBLE);
            this.ViewTable = dataGridView;
        }

        //main functionality

        public void SelectProduct()
        {
            DataGridViewRow row = this.ViewTable.CurrentRow;
            if (row == null)
                return;
            if (!row.IsNewRow)
            {
                // string c1 = row.Cells["ProductId"].Value.ToString();  
                this.SelectedRow = row;
            }
        }

        public void DisplayProducts(List<Product> products)
        {
            this.ViewTable.Rows.Clear();
            foreach (var prod in products)
            {
                this.AddRow(this.MakeRow(prod));
            }
        }

        public void ChangeSearchParam(SearchParameter search)
        {
            if (search != null)
            {
                this.SearchParam = search;
            }
        }

        public int GetSelectedProductId()
        {
            if (this.SelectedRow == null)
                throw new ArgumentException("Изберете продукт!");
            return int.Parse(this.SelectedRow.Cells[PRODUCT_ID].Value.ToString().Trim());
        }



        //private logic 

        private DataRow MakeRow(Product product)
        {
            DataRow row = Table.NewRow();
            row[PRODUCT_ID] = product.Id;
            row[CATEGORY_NAME] = product.CategoryName;
            row[PRODUCT_NAME] = product.ProductName;
            row[PRODUCT_QUANTITY] = product.Quantity;
            row[IMPORT_PRICE] = product.ImportPrice;
            row[SELL_PRICE] = product.SellPrice;
            row[IS_VISIBLE] = product.IsVisible;
            return row;
        }

        private void AddRow(DataRow row)
        {
            int rowId = this.ViewTable.Rows.Add();
            this.ViewTable.CurrentCell = this.ViewTable.Rows[rowId].Cells[0];

            this.ViewTable.Select();
            this.ViewTable.Rows[rowId].Cells[PRODUCT_ID].Value = row[PRODUCT_ID].ToString();
            this.ViewTable.Rows[rowId].Cells[CATEGORY_NAME].Value = row[CATEGORY_NAME].ToString();
            this.ViewTable.Rows[rowId].Cells[PRODUCT_NAME].Value = row[PRODUCT_NAME].ToString();
            this.ViewTable.Rows[rowId].Cells[PRODUCT_QUANTITY].Value = row[PRODUCT_QUANTITY].ToString();
            this.ViewTable.Rows[rowId].Cells[IMPORT_PRICE].Value = row[IMPORT_PRICE].ToString();
            this.ViewTable.Rows[rowId].Cells[SELL_PRICE].Value = row[SELL_PRICE].ToString();
            this.ViewTable.Rows[rowId].Cells[IS_VISIBLE].Value = row[IS_VISIBLE].ToString();
        }


    }
}
