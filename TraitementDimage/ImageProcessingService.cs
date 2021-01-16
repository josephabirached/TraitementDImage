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
    }
}
