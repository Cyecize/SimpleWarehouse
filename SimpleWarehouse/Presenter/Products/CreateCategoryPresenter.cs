using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Sections.Products;
using SimpleWarehouse.Services.Products;
using SimpleWarehouse.View;

namespace SimpleWarehouse.Presenter.Products
{
    class CreateCategoryPresenter : AbstractPresenter, ISubmitablePresenter
    {
        private const string CategoryWasNotCreated = "Имаше проблем със създаването на категорията";
        private ProductSection ProductSection { get; set; }
        private IAddCategoryView Form { get; set; }

        public override ILoggable Loggable { get => Form; }

        private bool IsFormCancelled;

        public CreateCategoryPresenter(IStateManager manager, ProductSection productSection) : base(manager)
        {
            this.IsFormCancelled = false;
            this.Form = (IAddCategoryView) FormFactory.CreateForm("SpecificCategoryForm", new object[] {this});
            this.ProductSection = productSection;
            List<Category> categories = this.ProductSection.CategoryService.FindAll();
            categories.Insert(0, new Category() {CategoryName = "ГЛАВНА!", Id = 0});
            this.Form.DisplayCategories(categories);
            this.Form.SelectedCategory = categories[0];
            ((Form) this.Form).FormClosing += (e, s) => this.Cancel();
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
            base.StateManager.OutputWriter.WriteLine("New Category StreamPresenter Disposed!");
        }

        public void Submit()
        {
            Category category = new Category();
            category.CategoryName = this.Form.CategoryName;
            if (this.Form.SelectedCategory.Id > 0)
                category.ParentId = this.Form.SelectedCategory.Id;

            if (this.ProductSection.CategoryService.CreateCategory(category))
            {
                this.Cancel();
                return;
            }
            this.Form.Log(CategoryWasNotCreated);
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