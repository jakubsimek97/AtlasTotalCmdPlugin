using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPoints.DataStructures
{
    // 3d point implementation
    public class Bod
    {
        public double X, Y, Z;
        public Bod(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Bod()
        {
            X = 0; Y = 0; Z = 0;
        }

        public static Bod operator +(Bod b1, Bod b2)
        {
            return new Bod(b1.X + b2.X, b1.Y + b2.Y, b1.Z + b2.Z);
        }

        public static Bod operator /(Bod b, double k)
        {
            return new Bod(b.X / k, b.Y / k, b.Z / k);
        }

        public static Bod operator -(Bod b1, Bod b2)
        {
            return new Bod(b1.X - b2.X, b1.Y - b2.Y, b1.Z - b2.Z);
        }
    }
}
