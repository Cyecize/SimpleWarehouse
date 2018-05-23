using SimpleWarehouse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWarehouse.Interfaces
{
    public interface IRevisionGridViewManager
    {
        DataGridView DataGrid { get; set; }

        void ClearRows();

        void Initialize();

        void InsertProducts(List<Product> products);


    }
}
