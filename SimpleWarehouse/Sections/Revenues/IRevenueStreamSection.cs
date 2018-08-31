using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Sections.Revenues
{
    public interface IRevenueStreamSection
    {
        void AddRevenueStreamAction();

        void DisplayArchivedRevenueStreams();

        void UpdateNonRevisedRevenueStreams();
    }
}
