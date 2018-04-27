using MaterialSkin.Controls;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Presenter;
using SimpleWarehouse.Services;
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
    public partial class ErrorForm : MaterialForm ,IView
    {
        private ErrorPresenter Presenter;

        public ErrorForm(ErrorPresenter presenter)
        {
            InitializeComponent();
            FormDecraptifier.Decraptify(this);
            this.Presenter = presenter;
        }

        public void HideAndDispose()
        {
            this.Hide();
            this.Dispose();
        }

        public void Log(string message)
        {
            this.ErrorBox.Text = message;
        }

        public void ShowAsDialog()
        {
            this.ShowDialog();
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            this.Presenter.AcceptError();
        }
    }
}
