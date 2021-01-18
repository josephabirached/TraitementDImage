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
    public partial class ThresholdPopup : Form
    {
        public ThresholdPopup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (high.Checked)
            {
                Form1.thresholdType = 1;
                Form1.threshold = (int)thresholdValue.Value;
                Form1.OK = true;
                Close();
            }
            else if (low.Checked)
            {
                Form1.thresholdType = 2;
                Form1.threshold = (int)thresholdValue.Value;
                Form1.OK = true;
                Close();
            }
        }
    }
}
