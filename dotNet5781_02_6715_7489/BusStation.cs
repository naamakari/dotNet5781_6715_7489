using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_6715_7489
{
    /// <summary>
    /// class for bus station
    /// </summary>
    /// <param name="args"></param>
    public class BusStation
    {
        public string StationCode
        {
            get;
            private set;
        }
        public Location StationLocation;
        public String AddressOfStation;

        //defualt constructor
        public BusStation() { }
        public BusStation(string code, string address = "/0")
        {
            StationCode = code;
            StationLocation = new Location();
            AddressOfStation = address;
        }
        public override string ToString()
        {
            return "Bus station code: " + StationCode + ", " + StationLocation;
        }
    }
}
