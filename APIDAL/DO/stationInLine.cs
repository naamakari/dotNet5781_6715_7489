﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    /// <summary>
    /// class for station that is at line
    /// </summary>
    public class stationInLine
    {
        public int LineId { get; set; }
        public int StationCode { get; set; }
        public int IndexStationAtLine { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsFirstStation { get; set; }
        public bool IsLastStation { get; set; }
        public override string ToString()
        {
            return HelpToString.ToStringProperty(this);
        }
    }
}
