﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
   public class LineTiming
    {
        public TimeSpan TripStart { get; set; }
        public int LineId { get; set; }
        public int BusNumLine { get; set; }
        public string LastStation { get; set; }
        public TimeSpan Timing { get; set; }
    }
}
