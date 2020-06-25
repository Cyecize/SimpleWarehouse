using System;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Sections.Products;
using SimpleWarehouse.View;

namespace SimpleWarehouse.Presenter.Products
{
    public class SearchProductPresenter : AbstractPresenter
    {
        public delegate void WorkCompletedCallBack(Product product);

        private const string Title = "Избор на стока";

        public SearchProductPresenter(IStateManager manager, WorkCompletedCallBack callBack) : base(manager)
        {
            Form = (ISearchProductView) FormFactory.CreateForm("SearchProductForm", new object[] {this});
            ProductSection = new ProductSection(Form.ProductDataTable, this, Form);
            Form.SetSearchParams(ProductSection.GetSearchParameters());
            ProductSection.UpdateVisibleProducts();
            Callback = callBack;
            Form.Text = Title;
        }

        private WorkCompletedCallBack Callback { get; }

        public ProductSection ProductSection { get; set; }

        public ISearchProductView Form { get; set; }

        public override ILoggable Loggable => Form;

        public void Submit()
        {
            try
            {
                var prodId = ProductSection.ViewService.GetSelectedProductId();
                var product = ProductSection.ProductDbService.FindById(prodId);
                Callback(product);
                GoBackAction();
            }
            catch (ArgumentException e)
            {
                Form.Log(e.Message);
            }
        }

        public void GoBackAction()
        {
            StateManager.Pop();
        }

        public override void Dispose()
        {
            Form.HideAndDispose();
        }


        public override void Update()
        {
            if (!IsFormShown)
            {
                Form.ShowAsDialog();
                IsFormShown = true;
            }
        }
    }
}