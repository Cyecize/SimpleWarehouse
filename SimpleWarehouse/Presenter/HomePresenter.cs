using SimpleWarehouse.App;
using SimpleWarehouse.Constants;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;

using SimpleWarehouse.Model;
using SimpleWarehouse.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleWarehouse.Presenter.Other;
using SimpleWarehouse.Presenter.Revenues;
using SimpleWarehouse.Repository;
using SimpleWarehouse.Sections.Operations;
using SimpleWarehouse.Sections.Products;
using SimpleWarehouse.Sections.Revisions;
using SimpleWarehouse.Sections.Settings;
using SimpleWarehouse.Sections.Transactions;

namespace SimpleWarehouse.Presenter
{
    public class HomePresenter : AbstractPresenter
    {
        private const string UserNotLoggedIn = "User is not Logged in, redirecting to login view";  
        private const string Tab1LabelText = "Продукти";  

        private bool IsProductsDisplayed;

        public ProductSection ProductSection { get; set; }

        public SettingsSection SettingsSection { get; set; }

        public IHomeView Form { get; set; }

        public override ILoggable Loggable { get => Form; }

        public IOperationsSection DeliveriesSection { get; set; }

        public IOperationsSection SalesSection { get; set; }

        public IRevisionSection RevisionSection { get; set; }

        public EditTransactionSection EditTransactionSection { get; set; }

        public HomePresenter(IStateManager manager) : base(manager)
        {
            this.Form = (IHomeView)FormFactory.CreateForm("MainForm", new object[] { this });
            //onClosingEvent to stop the application
            ((Form)(this.Form)).FormClosing += (sender, args) => ApplicationState.IsRunning = false;
            this.ProductSection = new ProductSection(this.Form.ProductDataTable, this, this.Form);
            this.SettingsSection = new SettingsSection(this);

            base.StateManager.EventManager.AddEvent(new Event(
                Constants.Config.EventListenerImmediate,
                CheckIsLoginHandler,
                base.GetStateManager().EventManager,
                true));

            this.IsProductsDisplayed = false;
            this.Form.TabLabelText = Tab1LabelText;
            this.Form.SetSearchParams(this.ProductSection.GetSearchParameters());

            

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
                case TabPageNames.TRANSACTIONS_TAB:
                    res = "Транзакции";
                    break;
                case TabPageNames.SETTINGS_TAB:
                    res = "Настройки";
                    break;
            }
            this.Form.TabLabelText = res;
        }

        public void RevenueAction()
        {
            if (Roles.IsStandard(base.StateManager.UserSession.SessionEntity.Roles))
            {
                if (base.StateManager.IsPresenterActive(this))
                    base.StateManager.Set(new RevenuePresenter(base.StateManager));
            }
        }

        public void ExpensesAction()
        {
            if (Roles.IsStandard(base.StateManager.UserSession.SessionEntity.Roles))
            {
                if (base.StateManager.IsPresenterActive(this))
                    base.StateManager.Set(new ExpensesPresenter(base.StateManager));
            }
        }

        public void RefreshAction()
        {
            base.StateManager.Database = new DatabaseContext(base.StateManager.ConnectionManager.GetConnection(), false);
            if (base.StateManager.IsPresenterPresent(this))
                base.StateManager.SetAndFix(new HomePresenter(base.StateManager));
        }

        public void LogoutAction()
        {
            base.StateManager.UserSession.IsActive = false;
            this.RefreshAction();
        }

        public void ClearLogAction()
        {
            base.EventIds.Add(base.StateManager.EventManager.AddEvent(new Event(10000, () => { this.Form.Log(""); }, base.StateManager.EventManager,true )));
        }

        ////---->overrides
        public override void Dispose()
        {
            foreach (var id in base.EventIds)
            {
                base.StateManager.EventManager.RemoveEvent(id);
            }
            this.Form.HideAndDispose();
            base.StateManager.OutputWriter.WriteLine("Home StreamPresenter Disposed!");
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
                if (Roles.IsStandard(base.StateManager.UserSession.SessionEntity.Roles))
                {
                    this.Form.EnableOrDisableMaterialBtn("RevenueBtn", true);
                    this.Form.EnableOrDisableMaterialBtn("InvoicesBtn", true);
                    this.Form.EnableOrDisableMaterialBtn("ExpensesBtn", true);
                }
                this.Form.Text = $"Simple Warehouse, Потребител: {base.StateManager.UserSession.SessionEntity.Username} ({string.Join(",", base.StateManager.UserSession.SessionEntity.Roles.Select(r => r.RoleType.ToString()))})";
                this.InitializeUserRequiredSections();
            }
        }

        //event handlers
        private void CheckIsLoginHandler()
        {
            if (!base.StateManager.UserSession.IsActive)
            {
                base.StateManager.OutputWriter.WriteLine(UserNotLoggedIn);
                base.StateManager.Push(new LoginPresenter(base.StateManager));
            }
            else
                base.StateManager.OutputWriter.WriteLine($"Player logged as {base.StateManager.UserSession.SessionEntity.Username}");
        }

        //private methods
        private void InitializeUserRequiredSections()
        {
            this.DeliveriesSection = new DeliverySection(
                this, this.Form.DeliveriesTab, this.Form.DeliveriesDataTable, this.Form.TotalDeliveryMoney);
            this.SalesSection = new SaleSection(
                this, this.Form.SalesTab, this.Form.SalesDataTable, this.Form.TotalSaleMoney);
            this.EditTransactionSection = new EditTransactionSection(this, this.Form);
            this.RevisionSection = new RevisionSection(this, this.Form);
            this.DeliveriesSection.Initialize();
            this.SalesSection.Initialize();
            this.RevisionSection.Initialize();
        }
    }
}
