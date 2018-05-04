using SimpleWarehouse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWarehouse.View
{
    public interface IHomeView : SimpleWarehouse.Interfaces.IView
    {
        DataGridView DataTable { get; set; }

        string SearchText { get; set; }

        void SetSearchParams(List<SearchParameter> searchParameters);

        void EnableOrDisableElement(string elName, Type elType, bool isEnabled); 

        void EnableOrDisableMaterialBtn(string btnName, bool isEnabled); 

        SearchParameter SearchParameter { get;}
    }
}
