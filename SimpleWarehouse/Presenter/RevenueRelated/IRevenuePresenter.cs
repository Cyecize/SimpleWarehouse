using SimpleWarehouse.RevenueRelated.View;
using SimpleWarehouse.Services.RevenueRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Presenter.RevenueRelated
{
    public interface IRevenuePresenter
    {
        IAddEntitySection AddEntitySection { get; set; }
        IArchivedEntitiesSection ArchivedEntitiesSection { get; set; }
        IRevenueView Form { get; set; }

        void Dispose();
    }
}
