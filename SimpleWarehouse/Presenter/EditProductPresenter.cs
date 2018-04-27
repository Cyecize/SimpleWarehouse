using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Managers;
using SimpleWarehouse.Model;
using SimpleWarehouse.Presenter.ProductSpecificPresenters;
using SimpleWarehouse.View;

namespace SimpleWarehouse.Presenter
{
    public class EditProductPresenter : AbstractPresenter, IProductSpecificPresenter
    {
        private ProductManager ProductManager;
        private ISpecificProductView Form;
        private bool IsFormCancelled;
        private Product ProductToEdit;

        public EditProductPresenter(IStateManager manager, Product productToEdit, ProductManager productManager) : base(manager)
        {
            this.ProductToEdit = productToEdit;
            this.ProductManager = productManager;
            this.Form = (ISpecificProductView)FormFactory.CreateForm("SpecificProductForm", new object[] { this });
            List<Category> categories = this.ProductManager.GetCategories();

            this.Form.ProductName = productToEdit.ProductName;
            this.Form.DisplayCategories(categories);
            this.Form.SelectedCategory = categories.Where(c => c.Id == productToEdit.CategoryId).FirstOrDefault();
            this.Form.Quantity = productToEdit.Quantity;
            this.Form.ImportPrice = productToEdit.ImportPrice;
            this.Form.SellPrice = productToEdit.SellPrice;
            this.Form.IsVisible = productToEdit.IsVisible;
        }

        public override void Dispose()
        {
            foreach (var id in base.EventIds)
            {
                base.StateManager.EventManager.RemoveEvent(id);
            }
            this.Form.HideAndDispose();
            base.StateManager.OutputWriter.WriteLine("Edit Product Presenter Disposed!");
        }

        public override void Update()
        {
            if (!base.IsFormShown)
            {
                this.Form.ShowAsDialog();
                base.IsFormShown = true;
            }
        }

        public void Cancel()
        {
            if (!this.IsFormCancelled)
            {
                base.StateManager.Pop();
                this.IsFormCancelled = true;
            }

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
                Quantity = this.Form.Quantity,
                Id = this.ProductToEdit.Id,
            };
            try
            {
                this.ProductManager.UpdateProduct(product, this.ProductToEdit.ProductName != product.ProductName);
                this.ProductManager.DisplayProducts();
                this.Cancel();
            }
            catch (ArgumentException e)
            {
                base.StateManager.Push(new ErrorPresenter(base.StateManager, e.Message, true));
            }
        }
    }
}
