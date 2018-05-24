
using DataGridViewTextButton.DataGridViewElements;
using MaterialSkin.Controls;
using SimpleWarehouse.Model;
using SimpleWarehouse.Presenter;
using SimpleWarehouse.Services;
using SimpleWarehouse.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SimpleWarehouse.Forms
{

    public partial class MainForm : MaterialForm, IHomeView
    {

        private HomePresenter Presenter;

        public DataGridView ProductDataTable { get => this.DataTableView; set => this.DataTableView = value; }
        public string SearchText { get => this.SearchBox.Text; set => this.SearchBox.Text = value; }
        public SearchParameter SearchParameter { get => (SearchParameter)this.SearchType.SelectedItem; }
        public DataGridView DeliveriesDataTable { get => this.DeliveriesDataGridView; set => this.DeliveriesDataGridView = value; }
        public DataGridView SalesDataTable { get => this.SalesDataGridView; set => this.SalesDataGridView = value; }
        public TabPage SelectedTabPage { get => this.materialTabControl1.SelectedTab; set => this.materialTabControl1.SelectedTab = value; }
        TabPage IHomeView.DeliveriesTab { get; set; }
        TabPage IHomeView.SalesTab { get; set; }
        public string TabLabelText { get => this.CurrentTabLabel.Text; set => this.CurrentTabLabel.Text = value; }
        public TextBox TotalDeliveryMoney { get => this.DeliveriesTotalMoney; set => this.DeliveriesTotalMoney = value; }
        public TextBox TotalSaleMoney { get => this.SalesTotalMoney; set => this.SalesTotalMoney = value; }

        //REVISION
        public DataGridView RevisionDataTable { get => this.RevisionDataGridView; set => this.RevisionDataGridView = value; }
        public string RevisionRevenue { get => this.RevisionRevenueTextBox.Text; set => this.RevisionRevenueTextBox.Text = value; }
        public string RevisionExpenses { get => this.RevisionExpensesTextBox.Text; set => this.RevisionExpensesTextBox.Text = value; }
        public string RevisionSalesRevenue { get => this.RevisionSalesRevenueTextBox.Text; set => this.RevisionSalesRevenueTextBox.Text = value; }
        public string RevisionSubTotal { get => this.RevisionSubTotalTextBox.Text; set => this.RevisionSubTotalTextBox.Text = value; }
        string IRevisionView.RevisionStartDate { get => this.RevisionStartDateLabel.Text; set => this.RevisionStartDateLabel.Text = value; }
        public string RevisonSubTotalPlusSalesRevenue { get => this.RevisionSalesPlusRevisionTotalTextBox.Text; set => this.RevisionSalesPlusRevisionTotalTextBox.Text = value; }

        public MainForm(HomePresenter presenter)
        {
            InitializeComponent();
            this.Presenter = presenter;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.InitializeProductSectionEvents();
            this.materialTabControl1.Selected += (o, e) =>
            {
                this.Presenter.OnTabChangeAction();
            };
        }

        public void ShowAsDialog()
        {
            this.ShowDialog();
        }

        private void MaterialButton1_Click(object sender, EventArgs e)
        {
            this.Presenter.ProductSection.AddNewProductRequest();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.ProductSection.EditProductRequest();
        }

        //events
        private void OnCellClick(Object sender, EventArgs e)
        {
            this.Presenter.ProductSection.SelectProductAction();
        }

        private void OnSearchParamChange(Object sender, EventArgs e)
        {
            this.Presenter.ProductSection.ChangeSearchParamAction();
        }


        //override

        public void SetSearchParams(List<SearchParameter> searchParameters)
        {
            this.SearchType.DataSource = searchParameters;
        }

        public void HideAndDispose()
        {
            this.Hide();
            this.Dispose();
        }

        public void Log(string message)
        {
            this.LogLabel.Text = message;
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            this.Presenter.RefreshAction();
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.LogoutAction();
        }

        private void AddCategoryBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.ProductSection.AddNewCategoryRequest();
        }


        public void EnableOrDisableElement(string elName, Type elType, bool isEnabled)
        {
            foreach (Control control in this.Controls)
            {
                if (elType == control.GetType())
                {
                    Button btn = (Button)control;
                    if (btn.Name == elName)
                    {
                        btn.Enabled = isEnabled;
                    }
                }
            }
        }

        public void EnableOrDisableMaterialBtn(string btnName, bool isEnabled)
        {
            EnableOrDisableElement(btnName, typeof(MaterialFlatButton), isEnabled);
        }

        //private logic
        private void RevenueBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.RevenueAction();
        }

        private void InvoicesBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.InvoicesAction();
        }

        private void ExpensesBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.ExpensesAction();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void InitializeProductSectionEvents()
        {
            this.DataTableView.CellClick += this.OnCellClick;
            this.DataTableView.AllowUserToAddRows = false;
            this.SearchBox.TextChanged += (obj, e) =>
            {
                this.Presenter.ProductSection.SearchProdAction();
            };
            this.DataTableView.KeyPress += (obj, e) =>
            {
                if (char.IsLetterOrDigit(((KeyPressEventArgs)e).KeyChar) || ((KeyPressEventArgs)e).KeyChar == (char)Keys.Space)
                    this.SearchBox.Text += ((KeyPressEventArgs)e).KeyChar;
                if (((KeyPressEventArgs)e).KeyChar == (char)Keys.OemBackslash || ((KeyPressEventArgs)e).KeyChar == (char)Keys.Back)
                {
                    if (this.SearchBox.Text.Length >= 1)
                        this.SearchBox.Text = this.SearchBox.Text.Substring(0, this.SearchBox.Text.Length - 1);
                }

            };
            this.SearchType.SelectedIndexChanged += this.OnSearchParamChange;
        }

        private void CancelDeliveryBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.DeliveriesSection.CancelOperation();
        }

        private void RefreshDeliveriesAction_Click(object sender, EventArgs e)
        {
            this.Presenter.DeliveriesSection.RefreshGridAction();
        }

        private void SaveDeliveryBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.DeliveriesSection.CreateTransactionAction();
        }

        private void SaveSaleBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.SalesSection.CreateTransactionAction();
        }

        private void LogLabel_Click(object sender, EventArgs e)
        {
            ((Label)sender).Text = "";
        }

        private void BeginRevisionBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.RevisionSection.BeginRevision();
        }

        private void RevisionCancelBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.RevisionSection.CancelOperation();
        }

        private void RevisionRefreshBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.RevisionSection.RefreshGridAction();
        }

        private void SalesCancelBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.SalesSection.CancelOperation();
        }

        private void SalesRefreshBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.SalesSection.RefreshGridAction();
        }

        private void RevisionTab_Click(object sender, EventArgs e)
        {

        }

        private void RevisionSaveBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.RevisionSection.CommitRevisionAction();
        }
    }
}
