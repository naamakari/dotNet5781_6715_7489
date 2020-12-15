using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using APIDAL;
using DO;
using APIBL;

namespace BL
{
   public class BLIMP : IBL
    {
        readonly IDAL dal = DalFactory.GetDal();
        BusBL bus;
        Bus buss;
       public int stam(int  shuv)
        {
            dal.AddBus(buss);
            return 15;
        }
       
    }
}
