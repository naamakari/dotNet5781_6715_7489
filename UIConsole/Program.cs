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

            //bl.AddBusStation(new BusStation()
            //{
            //    StationName = "hamacabim/ halulav",
            //    Address = "hamacabim 9",
            //    Latitude = (float)34.25687,
            //    Longitude = (float)31.23456
            //});

            //BusStationBL busStationBL = bl.GetBusStationBL(1112);
            //Console.WriteLine(busStationBL);
            //Console.WriteLine("========================");
            //busStationBL.Address = "hhhhhh";
            //bl.DeleteBusStation(1111);

            //BusLineBL line = bl.GetBusLineBL(1111);
            //Console.WriteLine(line);

            //IEnumerable<BusLineBL> busLines= bl.GetAllLines();
            // foreach(BusLineBL item in busLines)
            //     Console.WriteLine(item);
            //Console.WriteLine("======================================");
            //IEnumerable<BusStation> busStations = bl.GetAllStationsBy(x => x.StationCode == 1130 || x.StationCode == 1145); 

            //    bl.AddBusLine(new BusLineBL() { BusNumLine=15, AreaAtLand=Area.Jerusalem,
            //     FirstStation=bl.GetBusStationBL(1130),NumberFirstStation=1130
            //     ,LastStation=bl.GetBusStationBL(1145),NumberLastStation=1145,
            //      CollectionOfStation=busStations ,NumberOfStation=2
            //});


            //Console.WriteLine(bl.GetBusLineBL(1121));
            //foreach(BusLine item in busLines)
            //    Console.WriteLine(item);
            //IEnumerable<BusLineBL> busLines1 = bl.GetAllLines();
            //foreach (BusLineBL item in busLines1)
            //    Console.WriteLine(item);

            //Console.WriteLine("###################################################");
            //bl.DeleteBusLine(bl.GetBusLineBL(1111));
            //IEnumerable<BusLineBL> busLines = bl.GetAllLines();
            //foreach (BusLineBL item in busLines)
            //    Console.WriteLine(item);


            //StationInLine stationInLine=  new StationInLine()
            //  {
            //      LineId = 1111,
            //      StationCode = 1123,
            //      IsDeleted = false,
            //      IsFirstStation = false,
            //      IsLastStation = false,
            //      IndexStationAtLine = 5,

            //  };
            //  bl.AddStationToBus(stationInLine);
            //  IEnumerable<BusLineBL> busLines = bl.GetAllLines();
            //  foreach (BusLineBL item in busLines)
            //     Console.WriteLine(item);

            //BusLine busLine = bl.GetBusLineBL(1112);
            //Console.WriteLine(busLine);
            //Console.WriteLine("#@#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            //busLine.BusNumLine = 512;
            //bl.UpdateBusLine(busLine);
            //Console.WriteLine(busLine);

            IEnumerable<BusLineBL> busLineBLs = bl.GetAllLinesBy(x => x.NumberFirstStation == 1123);
            foreach (BusLineBL item in busLineBLs)
                Console.WriteLine(item);
            Console.ReadKey();
        }
       
    }
  
}
