using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPoints.Operations
{
    public interface IOperation
    {
        public void Transform(DataGridView view);
        public string GetNameOperation();
    }
}
