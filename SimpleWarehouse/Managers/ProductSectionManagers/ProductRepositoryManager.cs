using SimpleWarehouse.Interfaces;
using SimpleWarehouse.IO;
using SimpleWarehouse.Model;
using SimpleWarehouse.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Managers.ProductSectionManagers
{
    public class ProductRepositoryManager : IProductsRepositoryManager
    {
        private const string SQL_JOIN_VIEW_PROD = "SELECT * FROM prod_cat_joined ";

        private IEntityRepository<Product> ProductRepository;
        IEntityRepository<SearchParameter> SearchParamRepository;

        public ProductRepositoryManager(IMySqlManager sqlManager)
        {
            this.ProductRepository = new EntityRepo<Product>(sqlManager, new ConsoleWriter());
            this.SearchParamRepository = new EntityRepo<SearchParameter>(sqlManager, new ConsoleWriter());
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

        public List<Product> FindAll()
        {
            return this.ProductRepository.FindManyByQuery(SQL_JOIN_VIEW_PROD + " LIMIT 100");
        }

        public Product GetProductForEdit(int productId)
        {
            return this.ProductRepository.FindOneByQuery(SQL_JOIN_VIEW_PROD + $"WHERE id = {productId}");
        }

        public List<SearchParameter> GetSearchParameters()
        {
            return this.SearchParamRepository.FindManyByQuery("SELECT * FROM search_types");
        }

        public List<Product> Search(string param, SearchParameter parameterType)
        {
            param = ProductRepository.SqlManager.EscapeString(param);
            string colName = "product_name";
            if (parameterType != null)
                colName = parameterType.ColumnName;
            return this.ProductRepository
                .FindManyByQuery($"{SQL_JOIN_VIEW_PROD} WHERE {colName} LIKE '%{param}%' LIMIT 100");
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

        //private methods
        private bool ProdNameExists(Product p)
        {
            Product product = this.ProductRepository.FindOneByQuery(SQL_JOIN_VIEW_PROD + $" WHERE product_name = '{p.ProductName}'");
            if (product != null)
                if (p.CategoryId == product.CategoryId)
                    return true;

            return false;
        }
    }
}
