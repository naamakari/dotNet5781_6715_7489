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
        List<LineOfBus> Lines;
        public IEnumerator GetEnumerator()
        {
            return Lines.GetEnumerator();
        }
        public bool condition(LineOfBus lnb, int code)
        {
            foreach (LineBusStation item in lnb.Stations)
                if (item.Station.StationCode == code)
                    return true;
        }
        public List<LineOfBus> lineAcordingStation(int code)
        {
            List<LineOfBus> newLines = new List<LineOfBus>();
            return Lines(condition(code));
            Lines.FindAll(x=>)
        }

    }
}
