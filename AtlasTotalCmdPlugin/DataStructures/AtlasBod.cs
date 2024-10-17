using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TCPoints.DataStructures
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class TablePoint
    {
        public byte pri, typbo;
        public double x, y, z;
        public long ukaz;
    }
}
