using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataG
{
    class GLPointArr
    {
        ulong length;
	    GLPoint[] array;
        GLPointArr newGLPointArr(GPSRectArr raw)
        {
	        if(raw.array == null) return null;
	
	        GLPointArr res = new GLPointArr();
	        res.array = new GLPoint[(ulong)System.Runtime.InteropServices.Marshal.SizeOf(new GLPoint())*raw.length];
	        res.length = raw.length;

	        Vector.Vector3 p0, v0, v1;
	        p0.x = raw.array[0].x;
	        p0.y = raw.array[0].y;
	        p0.z = raw.array[0].z;
	
	        GPSRectArr.originateArray(raw);
	        v0.x = raw.array[1].x;
	        v0.y = raw.array[1].y;
	        v0.z = raw.array[1].z;
	        v0 = Vector.vectorNormalize3(v0);

	        v1 = Vector.vectorCross(p0, v0);
	        v1 = Vector.vectorNormalize3(v1);

	        ulong n;
	        for(n = 0; n < raw.length; n++)
	        {
		        // New vector : <v1 . v, v0 . v>
		        res.array[n].raw.x = raw.array[n].x;
		        res.array[n].raw.y = raw.array[n].y;
		        res.array[n].raw.z = raw.array[n].z;
		        res.array[n].speed = raw.array[n].speed_knots;

		        res.array[n].pt.x = Vector.vectorDot3(v1, res.array[n].raw);
		        res.array[n].pt.y = Vector.vectorDot3(v0, res.array[n].raw);
	        }

            GPSRectArr.deleteDataGPSRectArr(raw);
	        return res;
        }

        GLPointArr newGLPointArr_LL(GPSRectArr raw)
        {
	        if(raw.array == null) return null;
	
	        GLPointArr res = new GLPointArr();
	        res.array = new GLPoint[(ulong)System.Runtime.InteropServices.Marshal.SizeOf(new GLPoint())*raw.length];
	        res.length = raw.length;
	        Vector.Vector2 LaLo0;
	        LaLo0.x = raw.array[0].theta_lat;
	        LaLo0.y = raw.array[0].theta_lon;

	        ulong n;
	        for(n = 0; n < raw.length; n++)
	        {
		        res.array[n].raw.x = raw.array[n].x;
		        res.array[n].raw.y = raw.array[n].y;
		        res.array[n].raw.z = raw.array[n].z;
		        res.array[n].speed = raw.array[n].speed_knots;
	
		        res.array[n].pt.x = raw.array[n].theta_lon - LaLo0.y;
		        res.array[n].pt.y = raw.array[n].theta_lat - LaLo0.x;
		        res.array[n].pt.x *= GPSRaw.EARTH_RAD_M;
                res.array[n].pt.y *= GPSRaw.EARTH_RAD_M * Math.Sin(raw.array[n].theta_lon);
	        }
	        return res;
        }
    }
}
