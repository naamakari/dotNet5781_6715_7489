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
           BusLineBL busLineBL= bl.GetBusLineBL(1111);
            BusStation busStation1 = bl.GetBusStationBL(1111);
            BusStation busStation2 = bl.GetBusStationBL(1118);

            Console.WriteLine(bl.GetLineTiming(busLineBL, busStation1, busStation2));

            Console.WriteLine("hi");
            Console.ReadKey();
        }

    }

}
