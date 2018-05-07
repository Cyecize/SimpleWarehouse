using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Interfaces
{
    public interface IView
    {
        string Text { get; set; }

        void HideAndDispose();

        void Show();

        void ShowAsDialog();

        void Log(string message); 
    }
}
