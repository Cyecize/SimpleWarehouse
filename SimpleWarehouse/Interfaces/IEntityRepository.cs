using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Interfaces
{
    public interface IEntityRepository<T>
    {
        IMySqlManager SqlManager { get; set; }

        List<T> FindManyByQuery(string query);

        T FindOneByQuery(string query);

        T FindOneBy(string tableName ,string col, object value);

    }
}
