using OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCPoints.Exports;
using TCPoints.GUI;
using TCPoints.Operations;

namespace TCPoints.AllInterfaces
{
    public class EventsHandlers
    {
        private AllExports exports;
        private AllOperations operations;

        public EventsHandlers()
        {
            exports = new AllExports();
            operations = new AllOperations();
        }

        public void RunExportChoice(string file, DataGridView view)
        {
            GetChoice choice = new GetChoice(exports.GetNames(), exports.GetDialogName());
            choice.ShowDialog();
            try
            {
                IExport exporter = exports[choice.name];
                exporter.Save(view, file);
            }
            catch (Exception ex)
            {
            }
        }

        public void RunOperationChoice(DataGridView view)
        {
            GetChoice choice = new GetChoice(operations.GetNames(), operations.GetDialogName());
            choice.ShowDialog();
            RunIOperation(choice.name, view);

        }

        public void RunOperation(string operationName, DataGridView view)
        {
            RunIOperation(operationName, view);
        }

        private void RunIOperation(string name, DataGridView view)
        {
            IOperation operation = operations[name];
            try
            {
                operation.Transform(view);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
