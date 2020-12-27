using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return target;
        }
    }
}

