using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPoints.Operations
{
    public class SwitchXY : IOperation
    {
        public string name;

        public SwitchXY()
        {
            name = "Switch X/Y";
        }

        public void Transform(DataGridView vies)
        {
            // Uložení aktuálních DisplayIndex hodnot
            int tempX = vies.Columns["X"].DisplayIndex;
            int tempY = vies.Columns["Y"].DisplayIndex;

            // Použijeme volné místo pro dočasnou změnu
            int maxIndex = vies.Columns.Count; // Tato hodnota je mimo dosah aktuálních indexů

            // Prohození DisplayIndex hodnot
            vies.Columns["X"].DisplayIndex = maxIndex; // Dočasné přesunutí sloupce mimo rozsah
            vies.Columns["Y"].DisplayIndex = tempX;    // Nastavení Y na původní pozici X
            vies.Columns["X"].DisplayIndex = tempY;    // Vrácení X na pozici Y
        }

        public string GetNameOperation()
        {
            return name;
        }
    }
}
