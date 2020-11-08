using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_6715_7489
{
    public enum Area { North, South, Center, Jerusalem, General }
    /// <summary>
    /// Comparable class of bus lines
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
        public LineOfBus(LineBusStation startStation, LineBusStation destStation, Area area)
        {
            Stations = new List<LineBusStation>();
            Stations.Add(startStation);
            destStation.DistFromLast = destStation.Station.StationLocation.GetDistanceTo(startStation.Station.StationLocation);
            destStation.TimeFromLast = (int)destStation.DistFromLast;
            Stations.Add(destStation);
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

        public void AddRemoveStation(LineBusStation addSta, char sign, int addIndex=0)
        {
            int index;
            if (sign == 'a')//adding
            {
                if(addIndex>=0&&addIndex<= Stations.Count)//check if the index exist at the list
                { 
                Stations.Insert(addIndex, addSta);
                    if (addIndex == 0)//Want to add a station at the first place
                    {
                        Stations.First().DistFromLast = 0;
                        Stations.First().TimeFromLast = 0;
                    }
                    else//If the station is in the middle of the list or at the end
                    {
                        //index = Stations.FindIndex(x => x.Station.StationCode == codeBefore);
                        if (addIndex+1 == Stations.Count)//If the station you want to insert is the last station
                        {
                            addSta.DistFromLast = Stations[addIndex-1].Station.StationLocation.GetDistanceTo(addSta.Station.StationLocation);
                            addSta.TimeFromLast = (int)addSta.DistFromLast;//Calculate per average time of 60 km per hour and km per minute

                        }
                 
                    }
                
                }
                else //The organ after which you want to insert does not exist
                    throw new ArgumentException("The station isn't exist!!");

            }
            else if (sign == 'r')//Remove a station from the list
            {
                if (Stations.Count == 2)//if the user want to delete a station from a line wite 2 stations only
                    throw new MinimunStationsExeption("can not delete this station from this line");
                index = Stations.FindIndex(x => x == addSta);
                if (index == 0)//If we deleted the first station from the list
                {
                    Stations[1].DistFromLast = 0;
                    Stations[1].TimeFromLast = 0;
                }
                else  if (index == -1)
                    throw new ArgumentException("The station isn't exist!!");
                else if(index!=Stations.Count)//if the station that we want to delete is not th last one
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
            //Find the index in the list according to the first code given
            firstIndex = Stations.FindIndex(x => x.Station.StationCode == code1);
            //Find the index in the list according to the second code given
            lastIndex = Stations.FindIndex(x => x.Station.StationCode == code2);
            //If one of the station codes is not present
            if (firstIndex == -1 || lastIndex == -1)
                throw new ArgumentException("The station isn't exist!!");
            //Add to the sum all the travel distances of one of the stations
            for (int i = firstIndex; i <= lastIndex; i++)
                sumDis += Stations[i].DistFromLast;
            return sumDis;
        }
        public int TimeBetweenStations(int code1, int code2)
        {
            int firstIndex, lastIndex;
            int sumTime = 0;
            //Find the index in the list according to the first code given
            firstIndex = Stations.FindIndex(x => x.Station.StationCode == code1);
            //Find the index in the list according to the second code given
            lastIndex = Stations.FindIndex(x => x.Station.StationCode == code2);
            //If one of the station codes is not present
            if (firstIndex == -1 || lastIndex == -1)
                throw new ArgumentException("The station isn't exist!!");
            //Add to the sum all the travel times of one of the stations
            for (int i = firstIndex; i <= lastIndex; i++)
                sumTime += Stations[i].TimeFromLast;
            return sumTime;
        }
        public LineOfBus subPath(LineBusStation station1, LineBusStation station2)
        {
            LineOfBus newLine = new LineOfBus(station1,station2,this.AreaAtLand);


            int firstIndex, lastIndex;
            //We will find the indexes of the first and last place
            firstIndex = Stations.FindIndex(x => x.Station.StationCode == station1.Station.StationCode);
            lastIndex = Stations.FindIndex(x => x.Station.StationCode == station2.Station.StationCode);
            if (firstIndex == -1 || lastIndex == -1)
                throw new ArgumentException("The station isn't exist!!");
            for (int i = firstIndex; i <= lastIndex; i++)
                //We will add the appropriate stations to the new line
                newLine.AddRemoveStation(Stations[i], 'a', Stations[i - 1].Station.StationCode);
            return newLine;
        }
        //Implementation of the ComputerTo function
        public int CompareTo(object obj)
        {
            LineOfBus lb = (LineOfBus)obj;
            int thisTime, lbTime;
            thisTime = this.TimeBetweenStations(this.FirstStation.Station.StationCode, this.LastStation.Station.StationCode);
            lbTime = lb.TimeBetweenStations(lb.FirstStation.Station.StationCode, lb.LastStation.Station.StationCode);
            return thisTime.CompareTo(lbTime);
        }
        public bool IsStation( int code)
        {
            //the method search if some station is exist at bus
            foreach (LineBusStation item in Stations)
                if (item.Station.StationCode == code)
                    return true;
            return false;
        }

        public LineBusStation Search(int code)
        {
            //the method search if some station is exist at bus
            foreach (LineBusStation item in Stations)
                if (item.Station.StationCode == code)
                    return item;
            throw new ArgumentException("The station isn't exist!!");
        }

    }
}
