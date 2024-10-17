using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPoints.Exports
{
    public class CsvExport : IExport
    {
        private static string delimiter = ";";
        public bool Save(DataGridView view, string file)
        {
            file = Path.ChangeExtension(file, "csv");
            try
            {
                // Použití using pro správné uvolnění zdrojů
                using (StreamWriter outFile = new StreamWriter(file))
                {


                    // Export záhlaví z DataGridView
                    string header = string.Empty;
                    for (int col = 0; col < view.ColumnCount; col++)
                    {
                        header += view.Columns[col].HeaderText + delimiter;
                    }
                    header = EndLineInsteadDelimiter(header);
                    outFile.Write(header);

                    // Export dat z DataGridView
                    for (int row = 0; row < view.RowCount; row++)
                    {
                        string line = string.Empty;
                        for (int col = 0; col < view.ColumnCount; col++)
                        {
                            string value = view.Rows[row].Cells[col].Value?.ToString() ?? string.Empty;
                            line += value + delimiter;
                        }
                        line = EndLineInsteadDelimiter(line);
                        outFile.Write(line);
                    }


                }
                MessageBox.Show("Ulozeno.\n" + file);
                return true;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        public string GetExportName()
        {
            return "CsvExport";
        }

        private string EndLineInsteadDelimiter(string line)
        {
            return line.Substring(0, line.Length - 1) + "\n";
        }
    }
}
