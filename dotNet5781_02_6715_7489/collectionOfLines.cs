using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_6715_7489
{
    public class CollectionOfLines:IEnumerable
    {
        public List<LineOfBus> Lines;
        public IEnumerator GetEnumerator()
        {
            return Lines.GetEnumerator();
        }

        public CollectionOfLines()
        {
            Lines = new List<LineOfBus>();
        }

        public void AddLine(LineOfBus lineBus)
        {
            //add line to the collection 
            LineOfBus line_Bus = Lines.Find(x => x.NumLine == lineBus.NumLine);
            if (line_Bus!=null)//if a bus with the same line number is found
            {
                //Check if it is the same line in opposite directions
                if (line_Bus.FirstStation.CompareTo(lineBus.LastStation) != 0 || line_Bus.FirstStation.CompareTo(lineBus.LastStation) != 0)
                    throw new ArgumentException("ERROR! the num of line exists in the system");
            }
            else
            {
                if (lineBus.Stations.Count != 0)//Check if there are stations on the bus line
                    Lines.Add(lineBus);
                else
                    throw new ArgumentException("ERROR! there are no stops on this bus line");
            }
        }
       
        public List<LineOfBus> LineAcordingStation(int code)
        {
            //return list of the lines that contain the current station 
            if(Lines.FindAll(x => x.IsStation(code) == true)!=null)
                return Lines.FindAll(x=>x.IsStation(code)==true);
            throw new ArgumentException("No lines were found passing through this station");
        }

        public List<LineOfBus> SortLines()
        {
            Lines.Sort();
            return Lines;
        }

    }
}
