using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_6715_7489
{
    public enum Area { North, South, Center, Jerusalem, General }
    public class LineOfBus
    {
        public List<LineBusStation> Stations { get; set; }//להגדיר רשימה בתכנית הראשית שנשלחת לבנאי
        public int NumLine { get; set; }
        public LineBusStation FirstStation { get; set; }
        public LineBusStation LastStation { get; set; }
        public Area AreaAtLand { get; set; }

        //constructor
        public LineOfBus(List<LineBusStation> line, int num, Area area)
        {
            Stations = new List<LineBusStation>();
            foreach (LineBusStation item in line)//copy the list
                Stations.Add(item);
            Stations.First().DistFromLast = 0;//מעדכנים שמרחק התחנה הראשונה מהמתחנה שלפניה הוא 0
            Stations.First().TimeFromLast = 0;//מעדכנים שהזמן בין התחנה הראשונה לתחנה שלפניה הוא 0 
            FirstStation = Stations.First();//מעדכן את המאפיין להיות שווה לתחנה הראשונה ברשימה
            LastStation = Stations.Last();//מעדכן את המאפיין להיות שווה לתחנה האחרונה ברשימה
            AreaAtLand = area;
            NumLine = num;
        }



        public override string ToString()
        {
            return NumLine + ", " + AreaAtLand + ", ";//+ f1();
        }

        public void AddRemoveStation(LineBusStation station, char sign)
        {
            int index = 0;
            foreach (LineBusStation item in Stations)
            {
                index++;
                if (item.StationCode == station.StationCode)
                    break;

            }
            if (sign == 'a')//הוספה
            {
                Stations.Insert(index + 1, station);
            }
            else if (sign == 'r')
            {
                Stations.Remove(station);
            }
        }
        public bool IsExistAtPath(string code)
        {
            foreach (LineBusStation item in Stations)
                if (item.StationCode == code)
                    return true;
            return false;
        }

        //public float DisBetweenStation(string code1, string code2)
        //{
        //    return
        //}
    }
}
