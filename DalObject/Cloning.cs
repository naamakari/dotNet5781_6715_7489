using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DL
{


    /// <summary>
    /// class for cloning
    /// </summary>
    static class Cloning
    {
        internal static T Clone<T>(this T original)
        {
            T target = (T)Activator.CreateInstance(original.GetType());
            foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
                propertyInfo.SetValue(target, propertyInfo.GetValue(original, null), null);
            return target;
        }
    }
}

