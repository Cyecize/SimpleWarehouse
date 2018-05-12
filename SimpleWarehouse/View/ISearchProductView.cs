using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWarehouse.View
{
    public interface ISearchProductView : IView
    {
        DataGridView ProductDataTable { get; set; }

        string SearchText { get; set; }

        void SetSearchParams(List<SearchParameter> searchParameters);

        SearchParameter SearchParameter { get; }
    }
}
