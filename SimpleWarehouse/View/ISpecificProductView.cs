using System.Collections.Generic;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;

namespace SimpleWarehouse.View
{
    public interface ISpecificProductView : IView
    {
        string ProductName { get; set; }

        double Quantity { get; set; }

        double ImportPrice { get; set; }

        double SellPrice { get; set; }

        bool IsVisible { get; set; }

        Category SelectedCategory { get; set; }

        void DisplayCategories(List<Category> categories);
    }
}