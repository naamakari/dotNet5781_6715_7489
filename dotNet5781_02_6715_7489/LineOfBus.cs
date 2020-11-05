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
    public class LineOfBus : IComparable
    {
        static int statisNumLine = 0;
        public List<LineBusStation> Stations { get; set; }//להגדיר רשימה בתכנית הראשית שנשלחת לבנאי
        public int NumLine { get; set; }
        public LineBusStation FirstStation { get { return Stations.First(); } }
        public LineBusStation LastStation { get { return Stations.Last(); } }
                    public Area AreaAtLand { get; set; }

        //constructor
        public LineOfBus(Area area)
        {
            Stations = new List<LineBusStation>();
            //foreach (LineBusStation item in line)//copy the list
            //    Stations.Add(item);
            //Stations.First().DistFromLast = 0;//מעדכנים שמרחק התחנה הראשונה מהמתחנה שלפניה הוא 0
            //Stations.First().TimeFromLast = 0;//מעדכנים שהזמן בין התחנה הראשונה לתחנה שלפניה הוא 0 
            //FirstStation = Stations.First();//מעדכן את המאפיין להיות שווה לתחנה הראשונה ברשימה
            //LastStation = Stations.Last();//מעדכן את המאפיין להיות שווה לתחנה האחרונה ברשימה
           
           
            AreaAtLand = area;
            NumLine = ++statisNumLine;
        }



        public override string ToString()
        {
            string str1 = "";
            foreach (LineBusStation item in Stations)
            {
                str1 += "-> ";
                str1 += item.Station.StationCode;
            }
            return NumLine + ", " + AreaAtLand + ", " + str1;
        }

        public void AddRemoveStation(LineBusStation addSta, char sign, int codeBefore)
        {
            int index;
            if (sign == 'a')//הוספה
            {

                if (codeBefore == 0)//רוצים להוסיף תחנה לפני התחנה הראשונה
                {
                    Stations.Insert(0, addSta);//מכניסים למקום הראשון ברשימה
                    Stations.First().DistFromLast = 0;
                    Stations.First().TimeFromLast = 0;
                }
                else//אם התחנה היא באמצע הרשימה או בסופה
                {
                    index = Stations.FindIndex(x => x.Station.StationCode == codeBefore);
                    if (index == Stations.Capacity)//אם התחנה שאחריה רוצים להכניס היא התחנה האחרונה
                    {


                        addSta.DistFromLast = Stations[index].Station.StationLocation.GetDistanceTo(addSta.Station.StationLocation);
                        addSta.TimeFromLast = (int)addSta.DistFromLast;//מחשב לפי זמן  ממוצע של 60 קמש לשעה וקמ לדקה
                        Stations.Add(addSta);//תוסיף לסוף של הרשימה



                    }
                    else if (index == -1)//האיבר שאחריו רוצים להכניס לא קיים
                        throw new ArgumentException("The station isn't exist!!");
                    else//רוצים להוסיף תחנה באמצע המסלול
                    {
                        addSta.DistFromLast = Stations[index].Station.StationLocation.GetDistanceTo(addSta.Station.StationLocation);
                        addSta.TimeFromLast = (int)addSta.DistFromLast;//מחשב לפי זמן  ממוצע של 60 קמש לשעה וקמ לדקה
                        addSta.DistFromLast = Stations[index].Station.StationLocation.GetDistanceTo(addSta.Station.StationLocation);
                        Stations.Insert(index + 1, addSta);//הכנסה לאמצע הרשימה
                    }
                }


            }
            else if (sign == 'r')//הסרה של תחנה מהרשימה
            {
                index = Stations.FindIndex(x => x == addSta);
                if (index == 0)//אם מחקנו את התחנה הראשונה מהרשימה
                {
                    Stations[1].DistFromLast = 0;
                    Stations[1].TimeFromLast = 0;
                }
                else  if (index == -1)
                    throw new ArgumentException("The station isn't exist!!");
                else
                {
                    Stations[index + 1].DistFromLast += Stations[index].DistFromLast;
                    Stations[index + 1].TimeFromLast += Stations[index].TimeFromLast;
                }
                Stations.Remove(addSta);
            }
            else
                throw new ArgumentException("The caracter isn't valid!");
        }
        public bool IsExistAtPath(int code)
        {
            foreach (LineBusStation item in Stations)
                if (item.Station.StationCode == code)
                    return true;
            return false;
        }

        public float DisBetweenStations(int code1, int code2)
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
        public int TimeBetweenStations(int code1, int code2)
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
            LineOfBus newLine = new LineOfBus(this.AreaAtLand);


            int firstIndex, lastIndex;
            //נמצא את האינדקסים של המקום הראשון והאחרון
            firstIndex = Stations.FindIndex(x => x.Station.StationCode == station1.StationCode);
            lastIndex = Stations.FindIndex(x => x.Station.StationCode == station2.StationCode);
            if (firstIndex == -1 || lastIndex == -1)
                throw new ArgumentException("The station isn't exist!!");
            for (int i = firstIndex; i <= lastIndex; i++)
                //נוסיף לקו החדש את התחנות המתאימות
                newLine.AddRemoveStation(Stations[i], 'a', Stations[i - 1].Station.StationCode);
            return newLine;
        }
        //מימוש של פונקציית קומפייר טו
        public int CompareTo(object obj)
        {
            LineOfBus lb = (LineOfBus)obj;
            int thisTime, lbTime;
            thisTime = this.TimeBetweenStations(this.FirstStation.Station.StationCode, this.LastStation.Station.StationCode);
            lbTime = lb.TimeBetweenStations(lb.FirstStation.Station.StationCode, lb.LastStation.Station.StationCode);
            return thisTime.CompareTo(lbTime);
        }
        public bool Search( int code)
        {
            //the method search if some station is exist at bus
            foreach (LineBusStation item in Stations)
                if (item.Station.StationCode == code)
                    return true;
            return false;
        }

    }
}
