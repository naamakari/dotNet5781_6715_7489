using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    /// <summary>
    /// class for user that inter to the system
    /// </summary>
   public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool ManagePermission { get; set; }
        public override string ToString()
        {
            return HelpToString.ToStringProperty(this);
        }
    }
}
