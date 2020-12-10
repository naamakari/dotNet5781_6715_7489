using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotNet5781_01_6715_7489;

namespace dotNet5781_03B_6715_7489
{
    static public class busStatic
    {
        
       static public ObservableCollection<Bus> buses;
        static busStatic()
        {
            buses = new ObservableCollection<Bus>();
            //the treat time of the bus is passed alreay
            buses.Add(new Bus("7297962", new DateTime(2012, 4, 25), new DateTime(2015, 11, 25), 8002, 520, 205000));
            //this buses is close to the kilometraz
            buses.Add(new Bus("87555201", new DateTime(2019, 5, 5), new DateTime(2020, 10, 5), 19999, 450, 100520));
            buses.Add(new Bus("7854212", new DateTime(2015, 12, 7), new DateTime(2020, 11, 25), 199989, 742, 302451));
            //this bus is heve little fuel
            buses.Add(new Bus("14452102", new DateTime(2020, 7, 8), new DateTime(2020, 8, 9), 5201, 1152, 50120));
            buses.Add(new Bus("4152635", new DateTime(2013, 9, 8), new DateTime(2020, 1, 12), 2010, 23, 870021));
            buses.Add(new Bus("5214522", new DateTime(2017, 4, 27), new DateTime(2020, 2, 6), 12012, 145, 78452));
            buses.Add(new Bus("78854401", new DateTime(2018, 6, 7), new DateTime(2020, 3, 14), 8554, 78, 33320));
            buses.Add(new Bus("79965402", new DateTime(2020, 10, 24), new DateTime(2020, 4, 27), 445, 41, 12345));
            buses.Add(new Bus("7448541", new DateTime(2016, 7, 1), new DateTime(2020, 5, 20), 11425, 745, 78451));
            buses.Add(new Bus("7996522", new DateTime(2013, 2, 3), new DateTime(2020, 12, 11), 785, 852, 748512));
        }
       
    }
}
