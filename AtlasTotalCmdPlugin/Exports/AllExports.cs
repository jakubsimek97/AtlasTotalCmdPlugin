using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPoints.AllInterfaces;

namespace TCPoints.Exports
{
    public class AllExports : AllInterfaces<IExport>
    {
        public AllExports()
        {
            SetNamesToDict();
        }

        protected override void SetNamesToDict()
        {
            foreach (IExport ie in interFaces)
            {
                this.Add(ie.GetExportName(), ie);
            }
        }

        public override string GetDialogName()
        {
            return "Exporty do souboru";
        }

    }
}
