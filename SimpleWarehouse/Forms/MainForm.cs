using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MaterialSkin.Controls;
using SimpleWarehouse.Model;
using SimpleWarehouse.Model.Enum;
using SimpleWarehouse.Presenter;
using SimpleWarehouse.View;

namespace SimpleWarehouse.Forms
{
    public partial class MainForm : MaterialForm, IHomeView
    {
        public MainForm(HomePresenter presenter)
        {
            InitializeComponent();
            Presenter = presenter;
            StartPosition = FormStartPosition.CenterScreen;
            InitializeProductSectionEvents();
            materialTabControl1.Selected += (o, e) => { Presenter.OnTabChangeAction(); };
        }

        private HomePresenter Presenter { get; }

        public DataGridView ProductDataTable
        {
            get => DataTableView;
            set => DataTableView = value;
        }

        public string SearchText
        {
            get => SearchBox.Text;
            set => SearchBox.Text = value;
        }

        public SearchParameter SearchParameter => (SearchParameter) SearchType.SelectedItem;

        public DataGridView DeliveriesDataTable
        {
            get => DeliveriesDataGridView;
            set => DeliveriesDataGridView = value;
        }

        public DataGridView SalesDataTable
        {
            get => SalesDataGridView;
            set => SalesDataGridView = value;
        }

        public TabPage SelectedTabPage
        {
            get => materialTabControl1.SelectedTab;
            set => materialTabControl1.SelectedTab = value;
        }

        TabPage IHomeView.DeliveriesTab { get; set; }
        TabPage IHomeView.SalesTab { get; set; }

        public string TabLabelText
        {
            get => CurrentTabLabel.Text;
            set => CurrentTabLabel.Text = value;
        }

        public TextBox TotalDeliveryMoney
        {
            get => DeliveriesTotalMoney;
            set => DeliveriesTotalMoney = value;
        }

        public TextBox TotalSaleMoney
        {
            get => SalesTotalMoney;
            set => SalesTotalMoney = value;
        }

        //REVISION
        public DataGridView RevisionDataTable
        {
            get => RevisionDataGridView;
            set => RevisionDataGridView = value;
        }

        public string RevisionRevenue
        {
            get => RevisionRevenueTextBox.Text;
            set => RevisionRevenueTextBox.Text = value;
        }

        public string RevisionExpenses
        {
            get => RevisionExpensesTextBox.Text;
            set => RevisionExpensesTextBox.Text = value;
        }

        public string RevisionSalesRevenue
        {
            get => RevisionSalesRevenueTextBox.Text;
            set => RevisionSalesRevenueTextBox.Text = value;
        }

        public string RevisionSubTotal
        {
            get => RevisionSubTotalTextBox.Text;
            set => RevisionSubTotalTextBox.Text = value;
        }

        string IRevisionView.RevisionStartDate
        {
            get => RevisionStartDateLabel.Text;
            set => RevisionStartDateLabel.Text = value;
        }

        public string RevisonSubTotalPlusSalesRevenue
        {
            get => RevisionSalesPlusRevisionTotalTextBox.Text;
            set => RevisionSalesPlusRevisionTotalTextBox.Text = value;
        }

        public bool IsTransactionRevised
        {
            get => IsRevisedCheckbox.Checked;
            set => IsRevisedCheckbox.Checked = value;
        }

        public TransactionType SelectedTransactionType
        {
            get => (TransactionType) TransactionTypeBox.SelectedItem;
            set => throw new NotImplementedException();
        }

        public DateTime TransactionStartDate
        {
            get => TransactionStartDateSelector.Value;
            set => TransactionStartDateSelector.Value = value;
        }

        public DateTime TransactionEndtDate
        {
            get => TransactionEndDateSelector.Value;
            set => TransactionEndDateSelector.Value = value;
        }

        public DataGridView TransactionGrid => TransactionGridView;

        public void ShowAsDialog()
        {
            ShowDialog();
        }


        //override

        public void SetSearchParams(List<SearchParameter> searchParameters)
        {
            SearchType.DataSource = searchParameters;
        }

        public void HideAndDispose()
        {
            Hide();
            Dispose();
        }

        public void Log(string message)
        {
            LogLabel.Text = message;
            Presenter.ClearLogAction();
        }


        public void EnableOrDisableElement(string elName, Type elType, bool isEnabled)
        {
            foreach (Control control in Controls)
                if (elType == control.GetType())
                {
                    var btn = (Button) control;
                    if (btn.Name == elName) btn.Enabled = isEnabled;
                }
        }

        public void EnableOrDisableMaterialBtn(string btnName, bool isEnabled)
        {
            EnableOrDisableElement(btnName, typeof(MaterialFlatButton), isEnabled);
        }

        private void MaterialButton1_Click(object sender, EventArgs e)
        {
            Presenter.ProductSection.AddNewProductRequest();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            Presenter.ProductSection.EditProductRequest();
        }

        //events
        private void OnCellClick(object sender, EventArgs e)
        {
            Presenter.ProductSection.SelectProductAction();
        }

        private void OnSearchParamChange(object sender, EventArgs e)
        {
            Presenter.ProductSection.ChangeSearchParamAction();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            Presenter.RefreshAction();
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            Presenter.LogoutAction();
        }

        private void AddCategoryBtn_Click(object sender, EventArgs e)
        {
            Presenter.ProductSection.AddNewCategoryRequest();
        }

        //private logic
        private void RevenueBtn_Click(object sender, EventArgs e)
        {
            Presenter.RevenueAction();
        }

        private void ExpensesBtn_Click(object sender, EventArgs e)
        {
            Presenter.ExpensesAction();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            TransactionTypeBox.Items.Add(TransactionType.SALE);
            TransactionTypeBox.Items.Add(TransactionType.DELIVERY);
            TransactionTypeBox.Select(0, 1);
            TransactionEndDateSelector.Value = DateTime.Now.AddDays(1);
            TransactionStartDateSelector.Value = DateTime.Now.AddDays(-1);
        }

        private void InitializeProductSectionEvents()
        {
            DataTableView.CellClick += OnCellClick;
            DataTableView.AllowUserToAddRows = false;
            SearchBox.TextChanged += (obj, e) => { Presenter.ProductSection.SearchProdAction(); };
            DataTableView.KeyPress += (obj, e) =>
            {
                if (char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == (char) Keys.Space)
                    SearchBox.Text += e.KeyChar;
                if (e.KeyChar == (char) Keys.OemBackslash || e.KeyChar == (char) Keys.Back)
                    if (SearchBox.Text.Length >= 1)
                        SearchBox.Text = SearchBox.Text.Substring(0, SearchBox.Text.Length - 1);
            };
            SearchType.SelectedIndexChanged += OnSearchParamChange;
        }

        private void CancelDeliveryBtn_Click(object sender, EventArgs e)
        {
            Presenter.DeliveriesSection.CancelOperation();
        }

        private void RefreshDeliveriesAction_Click(object sender, EventArgs e)
        {
            Presenter.DeliveriesSection.RefreshGridAction();
        }

        private void SaveDeliveryBtn_Click(object sender, EventArgs e)
        {
            Presenter.DeliveriesSection.CreateTransactionAction();
        }

        private void SaveSaleBtn_Click(object sender, EventArgs e)
        {
            Presenter.SalesSection.CreateTransactionAction();
        }

        private void LogLabel_Click(object sender, EventArgs e)
        {
            ((Label) sender).Text = "";
        }

        private void BeginRevisionBtn_Click(object sender, EventArgs e)
        {
            Presenter.RevisionSection.BeginRevision();
        }

        private void RevisionCancelBtn_Click(object sender, EventArgs e)
        {
            Presenter.RevisionSection.CancelOperation();
        }

        private void RevisionRefreshBtn_Click(object sender, EventArgs e)
        {
            Presenter.RevisionSection.RefreshGridAction();
        }

        private void SalesCancelBtn_Click(object sender, EventArgs e)
        {
            Presenter.SalesSection.CancelOperation();
        }

        private void SalesRefreshBtn_Click(object sender, EventArgs e)
        {
            Presenter.SalesSection.RefreshGridAction();
        }

        private void RevisionTab_Click(object sender, EventArgs e)
        {
        }

        private void RevisionSaveBtn_Click(object sender, EventArgs e)
        {
            Presenter.RevisionSection.CommitRevisionAction();
        }

        private void CreateNewUserBtn_Click(object sender, EventArgs e)
        {
            Presenter.SettingsSection.CreateUserRequest();
        }

        private void DisableUserBtn_Click(object sender, EventArgs e)
        {
            Presenter.SettingsSection.DisableUserRequest();
        }

        private void ChangePasswordBtn_Click(object sender, EventArgs e)
        {
            Presenter.SettingsSection.ChangePasswordRequest();
        }

        private void ShowDbInfoBtn_Click(object sender, EventArgs e)
        {
            Presenter.SettingsSection.ShowDbInfoAction();
        }

        private void FindTransactionsBtn_Click(object sender, EventArgs e)
        {
            if (TransactionTypeBox.SelectedItem != null)
                Presenter.EditTransactionSection.Search();
        }
    }
}