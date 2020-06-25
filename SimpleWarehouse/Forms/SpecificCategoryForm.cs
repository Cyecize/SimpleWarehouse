using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MaterialSkin.Controls;
using SimpleWarehouse.Constants;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Util;
using SimpleWarehouse.View;

namespace SimpleWarehouse.Forms
{
    public partial class SpecificCategoryForm : MaterialForm, IAddCategoryView
    {
        public SpecificCategoryForm(ISubmitablePresenter presenter)
        {
            InitializeComponent();
            Presenter = presenter;
            CategoryNameField.KeyPress += (sen, eventt) =>
            {
                if (CategoryNameField.Text.Length > Config.MaxTextLen && eventt.KeyChar != (char) Keys.Back)
                    eventt.Handled = true;
            };
            FormDecraptifier.Decraptify(this);
        }

        private ISubmitablePresenter Presenter { get; }

        public string CategoryName
        {
            get => CategoryNameField.Text;
            set => CategoryNameField.Text = value;
        }

        public Category SelectedCategory
        {
            get => (Category) CategoriesField.SelectedItem;
            set => CategoriesField.SelectedItem = value;
        }

        public void DisplayCategories(List<Category> categories)
        {
            CategoriesField.DataSource = categories;
        }

        public void HideAndDispose()
        {
            Hide();
            Dispose();
        }

        public void Log(string message)
        {
            LogLabel.Text = message;
        }

        public void ShowAsDialog()
        {
            ShowDialog();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Presenter.Cancel();
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (CategoryNameField.Text.Length < 1)
            {
                Log("Невалидно име на Категория!");
                return;
            }

            Presenter.Submit();
        }
    }
}