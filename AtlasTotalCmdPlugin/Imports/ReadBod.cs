using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TCPoints.DataStructures;

namespace TCPoints.Imports
{
    public class ReadBod : IReadCoords
    {
        byte[] filedata;
        private string filePath;

        public bool Open(string file)
        {
            filePath = file;
            try
            {
                filedata = File.ReadAllBytes(file);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }


            return filedata.Length > 0;

        }

        public string GetExt()
        {
            return ".bod";
        }

        public void Close()
        {

        }

        public void Load(DataGridView view)
        {
            view.SuspendLayout();
            view.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Poradi" },
                new DataGridViewTextBoxColumn { Name = "Priznak" },
                new DataGridViewTextBoxColumn { Name = "Typ bodu" },
                new DataGridViewTextBoxColumn { Name = "X" },
                new DataGridViewTextBoxColumn { Name = "Y" },
                new DataGridViewTextBoxColumn { Name = "Z" },
                new DataGridViewTextBoxColumn { Name = "Ukaz" }
            });

            var rows = new List<DataGridViewRow>();
            int tablePointSize = Marshal.SizeOf<TablePoint>();
            //int blockSize = 2000*tablePointSize; // 4 MB blok
            int blockSize = (int)new FileInfo(filePath).Length;

            byte[] buffer = new byte[blockSize];


            using (var memoryStream = new MemoryStream(filedata))
            {
                int pocet = 0;
                int bytesRead;

                while ((bytesRead = memoryStream.Read(buffer, 0, blockSize)) > 0)
                {
                    using (var ms = new MemoryStream(buffer, 0, bytesRead))
                    using (var reader = new BinaryReader(ms))
                    {
                        while (ms.Position < ms.Length)
                        {
                            if (ms.Length - ms.Position < tablePointSize) // Velikost jednoho TablePoint záznamu
                                break; // Nedostatek dat pro celý záznam, přejdeme k dalšímu bloku

                            var record = new TablePoint
                            {
                                pri = reader.ReadByte(),
                                typbo = reader.ReadByte(),
                                x = reader.ReadDouble(),
                                y = reader.ReadDouble(),
                                z = reader.ReadDouble(),
                                ukaz = reader.ReadUInt32()
                            };

                            var row = new DataGridViewRow();
                            row.CreateCells(view, pocet + 1, record.pri, record.typbo, record.x, record.y, record.z, record.ukaz);
                            rows.Add(row);
                            pocet++;
                        }
                    }
                }
            }

            view.Rows.AddRange(rows.ToArray());
            view.ResumeLayout();
        }
    }
}
