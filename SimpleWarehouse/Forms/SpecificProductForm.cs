using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using MaterialSkin.Controls;
using SimpleWarehouse.Constants;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using SimpleWarehouse.Util;
using SimpleWarehouse.View;

namespace SimpleWarehouse.Forms
{
    public partial class SpecificProductForm : MaterialForm, ISpecificProductView
    {
        private readonly char _delimiter =
            Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);

        private readonly char _negative = '-';

        public SpecificProductForm(ISubmitablePresenter presenter)
        {
            InitializeComponent();
            Presenter = presenter;
            FormDecraptifier.Decraptify(this);
            SellPriceField.KeyPress += OnTypeHandler;
            ImportPriceField.KeyPress += OnTypeHandler;
            QuantityField.KeyPress += OnTypeHandler;
            ProdNameField.KeyPress += (sen, eventt) =>
            {
                if (ProdNameField.Text.Length > Config.MaxTextLen && eventt.KeyChar != (char) Keys.Back)
                    eventt.Handled = true;
            };
        }

        private ISubmitablePresenter Presenter { get; }

        public double Quantity
        {
            get => double.Parse(QuantityField.Text);
            set => QuantityField.Text = value.ToString();
        }

        public double ImportPrice
        {
            get => double.Parse(ImportPriceField.Text);
            set => ImportPriceField.Text = value.ToString();
        }

        public double SellPrice
        {
            get => double.Parse(SellPriceField.Text);
            set => SellPriceField.Text = value.ToString();
        }

        public bool IsVisible
        {
            get => VisibleCheckbox.Checked;
            set => VisibleCheckbox.Checked = value;
        }

        public Category SelectedCategory
        {
            get => (Category) CategoriesField.SelectedItem;
            set => CategoriesField.SelectedItem = value;
        }

        string ISpecificProductView.ProductName
        {
            get => ProdNameField.Text;
            set => ProdNameField.Text = value;
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

        private void OnTypeHandler(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && _delimiter != e.KeyChar &&
                        _negative != e.KeyChar;
            var control = (Control) sender;
            if (control.Text.Contains(_delimiter) && e.KeyChar == _delimiter)
                e.Handled = true;
            if (e.KeyChar == _negative && control.Text.Length > 0)
                e.Handled = true;
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            Presenter.Submit();
        }

        private bool ValidateForm()
        {
            var isValid = true;
            if (ProdNameField.Text.Length < 1)
            {
                Log(Messages.InvalidNameMsg);
                return false;
            }

            try
            {
                if (QuantityField.Text.Length < 1)
                    QuantityField.Text = "0";
                if (SellPriceField.Text.Length < 1)
                    SellPriceField.Text = "0";
                if (ImportPriceField.Text.Length < 1)
                    ImportPriceField.Text = "0";

                double.Parse(QuantityField.Text);
                double.Parse(SellPriceField.Text);
                double.Parse(ImportPriceField.Text);
            }
            catch (Exception)
            {
                Log(Messages.InvalidNumbersMsg);
                isValid = false;
            }

            if (CategoriesField.SelectedItem == null)
            {
                isValid = false;
                Log(@"Моля изберете категория");
            }

            return isValid;
        }
    }
}