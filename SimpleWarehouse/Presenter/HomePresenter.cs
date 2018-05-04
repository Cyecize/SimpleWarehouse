using SimpleWarehouse.App;
using SimpleWarehouse.Constants;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Services.ProductSectionManagers;
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
       
        private IEntityRepository<User> OnlineUserRepo;
        private bool IsProductsDisplayed;

        public ProductSectionManager ProductSection { get; set; }
        public IHomeView Form { get; set; }

        public HomePresenter(IStateManager mangaer) : base(mangaer)
        {
            this.OnlineUserRepo = new EntityRepo<User>(base.StateManager.SqlManager, base.StateManager.OutputWriter);
            this.Form = (IHomeView)FormFactory.CreateForm("MainForm", new object[] { this });
            //onClosingEvent to stopp the application
            ((Form)(this.Form)).FormClosing += (sender, args) => ApplicationState.IsRunning = false;
            this.ProductSection = new ProductSectionManager(base.StateManager.SqlManager, this.Form.DataTable, this);

            base.StateManager.EventManager.AddEvent(new Event(
                Constants.Config.EVENT_LISTENER_IMMEDIEATE,
                CheckIsLoginHandler,
                base.GetStateManager().EventManager,
                true));

            this.IsProductsDisplayed = false;
            this.Form.SetSearchParams(this.ProductSection.ProductsManager.GetSearchParameters());
            if (!base.StateManager.UserSession.IsActive)//prevent any actions till login
                return;
        }

        //---->main functionality

        //product section

        //requests
        
        //actions
       
        //end product section

        public void RefreshAction()
        {
            base.StateManager.Set(new HomePresenter(base.StateManager));
        }

        public void LogoutAction()
        {
            base.StateManager.UserSession.IsActive = false;
            this.RefreshAction();
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
                this.ProductSection.UpdateProducts();
                this.IsProductsDisplayed = true;
                if (Roles.IsRequredRoleMet(base.StateManager.UserSession.SessionEntity.Role, Constants.Config.USER_TYPICAL_ROLE))
                {
                    this.Form.EnableOrDisableMaterialBtn("AddRevenueBtn", true);
                }
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
