using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Services;
using SimpleWarehouse.Services.ProductSectionManagers;
using SimpleWarehouse.Model;
using SimpleWarehouse.Presenter.ProductSpecificPresenters;
using SimpleWarehouse.View;
using System.Windows.Forms;

namespace SimpleWarehouse.Presenter
{
    public class EditProductPresenter : AbstractPresenter, IProductSpecificPresenter
    {
        private ProductSectionManager ProductSectionManager;
        private ISpecificProductView Form;
        private bool IsFormCancelled;
        private Product ProductToEdit;

        public EditProductPresenter(IStateManager manager, Product productToEdit, ProductSectionManager productManager) : base(manager)
        {
            this.ProductToEdit = productToEdit;
            this.ProductSectionManager = productManager;
            this.Form = (ISpecificProductView)FormFactory.CreateForm("SpecificProductForm", new object[] { this });
            List<Category> categories = this.ProductSectionManager.CategoriesManager.GetCategories();
            ((Form)this.Form).FormClosing += (e, s) => this.Cancel();

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
                if (base.StateManager.IsPresenterActive(this))
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
                this.ProductSectionManager.ProductsManager.UpdateProduct(product, this.ProductToEdit.ProductName != product.ProductName);
                this.ProductSectionManager.UpdateProducts();
                this.Cancel();
            }
            catch (ArgumentException e)
            {
                base.StateManager.Push(new ErrorPresenter(base.StateManager, e.Message, true));
            }
        }
    }
}
