using MaterialSkin.Controls;
using SimpleWarehouse.Presenter.RevenueRelated;
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
    public partial class RevenueForm : MaterialForm, IRevenueView
    {
        private RevenuePresenter Presenter;

        public RevenueForm(RevenuePresenter presenter)
        {
            InitializeComponent();
            this.Presenter = presenter;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Приходи";

        }

        //overrides
        public void HideAndDispose()
        {
            this.Hide();
            this.Dispose();
        }

        public void Log(string message)
        {
            throw new NotImplementedException();
        }

        public void ShowAsDialog()
        {
            this.ShowDialog();
        }

        private void GoBackBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.Dispose();
        }
    }
}
