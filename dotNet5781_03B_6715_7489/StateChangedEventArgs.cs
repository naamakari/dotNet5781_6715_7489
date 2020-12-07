using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_03B_6715_7489
{
    public class StateChangedEventArgs: EventArgs
    {
        public readonly string myId;
        public StateChangedEventArgs(string myTempId)
        {
            myId = myTempId;
        }
    }
}
