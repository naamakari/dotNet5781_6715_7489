﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Location
    {
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public override string ToString()
        {
            return HelpToString.ToStringProperty(this);
        }
    }
}