using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    /// <summary>
    /// class for line of bus 
    /// </summary>
    public enum Area { North, South, Center, Jerusalem, General }
    public class BusLine
    {
        public int BusId { get; set; }
        public int BusNumLine { get; set; }
        public Area AreaAtLand { get; set; }
        public int NumberFirstStation { get; set; }
        public int NumberLastStation { get; set; }
        public bool IsDeleted { get; set; }
        public int NumberOfStation { get; set; }
        public override string ToString()
        {
            return HelpToString.ToStringProperty(this);
        }

    }
}
