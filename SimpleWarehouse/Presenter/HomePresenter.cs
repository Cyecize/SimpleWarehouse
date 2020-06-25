using System.Linq;
using System.Windows.Forms;
using SimpleWarehouse.App;
using SimpleWarehouse.Constants;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Presenter.Other;
using SimpleWarehouse.Presenter.Revenues;
using SimpleWarehouse.Repository;
using SimpleWarehouse.Sections.Operations;
using SimpleWarehouse.Sections.Products;
using SimpleWarehouse.Sections.Revisions;
using SimpleWarehouse.Sections.Settings;
using SimpleWarehouse.Sections.Transactions;
using SimpleWarehouse.View;

namespace SimpleWarehouse.Presenter
{
    public class HomePresenter : AbstractPresenter
    {
        private const string UserNotLoggedIn = "User is not Logged in, redirecting to login view";
        private const string Tab1LabelText = "Продукти";

        private bool IsProductsDisplayed;

        public HomePresenter(IStateManager manager) : base(manager)
        {
            Form = (IHomeView) FormFactory.CreateForm("MainForm", new object[] {this});
            //onClosingEvent to stop the application
            ((Form) Form).FormClosing += (sender, args) => ApplicationState.IsRunning = false;
            ProductSection = new ProductSection(Form.ProductDataTable, this, Form);
            SettingsSection = new SettingsSection(this);

            StateManager.EventManager.AddEvent(new Event(
                Config.EventListenerImmediate,
                CheckIsLoginHandler,
                GetStateManager().EventManager,
                true));

            IsProductsDisplayed = false;
            Form.TabLabelText = Tab1LabelText;
            Form.SetSearchParams(ProductSection.GetSearchParameters());


            if (!StateManager.UserSession.IsActive) //prevent any actions till login
                return;
        }

        public ProductSection ProductSection { get; set; }

        public SettingsSection SettingsSection { get; set; }

        public IHomeView Form { get; set; }

        public override ILoggable Loggable => Form;

        public IOperationsSection DeliveriesSection { get; set; }

        public IOperationsSection SalesSection { get; set; }

        public IRevisionSection RevisionSection { get; set; }

        public EditTransactionSection EditTransactionSection { get; set; }

        //---->main functionality
        public void OnTabChangeAction()
        {
            var tab = Form.SelectedTabPage;
            var res = "";
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

            Form.TabLabelText = res;
        }

        public void RevenueAction()
        {
            if (Roles.IsStandard(StateManager.UserSession.SessionEntity.Roles))
                if (StateManager.IsPresenterActive(this))
                    StateManager.Set(new RevenuePresenter(StateManager));
        }

        public void ExpensesAction()
        {
            if (Roles.IsStandard(StateManager.UserSession.SessionEntity.Roles))
                if (StateManager.IsPresenterActive(this))
                    StateManager.Set(new ExpensesPresenter(StateManager));
        }

        public void RefreshAction()
        {
            StateManager.Database = new DatabaseContext(StateManager.ConnectionManager.GetConnection(), false);
            if (StateManager.IsPresenterPresent(this))
                StateManager.SetAndFix(new HomePresenter(StateManager));
        }

        public void LogoutAction()
        {
            StateManager.UserSession.IsActive = false;
            RefreshAction();
        }

        public void ClearLogAction()
        {
            EventIds.Add(StateManager.EventManager.AddEvent(new Event(10000, () => { Form.Log(""); },
                StateManager.EventManager, true)));
        }

        ////---->overrides
        public override void Dispose()
        {
            foreach (var id in EventIds) StateManager.EventManager.RemoveEvent(id);
            Form.HideAndDispose();
            StateManager.OutputWriter.WriteLine("Home StreamPresenter Disposed!");
        }

        public override void Update()
        {
            if (!IsFormShown)
            {
                Form.Show();
                IsFormShown = true;
            }

            if (!IsProductsDisplayed && StateManager.UserSession.SessionEntity != null)
            {
                ProductSection.UpdateProducts();
                IsProductsDisplayed = true;
                if (Roles.IsStandard(StateManager.UserSession.SessionEntity.Roles))
                {
                    Form.EnableOrDisableMaterialBtn("RevenueBtn", true);
                    Form.EnableOrDisableMaterialBtn("InvoicesBtn", true);
                    Form.EnableOrDisableMaterialBtn("ExpensesBtn", true);
                }

                Form.Text =
                    $"Simple Warehouse, Потребител: {StateManager.UserSession.SessionEntity.Username} ({string.Join(",", StateManager.UserSession.SessionEntity.Roles.Select(r => r.RoleType.ToString()))})";
                InitializeUserRequiredSections();
            }
        }

        //event handlers
        private void CheckIsLoginHandler()
        {
            if (!StateManager.UserSession.IsActive)
            {
                StateManager.OutputWriter.WriteLine(UserNotLoggedIn);
                StateManager.Push(new LoginPresenter(StateManager));
            }
            else
            {
                StateManager.OutputWriter.WriteLine(
                    $"Player logged as {StateManager.UserSession.SessionEntity.Username}");
            }
        }

        //private methods
        private void InitializeUserRequiredSections()
        {
            DeliveriesSection = new DeliverySection(
                this, Form.DeliveriesTab, Form.DeliveriesDataTable, Form.TotalDeliveryMoney);
            SalesSection = new SaleSection(
                this, Form.SalesTab, Form.SalesDataTable, Form.TotalSaleMoney);
            EditTransactionSection = new EditTransactionSection(this, Form);
            RevisionSection = new RevisionSection(this, Form);
            DeliveriesSection.Initialize();
            SalesSection.Initialize();
            RevisionSection.Initialize();
        }
    }
}