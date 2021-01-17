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

        private Cursor WAIT = Cursors.WaitCursor;
        private Cursor DEFAULT = Cursors.Default;

        static public bool OK = false;

        static public int threshold = 0;
        
        static public int elementSize;

        /*
         * 0 state is RGB
         * 1 state is Greyscale
         * 2 state is Binary 
        */
        static private int img1State = 0, img2State = 0, img3State = 0;

        //Undo elements
        static private Image img1Undo, img2Undo, img3Undo;

        //Undo states
        static private int img1PreviousState, img2PreviousState, img3PreviousState;

        //Redo elements
        static private Image img1Redo, img2Redo, img3Redo;

        //Redo states
        static private int img1NextState, img2NextState, img3NextState;

        public Form1()
        {

            InitializeComponent();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        // Addition of 2 images
        private void additionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = WAIT;

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

            this.Cursor = DEFAULT;
            if(title == "Error")
            {
                MessageBox.Show(message, title);
            }

        }

        // Substraction of 2 images
        private void soustractionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = WAIT;

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

            this.Cursor = DEFAULT;
            if (title == "Error")
            {
                MessageBox.Show(message, title);
            }
        }

        // Open image file
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
            PictureBox selected;
            int selectedNumb;
            (selected,selectedNumb) = GetSelectedBox();
            if (selected.Image == null)
            {
                string message = "The selected image should not be empty!";
                string title = "Error";
                MessageBox.Show(message, title);
                return;
            }
            this.Cursor = WAIT;
            backupImage(selectedNumb);
            selected.Image = ImageProcessingService.ConvertBitmapToGrayscale(new Bitmap(selected.Image));
            ChangeSelectedState(selected, 1);
            this.Cursor = DEFAULT;
        }

        // Threshhold
        private void seuillageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message;
            string title;
            PictureBox selected;
            int selectedNumb;
            (selected,selectedNumb) = GetSelectedBox();
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
                this.Cursor = WAIT;
                backupImage(selectedNumb);
                selected.Image = ImageProcessingService.Threshhold(new Bitmap(selected.Image), threshold);
                ChangeSelectedState(selected, 2);
                this.Cursor = DEFAULT;
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

        // Opening white background
        private void openingWhiteBackground_Click(object sender, EventArgs e)
        {
            Opening(1);
        }

        // Opening blackbackground
        private void openingBlackBackground_Click(object sender, EventArgs e)
        {
            Opening(2);
        }

        // Closing white background
        private void closingWhiteBackground_Click(object sender, EventArgs e)
        {
            ClosingImage(1);
        }

        // Closing black background
        private void ClosingBlackBackground_Click(object sender, EventArgs e)
        {
            ClosingImage(2);
        }

        // Thinning Element 1 White
        private void thinningWhiteElement1_Click(object sender, EventArgs e)
        {
            thinning(1, 0);
        }

        // Thinning Element 1 Black
        private void thinningBlackElement1_Click(object sender, EventArgs e)
        {
            thinning(2, 0);
        }

        // Thinning Element 2 White
        private void thinningWhiteElement2_Click(object sender, EventArgs e)
        {
            thinning(1, 1);
        }

        //Thinning Element 2 Black
        private void thinningBlackElement2_Click(object sender, EventArgs e)
        {
            thinning(2, 1);
        }

        // Thickening Element 1 White
        private void ThickeningWhiteElement1_Click(object sender, EventArgs e)
        {
            thickening(1, 0);
        }

        //Thickening Element 1 Black
        private void ThickeningBlackElement1_Click(object sender, EventArgs e)
        {
            thickening(2, 0);
        }

        //Thickening Element 2 White
        private void ThickeningWhiteElement2_Click(object sender, EventArgs e)
        {
            thickening(1, 1);
        }

        // Thickening Element 2 Black
        private void ThickeningBlackElement2_Click(object sender, EventArgs e)
        {
            thickening(2, 1);
        }


        //Erosion
        private void Erosion(int type)
        {
            PictureBox selected;
            int selectedNumb;
            (selected, selectedNumb) = GetSelectedBox();
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
            else if (type == 2)
            {
                ImageProcessingService.SetBlackBackground();

            }
            ElementSizePopup pop = new ElementSizePopup("Erosion detail");
            pop.ShowDialog(this);
            if (OK)
            {
                OK = false;
                this.Cursor = WAIT;
                backupImage(selectedNumb);

                int[,] elt = ImageProcessingService.GetEltCarre(elementSize);
                selected.Image = ImageProcessingService.ErosionCarre(new Bitmap(selected.Image), elt, elementSize);
                this.Cursor = DEFAULT;
            }
        }

        //Dilatation
        private void Dilatation(int type)
        {
            PictureBox selected;
            int selectedNumb;
            (selected, selectedNumb) = GetSelectedBox();
            if (selected.Image == null)
            {
                string message = "Selected image should not be empty!";
                string title = "Error";
                MessageBox.Show(message, title);
                return;
            }

            if (GetSelectedState(selected) != 2)
            {
                string message = "The image must be converted to binary before expansion!";
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
            ElementSizePopup pop = new ElementSizePopup("Dilatation detail");
            pop.ShowDialog(this);
            if (OK)
            {
                this.Cursor = WAIT;
                OK = false;
                backupImage(selectedNumb);
                int[,] elt = ImageProcessingService.GetEltCarre(elementSize);
                selected.Image = ImageProcessingService.DillatationCarre(new Bitmap(selected.Image), elt, elementSize);
                this.Cursor = DEFAULT;
            }
        }

        // Opening 
        private void Opening(int type)
        {
            PictureBox selected;
            int selectedNumb;
            (selected, selectedNumb) = GetSelectedBox();
            if (selected.Image == null)
            {
                string message = "Selected image should not be empty!";
                string title = "Error";
                MessageBox.Show(message, title);
                return;
            }

            if (GetSelectedState(selected) != 2)
            {
                string message = "The image must be converted to binary before opening!";
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

            ElementSizePopup pop = new ElementSizePopup("Opening image detail");
            pop.ShowDialog(this);
            if (OK)
            {
                this.Cursor = WAIT;
                OK = false;
                backupImage(selectedNumb);
                int[,] elt = ImageProcessingService.GetEltCarre(elementSize);
                selected.Image = ImageProcessingService.OuvertureCarre(new Bitmap(selected.Image), elt, elementSize);
                this.Cursor = DEFAULT;
            }
        }

        // Closing
        private void ClosingImage(int type)
        {
            PictureBox selected;
            int selectedNumb;
            (selected, selectedNumb)= GetSelectedBox();
            if (selected.Image == null)
            {
                string message = "Selected image should not be empty!";
                string title = "Error";
                MessageBox.Show(message, title);
                return;
            }

            if (GetSelectedState(selected) != 2)
            {
                string message = "The image must be converted to binary before closing!";
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

            ElementSizePopup pop = new ElementSizePopup("Closing image detail");
            pop.ShowDialog(this);
            if (OK)
            {
                this.Cursor = WAIT;
                OK = false;
                backupImage(selectedNumb);
                int[,] elt = ImageProcessingService.GetEltCarre(elementSize);
                selected.Image = ImageProcessingService.FermetureCarre(new Bitmap(selected.Image), elt, elementSize);
                this.Cursor = DEFAULT;
            }
        }

        private void lantuejoulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PictureBox selected;
            int selectedNumb;
            int background = 1;
            (selected, selectedNumb) = GetSelectedBox();
            if (selected.Image == null)
            {
                string message = "Selected image should not be empty!";
                string title = "Error";
                MessageBox.Show(message, title);
                return;
            }

            if (GetSelectedState(selected) != 2)
            {
                string message = "The image must be converted to binary before closing!";
                string title = "Error";
                MessageBox.Show(message, title);
                return;
            }

            if (background == 1)
            {
                ImageProcessingService.SetWhiteBackground();
            }
            else
            {
                ImageProcessingService.SetBlackBackground();

            }

            this.Cursor = WAIT;
            backupImage(selectedNumb);
            selected.Image = ImageProcessingService.SkeletonByLantuejoul(new Bitmap(selected.Image));
            this.Cursor = DEFAULT;
        }

        // Thinning 
        private void thinning(int background, int element)
        {
            PictureBox selected;
            int selectedNumb;
            (selected, selectedNumb) = GetSelectedBox();
            if (selected.Image == null)
            {
                string message = "Selected image should not be empty!";
                string title = "Error";
                MessageBox.Show(message, title);
                return;
            }

            if (GetSelectedState(selected) != 2)
            {
                string message = "The image must be converted to binary before closing!";
                string title = "Error";
                MessageBox.Show(message, title);
                return;
            }

            if (background == 1)
            {
                ImageProcessingService.SetWhiteBackground();
            }
            else
            {
                ImageProcessingService.SetBlackBackground();

            }

            int[,] elt;
            if(element == 1)
            {
                elt = ImageProcessingService.GetThinningElt(1);
            }
            else
            {
                elt = ImageProcessingService.GetThinningElt(2);
            }
            this.Cursor = WAIT;
            backupImage(selectedNumb);
            selected.Image = ImageProcessingService.ThinningCarre(new Bitmap(selected.Image), elt);
            this.Cursor = DEFAULT;
        }

        //Thickening
        private void thickening(int background, int element)
        {
            PictureBox selected;
            int selectedNumb;
            (selected,selectedNumb) = GetSelectedBox();
            if (selected.Image == null)
            {
                string message = "Selected image should not be empty!";
                string title = "Error";
                MessageBox.Show(message, title);
                return;
            }

            if (GetSelectedState(selected) != 2)
            {
                string message = "The image must be converted to binary before closing!";
                string title = "Error";
                MessageBox.Show(message, title);
                return;
            }

            if (background == 1)
            {
                ImageProcessingService.SetWhiteBackground();
            }
            else
            {
                ImageProcessingService.SetBlackBackground();

            }

            int[,] elt;
            if (element == 1)
            {
                elt = ImageProcessingService.GetThickeningElt(1);
            }
            else
            {
                elt = ImageProcessingService.GetThickeningElt(2);
            }
            this.Cursor = WAIT;
            backupImage(selectedNumb);
            selected.Image = ImageProcessingService.ThickeningCarre(new Bitmap(selected.Image), elt);
            this.Cursor = DEFAULT;
        }

        // Get the selected picture box
        private (PictureBox,int) GetSelectedBox()
        {
            if (radioButton1.Checked)
            {
                return (pictureBox1,1);
            }
            else if (radioButton2.Checked)
            {
                return (pictureBox2,2);
            }
            else
            {
                return (pictureBox3,3);
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

        //Backups the image
        private void backupImage(int i)
        {
            if(i == 1)
            {
                img1Undo = pictureBox1.Image;
                img1PreviousState = img1State;
            }
            else if(i == 2)
            {
                img2Undo = pictureBox2.Image;
                img2PreviousState = img2State;
            }
            else
            {
                img3Undo = pictureBox3.Image;
                img3PreviousState = img3State;
            }
        }

        // Undo last operation
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                img1NextState = img1State;
                if (img1PreviousState != img1State)
                {
                    img1State = img1PreviousState;
                }

                img1Redo = pictureBox1.Image;
                pictureBox1.Image = img1Undo;
            }
            else if(radioButton2.Checked)
            {
                img2NextState = img2State;
                if (img2PreviousState != img2State)
                {
                    img2State = img2PreviousState;
                }
                img2Redo = pictureBox2.Image;
                pictureBox2.Image = img2Undo;
            }
            else
            {
                img3NextState = img3State;
                if (img3PreviousState != img3State)
                {
                    img3State = img3PreviousState;
                }
                img3Redo = pictureBox3.Image;
                pictureBox3.Image = img3Undo;
            }
        }

        //Redo last undo
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                img1PreviousState = img1State;
                if (img1NextState != img1State)
                {
                    img1State = img1NextState;
                } 
                img1Undo = pictureBox1.Image;
                pictureBox1.Image = img1Redo;
            }
            else if (radioButton2.Checked)
            {
                img2PreviousState = img2State;
                if (img2NextState != img2State)
                {
                    img2State = img2NextState;
                }
                img2Undo = pictureBox2.Image;
                pictureBox2.Image = img2Redo;
            }
            else
            {
                img3PreviousState = img3State;
                if (img3NextState != img3State)
                {
                    img3State = img3NextState;
                }
                img3Undo = pictureBox3.Image;
                pictureBox3.Image = img3Redo;
            }
        }

        // Amincisement homothopique
        private void amincissementHomothopiqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PictureBox selected;
            int selectedNumb;
            int background = 1;
            (selected, selectedNumb) = GetSelectedBox();
            if (selected.Image == null)
            {
                string message = "Selected image should not be empty!";
                string title = "Error";
                MessageBox.Show(message, title);
                return;
            }

            if (GetSelectedState(selected) != 2)
            {
                string message = "The image must be converted to binary before closing!";
                string title = "Error";
                MessageBox.Show(message, title);
                return;
            }

            if (background == 1)
            {
                ImageProcessingService.SetWhiteBackground();
            }
            else
            {
                ImageProcessingService.SetBlackBackground();

            }

            this.Cursor = WAIT;
            backupImage(selectedNumb);
            selected.Image = ImageProcessingService.SkeletonByThining(new Bitmap(selected.Image),25);
            this.Cursor = DEFAULT;
        }
    }
}
