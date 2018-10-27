using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Util;
using SimpleWarehouse.View;

namespace SimpleWarehouse.Forms
{
    public partial class SwitchDatabaseForm : MaterialForm, ISwitchDatabaseView
    {
        private ISubmitablePresenter Presenter { get; set; }

        public SwitchDatabaseForm(ISubmitablePresenter presenter) : base()
        {
            this.InitializeComponent();
            this.Presenter = presenter;
            FormDecraptifier.Decraptify(this);
            this.Log(string.Empty);
            this.StartPosition =  FormStartPosition.CenterScreen;
        }

        public void Log(string message)
        {
            this.LogLabel1.Text = message;
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

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.Submit();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.Cancel();
        }

        public void DisplayDatabases(List<string> databases)
        {
            this.DatabasesList.DataSource = databases;
        }

        public string GetSelectedDatabase()
        {
            return this.DatabasesList.SelectedItem + "";
        }
    }
}