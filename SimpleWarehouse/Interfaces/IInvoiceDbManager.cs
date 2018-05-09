using SimpleWarehouse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Interfaces
{
    public interface IInvoiceDbManager
    {
        List<Invoice> FindInvoicesByDate(DateTime startDate, DateTime endDate);

        void CreateInvoice(Invoice invoice);
    }
}
