using SimpleWarehouse.Interfaces;
using SimpleWarehouse.IO;
using SimpleWarehouse.Model;
using SimpleWarehouse.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWarehouse.Managers
{
    public class ProductManager
    {
        private const string PRODUCT_ID = "ProductId";
        private const string CATEGORY_NAME = "Category";
        private const string PRODUCT_NAME = "ProductName";
        private const string PRODUCT_QUANTITY = "Quantity";
        private const string IMPORT_PRICE = "ImportPrice";
        private const string SELL_PRICE = "SellPrice";
        private const string IS_VISIBLE = "Visible";
        private const string SQL_JOIN_STR_PROD = "SELECT  p.* , pk.category_name FROM products AS p INNER JOIN product_categories  AS pk ON p.category_id =  pk.id ";
        private const string SQL_JOIN_VIEW_PROD = "SELECT * FROM prod_cat_joined ";

        private DataTable Table;
        private DataGridView ViewTable;
        private DataGridViewRow SelectedRow;
        private IEntityRepository<Product> ProductRepository;
        private SearchParameter SearchParam;
        private IEntityRepository<Category> CategoryRepository;

        public ProductManager(DataGridView dataGridView, IMySqlManager sqlManager)
        {
            this.ProductRepository = new EntityRepo<Product>(sqlManager, new ConsoleWriter());
            this.CategoryRepository = new EntityRepo<Category>(sqlManager, new ConsoleWriter());
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

        public List<Category> GetCategories()
        {
            return this.CategoryRepository.FindManyByQuery($"SELECT * FROM product_categories");
        }

        public List<SearchParameter> GetSearchParameters()
        {
            IEntityRepository<SearchParameter> repo = new EntityRepo<SearchParameter>(ProductRepository.SqlManager, new ConsoleWriter());
            return repo.FindManyByQuery("SELECT * FROM search_types");
        }

        public void DisplayProducts()
        {
            this.PopulateData(this.ProductRepository.FindManyByQuery(SQL_JOIN_STR_PROD + " LIMIT 100"));
        }

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

        public void Search(string param)
        {
            param = ProductRepository.SqlManager.EscapeString(param);
            string colName = "product_name";
            if (this.SearchParam != null)
                colName = SearchParam.ColumnName;
            // this.PopulateData(this.ProductRepository.FindManyByQuery($"SELECT * FROM products WHERE {colName} LIKE '{param}%' LIMIT 100"));
            this.PopulateData(this.ProductRepository.FindManyByQuery(
                $"{SQL_JOIN_STR_PROD} WHERE {colName} LIKE '%{param}%' LIMIT 100"));
        }

        public void ChangeSearchParam(SearchParameter search)
        {
            if (search != null)
            {
                this.SearchParam = search;
            }
        }

        public Product GetProductForEdit()
        {
            if (this.SelectedRow == null)
            {
                throw new ArgumentException("Изберете продукт!");
            }
            Product product = this.ProductRepository.FindOneByQuery(SQL_JOIN_VIEW_PROD + $"WHERE id = {this.SelectedRow.Cells[PRODUCT_ID].Value}");
            return product;
        }

        public void UpdateProduct(Product product, bool performNameCheck)
        {
            if (performNameCheck)
            {
                if (this.ProdNameExists(product))
                    throw new ArgumentException("Името на продукта съществува в тази категория");
            }
            this.ProductRepository.SqlManager.ExecuteQuery(
                  $"UPDATE products SET category_id = {product.CategoryId} , product_name = '{product.ProductName}', quantity =  {product.Quantity}, import_price =  {product.ImportPrice}, sell_price =  {product.SellPrice}, is_visible =  {product.IsVisible.ToString().ToUpper()} WHERE id = {product.Id}");

        }

        public void CreateProduct(Product product)
        {
            if (this.ProdNameExists(product))
            {
                throw new ArgumentException("Името на продукта съществува в тази категория");
            }
            this.ProductRepository.SqlManager.ExecuteQuery(
                $"INSERT INTO products VALUES(NULL, {product.CategoryId} ,'{product.ProductName}', {product.Quantity}, {product.ImportPrice}, {product.SellPrice}, {product.IsVisible.ToString().ToUpper()})");

        }

        public void CreateCategory(Category category)
        {
            if(this.GetCategories().Where(c => c.CategoryName == category.CategoryName && c.ParantId == category.ParantId).FirstOrDefault() != null)
            {
                throw new ArgumentException("Съществуваща категория!");
            }
            string query = $"INSERT INTO product_categories VALUES(NULL, {category.ParantId}, '{category.CategoryName}')";
            this.CategoryRepository.SqlManager.ExecuteQuery(query);
        }

        //private logic

        private void PopulateData(List<Product> products)
        {
            this.ViewTable.Rows.Clear();
            foreach (var prod in products)
            {
                this.AddRow(this.MakeRow(prod));
            }
        }

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

        private bool ProdNameExists(Product p)
        {
            Product product = this.ProductRepository.FindOneByQuery(SQL_JOIN_VIEW_PROD + $" WHERE product_name = '{p.ProductName}'");
            if (product != null)
            {
                if (p.CategoryId == product.CategoryId)
                    return true;
            }
            return false;
        }

    }
}
