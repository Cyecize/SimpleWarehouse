using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;

namespace SimpleWarehouse.Services.Products
{
    public class ProductViewService : IProductViewService
    {
        private const string ProductId = "ProductId";
        private const string CategoryName = "Category";
        private const string ProductName = "ProductName";
        private const string ProductQuantity = "Quantity";
        private const string ImportPrice = "ImportPrice";
        private const string SellPrice = "SellPrice";
        private const string IsVisible = "Visible";

        private DataTable Table;
        private DataGridView ViewTable;
        private DataGridViewRow SelectedRow;
        private ILoggable Log;

        public SearchParameter SearchParam { get; set; }

        public ProductViewService(DataGridView dataGridView, ILoggable loggable)
        {
            this.Table = new DataTable();
            this.Table.Columns.Add(ProductId);
            this.Table.Columns.Add(CategoryName);
            this.Table.Columns.Add(ProductName);
            this.Table.Columns.Add(ProductQuantity);
            this.Table.Columns.Add(ImportPrice);
            this.Table.Columns.Add(SellPrice);
            this.Table.Columns.Add(IsVisible);
            this.ViewTable = dataGridView;
            this.Log = loggable;
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
            this.Log.Log($"Показани са {products.Count} продукти");
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
            return int.Parse(this.SelectedRow.Cells[ProductId].Value.ToString().Trim());
        }

        //private logic 

        private DataRow MakeRow(Product product)
        {
            DataRow row = Table.NewRow();
            row[ProductId] = product.Id;
            row[CategoryName] = product.Category.CategoryName;
            row[ProductName] = product.ProductName;
            row[ProductQuantity] = product.Quantity;
            row[ImportPrice] = product.ImportPrice;
            row[SellPrice] = product.SellPrice;
            row[IsVisible] = product.IsVisible;
            return row;
        }

        private void AddRow(DataRow row)
        {
            int rowId = this.ViewTable.Rows.Add();
            this.ViewTable.CurrentCell = this.ViewTable.Rows[rowId].Cells[0];

            this.ViewTable.Select();
            this.ViewTable.Rows[rowId].Cells[ProductId].Value = row[ProductId].ToString();
            this.ViewTable.Rows[rowId].Cells[CategoryName].Value = row[CategoryName].ToString();
            this.ViewTable.Rows[rowId].Cells[ProductName].Value = row[ProductName].ToString();
            this.ViewTable.Rows[rowId].Cells[ProductQuantity].Value = row[ProductQuantity].ToString();
            this.ViewTable.Rows[rowId].Cells[ImportPrice].Value = row[ImportPrice].ToString();
            this.ViewTable.Rows[rowId].Cells[SellPrice].Value = row[SellPrice].ToString();
            this.ViewTable.Rows[rowId].Cells[IsVisible].Value = row[IsVisible].ToString();
            this.ViewTable.ClearSelection();
            this.ViewTable.Rows[rowId].Selected = true;
            this.SelectProduct();
        }
    }
}
