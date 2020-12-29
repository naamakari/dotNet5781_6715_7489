using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using BO;
using APIBL;

namespace UIConsole
{
    class Program
    {
        static IBL bl;

        static void Main(string[] args)
        {
            bl = BlFactory.GetBL();
            bl.AddBusStation(new BusStation()
            {
                StationName = "hamacabim/ halulav",
                Address = "hamacabim 9",
                Latitude = (float)34.25687,
                Longitude = (float)31.23456
            });

            BusStationBL busStationBL = bl.GetBusStationBL(1112);
            Console.WriteLine(busStationBL);
            Console.WriteLine("========================");
            busStationBL.Address = "hhhhhh";
            bl.DeleteBusStation(1111);
            busStationBL = bl.GetBusStationBL(1112);
            Console.WriteLine(busStationBL);


            Console.ReadKey();
        }
       
    }
  
}
