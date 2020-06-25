using System;
using System.Windows.Forms;
using SimpleWarehouse.Constants;

namespace SimpleWarehouse.Factory
{
    public class FormFactory
    {
        private const string DisposeFormat = "Form {0} was disposed! (msg from FormFactory)";


        public static Form CreateForm(string formName, object[] parameter)
        {
            var formType = Type.GetType($"{Config.PathToForms}{formName}");
            var form = (Form) Activator.CreateInstance(formType, parameter);
            form.FormClosing += OnButtonCloseAction;
            return form;
        }

        private static void OnButtonCloseAction(object sender, EventArgs e)
        {
            var form = (Form) sender;
            var name = form.Name;
            form.Dispose();
            Console.WriteLine(DisposeFormat, name);
        }
    }
}