using SimpleWarehouse.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Interfaces
{
    public interface IProductViewManager
    {
        void SelectProduct();

        void DisplayProducts(List<Product> products);

        void ChangeSearchParam(SearchParameter search);

        int GetSelectedProductId();

         SearchParameter SearchParam { get; set; }
    }
}
