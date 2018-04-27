using MaterialSkin.Controls;
using SimpleWarehouse.Constants;
using SimpleWarehouse.Model;
using SimpleWarehouse.Presenter;
using SimpleWarehouse.Presenter.ProductSpecificPresenters;
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
    public partial class SpecificCategoryForm : MaterialForm, IAddCategoryView
    {
        private IProductSpecificPresenter Presenter;

        public SpecificCategoryForm(IProductSpecificPresenter presenter)
        {
            InitializeComponent();
            this.Presenter = presenter;
            this.CategoryNameField.KeyPress += (sen, eventt) =>
            {
                if (this.CategoryNameField.Text.Length > Constants.Config.MAX_TEXT_LEN && eventt.KeyChar != (char)Keys.Back)
                    eventt.Handled = true;
            };
            FormDecraptifier.Decraptify(this);
        }

        public string CategoryName { get => this.CategoryNameField.Text; set => this.CategoryNameField.Text = value; }

        public Category SelectedCategory { get => (Category)this.CategoriesField.SelectedItem; set => this.CategoriesField.SelectedItem = value; }

        public void DisplayCategories(List<Category> categories)
        {
            this.CategoriesField.DataSource = categories;
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

        public void ShowAsDialog()
        {
            this.ShowDialog();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.Cancel();
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (this.CategoryNameField.Text.Length < 1)
            {
                this.Log("Невалидно име на Категория!");
                return;
            }
            this.Presenter.Submit();
        }
    }
}
