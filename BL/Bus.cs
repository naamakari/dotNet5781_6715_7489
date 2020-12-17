using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BO
{
    public enum BusStatus { inDrive, ready, inRefuel, inTreat }

    /// <summary>
    /// class for every bus at the system at layer BL
    /// </summary>

    public class Bus
    {
        public string LicenseNumber { get; set; }
        public DateTime StartDate { get; set; }
        public float Kilometraz { get; set; }
        public float KmSinceRefeul { get; set; }
        public DateTime DateSinceLastTreat { get; set; }
        public float KmSinceLastTreat { get; set; }
        public BusStatus BusState { get; set; }
        public bool IsDeleted { get; set; }
        public override string ToString()
        {
            return HelpToString.ToStringProperty(this);
        }
    }
}
