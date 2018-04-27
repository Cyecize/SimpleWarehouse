using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DbNameReference : Attribute
    {

        public string name;

        public DbNameReference(string name)
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
