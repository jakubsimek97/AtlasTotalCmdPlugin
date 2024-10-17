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
    // this dialog is base for others dialog
    // it has implemented features like base keydown actions
    public partial class BaseDialog : Form
    {
        public BaseDialog()
        {
            InitializeComponent();
        }

        private void BaseDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }



        }
    }
}
