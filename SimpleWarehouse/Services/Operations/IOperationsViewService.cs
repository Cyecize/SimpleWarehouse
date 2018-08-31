using System.Collections.Generic;
using System.Windows.Forms;
using SimpleWarehouse.Model;

namespace SimpleWarehouse.Services.Operations
{
    public interface IOperationsViewService
    {
        void Initialize();

        void ClearRows();       

        void SetDataAtRow(int rowId, string cellName, object value);

        void AddSelectedProduct(DataGridViewRow row, Product product);

        int GetRowsCount();

        double RefreshGrid();

        object GetDataAtRow(int rowId, string cellName);

        DataGridViewRow GetCurrentRow();

        List<int> GetAllProductIds();        
    }
}
