using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataG
{
    class GPSRect
    {
        public double x;
        public double y;
        public double z;
        public double theta_lat;
        public double theta_lon;
        public double speed_knots;
        GPSRect raw2rect(GPSRaw raw_data)
        {
            // Conversion from polar to rectangular coords
            GPSRect res = new GPSRect();
            res.theta_lat = GPSRaw.getLatitude(raw_data);
            res.theta_lon = GPSRaw.getLongitude(raw_data);
            res.x = GPSRaw.EARTH_RAD_M * Math.Cos(res.theta_lat) * Math.Cos(res.theta_lon);
            res.y = GPSRaw.EARTH_RAD_M * Math.Cos(res.theta_lat) * Math.Sin(res.theta_lon);
            res.z = GPSRaw.EARTH_RAD_M * Math.Sin(res.theta_lat);
            res.speed_knots = raw_data.speed;
            return res;
        }
    }
}
