using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWarehouse.Model;

namespace SimpleWarehouse.Services.Products
{
    public interface ICategoryDbService
    {
        bool CreateCategory(Category category);

        List<Category> FindAll();
    }
}
