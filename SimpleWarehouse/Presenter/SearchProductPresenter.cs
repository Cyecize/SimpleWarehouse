using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Services.ProductSectionManagers;
using SimpleWarehouse.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Presenter
{
    public class SearchProductPresenter : AbstractPresenter
    {
        public delegate void WorkCompletedCallBack(Product product);
        private WorkCompletedCallBack Callback;


        public ProductSectionManager ProductSection { get; set; }
        public ISearchProductView Form { get; set; }
        
        public SearchProductPresenter(IStateManager manager, WorkCompletedCallBack callBack) : base(manager)
        {
            this.Form = (ISearchProductView)FormFactory.CreateForm("SearchProductForm", new object[] { this });
            this.ProductSection = new ProductSectionManager(base.StateManager.SqlManager, this.Form.ProductDataTable, this, this.Form);
            this.Form.SetSearchParams(this.ProductSection.ProductsManager.GetSearchParameters());
            this.ProductSection.UpdateVisibleProducts();
            this.Callback = callBack;
        }

        public void Submit()
        {
            
            try
            {
                int prodId = this.ProductSection.ProductViewManager.GetSelectedProductId();
                Product product = this.ProductSection.ProductsManager.GetProductForEdit(prodId);
                this.Callback(product);
                this.GoBackAction();
            }
            catch(ArgumentException e)
            {
                this.Form.Log(e.Message);
            }
        }

        public void GoBackAction()
        {
            base.StateManager.Pop();
        }

        public override void Dispose()
        {
            this.Form.HideAndDispose();
        }

        public override void Update()
        {
            if (!base.IsFormShown)
            {
                this.Form.ShowAsDialog();
                base.IsFormShown = true;
            }
        }
    }
}
