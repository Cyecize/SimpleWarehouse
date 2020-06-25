using System;
using System.Collections.Generic;
using System.Data;
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
        private readonly ILoggable Log;
        private DataGridViewRow SelectedRow;

        private readonly DataTable Table;
        private readonly DataGridView ViewTable;

        public ProductViewService(DataGridView dataGridView, ILoggable loggable)
        {
            Table = new DataTable();
            Table.Columns.Add(ProductId);
            Table.Columns.Add(CategoryName);
            Table.Columns.Add(ProductName);
            Table.Columns.Add(ProductQuantity);
            Table.Columns.Add(ImportPrice);
            Table.Columns.Add(SellPrice);
            Table.Columns.Add(IsVisible);
            ViewTable = dataGridView;
            Log = loggable;
            InitEvents();
        }

        public SearchParameter SearchParam { get; set; }

        //main functionality

        public void SelectProduct()
        {
            var row = ViewTable.CurrentRow;
            if (row == null)
                return;
            if (!row.IsNewRow)
                // string c1 = row.Cells["ProductId"].Value.ToString();  
                SelectedRow = row;
        }

        public void DisplayProducts(List<Product> products)
        {
            ViewTable.Rows.Clear();
            foreach (var prod in products) AddRow(MakeRow(prod));

            Log.Log($"Показани са {products.Count} продукти");
        }

        public void ChangeSearchParam(SearchParameter search)
        {
            if (search != null) SearchParam = search;
        }

        public int GetSelectedProductId()
        {
            if (SelectedRow == null)
                throw new ArgumentException("Изберете продукт!");

            return int.Parse(SelectedRow.Cells[ProductId].Value.ToString().Trim());
        }

        //private logic 

        private DataRow MakeRow(Product product)
        {
            var row = Table.NewRow();
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
            var rowId = ViewTable.Rows.Add();
            ViewTable.CurrentCell = ViewTable.Rows[rowId].Cells[0];

            ViewTable.Select();
            ViewTable.Rows[rowId].Cells[ProductId].Value = row[ProductId].ToString();
            ViewTable.Rows[rowId].Cells[CategoryName].Value = row[CategoryName].ToString();
            ViewTable.Rows[rowId].Cells[ProductName].Value = row[ProductName].ToString();
            ViewTable.Rows[rowId].Cells[ProductQuantity].Value = row[ProductQuantity].ToString();
            ViewTable.Rows[rowId].Cells[ImportPrice].Value = row[ImportPrice].ToString();
            ViewTable.Rows[rowId].Cells[SellPrice].Value = row[SellPrice].ToString();
            ViewTable.Rows[rowId].Cells[IsVisible].Value = row[IsVisible].ToString();
            ViewTable.ClearSelection();
            ViewTable.Rows[rowId].Selected = true;
            SelectProduct();
        }

        private void InitEvents()
        {
            ViewTable.CurrentCellChanged += (e, a) => { SelectProduct(); };
        }
    }
}