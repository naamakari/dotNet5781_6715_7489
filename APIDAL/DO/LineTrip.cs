using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
   public class LineTrip
    {
        public int Id { get; set; }
        public int LineId { get; set; }
        public int NumLine { get; set; }
        public TimeSpan StartAt { get; set; }
        public TimeSpan EndAt { get; set; }
        public int Frequency { get; set; }
    }
}
