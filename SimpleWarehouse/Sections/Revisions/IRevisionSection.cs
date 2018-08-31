using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Sections.Revisions
{
    public interface IRevisionSection
    {
        void Initialize();

        void CancelOperation();

        void BeginRevision();

        void UpdateTotalPriceAction(int rowId);

        void RefreshGridAction();

        void CommitRevisionAction();
    }
}
