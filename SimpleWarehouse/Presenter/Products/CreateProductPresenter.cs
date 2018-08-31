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
    class CreateProductPresenter : AbstractPresenter, ISubmitablePresenter
    {
        private ProductSection ProductSection { get; set; }
        private ISpecificProductView Form { get; set; }

        public override ILoggable Loggable { get => Form; }

        private bool IsFormCancelled;

        public CreateProductPresenter(IStateManager manager, ProductSection product) : base(manager)
        {
            this.IsFormCancelled = false;
            this.ProductSection = product;
            this.Form = (ISpecificProductView)FormFactory.CreateForm("SpecificProductForm", new object[] { this });
            ((Form)this.Form).FormClosing += (sen, e) => this.Cancel();
            this.Form.DisplayCategories(this.ProductSection.CategoryService.FindAll());
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
            base.StateManager.OutputWriter.WriteLine("New Product StreamPresenter Disposed!");
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
                this.ProductSection.AddNewProductAction(product);
                this.ProductSection.UpdateProducts();
                this.Cancel();
            }
            catch (ArgumentException e)
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
