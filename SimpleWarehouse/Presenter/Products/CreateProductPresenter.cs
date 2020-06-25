using System;
using System.Windows.Forms;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Presenter.Other;
using SimpleWarehouse.Sections.Products;
using SimpleWarehouse.View;

namespace SimpleWarehouse.Presenter.Products
{
    internal class CreateProductPresenter : AbstractPresenter, ISubmitablePresenter
    {
        private bool IsFormCancelled;

        public CreateProductPresenter(IStateManager manager, ProductSection product) : base(manager)
        {
            IsFormCancelled = false;
            ProductSection = product;
            Form = (ISpecificProductView) FormFactory.CreateForm("SpecificProductForm", new object[] {this});
            ((Form) Form).FormClosing += (sen, e) => Cancel();
            Form.DisplayCategories(ProductSection.CategoryService.FindAll());
        }

        private ProductSection ProductSection { get; }
        private ISpecificProductView Form { get; }

        public override ILoggable Loggable => Form;

        public void Cancel()
        {
            if (!IsFormCancelled)
            {
                StateManager.Pop();
                IsFormCancelled = true;
            }
        }

        public void Submit()
        {
            var product = new Product
            {
                ProductName = Form.ProductName,
                CategoryId = Form.SelectedCategory.Id,
                IsVisible = Form.IsVisible,
                ImportPrice = Form.ImportPrice,
                SellPrice = Form.SellPrice,
                Quantity = Form.Quantity
            };
            try
            {
                ProductSection.AddNewProductAction(product);
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
            StateManager.OutputWriter.WriteLine("New Product StreamPresenter Disposed!");
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