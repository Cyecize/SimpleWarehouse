using System;
using System.Windows.Forms;
using SimpleWarehouse.Interfaces;

namespace SimpleWarehouse.View
{
    public interface IHomeView : IView, ISearchProductView, IRevisionView, ITransactionView
    {
        DataGridView DeliveriesDataTable { get; set; }

        DataGridView SalesDataTable { get; set; }

        DataGridView RevisionDataTable { get; set; }

        TabPage SelectedTabPage { get; set; }

        TabPage DeliveriesTab { get; set; }

        TabPage SalesTab { get; set; }

        TextBox TotalDeliveryMoney { get; set; }

        TextBox TotalSaleMoney { get; set; }

        string TabLabelText { get; set; }

        void EnableOrDisableElement(string elName, Type elType, bool isEnabled);

        void EnableOrDisableMaterialBtn(string btnName, bool isEnabled);
    }
}