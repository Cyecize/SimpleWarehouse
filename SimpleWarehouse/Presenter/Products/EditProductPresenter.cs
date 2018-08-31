using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Presenter.Other;
using SimpleWarehouse.Sections.Products;
using SimpleWarehouse.View;

namespace SimpleWarehouse.Presenter.Products
{
    public class EditProductPresenter : AbstractPresenter, ISubmitablePresenter
    {
        private ProductSection ProductSection { get; set; }

        private ISpecificProductView Form { get; set; }

        public override ILoggable Loggable { get => Form; }

        private bool IsFormCancelled;

        private Product ProductToEdit { get; set; }

        public EditProductPresenter(IStateManager manager, Product productToEdit, ProductSection product) : base(manager)
        {
            this.ProductToEdit = productToEdit;
            this.ProductSection = product;
            this.Form = (ISpecificProductView)FormFactory.CreateForm("SpecificProductForm", new object[] { this });
            List<Category> categories = this.ProductSection.CategoryService.FindAll();
            ((Form)this.Form).FormClosing += (e, s) => this.Cancel();

            this.Form.ProductName = productToEdit.ProductName;
            this.Form.DisplayCategories(categories);
            this.Form.SelectedCategory = categories.FirstOrDefault(c => c.Id == productToEdit.CategoryId);
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
            base.StateManager.OutputWriter.WriteLine("Edit Product StreamPresenter Disposed!");
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
            this.ProductToEdit.ProductName = this.Form.ProductName;
            this.ProductToEdit.CategoryId = this.Form.SelectedCategory.Id;
            this.ProductToEdit.IsVisible = this.Form.IsVisible;
            this.ProductToEdit.ImportPrice = this.Form.ImportPrice;
            this.ProductToEdit.SellPrice = this.Form.SellPrice;
            this.ProductToEdit.Quantity = this.Form.Quantity;
         
            try
            {
                this.ProductSection.EditProductAction(this.ProductToEdit);
                this.ProductSection.UpdateProducts();
                this.Cancel();
            }
            catch (ArgumentException e)
            {
                base.StateManager.Push(new ErrorPresenter(base.StateManager, e.Message, true));
            }
        }
    }
}

