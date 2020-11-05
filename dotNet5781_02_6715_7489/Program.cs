using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_6715_7489
{
    class Program
    {
        static public Random rand = new Random(DateTime.Now.Millisecond);
        static void Main(string[] args)
        { 
            int stationIndex=0;
            int linesStations=0;
            List<BusStation> busStationsList = new List<BusStation>();
            List<LineOfBus> lineOfBusesList = new List<LineOfBus>();
            string address ="a";
            for (int i = stationIndex; i < 40; i++, address+= address)
                busStationsList[i] = new BusStation(address);
            for (int i = linesStations; i < 10; i++)
                lineOfBusesList[i] = new LineOfBus((Area)rand.Next(0,4));
            Console.ReadKey();
        }
    }
}
