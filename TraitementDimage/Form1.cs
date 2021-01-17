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
        /* 
         * Type 1 => Hex
         * Type 2 => Square
         * Default 0
        */
        static public int elementType;
        static public int elementSize;

        /*
         * 0 state is RGB
         * 1 state is Greyscale
         * 2 state is Binary 
        */
        static private int img1State = 0;
        static private int img2State = 0;
        static private int img3State = 0;

        public Form1()
        {
            InitializeComponent();
            /*int[][] elt = ImageProcessingService.GetEltHex(2);
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
            }*/
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        // Addition of 2 images
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

        // Substraction of 2 images
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

        // Open image
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
                                img1State = 0;
                                pictureBox1.Image = Image.FromFile(filePath);
                            }
                            else if (radioButton2.Checked)
                            {
                                img2State = 0;
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

        // Convert an image to Greyscale
        private void grisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PictureBox selected = GetSelectedBox();
            if (selected.Image == null)
            {
                string message = "The selected image should not be empty!";
                string title = "Error";
                MessageBox.Show(message, title);
                return;
            }

            selected.Image = ImageProcessingService.ConvertBitmapToGrayscale(new Bitmap(selected.Image));
            ChangeSelectedState(selected, 1);
        }

        // Threshhold
        private void seuillageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message;
            string title;

            PictureBox selected = GetSelectedBox();
            if(selected.Image == null)
            {
                message = "The selected image should not be empty!";
                title = "Error";
                MessageBox.Show(message, title);
                return;
            }
            if(GetSelectedState(selected) != 1 && GetSelectedState(selected) != 2)
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
                OK = false;
                selected.Image = ImageProcessingService.Threshhold(new Bitmap(selected.Image), threshold);
                ChangeSelectedState(selected, 2);
            }
        }

        //Erosion white background
        private void ErosionWhiteBackground_Click(object sender, EventArgs e)
        {

            Erosion(1);
        }

        // Erosion black background
        private void ErosionBlackBackground_Click(object sender, EventArgs e)
        {
            Erosion(2);
        }

        //Dilatation white background
        private void DillatationWhiteBackground_Click(object sender, EventArgs e)
        {

            Dilatation(1);
        }

        // Dilatation black background
        private void DilatationBlackBackground_Click(object sender, EventArgs e)
        {

            Dilatation(2);
        }


        //Erosion
        private void Erosion(int type)
        {
            PictureBox selected = GetSelectedBox();
            if (selected.Image == null)
            {
                string message = "Selected image should not be empty!";
                string title = "Error";
                MessageBox.Show(message, title);
                return;
            }

            if (GetSelectedState(selected) != 2)
            {
                string message = "The image must be converted to binary before erosion!";
                string title = "Error";
                MessageBox.Show(message, title);
                return;
            }

            if(type == 1)
            {
                ImageProcessingService.SetWhiteBackground();
            }
            else
            {
                ImageProcessingService.SetBlackBackground();

            }
            
            ErosionDilatationPopup pop = new ErosionDilatationPopup("Erosion detail");
            pop.ShowDialog(this);
            if (OK)
            {
                OK = false;

                if (elementType == 1)
                {
                    int[][] elt = ImageProcessingService.GetEltHex(elementSize);
                    selected.Image = ImageProcessingService.ErosionHex(new Bitmap(selected.Image), elt, elementSize);
                }
                else if (elementType == 2)
                {
                    int[][] elt = ImageProcessingService.GetEltCarre(elementSize);
                    selected.Image = ImageProcessingService.ErosionCarre(new Bitmap(selected.Image), elt, elementSize);
                }
            }
        }

        //Dilatation
        private void Dilatation(int type)
        {
            PictureBox selected = GetSelectedBox();
            if (selected.Image == null)
            {
                string message = "Selected image should not be empty!";
                string title = "Error";
                MessageBox.Show(message, title);
                return;
            }

            if (GetSelectedState(selected) != 2)
            {
                string message = "The image must be converted to binary before erosion!";
                string title = "Error";
                MessageBox.Show(message, title);
                return;
            }

            if (type == 1)
            {
                ImageProcessingService.SetWhiteBackground();
            }
            else
            {
                ImageProcessingService.SetBlackBackground();

            }

            ErosionDilatationPopup pop = new ErosionDilatationPopup("Erosion detail");
            pop.ShowDialog(this);
            if (OK)
            {
                OK = false;

                if (elementType == 1)
                {
                    int[][] elt = ImageProcessingService.GetEltHex(elementSize);
                    selected.Image = ImageProcessingService.DillatationHex(new Bitmap(selected.Image), elt, elementSize);
                }
                else if (elementType == 2)
                {
                    int[][] elt = ImageProcessingService.GetEltCarre(elementSize);
                    selected.Image = ImageProcessingService.DillatationCarre(new Bitmap(selected.Image), elt, elementSize);
                }
            }
        }

        // Get the selected picture box
        private PictureBox GetSelectedBox()
        {
            if (radioButton1.Checked)
            {
                return pictureBox1;
            }
            else if (radioButton2.Checked)
            {
                return pictureBox2;
            }
            else
            {
                return pictureBox3;
            }
        }

        //Changes the state of the currently selected picture
        private void ChangeSelectedState(PictureBox selected, int newState)
        {
            if(selected == pictureBox1)
            {
                img1State = newState;
            }
            else if(selected == pictureBox2)
            {
                img2State = newState;
            }
            else if(selected == pictureBox3)
            {
                img3State = newState;
            }
        }

        // Returns the state of the selected picture
        private int GetSelectedState(PictureBox selected)
        {
            if (selected == pictureBox1)
            {
                return img1State;
            }
            else if (selected == pictureBox2)
            {
                return img2State;
            }
            else if (selected == pictureBox3)
            {
                return img3State;
            }
            return 0;
        }

    }
}
