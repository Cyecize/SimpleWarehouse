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
using SimpleWarehouse.Presenter.RevenueRelated;
using SimpleWarehouse.Services.TransactionServices;

namespace SimpleWarehouse.Presenter
{
    public class HomePresenter : AbstractPresenter
    {

        private IEntityRepository<User> OnlineUserRepo;
        private bool IsProductsDisplayed;

        public ProductSectionManager ProductSection { get; set; }
        public IHomeView Form { get; set; }

        public ITransactionSection DeliveriesSection { get; set; }
        public ITransactionSection SalesSection { get; set; }

        public HomePresenter(IStateManager mangaer) : base(mangaer)
        {
            this.OnlineUserRepo = new EntityRepo<User>(base.StateManager.SqlManager, base.StateManager.OutputWriter);
            this.Form = (IHomeView)FormFactory.CreateForm("MainForm", new object[] { this });
            //onClosingEvent to stopp the application
            ((Form)(this.Form)).FormClosing += (sender, args) => ApplicationState.IsRunning = false;
            this.ProductSection = new ProductSectionManager(base.StateManager.SqlManager, this.Form.ProductDataTable, this, this.Form);

            base.StateManager.EventManager.AddEvent(new Event(
                Constants.Config.EVENT_LISTENER_IMMEDIEATE,
                CheckIsLoginHandler,
                base.GetStateManager().EventManager,
                true));

            this.IsProductsDisplayed = false;

            this.Form.TabLabelText = "Продукти";
            this.Form.SetSearchParams(this.ProductSection.ProductsManager.GetSearchParameters());
            if (!base.StateManager.UserSession.IsActive)//prevent any actions till login
                return;

        }

        //---->main functionality

        public void OnTabChangeAction()
        {
            TabPage tab = this.Form.SelectedTabPage;
            string res = "";
            switch (tab.Name)
            {
                case TabPageNames.PRODUCT_PAGE:
                    res = "Продукти";
                    break;
                case TabPageNames.DELIVERIES_PAGE:
                    res = "Доставки";
                    break;
                case TabPageNames.SALES_PAGE:
                    res = "Продажби";
                    break;
                case TabPageNames.REVISION_TAB:
                    res = "Ревизия";
                    break;
            }
            this.Form.TabLabelText = res;
        }

        public void RevenueAction()
        {
            if (Roles.IsRequredRoleMet(base.StateManager.UserSession.SessionEntity.Role, Config.USER_TYPICAL_ROLE))
            {
                if (base.StateManager.IsPresenterActive(this))
                    base.StateManager.Set(new RevenuePresenter(base.StateManager));
            }
        }

        public void InvoicesAction()
        {
            if (Roles.IsRequredRoleMet(base.StateManager.UserSession.SessionEntity.Role, Config.USER_TYPICAL_ROLE))
            {
                if (base.StateManager.IsPresenterActive(this))
                    base.StateManager.Set(new InvoicesPresenter(base.StateManager));
            }
        }

        public void ExpensesAction()
        {
            if (Roles.IsRequredRoleMet(base.StateManager.UserSession.SessionEntity.Role, Config.USER_TYPICAL_ROLE))
            {
                if (base.StateManager.IsPresenterActive(this))
                    base.StateManager.Set(new ExpensesPresenter(base.StateManager));
            }
        }

        public void RefreshAction()
        {
            if (base.StateManager.IsPresenterActive(this))
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
                    this.Form.EnableOrDisableMaterialBtn("RevenueBtn", true);
                    this.Form.EnableOrDisableMaterialBtn("InvoicesBtn", true);
                    this.Form.EnableOrDisableMaterialBtn("ExpensesBtn", true);
                }
                this.Form.Text = $"Simple Warehouse, Потребител: {base.StateManager.UserSession.SessionEntity.Username}";
                this.InitializeUserRequiredSections();
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
        private void InitializeUserRequiredSections()
        {
            this.DeliveriesSection = new DeliveryTransactionSection(
                this, this.Form.DeliveriesTab, this.Form.DeliveriesDataTable, new DeliveryTransactionDbManager(base.StateManager.SqlManager, base.StateManager.UserSession.SessionEntity));
            this.SalesSection = new SaleTransactionSection(
                this, this.Form.SalesTab, this.Form.SalesDataTable, new SalesTransactionDbManager(base.StateManager.SqlManager, base.StateManager.UserSession.SessionEntity));
            this.DeliveriesSection.Initialize();
            this.SalesSection.Initialize();
        }
    }
}
