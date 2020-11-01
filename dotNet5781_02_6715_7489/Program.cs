using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_6715_7489
{
    
    /// <summary>
    /// class for location of the station
    /// </summary>
    public class location
    {
        static public Random rand = new Random(DateTime.Now.Millisecond);
        float latitude;
        float longitude;
        public location()
        {
            //choose a random numbers 
            latitude = (float)rand.NextDouble() + rand.Next(31, 34);
            longitude = (float)rand.NextDouble() + rand.Next(34, 36);
        }
        public override string ToString()
        {
            return latitude + "°N " + longitude + "°E";
        }
    }


    /// <summary>
    /// class for bus station
    /// </summary>
    /// <param name="args"></param>
    public class busStation
    {

        private string station_code;
        public string StationCode
        {
            get { return station_code; }
            set { station_code = value; }
        }
        public location StationLocation;
        public String AddressOfStation;

        //defualt constructor
        public busStation() { }
        public busStation(string code,string address="/0")
            {
            StationCode = code;
            StationLocation = new location();
            AddressOfStation = address;
            }
        public override string ToString()
        {
            return "Bus station code: " + StationCode + ", " + StationLocation;
        }
    }

    /// <summary>
    /// class for line bus station
    /// </summary>
    public class lineBusStation: busStation
    {
        private float dist_From_Last;
        public float DistFromLast { get => dist_From_Last; set => dist_From_Last = value; }

        private float time_From_Last;
        public float TimeFromLast { get => time_From_Last; set => time_From_Last = value; }
    }

    class Program
    {

 
        static void Main(string[] args)
        {
            busStation bs=new busStation("1234","naharia");
            //bs.ToString();
            Console.WriteLine(bs);
            Console.ReadKey();
        }
    }
}
