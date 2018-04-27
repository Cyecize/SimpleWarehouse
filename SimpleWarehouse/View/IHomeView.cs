using SimpleWarehouse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWarehouse.View
{
    interface IHomeView : SimpleWarehouse.Interfaces.IView
    {
        DataGridView DataTable { get; set; }

        string SearchText { get; set; }

        void SetSearchParams(List<SearchParameter> searchParameters);

        SearchParameter SearchParameter { get;}
    }
}
