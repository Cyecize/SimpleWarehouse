using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Services.RevenueRelated
{
    public interface IAddEntitySection
    {
        void UpdateNonRevisedEntities();

        void AddEntityAction();
    }
}
