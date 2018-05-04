using SimpleWarehouse.Interfaces;
using SimpleWarehouse.IO;
using SimpleWarehouse.Model;
using SimpleWarehouse.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Services.ProductSectionManagers
{
    public class CategoryRepositoryManager : ICategoriesRepositoryManager
    {
        private IEntityRepository<Category> CategoryRepository;

        public CategoryRepositoryManager(IMySqlManager sqlManager)
        {
            this.CategoryRepository = new EntityRepo<Category>(sqlManager, new ConsoleWriter());
        }

        public void CreateCategory(Category category)
        {
            if (this.GetCategories().Where(c => c.CategoryName == category.CategoryName && c.ParantId == category.ParantId).FirstOrDefault() != null)
                throw new ArgumentException("Съществуваща категория!");
            string query = $"INSERT INTO product_categories VALUES(NULL, {category.ParantId}, '{category.CategoryName}')";
            this.CategoryRepository.SqlManager.ExecuteQuery(query);
        }

        public List<Category> GetCategories()
        {
            return this.CategoryRepository.FindManyByQuery($"SELECT * FROM product_categories");
        }
    }
}
