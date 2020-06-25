using System;
using System.Linq;
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
        private bool IsFormCancelled;

        public EditProductPresenter(IStateManager manager, Product productToEdit, ProductSection product) :
            base(manager)
        {
            ProductToEdit = productToEdit;
            ProductSection = product;
            Form = (ISpecificProductView) FormFactory.CreateForm("SpecificProductForm", new object[] {this});
            var categories = ProductSection.CategoryService.FindAll();
            ((Form) Form).FormClosing += (e, s) => Cancel();

            Form.ProductName = productToEdit.ProductName;
            Form.DisplayCategories(categories);
            Form.SelectedCategory = categories.FirstOrDefault(c => c.Id == productToEdit.CategoryId);
            Form.Quantity = productToEdit.Quantity;
            Form.ImportPrice = productToEdit.ImportPrice;
            Form.SellPrice = productToEdit.SellPrice;
            Form.IsVisible = productToEdit.IsVisible;
        }

        private ProductSection ProductSection { get; }

        private ISpecificProductView Form { get; }

        public override ILoggable Loggable => Form;

        private Product ProductToEdit { get; }

        public void Cancel()
        {
            if (!IsFormCancelled)
            {
                if (StateManager.IsPresenterActive(this))
                    StateManager.Pop();
                IsFormCancelled = true;
            }
        }

        public void Submit()
        {
            ProductToEdit.ProductName = Form.ProductName;
            ProductToEdit.CategoryId = Form.SelectedCategory.Id;
            ProductToEdit.IsVisible = Form.IsVisible;
            ProductToEdit.ImportPrice = Form.ImportPrice;
            ProductToEdit.SellPrice = Form.SellPrice;
            ProductToEdit.Quantity = Form.Quantity;

            try
            {
                ProductSection.EditProductAction(ProductToEdit);
                ProductSection.UpdateProducts();
                Cancel();
            }
            catch (ArgumentException e)
            {
                StateManager.Push(new ErrorPresenter(StateManager, e.Message, true));
            }
        }

        public override void Dispose()
        {
            foreach (var id in EventIds) StateManager.EventManager.RemoveEvent(id);
            Form.HideAndDispose();
            StateManager.OutputWriter.WriteLine("Edit Product StreamPresenter Disposed!");
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