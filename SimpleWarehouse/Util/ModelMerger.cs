using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Util
{
    public class ModelMerger
    {
        private const string FieldTypeMismatch = "Fields do not match";

        public T Merge<T>(object source, T dest)
        {
            Type sourceType = source.GetType();
            Type desType = dest.GetType();
           foreach (PropertyInfo sourceProp in sourceType.GetProperties())
           {
               PropertyInfo destProp = desType.GetProperty(sourceProp.Name);
               if(destProp == null)
                   continue;
               if(destProp.GetType() != sourceProp.GetType())
                   throw new ArgumentException(FieldTypeMismatch);
               destProp.SetValue(dest, sourceProp.GetValue(source));
           }         
            return  dest;
        }
    }
}
