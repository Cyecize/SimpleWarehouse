using SimpleWarehouse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Interfaces
{
    public interface IProductsRepositoryManager
    {
        void CreateProduct(Product product);

        void UpdateProduct(Product product, bool performNameCheck);

        List<Product> Search(string param, SearchParameter parameterType);

        List<Product> FindAll();

        Product GetProductForEdit(int productId);

        List<SearchParameter> GetSearchParameters();
    }
}
