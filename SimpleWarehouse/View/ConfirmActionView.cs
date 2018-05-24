using SimpleWarehouse.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.View
{
    public interface IConfirmActionView : IView
    {
        String ConfirmTextContent { get; set; }
    }
}
