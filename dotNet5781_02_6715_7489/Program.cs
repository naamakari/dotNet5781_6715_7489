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
        public float Latitude { get; }
       public float Longitude { get;}
        public location()
        {
            //choose a random numbers 
            Latitude = (float)rand.NextDouble() + rand.Next(31, 34);
            Longitude = (float)rand.NextDouble() + rand.Next(34, 36);
        }
        public override string ToString()
        {
            return Latitude + "°N " + Longitude + "°E";
        }
    }


    /// <summary>
    /// class for bus station
    /// </summary>
    /// <param name="args"></param>
    public class busStation
    {

        
        public string StationCode
        {
            get;
           private set;
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
    static public Random rand = new Random(DateTime.Now.Millisecond);
        public float DistFromLast { get; set; }
        public float TimeFromLast { get; set; }

        public lineBusStation(string code, string address = "/0") :base(code, address)
        {
            DistFromLast = (float)rand.NextDouble() + rand.Next(550);
            TimeFromLast = rand.Next(360);
        }

    }

    public enum Area{ North,South,Center,Jerusalem,General}
    /// <summary>
    /// 
    /// </summary>
    public class lineOfBus
    {

        public List<lineBusStation> Stations { get; set; }//להגדיר רשימה בתכנית הראשית שנשלחת לבנאי
        public int NumLine { get; set; }
        public lineBusStation FirstStation { get; set; }
        public lineBusStation LastStation { get; set; }
        public Area AreaAtLand { get; set; }

        //constructor
        public lineOfBus(List<lineBusStation> line,int num,Area area)
        {
            Stations = new List<lineBusStation>();
            foreach (lineBusStation item in line)//copy the list
                Stations.Add(item);
            Stations.First().DistFromLast = 0;//מעדכנים שמרחק התחנה הראשונה מהמתחנה שלפניה הוא 0
            Stations.First().TimeFromLast = 0;//מעדכנים שהזמן בין התחנה הראשונה לתחנה שלפניה הוא 0 
            FirstStation =Stations.First();//מעדכן את המאפיין להיות שווה לתחנה הראשונה ברשימה
            LastStation = Stations.Last();//מעדכן את המאפיין להיות שווה לתחנה האחרונה ברשימה
            AreaAtLand = area;
            NumLine = num;
        }

    
          
        public override string ToString()
        {
            return NumLine + ", " + AreaAtLand + ", ";//+ f1();
        }

        public void AddRemoveStation(string code,char sign)
        {

        }
        public bool IsExistAtPath(string code)
        {
            foreach (lineBusStation item in Stations)
                if (item.StationCode == code)
                    return true;
            return false;
        }

        public float DisBetweenStation(string code1, string code2)
        {
            return 
        }
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
