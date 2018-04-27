using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Presenter.ProductSpecificPresenters
{
    public interface IProductSpecificPresenter
    {
        void Submit();

        void Cancel();
    }
}
