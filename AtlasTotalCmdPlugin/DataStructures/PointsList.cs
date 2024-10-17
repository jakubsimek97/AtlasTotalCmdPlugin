using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPoints.DataStructures
{
    public class Points : List<Bod>
    {
        public Points()
        {

        }

        public void LoadFromDataGridView(DataGridView view)
        {
            foreach (DataGridViewRow row in view.Rows)
            {
                if (!row.IsNewRow)
                {
                    double x = Convert.ToDouble(row.Cells["X"].Value?.ToString());
                    double y = Convert.ToDouble(row.Cells["Y"].Value?.ToString());
                    double z = Convert.ToDouble(row.Cells["Z"].Value?.ToString());
                    this.Add(new Bod(x, y, z));
                }
            }
        }

        public Bod GetTeziste()
        {
            Bod teziste = new Bod();
            foreach (Bod b in this)
            {
                teziste += b;
            }
            teziste = teziste / this.Count;
            return teziste;
        }

        public void ReduceToTeziste()
        {
            Bod teziste = GetTeziste();
            for (int i = 0; i < this.Count; i++)
            {
                Bod b = this[i];
                b = b - teziste;
            }
        }


    }
}
