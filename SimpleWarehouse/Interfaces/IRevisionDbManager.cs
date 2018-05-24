using SimpleWarehouse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Interfaces
{
    public interface IRevisionDbManager
    {
        IMySqlManager SqlManager { get; set; }

        void CreateRevision(Revision revision);

        List<Revision> FindAll();

        List<Revision> FindAfterDate(DateTime date); 

        Revision FindOneById(int id);
    }
}
