using SimpleWarehouse.App;
using SimpleWarehouse.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SimpleWarehouse.Factory
{
    public class FormFactory
    {
        public static IMySqlManager SqlManager; 

        public static Form CreateForm(string formName, Object[] parameter)
        {
            Type formType = Type.GetType($"{Constants.Config.PATH_TO_FORMS}{formName}");
            Form form =  (Form)Activator.CreateInstance(formType, parameter);
            form.FormClosing += OnButtonCloseAction;
            return form;
        }

        private static void OnButtonCloseAction(Object sender, EventArgs e)
        {
            ((Form)sender).Dispose();
            Console.WriteLine("Form was disposed!");
        }

    }
}
