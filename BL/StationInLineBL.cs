using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    /// <summary>
    /// class for station that is at line
    /// </summary>
    public class stationInLineBL
    {
      public  int LineId { get; set; }
        public int StationCode { get; set; }
        public int IndexStationAtLine { get; set; }
        public bool IsDeleted { get; set; }
        public override string ToString()
        {
            return HelpToString.ToStringProperty(this);
        }
    }
}
