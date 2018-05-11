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

        private IRevenuePresenter Presenter;

        public RevenueForm(IRevenuePresenter presenter)
        {
            InitializeComponent();
            this.Presenter = presenter;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.RevenueAmountBox.KeyPress += this.OnTypeHandler;           
            this.RevisedEndDate.Value = DateTime.Now.AddDays(2);
        }

        public DateTime NewEntityDate { get => DateTimeForRevenue.Value; set => DateTimeForRevenue.Value = value; }
        public DataGridView NotRevisedDataTable { get => this.DataTableView; set => this.DataTableView = value; }
        public DataGridView ArchiveDataTable { get => this.ArchivedRevenuesTable; set => this.ArchivedRevenuesTable = value; }
        public double NewEntityAmount { get => double.Parse(this.RevenueAmountBox.Text); set => this.RevenueAmountBox.Text = value.ToString(); }
        public DateTime ArchivedEntitiesStartDate { get => RevisedStartDate.Value; set => RevisedStartDate.Value = value; }
        public DateTime ArchivedEntitiesEndDate { get => RevisedEndDate.Value; set => RevisedEndDate.Value = value; }
        public string TotalArchivedEntitiesRows { get => this.TotalRowsBox.Text; set => this.TotalRowsBox.Text = value; }
        public string TotalArchivedEntitiesPrice { get => this.TotalAmountBox.Text; set => this.TotalAmountBox.Text = value; }

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
            this.Presenter.GoBackAction();
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
                this.Presenter.AddEntitySection.AddEntityAction();
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
                if (this.NewEntityAmount < 1)
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
            this.Presenter.ArchivedEntitiesSection.DisplayArchivedEntities();
        }
    }
}
