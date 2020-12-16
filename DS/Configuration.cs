using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS
{
    /// <summary>
    /// class for initilized the running number for bus line and bus station
    /// </summary>
   public static class Configuration
    {
        static int BusLineRunNum = 1110;
        static int BusStationRunNum = 1110;

        public static int GetBusLineRunNum()
        {
            return ++BusLineRunNum;
        }
        public static int GetBusStationRunNum()
        {
            return ++BusStationRunNum;
        }
    }
}
