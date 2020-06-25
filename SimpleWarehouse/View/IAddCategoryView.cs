using System.Collections.Generic;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;

namespace SimpleWarehouse.View
{
    public interface IAddCategoryView : IView
    {
        string CategoryName { get; set; }

        Category SelectedCategory { get; set; }

        void DisplayCategories(List<Category> categories);
    }
}