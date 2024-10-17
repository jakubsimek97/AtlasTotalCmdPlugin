using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCPoints.GUI
{
    public partial class GetChoice : BaseDialog
    {
        public string name;
        public GetChoice(List<string> choices, string dialogName)
        {
            InitializeComponent();
            listBox1.Items.AddRange(choices.ToArray());
            this.Text = dialogName;
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                SelectAndClose();
            }

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            SelectAndClose();
        }

        private void SelectAndClose()
        {
            name = listBox1.SelectedItem.ToString();
            Close();
        }

    }
}
