using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
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
        public DalAlreayExistExeption(string message, Exception inner) : base(message, inner) { }
    }
    public class DalEmptyCollectionExeption : Exception
    {
        public DalEmptyCollectionExeption(string message) : base(message) { }
        public DalEmptyCollectionExeption(string message, Exception inner) : base(message, inner) { }

    }
    /// <summary>
    /// repersents errors during invalid remove  
    /// </summary>
    public class invalidRemoveExeption : Exception
    {
        public invalidRemoveExeption(string message) : base(message) { }
        public invalidRemoveExeption(string message, Exception inner) : base(message, inner) { }

    }

    /// <summary>
    /// repersents errors in case invalid remove 
    /// </summary>
    public class invalidRequestExeption : Exception
    {
        public invalidRequestExeption(string message) : base(message) { }
        public invalidRequestExeption(string message, Exception inner) : base(message, inner) { }

    }
}

