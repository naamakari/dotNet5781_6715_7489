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
            Console.WriteLine("HIII");
           // Bus bus1 = bl.GetBus("1111111");
            bl.AddBus(new Bus()
            {
                LicenseNumber = "1234567",
                StartDate = new DateTime(2000, 1, 2),
                Kilometraz = 1000,
                KmSinceLastTreat = 50,
                KmSinceRefeul = 100,
                DateSinceLastTreat = new DateTime(2020, 12, 3),
                BusState = BusStatus.ready,
                IsDeleted = false
            });

            Bus bus1 = bl.GetBus("1234567");
            bus1.Kilometraz=50;
            bl.UpdateBus(bus1);
            IEnumerable<Bus> buses = bl.GetAllBuses();
            foreach(var item in buses)
                Console.WriteLine(item);
            Console.WriteLine("========================================================");
            IEnumerable<Bus> busesBy = bl.GetAllBusesBy(item=>item.Kilometraz>=1000);
            foreach (var item in busesBy)
                Console.WriteLine(item);



            Console.ReadKey();
        }
       
    }
  
}
