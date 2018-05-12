using SimpleWarehouse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWarehouse.View
{
    public interface IHomeView : SimpleWarehouse.Interfaces.IView, ISearchProductView
    {

        DataGridView DeliveriesDataTable { get; set; }

        DataGridView SalesDataTable { get; set; }

        TabPage SelectedTabPage { get; set; }

        TabPage DeliveriesTab { get; set; }

        TabPage SalesTab { get; set; }

        void EnableOrDisableElement(string elName, Type elType, bool isEnabled);

        void EnableOrDisableMaterialBtn(string btnName, bool isEnabled);
    }
}
