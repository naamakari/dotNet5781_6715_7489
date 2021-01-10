using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BL;

namespace APIBL
{
    public static class BlFactory
    {
        public static IBL GetBL()
        {
            return BLIMP.Instance;
        }
    }
}
