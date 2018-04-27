using SimpleWarehouse.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Model
{
    public class SearchParameter
    {
        [DbNameReference(name:"id")]
        public int Id { get; set; }

        [DbNameReference(name: "display_name")]
        public string DisplayName { get; set; }

        [DbNameReference(name: "column_name")]
        public string ColumnName { get; set; }


        public override string ToString()
        {
            return DisplayName;
        }
    }
}
