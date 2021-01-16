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
        public static int ZERO = 0;

        public static void SetWhiteBackground() 
        {
            ONE = 0;
            ZERO = 255;
        }

        public static void SetBlackBackground()
        {
            ONE = 255;
            ZERO = 0;
        }

        public static Bitmap ConvertBitmapToGrayscale(Bitmap bitmap)
        {
            // Make a Bitmap24 object.
            Bitmap bm = new Bitmap(bitmap);

            // Process the pixels.
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color color = bm.GetPixel(x, y);
                    int average = (color.R + color.G + color.B) / 3;
                    Color gray = Color.FromArgb(average, average, average);
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

        public static Bitmap ErosionCarre(Bitmap bitmap, int[][] elt, int taille)
        {
            Bitmap bm = new Bitmap(bitmap);
            int somme;
            int goal = 0;
            int width = taille * 2 + 1;
            int height = width;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (elt[i][j] == ONE)
                    {
                        goal++;
                    }
                }
            }
            // Process the pixels.
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    somme = 0;
                    for (int i = 0; i < width; i++)
                    {
                        for (int j = 0; j < height; j++)
                        {
                            if (elt[i][j] == ONE)
                            {
                                try
                                {
                                    if (bitmap.GetPixel(x - width + i, y - height + j).R == ONE)
                                    {
                                        somme++;
                                    }
                                }
                                catch (Exception ex) { }
                            }
                        }
                    }
                    if (somme == goal)
                    {
                        bm.SetPixel(x, y, Color.FromArgb(ONE, ONE, ONE));
                    }
                    else
                    {
                        bm.SetPixel(x, y, Color.FromArgb(ZERO, ZERO, ZERO));
                    }
                }
            }

            // Return bitmap
            return bm;
        }
        public static Bitmap DillatationCarre(Bitmap bitmap, int[][] elt, int taille)
        {
            Bitmap bm = new Bitmap(bitmap);
            int somme;
            int width = taille * 2 + 1;
            int height = width;

            // Process the pixels.
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    somme = 0;
                    for (int i = 0; i < width; i++)
                    {
                        for (int j = 0; j < height; j++)
                        {
                            if (elt[i][j] == ONE)
                            {
                                try
                                {
                                    if (bitmap.GetPixel(x - width + i, y - height + j).R == ONE)
                                    {
                                        somme++;
                                    }
                                }
                                catch (Exception ex) { }
                            }
                        }
                    }
                    if (somme > 0)
                    {
                        bm.SetPixel(x, y, Color.FromArgb(ONE, ONE, ONE));
                    }
                    else
                    {
                        bm.SetPixel(x, y, Color.FromArgb(ZERO, ZERO, ZERO));
                    }


                }
            }
            return bm;
        }
        public static Bitmap ErosionHex(Bitmap bitmap, int[][] elt, int taille)
        {
            Bitmap bm = new Bitmap(bitmap);
            int somme;
            int goal = 0;
            int width = taille * 2 + 1;
            int height = width;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (elt[i][j] == ONE)
                    {
                        goal++;
                    }
                }
            }
            // Process the pixels.
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    somme = 0;
                    for (int i = 0; i < width; i++)
                    {
                        for (int j = 0; j < height; j++)
                        {
                            if (elt[i][j] == ONE)
                            {
                                try
                                {
                                    if (bitmap.GetPixel(x - width + i, y - height + j).R == ONE)
                                    {
                                        somme++;
                                    }
                                }
                                catch (Exception ex) { }
                            }
                        }
                    }
                    if (somme == goal)
                    {
                        bm.SetPixel(x, y, Color.FromArgb(ONE, ONE, ONE));
                    }
                    else
                    {
                        bm.SetPixel(x, y, Color.FromArgb(ZERO, ZERO, ZERO));
                    }
                }
            }

            // Return bitmap
            return bm;
        }


    }
}
