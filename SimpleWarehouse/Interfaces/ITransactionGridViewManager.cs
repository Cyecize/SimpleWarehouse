using SimpleWarehouse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWarehouse.Interfaces
{
    public interface ITransactionGridViewManager
    {
        TabPage TabPage { get; set; }

        DataGridView DataGrid { get; set; }

        void Dispose();

        void AddSelectedProduct(DataGridViewRow row, Product product);

        void Initialize();
    }
}
