using MaterialSkin.Controls;
using SimpleWarehouse.Presenter;
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
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Util;

namespace SimpleWarehouse.Forms
{
    public partial class ConfirmActionForm : MaterialForm, IConfirmActionView
    {
        private ISubmitablePresenter Presenter { get; set; }
        public string ConfirmTextContent { get => this.ConfirmTextBox.Text; set => this.ConfirmTextBox.Text = value; }

        public ConfirmActionForm(ISubmitablePresenter presenter)
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

        public void ShowAsDialog()
        {
            this.ShowDialog();
        }

        public void Log(string message)
        {
            throw new NotImplementedException();
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.Submit();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.Cancel();
        }
    }
}
