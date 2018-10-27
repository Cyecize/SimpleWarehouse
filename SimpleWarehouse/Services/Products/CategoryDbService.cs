using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWarehouse.Model;
using  static SimpleWarehouse.App.ApplicationState;

namespace SimpleWarehouse.Services.Products
{
    public class CategoryDbService : ICategoryDbService
    {

        public CategoryDbService()
        {

        }
        
        public bool CreateCategory(Category category)
        {
            try
            {
                Database.Categories.Add(category);
                Database.SaveChanges();
                return true;
            }

            catch (Exception)
            {
                return false;
            }
        }

        public List<Category> FindAll()
        {
            return new List<Category>(Database.Categories);
        }
    }
}
