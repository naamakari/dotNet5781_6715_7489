using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
   public class FollowingStations
    {
        public int StationCode1 { get; set; }
        public int StationCode2 { get; set; }
        //public string key { get; set; }
        public float DistanceBetweenStations { get; set; }
        public DateTime TimeTravelBetweenStations { get; set; }
        public override string ToString()
        {
            return HelpToString.ToStringProperty(this);
        }

    }
}
