using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public enum Area { North, South, Center, Jerusalem, General }
    public class BusLine
    {
        public int BusId { get; set; }
        public int BusNumLine { get; set; }
        public Area AreaAtLand { get; set; }
        public int NumberFirstStation { get; set; }
        public int NumberLastStation { get; set; }
        public bool isDeleted { get; set; }

    }
}
