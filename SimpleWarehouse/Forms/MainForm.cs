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

        public DataGridView DataTable { get => this.DataTableView; set => this.DataTableView = value; }
        public string SearchText { get => this.SearchBox.Text; set => this.SearchBox.Text = value; }
        public SearchParameter SearchParameter { get => (SearchParameter)this.SearchType.SelectedItem; }

        public MainForm(HomePresenter presenter)
        {
            InitializeComponent();
            this.Presenter = presenter;
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.Text = "Logged user: Georgi";


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
            throw new NotImplementedException();
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
    }
}
