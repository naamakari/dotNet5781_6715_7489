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
       
        public List<LineOfBus> lineAcordingStation(int code)
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
