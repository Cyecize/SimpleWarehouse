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
    public partial class SearchProductForm : MaterialForm, ISearchProductView
    {
        private SearchProductPresenter Presenter { get; set; }
        public DataGridView ProductDataTable { get => this.DataTableView; set => this.DataTableView = value; }
        public string SearchText { get => this.SearchBox.Text; set => this.SearchBox.Text = value; }

        public SearchParameter SearchParameter => (SearchParameter)this.SearchType.SelectedItem;

        public SearchProductForm(SearchProductPresenter presenter)
        {
            InitializeComponent();
            this.Presenter = presenter;
            this.InitializeEvents();
            this.StartPosition = FormStartPosition.CenterScreen;
            FormDecraptifier.Decraptify(this);
        }


        //overrides
        public void SetSearchParams(List<SearchParameter> searchParameters)
        {
            this.SearchType.DataSource = searchParameters;
        }

        public void HideAndDispose()
        {
            this.Hide();
            this.Dispose();
        }

        public void ShowAsDialog()
        {
            this.ShowDialog();
        }

        public void Log(string message)
        {
            this.LogLabel.Text = message;
        }
        //private logic 

        private void InitializeEvents()
        {
            this.DataTableView.CellClick += this.OnCellClick;
            this.DataTableView.AllowUserToAddRows = false;
            this.SearchBox.TextChanged += (obj, e) =>
            {
                this.Presenter.ProductSection.SearchVisibleProdAction();
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

        //events
        private void OnSearchParamChange(Object sender, EventArgs e)
        {
            this.Presenter.ProductSection.ChangeSearchParamAction();
        }

        private void OnCellClick(Object sender, EventArgs e)
        {
            this.Presenter.ProductSection.SelectProductAction();
        }

        private void SelectProductBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.Submit();
        }

        private void GoBackBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.GoBackAction();
        }
    }
}
