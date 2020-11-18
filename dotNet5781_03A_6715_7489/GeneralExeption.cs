using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_6715_7489
{
    [Serializable]
    public class MinimunStationsExeption : Exception
    {
        //public override string Message
        //{
        //    get { return "can not delete this station from this line"; }
        //}
    public MinimunStationsExeption() : base() { }
        public MinimunStationsExeption(string message) : base(message) { }
        public MinimunStationsExeption(string message, Exception inner) : base(message, inner) { }
        protected MinimunStationsExeption(SerializationInfo Info,StreamingContext context) : base(Info, context) { }
    }
}
