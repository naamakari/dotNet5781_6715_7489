using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    /// <summary>
    /// class of station that bus pass over there
    /// </summary>
    public class BusStationBL
    {
        public int StationCode { get; set; }
        public LocationBL StationLocation { get; set; }
        public string Address { get; set; }

        public string StationName { get; set; }
        IEnumerable<BusLineBL> CollectionBusLines { get; set; }
        public override string ToString()
        {
            return HelpToString.ToStringProperty(this);
        }

    }
}
