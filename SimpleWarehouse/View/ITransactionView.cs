using SimpleWarehouse.Constants;
using SimpleWarehouse.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWarehouse.View
{
    public interface ITransactionView : IView
    {
        bool IsTransactionRevised { get; set; }

        TransactionTypes SelectedTransactionType { get; set; }

        DateTime TransactionStartDate { get; set; }

        DateTime TransactionEndtDate { get; set; }

        DataGridView TransactionGrid { get; }
    }
}
