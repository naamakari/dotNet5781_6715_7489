using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    /// <summary>
    /// class for presentation of all the lines that pass there
    /// </summary>
    public class BusStationBL:BusStation
    {
      public  IEnumerable<BO.BusLine> CollectionBusLines { get; set; }

    }
}
