﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_6715_7489
{
    /// <summary>
    /// class for line bus station
    /// </summary>
    public class LineBusStation:IComparable
    {
        static public Random rand = new Random(DateTime.Now.Millisecond);
        public float DistFromLast { get; set; }
        public int TimeFromLast { get; set; }
        public BusStation Station { get; set; }

        public LineBusStation(string address = "/0" )
        {
            DistFromLast =0;
            TimeFromLast =0;
            Station = new BusStation(address);
        }

        public int CompareTo(object obj)
        {
            LineBusStation lb = (LineBusStation)obj;
            return this.Station.StationCode.CompareTo(lb.Station.StationCode);
        }
        public override string ToString()
        {
            return Station.ToString();
        }
    }
}
