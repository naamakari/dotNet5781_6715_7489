﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DO
{
    /// <summary>
    /// class that implement function of tostring property
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
                str += "\n" + item.Name + ": " + item.GetValue(t, null);
            return str;
        }
    }
}
