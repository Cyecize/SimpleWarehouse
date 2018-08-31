using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWarehouse.Model;

namespace SimpleWarehouse.Services.Products
{
    public interface IProductViewService
    {
        SearchParameter SearchParam { get; set; }

        void SelectProduct();

        void DisplayProducts(List<Product> products);

        void ChangeSearchParam(SearchParameter search);

        int GetSelectedProductId();
    }
}
