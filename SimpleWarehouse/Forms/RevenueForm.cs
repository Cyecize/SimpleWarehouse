using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using MaterialSkin.Controls;
using SimpleWarehouse.Constants;
using SimpleWarehouse.Presenter.Revenues;
using SimpleWarehouse.RevenueRelated.View;

namespace SimpleWarehouse.Forms
{
    public partial class RevenueForm : MaterialForm, IRevenueView
    {
        private const string CommentLengthExceeded = "Надвишена дължина на коментара";

        private readonly char _delimiter =
            Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);

        public RevenueForm(IRevenueStreamPresenter streamPresenter)
        {
            InitializeComponent();
            StreamPresenter = streamPresenter;
            StartPosition = FormStartPosition.CenterScreen;
            RevenueAmountBox.KeyPress += OnTypeHandler;
            RevisedEndDate.Value = DateTime.Now.AddDays(2);
        }

        private IRevenueStreamPresenter StreamPresenter { get; }

        public DateTime NewEntityDate
        {
            get => DateTimeForRevenue.Value;
            set => DateTimeForRevenue.Value = value;
        }

        public DataGridView NotRevisedDataTable
        {
            get => DataTableView;
            set => DataTableView = value;
        }

        public DataGridView ArchiveDataTable
        {
            get => ArchivedRevenuesTable;
            set => ArchivedRevenuesTable = value;
        }

        public double NewEntityAmount
        {
            get => double.Parse(RevenueAmountBox.Text);
            set => RevenueAmountBox.Text = value.ToString();
        }

        public DateTime ArchivedEntitiesStartDate
        {
            get => RevisedStartDate.Value;
            set => RevisedStartDate.Value = value;
        }

        public DateTime ArchivedEntitiesEndDate
        {
            get => RevisedEndDate.Value;
            set => RevisedEndDate.Value = value;
        }

        public string TotalArchivedEntitiesRows
        {
            get => TotalRowsBoxArchive.Text;
            set => TotalRowsBoxArchive.Text = value;
        }

        public string TotalArchivedEntitiesPrice
        {
            get => TotalAmountBoxArchive.Text;
            set => TotalAmountBoxArchive.Text = value;
        }
        public string TotalEntitiesRows
        {
            get => TotalRowsBox.Text;
            set => TotalRowsBox.Text = value;
        }

        public string TotalEntitiesPrice
        {
            get => TotalAmountBox.Text;
            set => TotalAmountBox.Text = value;
        }

        public string CommentArchive { get => LblCommentSearchArchive.Text; set => LblCommentSearchArchive.Text = value; }

        public string CommentText
        {
            get => CommentBox.Text;
            set => CommentBox.Text = value;
        }

        //overrides
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

        private void GoBackBtn_Click(object sender, EventArgs e)
        {
            StreamPresenter.GoBackAction();
        }

        //events 
        private void OnTypeHandler(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && _delimiter != e.KeyChar;
            if (((Control) sender).Text.Contains(_delimiter) && e.KeyChar == _delimiter) e.Handled = true;
        }

        private void AddRevenueBtn_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
                StreamPresenter.RevenueStreamSection.AddRevenueStreamAction();
        }

        //private methods

        private bool ValidateForm()
        {
            var isValid = true;
            try
            {
                if (RevenueAmountBox.Text.Length < 1)
                    RevenueAmountBox.Text = "0";
                double.Parse(RevenueAmountBox.Text);
                if (NewEntityAmount < 1)
                {
                    Log(Messages.InvalidNumbersMsg);
                    return false;
                }
            }
            catch (Exception)
            {
                Log(Messages.InvalidNumbersMsg);
                isValid = false;
            }

            if (CommentBox.Text.Length >= 255)
            {
                Log(CommentLengthExceeded);
                isValid = false;
            }

            return isValid;
        }

        private void FindArchivedRevenues_Click(object sender, EventArgs e)
        {
            StreamPresenter.RevenueStreamSection.DisplayArchivedRevenueStreams();
        }

        private void CommentBox_KeyUp(object sender, KeyEventArgs e)
        {
            StreamPresenter.RevenueStreamSection.UpdateNonRevisedRevenueStreams(this.CommentBox.Text);
        }
    }
}