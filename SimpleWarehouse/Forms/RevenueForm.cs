using MaterialSkin.Controls;
using SimpleWarehouse.Constants;
using SimpleWarehouse.Presenter.RevenueRelated;
using SimpleWarehouse.RevenueRelated.View;
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
    public partial class RevenueForm : MaterialForm, IRevenueView
    {
        private char DELIMETER = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);

        private RevenuePresenter Presenter;

        public RevenueForm(RevenuePresenter presenter)
        {
            InitializeComponent();
            this.Presenter = presenter;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Приходи";
            this.RevenueAmountBox.KeyPress += this.OnTypeHandler;           
            this.RevisedEndDate.Value = DateTime.Now.AddDays(2);
        }

        public DateTime NewRevenueDate { get => DateTimeForRevenue.Value; set => DateTimeForRevenue.Value = value; }
        public DataGridView NotRevisedDataTable { get => this.DataTableView; set => this.DataTableView = value; }
        public DataGridView ArchiveDataTable { get => this.ArchivedRevenuesTable; set => this.ArchivedRevenuesTable = value; }
        public double NewRevenueAmount { get => double.Parse(this.RevenueAmountBox.Text); set => this.RevenueAmountBox.Text = value.ToString(); }
        public DateTime ArchivedRevenuesStartDate { get => RevisedStartDate.Value; set => RevisedStartDate.Value = value; }
        public DateTime ArchivedRevenuesEndDate { get => RevisedEndDate.Value; set => RevisedEndDate.Value = value; }
        public string TotalArchivedRevenuesRows { get => this.TotalRowsBox.Text; set => this.TotalRowsBox.Text = value; }
        public string TotalArchivedRevenuesPrice { get => this.TotalAmountBox.Text; set => this.TotalAmountBox.Text = value; }

        //overrides
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

        private void GoBackBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.Dispose();
        }

        //events 
        private void OnTypeHandler(Object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && DELIMETER != e.KeyChar);
            if (((Control)sender).Text.Contains(DELIMETER) && e.KeyChar == DELIMETER)
            {
                e.Handled = true;
            }
        }

        private void AddRevenueBtn_Click(object sender, EventArgs e)
        {
            if (this.ValidateForm())
                this.Presenter.AddRevenueSection.AddRevenueAction();
        }

        //private methods

        private bool ValidateForm()
        {
            bool isValid = true;
            try
            {
                if (this.RevenueAmountBox.Text.Length < 1)
                    this.RevenueAmountBox.Text = "0";
                double.Parse(this.RevenueAmountBox.Text);
                if (this.NewRevenueAmount < 1)
                {
                    this.Log(Messages.INVALID_NUMBERS_MSG);
                    return false;
                }

            }
            catch (Exception)
            {
                this.Log(Messages.INVALID_NUMBERS_MSG);
                isValid = false;
            }
            return isValid;
        }

        private void FindArchivedRevenues_Click(object sender, EventArgs e)
        {
            this.Presenter.ArchivedRevenuesSection.DisplayArchivedRevenues();
        }
    }
}
