using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DbTableNameReference : Attribute
    {
        public string name;

        public DbTableNameReference(string name)
        {
            this.name = name;
        }

        public virtual string Name
        {
            get { return name; }
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
