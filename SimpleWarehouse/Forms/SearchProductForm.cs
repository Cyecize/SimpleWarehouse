using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MaterialSkin.Controls;
using SimpleWarehouse.Model;
using SimpleWarehouse.Presenter.Products;
using SimpleWarehouse.Util;
using SimpleWarehouse.View;

namespace SimpleWarehouse.Forms
{
    public partial class SearchProductForm : MaterialForm, ISearchProductView
    {
        public SearchProductForm(SearchProductPresenter presenter)
        {
            InitializeComponent();
            Presenter = presenter;
            InitializeEvents();
            StartPosition = FormStartPosition.CenterScreen;
            FormDecraptifier.Decraptify(this);
        }

        private SearchProductPresenter Presenter { get; }
        public DataGridView ProductDataTable { get; set; }

        public string SearchText
        {
            get => SearchBox.Text;
            set => SearchBox.Text = value;
        }

        public SearchParameter SearchParameter => (SearchParameter) SearchType.SelectedItem;


        //overrides
        public void SetSearchParams(List<SearchParameter> searchParameters)
        {
            SearchType.DataSource = searchParameters;
        }

        public void HideAndDispose()
        {
            Hide();
            Dispose();
        }

        public void ShowAsDialog()
        {
            ShowDialog();
        }

        public void Log(string message)
        {
            LogLabel.Text = message;
        }
        //private logic 

        private void InitializeEvents()
        {
            ProductDataTable.CellClick += OnCellClick;
            ProductDataTable.AllowUserToAddRows = false;
            SearchBox.TextChanged += (obj, e) => { Presenter.ProductSection.SearchVisibleProdAction(); };
            ProductDataTable.KeyPress += (obj, e) =>
            {
                if (e.KeyChar == (char) Keys.Enter)
                    Presenter.Submit();
                if (char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == (char) Keys.Space)
                    SearchBox.Text += e.KeyChar;
                if (e.KeyChar == (char) Keys.OemBackslash || e.KeyChar == (char) Keys.Back)
                    if (SearchBox.Text.Length >= 1)
                        SearchBox.Text = SearchBox.Text.Substring(0, SearchBox.Text.Length - 1);
                if (e.KeyChar == (char) Keys.Up || e.KeyChar == (char) Keys.Down)
                    Presenter.ProductSection.SelectProductAction();
            };
            SearchType.SelectedIndexChanged += OnSearchParamChange;
            KeyDown += (o, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    Presenter.Submit();
            };
        }

        //events
        private void OnSearchParamChange(object sender, EventArgs e)
        {
            Presenter.ProductSection.ChangeSearchParamAction();
        }

        private void OnCellClick(object sender, EventArgs e)
        {
            Presenter.ProductSection.SelectProductAction();
        }

        private void SelectProductBtn_Click(object sender, EventArgs e)
        {
            Presenter.Submit();
        }

        private void GoBackBtn_Click(object sender, EventArgs e)
        {
            Presenter.GoBackAction();
        }
    }
}