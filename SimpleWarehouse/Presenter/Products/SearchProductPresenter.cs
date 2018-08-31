using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Sections.Products;
using SimpleWarehouse.View;

namespace SimpleWarehouse.Presenter.Products
{
    public class SearchProductPresenter : AbstractPresenter
    {
        private const string Title = "Избор на стока";

        public delegate void WorkCompletedCallBack(Product product);

        private WorkCompletedCallBack Callback { get; set; }

        public ProductSection ProductSection { get; set; }

        public ISearchProductView Form { get; set; }

        public override ILoggable Loggable => Form;

        public SearchProductPresenter(IStateManager manager, WorkCompletedCallBack callBack) : base(manager)
        {
            this.Form = (ISearchProductView)FormFactory.CreateForm("SearchProductForm", new object[] { this });
            this.ProductSection = new ProductSection(this.Form.ProductDataTable, this, this.Form);
            this.Form.SetSearchParams(this.ProductSection.GetSearchParameters());
            this.ProductSection.UpdateVisibleProducts();
            this.Callback = callBack;
            this.Form.Text = Title;
        }

        public void Submit()
        {
            try
            {
                int prodId = this.ProductSection.ViewService.GetSelectedProductId();
                Product product = this.ProductSection.ProductDbService.FindById(prodId);
                this.Callback(product);
                this.GoBackAction();
            }
            catch (ArgumentException e)
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
