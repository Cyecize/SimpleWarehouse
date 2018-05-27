using MaterialSkin.Controls;
using SimpleWarehouse.Constants;
using SimpleWarehouse.Model;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWarehouse.Forms
{
    public partial class SpecificProductForm : MaterialForm, ISpecificProductView
    {
        private char DELIMETER = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
        private IProductSpecificPresenter Presenter;

        public double Quantity { get => double.Parse(this.QuantityField.Text); set => this.QuantityField.Text = value.ToString(); }
        public double ImportPrice { get => double.Parse(this.ImportPriceField.Text); set => this.ImportPriceField.Text = value.ToString(); }
        public double SellPrice { get => double.Parse(this.SellPriceField.Text); set => this.SellPriceField.Text = value.ToString(); }
        public bool IsVisible { get => this.VisibleCheckbox.Checked; set => this.VisibleCheckbox.Checked = value; }
        public Category SelectedCategory { get => (Category)this.CategoriesField.SelectedItem; set => this.CategoriesField.SelectedItem = value; }
        string ISpecificProductView.ProductName { get => this.ProdNameField.Text; set => this.ProdNameField.Text = value; }

        public SpecificProductForm(IProductSpecificPresenter presenter)
        {
            InitializeComponent();
            this.Presenter = presenter;
            FormDecraptifier.Decraptify(this);
            this.SellPriceField.KeyPress += this.OnTypeHandler;
            this.ImportPriceField.KeyPress += this.OnTypeHandler;
            this.QuantityField.KeyPress += this.OnTypeHandler;
            this.ProdNameField.KeyPress += (sen, eventt) =>
            {
                if (this.ProdNameField.Text.Length > Constants.Config.MAX_TEXT_LEN && eventt.KeyChar != (char)Keys.Back)
                    eventt.Handled = true;
            };
        }

        

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

        private void OnTypeHandler(Object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && DELIMETER != e.KeyChar);
            if (((Control)sender).Text.Contains(DELIMETER) && e.KeyChar == DELIMETER)
            {
                e.Handled = true;
            }
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                return;
            }
            this.Presenter.Submit();
        }

        private bool ValidateForm()
        {
            bool isValid = true;
            if (this.ProdNameField.Text.Length < 1)
            {
                this.Log(Messages.INVALID_NAME_MSG);
                return false;
            }
            try
            {
                if (this.QuantityField.Text.Length < 1)
                    this.QuantityField.Text = "0";
                if (this.SellPriceField.Text.Length < 1)
                    this.SellPriceField.Text = "0";
                if (this.ImportPriceField.Text.Length < 1)
                    this.ImportPriceField.Text = "0";

                double.Parse(this.QuantityField.Text);
                double.Parse(this.SellPriceField.Text);
                double.Parse(this.ImportPriceField.Text);

            }
            catch (Exception)
            {
                this.Log(Messages.INVALID_NUMBERS_MSG);
                isValid = false;
            }

            if(this.CategoriesField.SelectedItem == null)
            {
                isValid = false;
                this.Log("Моля изберете категория");
            }

            return isValid;
        }
    }
}
