using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vectors
{
    class GeomVector
    {
        public double x { get; }
        public double y { get; }
        public double z { get; }

        public GeomVector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static GeomVector operator +(GeomVector v1, GeomVector v2)
        {
            return new GeomVector(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }
        public static GeomVector operator -(GeomVector v1, GeomVector v2)
        {
            return new GeomVector(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }
        public static GeomVector operator *(GeomVector v1, GeomVector v2)
        {
            return new GeomVector(v1.y * v2.z - v1.z * v2.y,-v1.x*v2.z+v1.z*v2.x ,v1.x*v2.y-v1.y*v2.x);
        }
        public static GeomVector operator *(double num, GeomVector v1)
        {
            return new GeomVector(num * v1.x, num * v1.y, num * v1.z);
        }
        public static double scalarMultiplication(GeomVector v1, GeomVector v2)
        {
            return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
        }
        public double scalar()
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }
        public override string ToString()
        {
            return "(" + x + ", " + y + ", " + z + ")";
        }
    }
}
