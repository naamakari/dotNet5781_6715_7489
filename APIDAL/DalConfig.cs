using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace APIDAL
{
  
    /// <summary>
    /// Class for processing config.xml file and getting from there
    /// information which is relevant for initialization of DalApi
    /// </summary>
    static class DalConfig
    {
        internal static string DalName;
        internal static Dictionary<string, string> DalPackages;

        /// <summary>
        /// Static constructor extracts Dal packages list and Dal type from
        /// Dal configuration file config.xml
        /// </summary>
        static DalConfig()
        {
            XElement dalConfig = XElement.Load(@"config.xml");
            DalName = dalConfig.Element("dal").Value;
            DalPackages = (from pkg in dalConfig.Element("dal-packages").Elements()
                           select pkg).ToDictionary(p => "" + p.Name, p => p.Value);
        }
    }

    /// <summary>
    /// Represents errors during DalApi initialization
    /// </summary>
    [Serializable]
    public class DalConfigException : Exception
    {
        public DalConfigException(string message) : base(message) { }
        public DalConfigException(string message, Exception inner) : base(message, inner) { }
      
    }
    /// <summary>
    ///  Represents errors during insert alreay exist object
    /// </summary>
    [Serializable]
    public class DalAlreayExistExeption:Exception
    {
        public DalAlreayExistExeption(string message) : base(message) { }
    }
    public class DalEmptyCollectionExeption : Exception
    {
        public DalEmptyCollectionExeption(string message) : base(message) { }
    }
}

