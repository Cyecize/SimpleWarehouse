using System.Collections.Generic;
using SimpleWarehouse.Model;

namespace SimpleWarehouse.Services.Products
{
    public interface ICategoryDbService
    {
        bool CreateCategory(Category category);

        List<Category> FindAll();
    }
}