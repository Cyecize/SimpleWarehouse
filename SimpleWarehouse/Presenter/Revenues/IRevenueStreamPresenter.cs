using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.RevenueRelated.View;
using SimpleWarehouse.Sections.Revenues;

namespace SimpleWarehouse.Presenter.Revenues
{
    public interface IRevenueStreamPresenter : IPresenter
    {
        IRevenueStreamSection RevenueStreamSection { get; set; }
        
        IRevenueView Form { get; set; }

        void GoBackAction();
    }
}
