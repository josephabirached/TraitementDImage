using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TraitementDimage
{
    public partial class ErosionDilatationPopup : Form
    {
        public ErosionDilatationPopup(String title)
        {
            this.Text = title;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (hexErosion.Checked)
            {
                Form1.elementType = 1;
                Form1.elementSize = (int)elementSize.Value;
                Form1.OK = true;
                Close();
            }
            else if (squareErosion.Checked)
            {
                Form1.elementType = 2;
                Form1.elementSize = (int)elementSize.Value;
                Form1.OK = true;
                Close();
            }

        }
    }
}
