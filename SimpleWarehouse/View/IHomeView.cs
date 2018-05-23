﻿using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWarehouse.View
{
    public interface IHomeView : IView, ISearchProductView, IRevisionView
    {

        DataGridView DeliveriesDataTable { get; set; }

        DataGridView SalesDataTable { get; set; }

        DataGridView RevisionDataTable { get; set; }

        TabPage SelectedTabPage { get; set; }

        TabPage DeliveriesTab { get; set; }

        TabPage SalesTab { get; set; }

        void EnableOrDisableElement(string elName, Type elType, bool isEnabled);

        void EnableOrDisableMaterialBtn(string btnName, bool isEnabled);

        TextBox TotalDeliveryMoney { get; set; }

        TextBox TotalSaleMoney { get; set; }

        string TabLabelText { get; set; }
        
    }
}
