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
        private const string DisposeFormat = "Form {0} was disposed! (msg from FormFactory)";


        public static Form CreateForm(string formName, Object[] parameter)
        {
            Type formType = Type.GetType($"{Constants.Config.PathToForms}{formName}");
            Form form =  (Form)Activator.CreateInstance(formType, parameter);
            form.FormClosing += OnButtonCloseAction;
            return form;
        }

        private static void OnButtonCloseAction(Object sender, EventArgs e)
        {
            Form form = (Form) sender;
            string name = form.Name;
            form.Dispose();
            Console.WriteLine(DisposeFormat, name);
        }

    }
}
