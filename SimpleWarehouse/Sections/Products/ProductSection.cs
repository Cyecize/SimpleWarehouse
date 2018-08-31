using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleWarehouse.Constants;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Presenter;
using SimpleWarehouse.Presenter.Other;
using SimpleWarehouse.Presenter.Products;
using SimpleWarehouse.Repository;
using SimpleWarehouse.Services.Products;
using SimpleWarehouse.View;

namespace SimpleWarehouse.Sections.Products
{
    public class ProductSection
    {
        private IPresenter Presenter { get; set; }
        private ISearchProductView Form { get; set; }

        public IProductViewService ViewService { get; set; }

        public IProductDbService ProductDbService { get; set; }

        public ICategoryDbService CategoryService { get; set; }

        public ProductSection( DataGridView dataGridView, IPresenter presenter, ISearchProductView form)
        {      
            this.ViewService = new ProductViewService(dataGridView, form);
            this.ProductDbService = new ProductDbService();
            this.CategoryService  = new CategoryDbService();
            this.Presenter = presenter;
            this.Form = form;
        }

        //functionality
        public void UpdateProducts()
        {
            if (this.Form.SearchText == string.Empty)
                this.ViewService.DisplayProducts(this.ProductDbService.FindAll());
            else
                this.SearchProdAction();
        }

        public void UpdateVisibleProducts()
        {
            this.ViewService.DisplayProducts(this.ProductDbService.SearchVisible("", this.ProductDbService.GetSearchParameters()[0]));
        }

        //actions
        public void SelectProductAction()
        {
            this.ViewService.SelectProduct();
        }

        public void SearchProdAction()
        {
            List<Product> prods = this.ProductDbService.Search(this.Form.SearchText, this.ViewService.SearchParam);
            this.ViewService.DisplayProducts(prods);
        }

        public void SearchVisibleProdAction()
        {
            List<Product> prods = this.ProductDbService.SearchVisible(this.Form.SearchText, this.ViewService.SearchParam);
            this.ViewService.DisplayProducts(prods);
        }

        public void ChangeSearchParamAction()
        {
            this.ViewService.ChangeSearchParam(this.Form.SearchParameter);
        }

        public bool AddNewProductAction(Product product)
        {
            return this.ProductDbService.CreateProduct(product);
        }

        public bool AddNewCategoryAction(Category category)
        {
            return this.CategoryService.CreateCategory(category);
        }

        public bool EditProductAction(Product product)
        {
            return this.ProductDbService.UpdateProduct(product);
        }

        //requests
        public void AddNewProductRequest()
        {
            if (!Roles.IsStandard(this.Presenter.GetStateManager().UserSession.SessionEntity.Roles))
            {
                this.Presenter.GetStateManager().Push(new ErrorPresenter(this.Presenter.GetStateManager(), Messages.NotAuthorizedMsg));
                return;
            }
            this.Presenter.GetStateManager().Push(new CreateProductPresenter(this.Presenter.GetStateManager(), this));
        }

        public void EditProductRequest()
        {
            Product product;
            if (!Roles.IsStandard(this.Presenter.GetStateManager().UserSession.SessionEntity.Roles))
            {
                this.Presenter.GetStateManager().Push(new ErrorPresenter(this.Presenter.GetStateManager(), Messages.NotAuthorizedMsg));
                return;
            }
            try
            {   
                product = this.ProductDbService.FindById(this.ViewService.GetSelectedProductId());
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
            if (!Roles.IsStandard(this.Presenter.GetStateManager().UserSession.SessionEntity.Roles))
            {
                this.Presenter.GetStateManager().Push(new ErrorPresenter(this.Presenter.GetStateManager(), Messages.NotAuthorizedMsg));
                return;
            }
            this.Presenter.GetStateManager().Push(new CreateCategoryPresenter(this.Presenter.GetStateManager(), this));
        }

     
        public void AddRevenueRequest()
        {
            //if (!Roles.IsStandard(this.Presenter.GetStateManager().UserSession.SessionEntity.Roles))
            //{
            //    this.Presenter.GetStateManager().Push(new ErrorPresenter(this.Presenter.GetStateManager(), Messages.NOT_AUTHORIZED_MSG));
            //    return;
            //}
            //this.Presenter.GetStateManager().Push(n);
        }

        public List<SearchParameter> GetSearchParameters()
        {
            return this.ProductDbService.GetSearchParameters();
        }
    }
}