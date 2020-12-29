using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    /// <summary>
    /// class for presentation for  UI
    /// </summary>
    public class BusLineBL:BusLine
    {
      public BusStation FirstStation { get; set; }
       public BusStation LastStation { get; set; }
        public IEnumerable<BO.BusStation> CollectionOfStation { get; set; }
        public override string ToString()
        {
            return HelpToString.ToStringProperty(this);
        }
    }
}
