using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TCPoints.AllInterfaces;

namespace TCPoints.Imports
{

    public class AllReaders : AllInterfaces<IReadCoords>
    {
        public AllReaders()
        {
            SetNamesToDict();
        }

        protected override void SetNamesToDict()
        {
            foreach (IReadCoords ie in interFaces)
            {
                this.Add(ie.GetExt(), ie);
            }
        }

        public override string GetDialogName()
        {
            return "Seznam operaci se souborem";
        }

    }
    
}
