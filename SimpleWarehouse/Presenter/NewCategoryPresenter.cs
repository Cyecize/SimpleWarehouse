using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Services.ProductSectionManagers;
using SimpleWarehouse.Model;
using SimpleWarehouse.Presenter.ProductSpecificPresenters;
using SimpleWarehouse.View;

namespace SimpleWarehouse.Presenter
{
    public class NewCategoryPresenter : AbstractPresenter, IProductSpecificPresenter
    {
        private ProductSectionManager ProductSectionManager;
        private IAddCategoryView Form;
        private bool IsFormCancelled;

        public NewCategoryPresenter(IStateManager manager, ProductSectionManager product) : base(manager)
        {
            this.IsFormCancelled = false;
            this.Form = (IAddCategoryView)FormFactory.CreateForm("SpecificCategoryForm", new object[] { this });
            this.ProductSectionManager = product;
            List<Category> categories = this.ProductSectionManager.CategoriesManager.GetCategories();
            categories.Insert(0, new Category() { CategoryName = "ГЛАВНА!", Id = 0 });
            this.Form.DisplayCategories(categories);
            this.Form.SelectedCategory = categories[0];
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
            base.StateManager.OutputWriter.WriteLine("New Category Presenter Disposed!");
        }

        public void Submit()
        {
            Category category = new Category() { CategoryName = this.Form.CategoryName, ParantId = this.Form.SelectedCategory.Id };
            try
            {
                this.ProductSectionManager.CategoriesManager.CreateCategory(category);
                this.Cancel();
            }catch(ArgumentException e)
            {
                this.Form.Log(e.Message);
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
