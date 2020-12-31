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
    public class BusStation
    {
        public int StationCode { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public string Address { get; set; }
        public string StationName { get; set; }
        public override string ToString()
        {
            return HelpToString.ToStringProperty(this);
        }

    }
}
