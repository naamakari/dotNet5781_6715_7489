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
            Bus bus1 = bl.GetBus("1111111");
            Console.WriteLine(bus1) ;
            Console.ReadKey();
        }
       
    }
  
}
