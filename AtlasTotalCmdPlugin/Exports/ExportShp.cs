using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using NetTopologySuite.Features;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using System.Windows.Forms;

namespace TCPoints.Exports
{
    public class ExportShp : IExport
    {
        public bool Save(DataGridView view, string file)
        {
            file = Path.ChangeExtension(file, ".shp");

            try
            {
                File.Delete(file);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            List<string> columnNames = view.Columns
                           .Cast<DataGridViewColumn>()
                           .Select(c => c.Name)
                           .ToList();

            GeometryFactory geometryFactory = new GeometryFactory(new PrecisionModel(), 5514);
            List<IFeature> features = new List<IFeature>();

            for (int row = 0; row < view.RowCount; row++)
            {
                double x = Convert.ToDouble(view.Rows[row].Cells["X"].Value);

                if (x == 0)
                    continue;

                double y = Convert.ToDouble(view.Rows[row].Cells["Y"].Value);

                // Zkontroluj, zda jsou souřadnice validní
                if (double.IsNaN(x) || double.IsNaN(y))
                    continue;

                AttributesTable attributes = new AttributesTable();

                for (int col = 0; col < view.ColumnCount; col++)
                {
                    object value = view.Rows[row].Cells[col].Value ?? DBNull.Value;

                    // Ověř, že hodnota je podporovaného typu
                    //if (value is string || value is double || value is int)
                    //{
                        attributes.Add(columnNames[col], value.ToString());
                    //}
                }

                // Vytvoření bodu bez zbytečného volání CreateGeometry
                Feature feature = new Feature(geometryFactory.CreatePoint(new Coordinate(x, y)), attributes);
                features.Add(feature);
            }

            

            var writer = new ShapefileDataWriter(file, geometryFactory)
            {
                Header = ShapefileDataWriter.GetHeader(features[0], features.Count)
            };

            // Zápis všech feature do souboru
            writer.Write(features);

            return true;
        }

        public string GetExportName()
        {
            return "ShpExport";
        }
    }
}
