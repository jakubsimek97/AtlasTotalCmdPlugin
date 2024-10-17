using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPoints.Exports
{
    public class ExcelExport : IExport
    {
        private string name;
        public ExcelExport()
        {
            name = "Excel";
        }

        public bool Save(DataGridView view, string file)
        {
            file = Path.ChangeExtension(file, "xlsx");
            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                // Použití using pro správné uvolnění zdrojů
                using (ExcelPackage pck = new ExcelPackage(new FileInfo(file)))
                {
                    string sheetName = "Export"; // Lepší použít jednoduché jméno pro list
                    var ws = pck.Workbook.Worksheets[sheetName];

                    if (ws == null)
                    {
                        ws = pck.Workbook.Worksheets.Add(sheetName);
                    }

                    // Export záhlaví z DataGridView
                    for (int col = 0; col < view.ColumnCount; col++)
                    {
                        ws.Cells[1, col + 1].Value = view.Columns[col].HeaderText;
                    }

                    // Export dat z DataGridView
                    for (int row = 0; row < view.RowCount; row++)
                    {
                        for (int col = 0; col < view.ColumnCount; col++)
                        {
                            var value = view.Rows[row].Cells[col].Value?.ToString() ?? string.Empty;
                            ws.Cells[row + 2, col + 1].Value = value; // Excel začíná indexováním od 1
                        }
                    }

                    // Uložení souboru
                    pck.Save();
                }
                MessageBox.Show("Ulozeno.\n" + file);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during export: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public string GetExportName()
        {
            return name;
        }

    }
}
