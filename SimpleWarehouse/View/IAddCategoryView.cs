using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.View
{
    public interface IAddCategoryView : IView
    {
        string CategoryName { get; set; }

        Category SelectedCategory { get; set; }

        void DisplayCategories(List<Category> categories);
    }
}
