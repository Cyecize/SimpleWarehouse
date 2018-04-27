using SimpleWarehouse.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Model
{
    public class Category
    {
        [DbNameReference(name:("id"))]
        public int Id { get; set; }

        [DbNameReference(name: ("parent_id"))]
        public int ParantId { get; set; }

        [DbNameReference(name: ("category_name"))]
        public string CategoryName { get; set; }

        public override string ToString()
        {
            return CategoryName; 
        }
    }
}
