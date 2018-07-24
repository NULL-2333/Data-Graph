using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataG
{
    class Vector
    {
        public struct Vector2
        {
            public double x;
            public double y;
        };

        public struct Vector3
        {
            public double x;
            public double y;
            public double z;
        };
        public static Vector3 vectorCross(Vector3 v1, Vector3 v2)
        {
            Vector3 res;
            res.x = (v1.y * v2.z) - (v1.z * v2.y);
            res.y = (v1.z * v2.x) - (v1.x * v2.z);
            res.z = (v1.x * v2.y) - (v1.y * v2.x);
            return res;
        }

        public static double vectorDot3(Vector3 v1, Vector3 v2)
        {
            return (v1.x * v2.x) + (v1.y * v2.y) + (v1.z * v2.z);
        }

        public static Vector3 vectorNormalize3(Vector3 v)
        {
            double factor = Math.Sqrt(vectorDot3(v, v));
            v.x /= factor;
            v.y /= factor;
            v.z /= factor;
            return v;
        }

        public static double vectorDot2(Vector2 v1, Vector2 v2)
        {
            return (v1.x * v2.x) + (v1.y * v2.y);
        }

        public static Vector2 vectorNormalize2(Vector2 v)
        {
            double factor = Math.Sqrt(vectorDot2(v, v));
            v.x /= factor;
            v.y /= factor;
            return v;
        }
    }
}
