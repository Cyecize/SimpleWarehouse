using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MaterialSkin.Controls;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Util;
using SimpleWarehouse.View;

namespace SimpleWarehouse.Forms
{
    public partial class SwitchDatabaseForm : MaterialForm, ISwitchDatabaseView
    {
        public SwitchDatabaseForm(ISubmitablePresenter presenter)
        {
            InitializeComponent();
            Presenter = presenter;
            FormDecraptifier.Decraptify(this);
            Log(string.Empty);
            StartPosition = FormStartPosition.CenterScreen;
        }

        private ISubmitablePresenter Presenter { get; }

        public void Log(string message)
        {
            LogLabel1.Text = message;
        }

        public void HideAndDispose()
        {
            Hide();
            Dispose();
        }

        public void ShowAsDialog()
        {
            ShowDialog();
        }

        public void DisplayDatabases(List<string> databases)
        {
            DatabasesList.DataSource = databases;
        }

        public string GetSelectedDatabase()
        {
            return DatabasesList.SelectedItem + "";
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            Presenter.Submit();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Presenter.Cancel();
        }
    }
}