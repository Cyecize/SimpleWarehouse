using System.Collections.Generic;
using System.Windows.Forms;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;

namespace SimpleWarehouse.View
{
    public interface ISearchProductView : IView
    {
        DataGridView ProductDataTable { get; set; }

        string SearchText { get; set; }

        SearchParameter SearchParameter { get; }

        void SetSearchParams(List<SearchParameter> searchParameters);
    }
}