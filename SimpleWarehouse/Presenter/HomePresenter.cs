using SimpleWarehouse.App;
using SimpleWarehouse.Constants;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Managers;
using SimpleWarehouse.Model;
using SimpleWarehouse.Service;
using SimpleWarehouse.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWarehouse.Presenter
{
    public class HomePresenter : AbstractPresenter
    {
        private IHomeView Form { get; set; }
        private IEntityRepository<User> OnlineUserRepo;
        private ProductManager ProductManager;
        private bool IsProductsDisplayed;

        public HomePresenter(IStateManager mangaer) : base(mangaer)
        {
            this.OnlineUserRepo = new EntityRepo<User>(base.StateManager.SqlManager, base.StateManager.OutputWriter);
            this.Form = (IHomeView)FormFactory.CreateForm("MainForm", new object[] { this });
            //onClosingEvent to stopp the application
            ((Form)(this.Form)).FormClosing += (sender, args) => ApplicationState.IsRunning = false;
            this.ProductManager = new ProductManager(this.Form.DataTable, base.StateManager.SqlManager);

            base.StateManager.EventManager.AddEvent(new Event(
                Constants.Config.EVENT_LISTENER_IMMEDIEATE,
                CheckIsLoginHandler,
                base.GetStateManager().EventManager,
                true));

            this.IsProductsDisplayed = false;
            this.Form.SetSearchParams(this.ProductManager.GetSearchParameters());
            if (!base.StateManager.UserSession.IsActive)//prevent any actions till login
                return;
        }

        //---->main functionality

        //product section
      
        public void SelectProduct()
        {
            this.ProductManager.SelectProduct();
        }

        public void AddNewProductAction()
        {
            if (!Roles.IsRequredRoleMet(base.StateManager.UserSession.SessionEntity.Role, Constants.Config.USER_TYPICAL_ROLE))
            {
                base.StateManager.Push(new ErrorPresenter(base.StateManager, Messages.NOT_AUTHORIZED_MSG));
                return;
            }
            base.StateManager.Push(new NewProductPresenter(base.StateManager, this.ProductManager)); 
        }

        public void EditProductRequest()
        {
            if (!Roles.IsRequredRoleMet(base.StateManager.UserSession.SessionEntity.Role, Constants.Config.USER_TYPICAL_ROLE))
            {
                base.StateManager.Push(new ErrorPresenter(base.StateManager, Messages.NOT_AUTHORIZED_MSG));
                return;
            }
            try
            {
                this.ProductManager.GetProductForEdit();
            }
            catch (ArgumentException e)
            {
                base.StateManager.Push(new ErrorPresenter(base.StateManager, e.Message));
                return;
            }
            Product product = this.ProductManager.GetProductForEdit();
            base.StateManager.Push(new EditProductPresenter(base.StateManager, product, this.ProductManager));

        }

        public void AddNewCategoryAction()
        {
            base.StateManager.Push(new NewCategoryPresenter(base.StateManager, this.ProductManager));
        }

        public void SearchProd()
        {
            this.ProductManager.Search(this.Form.SearchText);
        }

        public void ChangeSearchParam()
        {
            this.ProductManager.ChangeSearchParam(this.Form.SearchParameter);
        }
        //end product section

        public void Refresh()
        {
            base.StateManager.Set(new HomePresenter(base.StateManager));
        }

        public void Logout()
        {
            base.StateManager.UserSession.IsActive = false;
            this.Refresh();
        }

        //---->overrides
        public override void Dispose()
        {
            foreach (var id in base.EventIds)
            {
                base.StateManager.EventManager.RemoveEvent(id);
            }
            this.Form.HideAndDispose();
            base.StateManager.OutputWriter.WriteLine("Home Presenter Disposed!");
        }

        public override void Update()
        {
            if (!base.IsFormShown)
            {
                this.Form.Show();
                base.IsFormShown = true;
            }
            if (!this.IsProductsDisplayed && base.StateManager.UserSession.SessionEntity != null)
            {
                this.ProductManager.DisplayProducts();
                this.IsProductsDisplayed = true;
            }

        }


        //event handlers
        private void CheckIsLoginHandler()
        {
            if (!base.StateManager.UserSession.IsActive)
            {
                base.StateManager.OutputWriter.WriteLine("User is not Logged in, redirecting to login view");
                base.StateManager.Push(new LoginPresenter(base.StateManager));
            }
            else
                base.StateManager.OutputWriter.WriteLine($"Player logges as {base.StateManager.UserSession.SessionEntity.Username}");
        }

        //private methods


    }
}
