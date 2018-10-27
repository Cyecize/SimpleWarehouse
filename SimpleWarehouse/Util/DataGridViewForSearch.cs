using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWarehouse.Util
{
    class DataGridViewForSearch : DataGridView
    {
        public DataGridViewForSearch() : base()
        {

        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if ((e.KeyData & Keys.KeyCode) == Keys.Enter)
                return;
            else
                base.OnKeyDown(e);
        }
    }
}
