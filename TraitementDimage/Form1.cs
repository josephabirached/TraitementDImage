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

    public partial class Form1 : Form
    {

        static public bool OK = false;
        static public int threshold = 0;
        // 0 state is RGB
        // 1 state is Greyscale
        // 2 state is Binary
        static private int img1State = 0;
        static private int img2State = 0;
        static private int img3State = 0;

        public Form1()
        {
            InitializeComponent();
            int[][] elt = ImageProcessingService.GetEltHex(2);
            for (int i = 0; i < elt.Length; i++)
            {
                for (int j = 0; j < elt.Length; j++)
                {
                    Console.Write(elt[i][j] + " ");
                }
                Console.WriteLine();
            }

            int[][] elt1 = ImageProcessingService.GetEltHex(1);
            for (int i = 0; i < elt1.Length; i++)
            {
                for (int j = 0; j < elt1.Length; j++)
                {
                    Console.Write(elt1[i][j] + " ");
                }
                Console.WriteLine();
            }

            int[][] elt2 = ImageProcessingService.GetEltHex(3);
            for (int i = 0; i < elt2.Length; i++)
            {
                for (int j = 0; j < elt2.Length; j++)
                {
                    Console.Write(elt2[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //Addition
        private void additionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string title="";
            string message="";
 
            if (pictureBox1.Image == null)
            {
                message = "Image 1 can't be empty!";
                title = "Error";
            }
            else if (pictureBox2.Image == null)
            {
                message = "Image 2 can't be empty!";
                title = "Error";
            }
            else
            {
                if(pictureBox1.Image.Height == pictureBox2.Image.Height && pictureBox1.Image.Width == pictureBox2.Image.Width)
                {
                    pictureBox3.Image = ImageProcessingService.Addition(new Bitmap(pictureBox1.Image), new Bitmap(pictureBox2.Image));
                }
                else
                {
                    message = "Both images should be the same size!";
                    title = "Error";
                }
            }

            if(title == "Error")
            {
                MessageBox.Show(message, title);
            }

        }

        //Soustraction
        private void soustractionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string title = "";
            string message = "";

            if (pictureBox1.Image == null)
            {
                message = "Image 1 can't be empty!";
                title = "Error";
            }
            else if (pictureBox2.Image == null)
            {
                message = "Image 2 can't be empty!";
                title = "Error";
            }
            else
            {
                if (pictureBox1.Image.Height == pictureBox2.Image.Height && pictureBox1.Image.Width == pictureBox2.Image.Width)
                {
                    pictureBox3.Image = ImageProcessingService.Substraction(new Bitmap(pictureBox1.Image), new Bitmap(pictureBox2.Image));
                }
                else
                {
                    message = "Both images should be the same size!";
                    title = "Error";
                }
            }

            if (title == "Error")
            {
                MessageBox.Show(message, title);
            }
        }

        private void ouvertureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!radioButton3.Checked)
            {
                string filePath = string.Empty;

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "All Images| *.jpg; *.bmp; *.png";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        filePath = openFileDialog.FileName;
                    
                        if (!string.IsNullOrEmpty(filePath))
                        {
                            if (radioButton1.Checked)
                            {
                                pictureBox1.Image = Image.FromFile(filePath);
                            }
                            else if (radioButton2.Checked)
                            {
                                pictureBox2.Image = Image.FromFile(filePath);
                            }
                        }                    
                    }

                }
            }
            else
            {
                string message = "You can't input an image to the result container";
                string title = "Error";
                MessageBox.Show(message, title);
            }
        }

        private void grisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked && radioButton1.Image == null)
            {
                string message = "Image 1 should not be empty!";
                string title = "Error";
                MessageBox.Show(message, title);
                return;
            }
            else if (radioButton2.Checked && radioButton2.Image == null)
            {
                string message = "Image 2 should not be empty!";
                string title = "Error";
                MessageBox.Show(message, title);
                return;
            }

            if (radioButton1.Checked)
            {
                pictureBox1.Image = ImageProcessingService.ConvertBitmapToGrayscale(new Bitmap(pictureBox1.Image));
                img1State = 1;
            }
            else if (radioButton2.Checked)
            {
                pictureBox2.Image = ImageProcessingService.ConvertBitmapToGrayscale(new Bitmap(pictureBox2.Image));
                img2State = 1;
            }
        }

        private void seuillageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message;
            string title;
            
            if(radioButton1.Checked && img1State != 1)
            {
                message = "Image should be Greyscale!";
                title = "Error";
                MessageBox.Show(message, title);
                return;
            }
            else if (radioButton2.Checked && img2State != 1)
            {
                message = "Image should be Greyscale!";
                title = "Error";
                MessageBox.Show(message, title);
                return;
            }
            else if (radioButton2.Checked && img2State != 1)
            {
                message = "Image should be Greyscale!";
                title = "Error";
                MessageBox.Show(message, title);
                return;
            }

            ThreshPopup pop = new ThreshPopup();
            pop.ShowDialog(this);
            if (OK)
            {
                if (radioButton1.Checked)
                {
                    pictureBox1.Image = ImageProcessingService.Threshhold(new Bitmap(pictureBox1.Image), threshold);
                    img1State = 2;
                }
                else if (radioButton2.Checked)
                {
                    pictureBox2.Image = ImageProcessingService.Threshhold(new Bitmap(pictureBox2.Image), threshold);
                    img2State = 2;
                }
                else
                {
                    pictureBox3.Image = ImageProcessingService.Threshhold(new Bitmap(pictureBox3.Image), threshold);
                    img3State = 2;
                }
            }
        }

        //Erosion white background
        private void whiteBackgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
