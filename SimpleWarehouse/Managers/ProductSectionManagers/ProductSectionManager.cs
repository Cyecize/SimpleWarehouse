using SimpleWarehouse.Constants;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWarehouse.Managers.ProductSectionManagers
{
    public class ProductSectionManager
    {
        private HomePresenter Presenter;

        public IProductsRepositoryManager ProductsManager { get; set; }
        public ICategoriesRepositoryManager CategoriesManager { get; set; }
        public IProductViewManager ProductViewManager { get; set; }

        public ProductSectionManager(IMySqlManager sqlManager, DataGridView dataGridView, HomePresenter presenter)
        {
            this.ProductsManager = new ProductRepositoryManager(sqlManager);
            this.CategoriesManager = new CategoryRepositoryManager(sqlManager);
            this.ProductViewManager = new ProductViewManager(dataGridView);
            this.Presenter = presenter;
        }

        //functionality

        public void UpdateProducts()
        {
            this.ProductViewManager.DisplayProducts(this.ProductsManager.FindAll());
        }

        //actions

        public void SelectProductAction()
        {
            this.ProductViewManager.SelectProduct();
        }

        public void SearchProdAction()
        {
            List<Product> prods = this.ProductsManager.Search(this.Presenter.Form.SearchText, this.ProductViewManager.SearchParam);
            this.ProductViewManager.DisplayProducts(prods);
        }

        public void ChangeSearchParamAction()
        {
            this.ProductViewManager.ChangeSearchParam(this.Presenter.Form.SearchParameter);
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
                product = this.ProductsManager.GetProductForEdit(this.ProductViewManager.GetSelectedProductId());
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
