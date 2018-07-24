using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataG
{
    class GPSRectArr
    {
        public ulong length;
        public GPSRect[] array;
        public static void deleteDataGPSRectArr(GPSRectArr obj)
        {
            GPSRaw.bytes_freed += (ulong)System.Runtime.InteropServices.Marshal.SizeOf(new GPSRect()) * obj.length;
            obj.array = null;
            obj.length = 0;
        }
        public static void originateArray(GPSRectArr obj)
        {
	        if(obj.array == null) return;
	        if(obj.length == 0)
	        {
		        return;
	        }

	        double x0 = obj.array[0].x, y0 = obj.array[0].y, z0 = obj.array[0].z;
	        ulong n;
	        for(n = 0; n < obj.length; n++)
	        {
		        obj.array[n].x -= x0;
		        obj.array[n].y -= y0;
		        obj.array[n].z -= z0;
	        }
        }
    }
}
