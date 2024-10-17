
using TCPoints.Operations;
using TCPoints.Imports;
using TCPoints.AllInterfaces;

namespace TCPoints.GUI
{
    public partial class MainPage : BaseDialog
    {
        private string filePath;
        private EventsHandlers eventsHandlers;
        public MainPage(string file)
        {
            filePath = file;
            InitializeComponent();
            LoadTable();
            ResizeColumns();
            this.KeyPreview = true;
            eventsHandlers = new EventsHandlers();
        }

        private void LoadTable()
        {
            AllReaders readers = new AllReaders();

            try
            {
                IReadCoords reader = readers[Path.GetExtension(filePath)];
                if (reader.Open(filePath))
                {
                    reader.Load(dataGridView1);
                    reader.Close();
                }
                else
                    Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ResizeColumns()
        {
            // Nastavení vlastností sloupců pro rovnoměrné rozložení
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Width = dataGridView1.Width / dataGridView1.Columns.Count;
            }
        }

        private void dataGridView1_SizeChanged(object sender, EventArgs e)
        {
            ResizeColumns();
        }

        private void MainPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.E)
            {
                eventsHandlers.RunExportChoice(filePath, dataGridView1);
            }
            else if (e.KeyCode == Keys.O)
            {
                eventsHandlers.RunOperationChoice(dataGridView1);
            }
            else if (e.KeyCode == Keys.R)
            {
                LoadTable();
            }

            e.Handled = true;
        }



        private void export_Click(object sender, EventArgs e)
        {
            eventsHandlers.RunExportChoice(filePath, dataGridView1);
        }

        private void switchXY_Click(object sender, EventArgs e)
        {
            eventsHandlers.RunOperation(switchXY.Text, dataGridView1);
        }

        private void loadExternalDll_Click(object sender, EventArgs e)
        {
            LoadExternalDll loadDll = new LoadExternalDll();
            loadDll.ShowDialog();
        }
    }
}
