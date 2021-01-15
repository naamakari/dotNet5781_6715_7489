using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    /// <summary>
    /// class for line bus schedule view
    /// </summary>
    public class LineTiming
    {
        public TimeSpan TripStart { get; set; }
        public int LineId { get; set; }
        public int BusNumLine { get; set; }
        public string LastStation { get; set; }
        public TimeSpan Timing { get; set; }
        public TimeSpan TimingForDest { get; set; }
    }
}
