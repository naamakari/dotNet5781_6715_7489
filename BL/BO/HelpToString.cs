using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections;

namespace BO
{
    /// <summary>
    /// class that implement tostring property
    /// </summary>
    public static class HelpToString
    {
        /// <summary>
        /// the function implement the tostring properthy method 
        /// for all the classes that need tostring
        /// </summary>
        public static string ToStringProperty<T>(this T t)
        {
            string str = "";
            foreach (PropertyInfo item in t.GetType().GetProperties())
            {
                var value = item.GetValue(t, null);
                if (value is IEnumerable)
                {
                    if (value is string)
                        str += "\n" + item.Name + ": " + value;
                    else
                    {
                        str += "\n" + item.Name + ": ";
                        foreach (var item1 in (IEnumerable)value)
                            str += item1.ToStringProperty(" ");
                    }
                }
                
                else
                    str += "\n" + item.Name + ": " + value;
            }
            return str;
        }
        public static string ToStringProperty<T>(this T t, string suffix = "")
        {
            string str = "";
            foreach (PropertyInfo prop in t.GetType().GetProperties())
            {
                var value = prop.GetValue(t, null);
                if (value is IEnumerable)
                    foreach (var item in (IEnumerable)value)
                        str += item.ToStringProperty("   ");
                else
                    str += "\n" + suffix + prop.Name + ": " + value;
            }
            return str;
        }
    }
}
