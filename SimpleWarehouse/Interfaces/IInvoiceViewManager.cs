using SimpleWarehouse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Interfaces
{
    public interface IInvoiceViewManager
    {
        void DisplayInvoices(List<Invoice> invoices);
    }
}
