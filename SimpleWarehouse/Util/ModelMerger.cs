using System;

namespace SimpleWarehouse.Util
{
    public class ModelMerger
    {
        private const string FieldTypeMismatch = "Fields do not match";

        public T Merge<T>(object source, T dest)
        {
            var sourceType = source.GetType();
            var desType = dest.GetType();
            foreach (var sourceProp in sourceType.GetProperties())
            {
                var destProp = desType.GetProperty(sourceProp.Name);
                if (destProp == null)
                    continue;
                if (destProp.GetType() != sourceProp.GetType())
                    throw new ArgumentException(FieldTypeMismatch);
                destProp.SetValue(dest, sourceProp.GetValue(source));
            }

            return dest;
        }
    }
}