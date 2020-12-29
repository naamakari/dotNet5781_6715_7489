using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    /// <summary>
    /// class for line of bus 
    /// </summary>
    public class BusLine
    {
       public int BusId { get; set; }
        public int BusNumLine { get; set; }
        public Area AreaAtLand { get; set; }
        public int NumberFirstStation { get; set; }
        public int NumberLastStation { get; set; }
        public override string ToString()
        {
            return HelpToString.ToStringProperty(this);
        }
    }
}
