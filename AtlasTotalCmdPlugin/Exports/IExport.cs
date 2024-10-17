using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPoints.Exports
{
    public interface IExport
    {
        public bool Save(DataGridView view, string file);
        public string GetExportName();
    }
}
