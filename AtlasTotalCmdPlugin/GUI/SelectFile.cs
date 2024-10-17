using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPoints.GUI
{
    public class SelectFile
    {
        public static string FromWindows(string title, string fileTypeName, string ext)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = title;
            openFileDialog.Filter = fileTypeName + " (*." + ext + ")|*." + ext; // Filtrovat pouze DLL soubory
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // Výchozí adresář

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }

            return string.Empty;
        }
    }
}
