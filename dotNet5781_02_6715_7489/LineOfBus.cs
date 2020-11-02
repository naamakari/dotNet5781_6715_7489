using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_6715_7489
{
    public enum Area { North, South, Center, Jerusalem, General }
    /// <summary>
    /// מחלקה ברת השוואה של קווי אוטובוס
    /// </summary>
    public class LineOfBus:IComparable
    {
        static int statisNumLine = 0;
        public List<LineBusStation> Stations { get; set; }//להגדיר רשימה בתכנית הראשית שנשלחת לבנאי
        public int NumLine { get; set; }
        public LineBusStation FirstStation { get; set; }
        public LineBusStation LastStation { get; set; }
        public Area AreaAtLand { get; set; }

        //constructor
        public LineOfBus(List<LineBusStation> line, Area area)
        {
            Stations = new List<LineBusStation>();
            foreach (LineBusStation item in line)//copy the list
                Stations.Add(item);
            Stations.First().DistFromLast = 0;//מעדכנים שמרחק התחנה הראשונה מהמתחנה שלפניה הוא 0
            Stations.First().TimeFromLast = 0;//מעדכנים שהזמן בין התחנה הראשונה לתחנה שלפניה הוא 0 
            FirstStation = Stations.First();//מעדכן את המאפיין להיות שווה לתחנה הראשונה ברשימה
            LastStation = Stations.Last();//מעדכן את המאפיין להיות שווה לתחנה האחרונה ברשימה
            AreaAtLand = area;
            NumLine= ++statisNumLine;
        }



        public override string ToString()
        {
            string str1 = "", str2 = "";
            foreach (LineBusStation item in Stations)
            {
                str1 += "-> ";
                str1 += item.Station.StationCode;
            }
            Stations.Reverse();//הןפך את הרשימה כדי שנוכל לעבור מהסוף להתחלה
            foreach (LineBusStation item in Stations)
            {
                str2 += "-> ";
                str2 += item.Station.StationCode;

            }
            Stations.Reverse();//הופך את הרשימה בחזרה לסדר המקורי
            return NumLine + ", " + AreaAtLand + ", " + str1 + ", " + str2;
        }

        public void AddRemoveStation(LineBusStation station, char sign, string code)
        {
            int index = -1;

            if (sign == 'a')//הוספה
            {
                if (code == "0")//רוצים להוסיף תחנה לפני התחנה הראשונה
                {
                    Stations.Insert(0, station);//מכניסים למקום הראשון ברשימה
                    FirstStation = station;//מעדכנים את המאפיין של המקום הראשון להיות התחנה שהתווספה
                    Stations.First().DistFromLast = 0;
                    Stations.First().TimeFromLast = 0;
                }
                else//אם התחנה היא באמצע הרשימה או בסופה
                {
                    foreach (LineBusStation item in Stations)
                    {
                        index++;//מונה את מספר האיברים ברשימה כדי לדעת לאן להכניס 
                        if (item.Station.StationCode == code)
                            break;

                    }
                    if (index == Stations.Capacity)//אם התחנה שאחריה רוצים הלכניס היא התחנה האחרונה
                    {
                        if (Stations[index].Station.StationCode == code)
                        {
                            Stations.Add(station);//תוסיף לסוף של הרשימה
                            LastStation = station;//תעדכן את המאפיין של התחנה האחרונה להיות התחנה שהתווספה עכשיו
                        }
                        else throw new ArgumentException("The station isn't exist!!");
                    }
                    else
                        Stations.Insert(index + 1, station);//הכנסה לאמצע הרשימה
                }


            }
            else if (sign == 'r')//הסרה של תחנה מהרשימה
            {
                if (IsExistAtPath(station.Station.StationCode) == true)//מצאנו את התחנה המבוקשת ברשימה
                {
                    Stations.Remove(station);
                    if (Stations.First().DistFromLast != 0)//אם מחקנו את התחנה הראשונה מהרשימה
                    {
                        Stations.First().DistFromLast = 0;
                        Stations.First().TimeFromLast = 0;
                    }
                }
                else
                    throw new ArgumentException("The station isn't exist!!");
            }
            else
                throw new ArgumentException("The caracter isn't valid!");
        }
        public bool IsExistAtPath(string code)
        {
            foreach (LineBusStation item in Stations)
                if (item.Station.StationCode == code)
                    return true;
            return false;
        }

        public float DisBetweenStations(string code1, string code2)
        {
            int firstIndex, lastIndex;
            float sumDis = 0;
            //מוצאים את האינדקס ברשימה לפני הקוד הראשון שניתן
            firstIndex = Stations.FindIndex(x => x.Station.StationCode == code1);
            //מוצאים את האינדקס ברשימה לפי הקוד השני שניתן
            lastIndex = Stations.FindIndex(x => x.Station.StationCode == code2);
            //אם אחד מקודי התחנה לא נמצאים
            if (firstIndex == -1 || lastIndex == -1)
                throw new ArgumentException("The station isn't exist!!");
            //תוסיף לסכום את כל מרחקי הנסיעה של אחת מהתחנות
            for (int i = firstIndex; i <= lastIndex; i++)
                sumDis += Stations[i].DistFromLast;
            return sumDis;
        }
        public int TimeBetweenStations(string code1, string code2)
        {
            int firstIndex, lastIndex;
            int sumTime = 0;
            //מוצאים את האינדקס ברשימה לפני הקוד הראשון שניתן
            firstIndex = Stations.FindIndex(x => x.Station.StationCode == code1);
            //מוצאים את האינדקס ברשימה לפי הקוד השני שניתן
            lastIndex = Stations.FindIndex(x => x.Station.StationCode == code2);
            //אם אחד מקודי התחנה לא נמצאים
            if (firstIndex == -1 || lastIndex == -1)
                throw new ArgumentException("The station isn't exist!!");
            //תוסיף לסכום את כל זמני הנסיעה של אחת מהתחנות
            for (int i = firstIndex; i <= lastIndex; i++)
                sumTime += Stations[i].TimeFromLast;
            return sumTime;
        }
        public LineOfBus subPath(BusStation station1, BusStation station2)
        {
            //ניצור רשימה חדשה כדי להעביר אליה את תת המסלול
            List<LineBusStation> newStation = new List<LineBusStation>();
            int firstIndex, lastIndex;
            firstIndex = Stations.FindIndex(x => x.Station.StationCode==station1.StationCode);
            lastIndex = Stations.FindIndex(x => x.Station.StationCode==station2.StationCode);
            if (firstIndex == -1 || lastIndex == -1)
                throw new ArgumentException("The station isn't exist!!");
            for (int i = firstIndex; i <= lastIndex; i++)
                //נוסיף לרשימה החדשה את כל האיברים המתאימים
                newStation.Add(Stations[i]);
            //נאתחל אותה בבנאי
            LineOfBus newLine = new LineOfBus(newStation, this.AreaAtLand);
            return newLine;
        }
        //מימוש של פונקציית קומפייר טו
        public int CompareTo(object obj)
        {
            LineOfBus lb = (LineOfBus)obj;
            int thisTime, lbTime;
            thisTime=this.TimeBetweenStations(this.FirstStation.Station.StationCode, this.LastStation.Station.StationCode);
           lbTime= lb.TimeBetweenStations(lb.FirstStation.Station.StationCode, lb.LastStation.Station.StationCode);
            return thisTime.CompareTo(lbTime);
        }

    }
}
