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
    public class BusLine
    {
       public int BusId { get; set; }
        public int BusNumLine { get; set; }
        public Area AreaAtLand { get; set; }
        public int FirstStationCode { get; set; }
        public int LastStationCode { get; set; } 
        public int NumberOfStation { get; set; }
        public override string ToString()
        {
            return HelpToString.ToStringProperty(this);
        }
    }
}
