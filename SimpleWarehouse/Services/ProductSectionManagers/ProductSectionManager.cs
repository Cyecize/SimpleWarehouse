using SimpleWarehouse.Constants;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Presenter;
using SimpleWarehouse.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWarehouse.Services.ProductSectionManagers
{
    public class ProductSectionManager
    {
        private IPresenter Presenter;
        private ISearchProductView Form { get; set; }

        public IProductsRepositoryManager ProductsManager { get; set; }
        public ICategoriesRepositoryManager CategoriesManager { get; set; }
        public IProductViewManager ProductViewManager { get; set; }


        public ProductSectionManager(IMySqlManager sqlManager, DataGridView dataGridView, IPresenter presenter, ISearchProductView form)
        {
            this.ProductsManager = new ProductRepositoryManager(sqlManager);
            this.CategoriesManager = new CategoryRepositoryManager(sqlManager);
            this.ProductViewManager = new ProductViewManager(dataGridView, form);
            this.Presenter = presenter;
            this.Form = form;
        }

        //functionality

        public void UpdateProducts()
        {
            if (this.Form.SearchText == string.Empty)
                this.ProductViewManager.DisplayProducts(this.ProductsManager.FindAllByLimit(Config.LIMIT_FOR_DB_PRODUCTS));
            else
                this.SearchProdAction();
        }

        public void UpdateVisibleProducts()
        {
            this.ProductViewManager.DisplayProducts(this.ProductsManager.SearchVisible("", this.ProductsManager.GetSearchParameters()[0]));
        }

        //actions

        public void SelectProductAction()
        {
            this.ProductViewManager.SelectProduct();
        }

        public void SearchProdAction()
        {
            List<Product> prods = this.ProductsManager.Search(this.Form.SearchText, this.ProductViewManager.SearchParam);
            this.ProductViewManager.DisplayProducts(prods);
        }

        public void SearchVisibleProdAction()
        {
            List<Product> prods = this.ProductsManager.SearchVisible(this.Form.SearchText, this.ProductViewManager.SearchParam);
            this.ProductViewManager.DisplayProducts(prods);
        }

        public void ChangeSearchParamAction()
        {
            this.ProductViewManager.ChangeSearchParam(this.Form.SearchParameter);
        }

        //requests
        public void AddNewProductRequest()
        {
            if (!Roles.IsRequredRoleMet(this.Presenter.GetStateManager().UserSession.SessionEntity.Role, Constants.Config.USER_TYPICAL_ROLE))
            {
                this.Presenter.GetStateManager().Push(new ErrorPresenter(this.Presenter.GetStateManager(), Messages.NOT_AUTHORIZED_MSG));
                return;
            }
            this.Presenter.GetStateManager().Push(new NewProductPresenter(this.Presenter.GetStateManager(), this));
        }

        public void EditProductRequest()
        {
            Product product;
            if (!Roles.IsRequredRoleMet(this.Presenter.GetStateManager().UserSession.SessionEntity.Role, Constants.Config.USER_TYPICAL_ROLE))
            {
                this.Presenter.GetStateManager().Push(new ErrorPresenter(this.Presenter.GetStateManager(), Messages.NOT_AUTHORIZED_MSG));
                return;
            }
            try
            {
                product = this.ProductsManager.FindProductById(this.ProductViewManager.GetSelectedProductId());
            }
            catch (ArgumentException e)
            {
                this.Presenter.GetStateManager().Push(new ErrorPresenter(this.Presenter.GetStateManager(), e.Message));
                return;
            }
            this.Presenter.GetStateManager().Push(new EditProductPresenter(this.Presenter.GetStateManager(), product, this));

        }

        public void AddNewCategoryRequest()
        {
            if (!Roles.IsRequredRoleMet(this.Presenter.GetStateManager().UserSession.SessionEntity.Role, Constants.Config.USER_TYPICAL_ROLE))
            {
                this.Presenter.GetStateManager().Push(new ErrorPresenter(this.Presenter.GetStateManager(), Messages.NOT_AUTHORIZED_MSG));
                return;
            }
            this.Presenter.GetStateManager().Push(new NewCategoryPresenter(this.Presenter.GetStateManager(), this));
        }

        public void AddRevenueRequest()
        {
            if (!Roles.IsRequredRoleMet(this.Presenter.GetStateManager().UserSession.SessionEntity.Role, Constants.Config.USER_TYPICAL_ROLE))
            {
                this.Presenter.GetStateManager().Push(new ErrorPresenter(this.Presenter.GetStateManager(), Messages.NOT_AUTHORIZED_MSG));
                return;
            }
        }

    }
}
