using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Managers;
using SimpleWarehouse.Managers.ProductSectionManagers;
using SimpleWarehouse.Model;
using SimpleWarehouse.Presenter.ProductSpecificPresenters;
using SimpleWarehouse.View;

namespace SimpleWarehouse.Presenter
{
    public class NewProductPresenter : AbstractPresenter, IProductSpecificPresenter
    {
        private ProductSectionManager ProductSectionManager;
        private ISpecificProductView Form;
        private bool IsFormCancelled; 

        public NewProductPresenter(IStateManager manager, ProductSectionManager productManager) : base(manager)
        {
            this.IsFormCancelled = false;
            this.ProductSectionManager = productManager;
            this.Form = (ISpecificProductView)FormFactory.CreateForm("SpecificProductForm", new object[] { this });
            ((Form)this.Form).FormClosing += (sen, e) => this.Cancel();
            this.Form.DisplayCategories(this.ProductSectionManager.CategoriesManager.GetCategories());
        }

        public void Cancel()
        {
            if (!this.IsFormCancelled)
            {
                base.StateManager.Pop();
                this.IsFormCancelled = true;
            }
           
        }

        public override void Dispose()
        {
            foreach (var id in base.EventIds)
            {
                base.StateManager.EventManager.RemoveEvent(id);
            }
            this.Form.HideAndDispose();
            base.StateManager.OutputWriter.WriteLine("New Product Presenter Disposed!");
        }

        public void Submit()
        {
            Product product = new Product()
            {
                ProductName = this.Form.ProductName,
                CategoryId = this.Form.SelectedCategory.Id,
                IsVisible = this.Form.IsVisible,
                ImportPrice = this.Form.ImportPrice,
                SellPrice = this.Form.SellPrice,
                Quantity = this.Form.Quantity
            };
            try
            {
                this.ProductSectionManager.ProductsManager.CreateProduct(product);
                this.ProductSectionManager.UpdateProducts();
                this.Cancel();
            }catch(ArgumentException e)
            {
                base.StateManager.Push(new ErrorPresenter(base.StateManager, e.Message, true)); 
            }
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
