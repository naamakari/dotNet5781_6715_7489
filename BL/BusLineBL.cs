using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    /// <summary>
    /// class for line of bus 
    /// </summary>
    public enum Area { North, South, Center, Jerusalem, General }
    public class BusLineBL
    {
       public int BusId { get; set; }
        public int BusNumLine { get; set; }
        public Area AreaAtLand { get; set; }
        public BusStationBL FirstStation { get; set; }
        public BusStationBL LastStation { get; set; }
        public IEnumerable<stationInLineBL> CollectionOfStation { get; set; }
        public override string ToString()
        {
            return HelpToString.ToStringProperty(this);
        }
    }
}
