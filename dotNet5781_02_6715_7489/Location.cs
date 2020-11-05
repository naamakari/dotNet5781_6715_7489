using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace dotNet5781_02_6715_7489
{
    /// <summary>
    /// class for location of the station
    /// </summary>
    public class Location
    {
        static public Random rand = new Random(DateTime.Now.Millisecond);
        public float Latitude { get; }
        public float Longitude { get; }
        public Location()
        {
            //choose a random numbers 
            Latitude = (float)rand.NextDouble() + rand.Next(31, 34);
            Longitude = (float)rand.NextDouble() + rand.Next(34, 36);
        }
        public override string ToString()
        {
            return Latitude + "°N " + Longitude + "°E";
        }

        /// <summary>
        /// calculate distance formula
        /// </summary>
        /// <param name="loca"></param>
        /// <returns></returns>
        public float GetDistanceTo(Location loca)
        {
           return (float)Math.Sqrt(Math.Pow(this.Latitude - loca.Latitude, 2) + Math.Pow(this.Longitude - loca.Longitude, 2));
        }
    }
    
}
