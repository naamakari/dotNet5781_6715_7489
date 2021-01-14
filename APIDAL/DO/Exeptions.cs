using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{

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
    public class DalAlreayExistExeption : Exception
    {
        public DalAlreayExistExeption(string message) : base(message) { }
    }
    [Serializable]
    public class DalAlreayExistFollowingStationsExeption : Exception
    {
        public DalAlreayExistFollowingStationsExeption(string message) : base(message) { }
    }
    /// <summary>
    ///  Represents errors during we ask for empty collection
    /// </summary>
    public class DalEmptyCollectionExeption : Exception
    {
        public DalEmptyCollectionExeption(string message) : base(message) { }
    }
    /// <summary>
    ///  Represents errors during the remove from the list isnot working
    /// </summary>
    [Serializable]
    public class CanNotRemoveException : Exception
    {
        public CanNotRemoveException(string message) : base(message) { }
        public CanNotRemoveException(string message, Exception inner) : base(message, inner) { }

    }
    /// <summary>
    ///  Represents errors when there is a problem opening the XML file
    /// </summary>
    public class XMLFileLoadCreateException: Exception
    {
        public string xmlFilePath;
        public XMLFileLoadCreateException(string xmlPath) : base() { xmlFilePath = xmlPath; }
        public XMLFileLoadCreateException(string xmlPath, string message) :
            base(message)
        { xmlFilePath = xmlPath; }
        public XMLFileLoadCreateException(string xmlPath, string message, Exception innerException) :
            base(message, innerException)
        { xmlFilePath = xmlPath; }

        public override string ToString() => base.ToString() + $", fail to load or create xml file: {xmlFilePath}";
    }
}
