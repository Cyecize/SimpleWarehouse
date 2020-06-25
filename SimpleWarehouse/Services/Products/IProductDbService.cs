using System.Collections.Generic;
using SimpleWarehouse.Model;

namespace SimpleWarehouse.Services.Products
{
    public interface IProductDbService
    {
        bool UpdateProduct(Product product);

        bool CreateProduct(Product product);

        Product FindById(int productId);

        List<Product> Search(string param, SearchParameter parameterType);

        List<Product> SearchVisible(string param, SearchParameter parameterType);

        List<Product> FindAllByLimit(int limit);

        List<Product> FindAll();

        List<Product> FindAllVisible();

        List<SearchParameter> GetSearchParameters();
    }
}