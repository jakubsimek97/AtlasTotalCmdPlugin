using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPoints.Operations
{
    public class Centroid : IOperation
    {
        public string name;
        public Centroid()
        {
            name = "Reduction to centroid";
        }

        public void Transform(DataGridView view)
        {

        }

        public string GetNameOperation()
        {
            return name;
        }
    }
}
