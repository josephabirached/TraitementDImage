using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraitementDimage
{
    public class ImageProcessingService
    {
        public static int ONE = 255;
        public static int TWO = 0;

        public static Bitmap ConvertBitmapToGrayscale(Bitmap bitmap)
        {
            // Make a Bitmap24 object.
            Bitmap bm = new Bitmap(bitmap);

            // Process the pixels.
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color color = bm.GetPixel(x,y);
                    int average = (color.R + color.G + color.B) / 3;
                    Color gray = Color.FromArgb(average,average,average);
                    bm.SetPixel(x, y, gray);
                }
            }

            // Return bitmap
            return bm;
        }

        public static Bitmap Threshhold(Bitmap bitmap, int thresh)
        {
            // Make a Bitmap24 object.
            Bitmap bm = new Bitmap(bitmap);

            // Process the pixels.
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color color = bm.GetPixel(x, y);
                    Color color1;
                    if (color.R >= thresh)
                    {
                        color1 = Color.White;
                    }
                    else
                    {
                        color1 = Color.Black;
                    }
                    bm.SetPixel(x, y, color1);
                }
            }

            // Return bitmap
            return bm;
        }

        public static Bitmap Addition(Bitmap bitmap1, Bitmap bitmap2)
        {
            // Make a Bitmap24 object.
            Bitmap bm = new Bitmap(bitmap1);

            // Process the pixels.
            for (int x = 0; x < bitmap1.Width; x++)
            {
                for (int y = 0; y < bitmap1.Height; y++)
                {
                    Color color1 = bitmap1.GetPixel(x, y);
                    Color color2 = bitmap2.GetPixel(x, y);
                    int red = Math.Min(color1.R + color2.R, 255);
                    int green = Math.Min(color1.G + color2.G, 255);
                    int blue = Math.Min(color1.B + color2.B, 255);

                    Color color = Color.FromArgb(red, green, blue);

                    bm.SetPixel(x, y, color);
                }
            }

            // Return bitmap
            return bm;
        }

        public static Bitmap Substraction(Bitmap bitmap1, Bitmap bitmap2)
        {
            // Make a Bitmap24 object.
            Bitmap bm = new Bitmap(bitmap1);

            // Process the pixels.
            for (int x = 0; x < bitmap1.Width; x++)
            {
                for (int y = 0; y < bitmap1.Height; y++)
                {
                    Color color1 = bitmap1.GetPixel(x, y);
                    Color color2 = bitmap2.GetPixel(x, y);
                    int red = Math.Max(color1.R - color2.R, 0);
                    int green = Math.Max(color1.G - color2.G, 0);
                    int blue = Math.Max(color1.B - color2.B, 0);

                    Color color = Color.FromArgb(red, green, blue);

                    bm.SetPixel(x, y, color);
                }
            }

            // Return bitmap
            return bm;
        }

        public static Bitmap ErosionCarre(Bitmap bitmap, int [][] elt, int width, int height)
        {
            Bitmap bm = new Bitmap(bitmap);

            // Process the pixels.
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    bool isOne = true;
                    for (int i = 0; i<width; i++)
                    {
                        
                    }

                    //bm.SetPixel(x, y, color);
                }
            }

            // Return bitmap
            return bm;
        }
    }
}
