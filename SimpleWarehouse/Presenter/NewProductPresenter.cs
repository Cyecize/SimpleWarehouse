using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Managers;
using SimpleWarehouse.Model;
using SimpleWarehouse.Presenter.ProductSpecificPresenters;
using SimpleWarehouse.View;

namespace SimpleWarehouse.Presenter
{
    public class NewProductPresenter : AbstractPresenter, IProductSpecificPresenter
    {
        private ProductManager ProductManager;
        private ISpecificProductView Form;
        private bool IsFormCancelled; 

        public NewProductPresenter(IStateManager manager, ProductManager productManager) : base(manager)
        {
            this.IsFormCancelled = false;
            this.ProductManager = productManager;
            this.Form = (ISpecificProductView)FormFactory.CreateForm("SpecificProductForm", new object[] { this });
            ((Form)this.Form).FormClosing += (sen, e) => this.Cancel();
            this.Form.DisplayCategories(this.ProductManager.GetCategories());
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
                this.ProductManager.CreateProduct(product);
                this.ProductManager.DisplayProducts();
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
