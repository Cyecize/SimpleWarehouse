using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SimpleWarehouse.Constants;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Presenter.Other;
using SimpleWarehouse.Presenter.Products;
using SimpleWarehouse.Services.Products;
using SimpleWarehouse.View;

namespace SimpleWarehouse.Sections.Products
{
    public class ProductSection
    {
        public ProductSection(DataGridView dataGridView, IPresenter presenter, ISearchProductView form)
        {
            ViewService = new ProductViewService(dataGridView, form);
            ProductDbService = new ProductDbService();
            CategoryService = new CategoryDbService();
            Presenter = presenter;
            Form = form;
        }

        private IPresenter Presenter { get; }
        private ISearchProductView Form { get; }

        public IProductViewService ViewService { get; set; }

        public IProductDbService ProductDbService { get; set; }

        public ICategoryDbService CategoryService { get; set; }

        //functionality
        public void UpdateProducts()
        {
            if (Form.SearchText == string.Empty)
                ViewService.DisplayProducts(ProductDbService.FindAll());
            else
                SearchProdAction();
        }

        public void UpdateVisibleProducts()
        {
            ViewService.DisplayProducts(ProductDbService.SearchVisible("", ProductDbService.GetSearchParameters()[0]));
        }

        //actions
        public void SelectProductAction()
        {
            ViewService.SelectProduct();
        }

        public void SearchProdAction()
        {
            var prods = ProductDbService.Search(Form.SearchText, ViewService.SearchParam);
            ViewService.DisplayProducts(prods);
        }

        public void SearchVisibleProdAction()
        {
            var prods = ProductDbService.SearchVisible(Form.SearchText, ViewService.SearchParam);
            ViewService.DisplayProducts(prods);
        }

        public void ChangeSearchParamAction()
        {
            ViewService.ChangeSearchParam(Form.SearchParameter);
        }

        public bool AddNewProductAction(Product product)
        {
            return ProductDbService.CreateProduct(product);
        }

        public bool AddNewCategoryAction(Category category)
        {
            return CategoryService.CreateCategory(category);
        }

        public bool EditProductAction(Product product)
        {
            return ProductDbService.UpdateProduct(product);
        }

        //requests
        public void AddNewProductRequest()
        {
            if (!Roles.IsStandard(Presenter.GetStateManager().UserSession.SessionEntity.Roles))
            {
                Presenter.GetStateManager()
                    .Push(new ErrorPresenter(Presenter.GetStateManager(), Messages.NotAuthorizedMsg));
                return;
            }

            Presenter.GetStateManager().Push(new CreateProductPresenter(Presenter.GetStateManager(), this));
        }

        public void EditProductRequest()
        {
            Product product;
            if (!Roles.IsStandard(Presenter.GetStateManager().UserSession.SessionEntity.Roles))
            {
                Presenter.GetStateManager()
                    .Push(new ErrorPresenter(Presenter.GetStateManager(), Messages.NotAuthorizedMsg));
                return;
            }

            try
            {
                product = ProductDbService.FindById(ViewService.GetSelectedProductId());
            }
            catch (ArgumentException e)
            {
                Presenter.GetStateManager().Push(new ErrorPresenter(Presenter.GetStateManager(), e.Message));
                return;
            }

            Presenter.GetStateManager().Push(new EditProductPresenter(Presenter.GetStateManager(), product, this));
        }

        public void AddNewCategoryRequest()
        {
            if (!Roles.IsStandard(Presenter.GetStateManager().UserSession.SessionEntity.Roles))
            {
                Presenter.GetStateManager()
                    .Push(new ErrorPresenter(Presenter.GetStateManager(), Messages.NotAuthorizedMsg));
                return;
            }

            Presenter.GetStateManager().Push(new CreateCategoryPresenter(Presenter.GetStateManager(), this));
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
            return ProductDbService.GetSearchParameters();
        }
    }
}