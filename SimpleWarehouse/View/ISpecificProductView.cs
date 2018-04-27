using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
