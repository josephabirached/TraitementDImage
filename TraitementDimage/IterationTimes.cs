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
    public partial class IterationTimes : Form
    {
        public IterationTimes(String title)
        {
            this.Text = title;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.iterations = (int)numericUpDown1.Value;
            Form1.OK = true;
            Close();
        }
    }
}
