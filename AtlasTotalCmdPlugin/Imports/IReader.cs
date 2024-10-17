using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPoints.Imports
{
    public interface IReadCoords
    {
        public bool Open(string file);
        public void Load(DataGridView view);

        public void Close();

        public string GetExt();
    }
}
