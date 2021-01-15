using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    /// <summary>
    /// class for presentation of bus station for UI with details of the lines that pass through it all the lines that pass there
    /// </summary>
    public class BusStationBL:BusStation
    {
        public string Location { get; set; }
      public  IEnumerable<BO.BusLine> CollectionBusLines { get; set; }
        public override string ToString()
        {
            return HelpToString.ToStringProperty(this);
        }

    }
}
