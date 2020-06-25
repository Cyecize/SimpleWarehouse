using System.Windows.Forms;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Sections.Products;
using SimpleWarehouse.View;

namespace SimpleWarehouse.Presenter.Products
{
    internal class CreateCategoryPresenter : AbstractPresenter, ISubmitablePresenter
    {
        private const string CategoryWasNotCreated = "Имаше проблем със създаването на категорията";

        private bool IsFormCancelled;

        public CreateCategoryPresenter(IStateManager manager, ProductSection productSection) : base(manager)
        {
            IsFormCancelled = false;
            Form = (IAddCategoryView) FormFactory.CreateForm("SpecificCategoryForm", new object[] {this});
            ProductSection = productSection;
            var categories = ProductSection.CategoryService.FindAll();
            categories.Insert(0, new Category {CategoryName = "ГЛАВНА!", Id = 0});
            Form.DisplayCategories(categories);
            Form.SelectedCategory = categories[0];
            ((Form) Form).FormClosing += (e, s) => Cancel();
        }

        private ProductSection ProductSection { get; }
        private IAddCategoryView Form { get; }

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
            var category = new Category();
            category.CategoryName = Form.CategoryName;
            if (Form.SelectedCategory.Id > 0)
                category.ParentId = Form.SelectedCategory.Id;

            if (ProductSection.CategoryService.CreateCategory(category))
            {
                Cancel();
                return;
            }

            Form.Log(CategoryWasNotCreated);
        }

        public override void Dispose()
        {
            foreach (var id in EventIds) StateManager.EventManager.RemoveEvent(id);

            Form.HideAndDispose();
            StateManager.OutputWriter.WriteLine("New Category StreamPresenter Disposed!");
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