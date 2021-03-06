﻿using System.Windows.Forms;

namespace SimpleWarehouse.Util
{
    public class FormDecraptifier
    {
        public static void Decraptify(Form form)
        {
            //form.FormBorderStyle = FormBorderStyle.FixedDialog;
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Set the MaximizeBox to false to remove the maximize box.
            form.MaximizeBox = false;

            // Set the MinimizeBox to false to remove the minimize box.
            form.MinimizeBox = false;

            // Set the start position of the form to the center of the screen.
            form.StartPosition = FormStartPosition.CenterParent;
        }
    }
}