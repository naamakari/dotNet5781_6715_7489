using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_6715_7489
{
    /// <summary>
    /// class for line bus station
    /// </summary>
    public class LineBusStation:BusStation
    {
        static public Random rand = new Random(DateTime.Now.Millisecond);
        public float DistFromLast { get; set; }
        public float TimeFromLast { get; set; }

        public LineBusStation(string code, string address = "/0") : base(code, address)
        {
            DistFromLast = (float)rand.NextDouble() + rand.Next(550);
            TimeFromLast = rand.Next(360);
        }
    }
}
