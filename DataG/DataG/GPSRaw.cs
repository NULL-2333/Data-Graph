using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataG
{
    class GPSRaw
    {
        public Int32 curr_time;
        public Int32 lat;
        public Int32 lat_min;
        public Int32 lon;
        public Int32 lon_min;
        public Int32 speed;
        public static ulong bytes_allocd;
        public static ulong bytes_freed;
        public const double EARTH_RAD_M = 6378100.00;  // Radius of earth in meters
        public const double EARTH_RAD_FT = 20925525.0; // Radius of earth in feet
        public const double EARTH_RAD_MI = 3963.16700; // Radius of earth in miles
        public static double DEG2RAD(double x)  // Convert degrees to radians
        {
            return x * 0.017453293;
        }
        public static double RAD2DEG(double x)  // Convert radians to degrees
        {
            return x * 57.29577951;
        }
        public static double KNTS2MPH(double x) // Convert knots to mph
        {
            return x * 1.150780000;
        }
        public static double KNTS2MS(double x)  // Convert knots to m/s
        {
            return x * 0.514440000;
        }
        public static double KNTS2KPH(double x) // Convert knots to kph
        {
            return x * 1.852000000;
        }
        public static double KNTS2FPS(double x) // Convert knots to fps
        {
            return x * 1.687810000;
        }
        public static double getLatitude(GPSRaw data)
        {
            return 0.017453293 * ((double)data.lat + ((double)data.lat_min / 600000.0));
        }
        public static double getLongitude(GPSRaw data)
        {
            return 0.017453293 * ((double)data.lon + ((double)data.lon_min / 600000.0));
        }

        public static double getSpeedMPH(GPSRaw data)
        {
            
            return KNTS2MPH(data.speed);
        }

        public static double getSpeedMS(GPSRaw data)
        {
            return KNTS2MS(data.speed);
        }

        public static double getSpeedKPH(GPSRaw data)
        {
            return KNTS2KPH(data.speed);
        }

        public static double getSpeedFPS(GPSRaw data)
        {
            return KNTS2FPS(data.speed);
        }
    }
}
