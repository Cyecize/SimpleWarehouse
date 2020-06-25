using System.Collections.Generic;
using System.Windows.Forms;
using SimpleWarehouse.Model;

namespace SimpleWarehouse.Services.Revisions
{
    public interface IRevisionViewService
    {
        void Initialize();

        void ClearRows();

        void EndEdit();

        void SetDataAtRow(int rowId, string cellName, object value);

        void InsertProducts(List<Product> products);

        int GetRowsCount();

        object GetDataAtRow(int rowId, string cellName);

        DataGridViewRow GetCurrentRow();
    }
}