using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPoints.AllInterfaces;

namespace TCPoints.Operations
{
    public class AllOperations : AllInterfaces<IOperation>
    {
        public AllOperations()
        {
            SetNamesToDict();
        }

        protected override void SetNamesToDict()
        {
            foreach (IOperation ie in interFaces)
            {
                this.Add(ie.GetNameOperation(), ie);
            }
        }

        public override string GetDialogName()
        {
            return "Seznam operaci se souborem";
        }

    }
}
