using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotNet5781_01_6715_7489;

namespace dotNet5781_03B_6715_7489
{
    public class StatusChangedObserver
    {
        public StatusChangedObserver(Bus bus)
        {
            bus.StatusChanged +=MainWindow.Bus_StatusChanged;
        }
        public StatusChangedObserver(Bus bus, int i)
        {
           
            bus.StatusChanged += toDrive.Bus_StatusChanged;
            
        }
        public StatusChangedObserver(Bus bus, bool flag)
        {
          
            bus.StatusChanged += disPlayDetails.Bus_StatusChanged1;
        }
        public StatusChangedObserver(Bus bus, char ch)
        {

            bus.StatusChanged +=disPlayDetails.Bus_StatusChanged;
        }

    }
}
