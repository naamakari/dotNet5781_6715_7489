using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_6715_7489
{
    public class ErrorCharExeption : Exception
    {
        public override string Message
        {
            get { return "The caracter isn't valid!"; }
                }
    }
}
