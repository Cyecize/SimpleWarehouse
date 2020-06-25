using System;
using System.Windows.Forms;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model.Enum;

namespace SimpleWarehouse.View
{
    public interface ITransactionView : IView
    {
        bool IsTransactionRevised { get; set; }

        TransactionType SelectedTransactionType { get; set; }

        DateTime TransactionStartDate { get; set; }

        DateTime TransactionEndtDate { get; set; }

        DataGridView TransactionGrid { get; }
    }
}