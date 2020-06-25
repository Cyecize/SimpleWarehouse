using System.Windows.Forms;

namespace SimpleWarehouse.Util
{
    internal class DataGridViewForSearch : DataGridView
    {
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if ((e.KeyData & Keys.KeyCode) == Keys.Enter)
                return;
            base.OnKeyDown(e);
        }
    }
}