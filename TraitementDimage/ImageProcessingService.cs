using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TraitementDimage
{
    public class ImageProcessingService
    {
        public static int ONE = 255;
        public static int ZERO = 0;
        public static byte DC = 1;
        public static byte SEFER = 0;
        public static byte WAHAD = 15;

        public static void SetWhiteBackground()
        {
            ONE = 0;
            ZERO = 255;
            WAHAD = 0;
            SEFER = 15;
        }

        public static void SetBlackBackground()
        {
            ONE = 255;
            ZERO = 0;
            WAHAD = 15;
            SEFER = 0;
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

        public static Bitmap Binarisation(Bitmap bitmap, int thresh)
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

        public static Bitmap Threshold(Bitmap bitmap, int topThresh, int bottomThresh)
        {
            Bitmap bm = new Bitmap(bitmap);

            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color color = bm.GetPixel(x, y);
                    Color color1;
                    if (color.R > topThresh)
                    {
                        color1 = Color.FromArgb(topThresh, topThresh, topThresh);
                    }
                    else if (color.R < bottomThresh)
                    {
                        color1 = Color.FromArgb(bottomThresh, bottomThresh, bottomThresh);
                    }
                    else
                    {
                        color1 = color;
                    }
                    bm.SetPixel(x, y, color1);
                }
            }

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

        public static Bitmap ErosionCarre(Bitmap bitmap, int[,] elt, int taille)
        {
            Bitmap bm = new Bitmap(bitmap);

            int width = taille * 2 + 1;
            int height = width;
            bool isZero = false;
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    bm.SetPixel(x, y, Color.FromArgb(ZERO, ZERO, ZERO));
                }
            }


            // Process the pixels.
            for (int x = taille; x < bitmap.Width - taille; x++)
            {
                for (int y = taille; y < bitmap.Height - taille; y++)
                {
                    isZero = false;
                    for (int i = 0; i < width && !isZero; i++)
                    {
                        for (int j = 0; j < height && !isZero; j++)
                        {
                            if (elt[j, i] == ONE)
                            {

                                if (bitmap.GetPixel(x - taille + i, y - taille + j).R != ONE)
                                {
                                    isZero = true;
                                }


                            }
                        }
                    }
                    if (!isZero)
                    {
                        bm.SetPixel(x, y, Color.FromArgb(ONE, ONE, ONE));
                    }

                }
            }

            // Return bitmap
            return bm;
        }
        public static Bitmap DillatationCarre(Bitmap bitmap, int[,] elt, int taille)
        {
            Bitmap bm = new Bitmap(bitmap);
            int width = taille * 2 + 1;
            int height = width;

            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    bm.SetPixel(x, y, Color.FromArgb(ZERO, ZERO, ZERO));
                }
            }
            bool isOne = false;
            // Process the pixels.
            for (int x = taille; x < bitmap.Width - taille; x++)
            {
                for (int y = taille; y < bitmap.Height - taille; y++)
                {
                    isOne = false;

                    for (int i = 0; i < width && !isOne; i++)
                    {
                        for (int j = 0; j < height && !isOne; j++)
                        {
                            if (elt[j, i] == ONE)
                            {
                                try
                                {
                                    if (bitmap.GetPixel(x - taille + i, y - taille + j).R == ONE)
                                    {
                                        isOne = true;
                                    }
                                }
                                catch (Exception ex) { }
                            }
                        }
                    }
                    if (isOne)
                    {
                        bm.SetPixel(x, y, Color.FromArgb(ONE, ONE, ONE));
                    }

                }
            }
            return bm;
        }


        private static int[][] flipElt(int[][] elt)
        {
            int[][] flipped = new int[elt.Length][];
            for (int i = 0; i < elt.Length; i++)
            {
                flipped[i] = new int[elt.Length];
            }
            for (int i = 0; i < elt.Length; i++)
            {
                for (int j = 0; j < elt.Length; j++)
                {
                    flipped[i][j] = elt[i][elt.Length - j - 1];
                }
            }
            return flipped;
        }

        public static int[,] GetEltCarre(int N)
        {
            int L = 2 * N + 1;
            int[,] elt = new int[L, L];

            for (int i = 0; i < L; i++)
            {
                for (int j = 0; j < L; j++)
                {
                    elt[i, j] = ONE;
                }
            }
            return elt;
        }

        public static int[][] GetEltHex(int N)
        {
            int L = 2 * N + 1;
            int[][] elt = new int[L][];
            for (int i = 0; i < L; i++)
            {
                elt[i] = new int[L];
            }
            for (int i = 0; i < N; i++)
            {
                int j = 0;
                for (; j < L - N + i; j++)
                {
                    elt[i][j] = ONE;
                    elt[L - i - 1][j] = ONE;
                }
                for (; j < L; j++)
                {
                    elt[i][j] = ZERO;
                    elt[L - i - 1][j] = ZERO;
                }
            }
            for (int j = 0; j < L; j++)
            {
                elt[N][j] = ONE;
            }
            return elt;
        }

        public static Bitmap OuvertureCarre(Bitmap bitmap, int[,] elt, int taille)
        {
            Bitmap erode = ErosionCarre(bitmap, elt, taille);
            int[,] eltT = Traspose(elt);
            Bitmap bm = DillatationCarre(erode, eltT, taille);

            // Return bitmap
            return bm;
        }

        public static Bitmap FermetureCarre(Bitmap bitmap, int[,] elt, int taille)
        {
            Bitmap dilate = DillatationCarre(bitmap, elt, taille);
            int[,] eltT = Traspose(elt);
            Bitmap bm = ErosionCarre(dilate, eltT, taille);


            // Return bitmap
            return bm;
        }

        public static int[,] Traspose(int[,] elt)
        {
            int w = elt.GetLength(0);
            int h = elt.GetLength(1);

            int[,] result = new int[h, w];

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    result[j, i] = elt[i, j];
                }
            }

            return result;
        }

        // 0 0 0
        // x 1 x
        // 1 1 1

        // x 0 0
        // 1 1 0
        // x 1 x
        public static byte[,] GetThinningElt(int type = 0)
        {


            byte[,] result = new byte[3, 3];
            if (type == 0)
            {
                result[0, 0] = SEFER;
                result[0, 1] = SEFER;
                result[0, 2] = SEFER;
                result[1, 0] = DC;
                result[1, 1] = WAHAD;
                result[1, 2] = DC;
                result[2, 0] = WAHAD;
                result[2, 1] = WAHAD;
                result[2, 2] = WAHAD;
            }
            else
            {
                result[0, 0] = DC;
                result[0, 1] = SEFER;
                result[0, 2] = SEFER;
                result[1, 0] = WAHAD;
                result[1, 1] = WAHAD;
                result[1, 2] = SEFER;
                result[2, 0] = DC;
                result[2, 1] = WAHAD;
                result[2, 2] = DC;
            }


            return result;
        }



        private static byte[] CopyBytes(byte[] src)
        {
            byte[] copy = new byte[src.Length];
            for (int i = 0; i < src.Length; i++)
            {
                copy[i] = src[i];
            }
            return copy;
        }
        private static byte[] CopyBytes(byte[] src, byte[] dest)
        {

            for (int i = 0; i < src.Length; i++)
            {
                dest[i] = src[i];
            }
            return dest;
        }

        public static Bitmap ThinningCarre(Bitmap bitmap, byte[,] elt, int iterations = 10)
        {
            Bitmap bm = new Bitmap(bitmap);
            Bitmap tmp = new Bitmap(bitmap);
            int taille = 1;
            bool isZero;
            BitmapData bmData = bm.LockBits(new Rectangle(0, 0, bm.Width, bm.Height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
            BitmapData tmpData = tmp.LockBits(new Rectangle(0, 0, bm.Width, bm.Height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
            int bytes = bm.Width * bm.Height;
            byte[] bmbytes = new byte[bytes];
            byte[] tmpbytes = new byte[bytes];
            byte[,] localElt = elt;
            Marshal.Copy(bmData.Scan0, bmbytes, 0, bytes);
            Marshal.Copy(tmpData.Scan0, tmpbytes, 0, bytes);

            // Process the pixels.
            /* for (int k = 0; k < iterations; k++)
             {

                 for (int l = 0; l < 8; l++)
                 {
                     localElt = elt;
                     for (int x = taille; x < bitmap.Height - taille; x++)
                     {
                         for (int y = taille; y < bitmap.Height - taille; y++)
                         {
                             isZero = true;

                             for (int i = 0; i < 3 && isZero; i++)
                             {
                                 for (int j = 0; j < 3 && isZero; j++)
                                 {
                                     if (elt[j, i] != DC)
                                     {

                                         if (bmbytes[(x - taille + i) + (y - taille + j) * bm.Height] != localElt[j, i])
                                         //bitmap.getpixel(x - taille + i, y - taille + j).r != elt[j, i])
                                         {
                                             isZero = false;
                                         }

                                     }
                                 }
                             }
                             if (isZero)
                             {
                                 tmpbytes[(x) + (y) * bm.Height] = SEFER;

                             }
                             else
                             {
                                 tmpbytes[(x) + (y) * bm.Height] = bmbytes[(x) + (y) * bm.Height];
                             }

                         }
                     }
                     bmbytes = CopyBytes(tmpbytes);
                     localElt = MatrixRotation(localElt);
                 }


             }*/


            for (int i = 0; i < iterations; i++)
            {
                // 0 . 1 bm->tmp
                // 0 1 1
                // 0 . 1
                for (int x = taille; x < bitmap.Width - taille; x++)
                {
                    for (int y = taille; y < bitmap.Height - taille; y++)
                    {
                        if (bmbytes[bm.Width * y + x] == WAHAD &&    //(x,y)
                            bmbytes[bm.Width * (y - 1) + (x + 1)] == WAHAD && //(x+1,y-1)
                            bmbytes[bm.Width * y + (x + 1)] == WAHAD &&     //(x+1,y)
                            bmbytes[bm.Width * (y + 1) + (x + 1)] == WAHAD &&//(x+1,y+1)
                            bmbytes[bm.Width * (y - 1) + (x - 1)] == SEFER && //(x-1,y-1)
                            bmbytes[bm.Width * y + (x - 1)] == SEFER &&     //(x-1,y)
                            bmbytes[bm.Width * (y + 1) + (x - 1)] == SEFER)         //(x-1,y+1)
                        {

                            tmpbytes[(x) + (y) * bm.Width] = SEFER;
                        }
                        else
                        {
                            tmpbytes[(x) + (y) * bm.Width] = bmbytes[(x) + (y) * bm.Width];
                        }
                    }
                }

                bmbytes = CopyBytes(tmpbytes, bmbytes);



                // 0 0 .
                // 0 1 1
                // . 1 1
                for (int x = taille; x < bitmap.Width - taille; x++)
                {
                    for (int y = taille; y < bitmap.Height - taille; y++)
                    {
                        if (bmbytes[bm.Width * y + x] == WAHAD &&
                            bmbytes[bm.Width * y + (x + 1)] == WAHAD &&
                            bmbytes[bm.Width * y + (x - 1)] == SEFER &&
                            bmbytes[bm.Width * (y - 1) + (x)] == SEFER &&
                            bmbytes[bm.Width * (y - 1) + (x - 1)] == SEFER &&
                            bmbytes[bm.Width * (y + 1) + x] == WAHAD &&
                            bmbytes[bm.Width * (y + 1) + (x + 1)] == WAHAD)
                        {

                            tmpbytes[(x) + (y) * bm.Width] = SEFER;
                        }
                        else
                        {
                            tmpbytes[(x) + (y) * bm.Width] = bmbytes[(x) + (y) * bm.Width];
                        }
                    }
                }

                bmbytes = CopyBytes(tmpbytes, bmbytes);


                // 0 0 0 bm->tmp
                // . 1 .
                // 1 1 1
                for (int x = taille; x < bitmap.Width - taille; x++)
                {
                    for (int y = taille; y < bitmap.Height - taille; y++)
                    {
                        if (bmbytes[bm.Width * y + x] == WAHAD &&
                            bmbytes[bm.Width * (y - 1) + (x - 1)] == SEFER &&
                            bmbytes[bm.Width * (y - 1) + x] == SEFER &&
                            bmbytes[bm.Width * (y - 1) + (x + 1)] == SEFER &&
                            bmbytes[bm.Width * (y + 1) + (x - 1)] == WAHAD &&
                            bmbytes[bm.Width * (y + 1) + x] == WAHAD &&
                            bmbytes[bm.Width * (y + 1) + (x + 1)] == WAHAD)
                        {

                            tmpbytes[(x) + (y) * bm.Width] = SEFER;
                        }
                        else
                        {
                            tmpbytes[(x) + (y) * bm.Width] = bmbytes[(x) + (y) * bm.Width];
                        }
                    }
                }

                bmbytes = CopyBytes(tmpbytes, bmbytes);

                // . 0 0
                // 1 1 0
                // 1 1 .
                for (int x = taille; x < bitmap.Width - taille; x++)
                {
                    for (int y = taille; y < bitmap.Height - taille; y++)
                    {
                        if (bmbytes[bm.Width * y + x] == WAHAD &&
                            bmbytes[bm.Width * y + (x + 1)] == SEFER &&
                            bmbytes[bm.Width * y + (x - 1)] == WAHAD &&
                            bmbytes[bm.Width * (y - 1) + x] == SEFER &&
                            bmbytes[bm.Width * (y - 1) + (x + 1)] == SEFER &&
                            bmbytes[bm.Width * (y + 1) + (x - 1)] == WAHAD &&
                            bmbytes[bm.Width * (y + 1) + x] == WAHAD)
                        {

                            tmpbytes[(x) + (y) * bm.Width] = SEFER;
                        }
                        else
                        {
                            tmpbytes[(x) + (y) * bm.Width] = bmbytes[(x) + (y) * bm.Width];
                        }
                    }
                }

                bmbytes = CopyBytes(tmpbytes, bmbytes);

                // 1 . 0 bm->tmp
                // 1 1 0
                // 1 . 0
                for (int x = taille; x < bitmap.Width - taille; x++)
                {
                    for (int y = taille; y < bitmap.Height - taille; y++)
                    {
                        if (bmbytes[bm.Width * y + x] == WAHAD &&
                            bmbytes[bm.Width * y + (x + 1)] == SEFER &&
                            bmbytes[bm.Width * (y - 1) + (x + 1)] == SEFER &&
                            bmbytes[bm.Width * (y + 1) + (x + 1)] == SEFER &&
                            bmbytes[bm.Width * (y - 1) + (x - 1)] == WAHAD &&
                            bmbytes[bm.Width * y + (x - 1)] == WAHAD &&
                            bmbytes[bm.Width * (y + 1) + (x - 1)] == WAHAD)
                        {

                            tmpbytes[(x) + (y) * bm.Width] = SEFER;
                        }
                        else
                        {
                            tmpbytes[(x) + (y) * bm.Width] = bmbytes[(x) + (y) * bm.Width];
                        }
                    }
                }

                bmbytes = CopyBytes(tmpbytes, bmbytes);

                // 1 1 .
                // 1 1 0
                // . 0 0
                for (int x = taille; x < bitmap.Width - taille; x++)
                {
                    for (int y = taille; y < bitmap.Height - taille; y++)
                    {
                        if (bmbytes[bm.Width * y + x] == WAHAD &&
                            bmbytes[bm.Width * y + (x + 1)] == SEFER &&
                            bmbytes[bm.Width * (y + 1) + (x + 1)] == SEFER &&
                            bmbytes[bm.Width * y + (x - 1)] == WAHAD &&
                            bmbytes[bm.Width * (y - 1) + (x - 1)] == WAHAD &&
                            bmbytes[bm.Width * (y - 1) + x] == WAHAD &&
                            bmbytes[bm.Width * (y + 1) + x] == SEFER)
                        {

                            tmpbytes[(x) + (y) * bm.Width] = SEFER;
                        }
                        else
                        {
                            tmpbytes[(x) + (y) * bm.Width] = bmbytes[(x) + (y) * bm.Width];
                        }
                    }
                }

                bmbytes = CopyBytes(tmpbytes, bmbytes);

                // 1 1 1 bm->tmp
                // . 1 .
                // 0 0 0
                for (int x = taille; x < bitmap.Width - taille; x++)
                {
                    for (int y = taille; y < bitmap.Height - taille; y++)
                    {
                        if (bmbytes[bm.Width * y + x] == WAHAD &&
                            bmbytes[bm.Width * (y - 1) + x] == WAHAD &&
                            bmbytes[bm.Width * (y - 1) + (x - 1)] == WAHAD &&
                            bmbytes[bm.Width * (y - 1) + (x + 1)] == WAHAD &&
                            bmbytes[bm.Width * (y + 1) + x] == SEFER &&
                            bmbytes[bm.Width * (y + 1) + (x - 1)] == SEFER &&
                            bmbytes[bm.Width * (y + 1) + (x + 1)] == SEFER)
                        {

                            tmpbytes[(x) + (y) * bm.Width] = SEFER;
                        }
                        else
                        {
                            tmpbytes[(x) + (y) * bm.Width] = bmbytes[(x) + (y) * bm.Width];
                        }
                    }
                }

                bmbytes = CopyBytes(tmpbytes, bmbytes);

                // . 1 1
                // 0 1 1
                // 0 0 .
                for (int x = taille; x < bitmap.Width - taille; x++)
                {
                    for (int y = taille; y < bitmap.Height - taille; y++)
                    {
                        if (bmbytes[bm.Width * y + x] == WAHAD &&
                            bmbytes[bm.Width * (y - 1) + x] == WAHAD &&
                            bmbytes[bm.Width * (y + 1) + x] == SEFER &&
                            bmbytes[bm.Width * y + (x + 1)] == WAHAD &&
                            bmbytes[bm.Width * (y - 1) + (x + 1)] == WAHAD &&
                            bmbytes[bm.Width * y + (x - 1)] == SEFER &&
                            bmbytes[bm.Width * (y + 1) + (x - 1)] == SEFER)
                        {

                            tmpbytes[(x) + (y) * bm.Width] = SEFER;
                        }
                        else
                        {
                            tmpbytes[(x) + (y) * bm.Width] = bmbytes[(x) + (y) * bm.Width];
                        }
                    }
                }

                bmbytes = CopyBytes(tmpbytes, bmbytes);

            }

            Marshal.Copy(bmbytes, 0, bmData.Scan0, bytes);
            bm.UnlockBits(bmData);
            tmp.UnlockBits(tmpData);

            return bm;

        }

        public static Bitmap ThickeningCarre(Bitmap bitmap, int iterations = 4)
        {
            Bitmap bm = new Bitmap(bitmap);
            Bitmap tmp = new Bitmap(bitmap);
            int taille = 1;
            bool isZero;
            BitmapData bmData = bm.LockBits(new Rectangle(0, 0, bm.Width, bm.Height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
            BitmapData tmpData = tmp.LockBits(new Rectangle(0, 0, bm.Width, bm.Height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
            int bytes = bm.Width * bm.Height;
            byte[] bmbytes = new byte[bytes];
            byte[] tmpbytes = new byte[bytes];
            Marshal.Copy(bmData.Scan0, bmbytes, 0, bytes);
            Marshal.Copy(tmpData.Scan0, tmpbytes, 0, bytes);




            for (int i = 0; i < iterations; i++)
            {
                // 0 . 1 bm->tmp
                // 0 0 1
                // 0 . 1
                for (int x = taille; x < bitmap.Width - taille; x++)
                {
                    for (int y = taille; y < bitmap.Height - taille; y++)
                    {
                        if (bmbytes[bm.Width * y + x] == SEFER &&    //(x,y)
                            bmbytes[bm.Width * (y - 1) + (x + 1)] == WAHAD && //(x+1,y-1)
                            bmbytes[bm.Width * y + (x + 1)] == WAHAD &&     //(x+1,y)
                            bmbytes[bm.Width * (y + 1) + (x + 1)] == WAHAD &&//(x+1,y+1)
                            bmbytes[bm.Width * (y - 1) + (x - 1)] == SEFER && //(x-1,y-1)
                            bmbytes[bm.Width * y + (x - 1)] == SEFER &&     //(x-1,y)
                            bmbytes[bm.Width * (y + 1) + (x - 1)] == SEFER)         //(x-1,y+1)
                        {

                            tmpbytes[(x) + (y) * bm.Width] = WAHAD;
                        }
                        else
                        {
                            tmpbytes[(x) + (y) * bm.Width] = bmbytes[(x) + (y) * bm.Width];
                        }
                    }
                }

                bmbytes = CopyBytes(tmpbytes, bmbytes);



                // 0 0 .
                // 0 0 1
                // . 1 1
                for (int x = taille; x < bitmap.Width - taille; x++)
                {
                    for (int y = taille; y < bitmap.Height - taille; y++)
                    {
                        if (bmbytes[bm.Width * y + x] == SEFER &&
                            bmbytes[bm.Width * y + (x + 1)] == WAHAD &&
                            bmbytes[bm.Width * y + (x - 1)] == SEFER &&
                            bmbytes[bm.Width * (y - 1) + (x)] == SEFER &&
                            bmbytes[bm.Width * (y - 1) + (x - 1)] == SEFER &&
                            bmbytes[bm.Width * (y + 1) + x] == WAHAD &&
                            bmbytes[bm.Width * (y + 1) + (x + 1)] == WAHAD)
                        {

                            tmpbytes[(x) + (y) * bm.Width] = WAHAD;
                        }
                        else
                        {
                            tmpbytes[(x) + (y) * bm.Width] = bmbytes[(x) + (y) * bm.Width];
                        }
                    }
                }

                bmbytes = CopyBytes(tmpbytes, bmbytes);


                // 0 0 0 bm->tmp
                // . 0 .
                // 1 1 1
                for (int x = taille; x < bitmap.Width - taille; x++)
                {
                    for (int y = taille; y < bitmap.Height - taille; y++)
                    {
                        if (bmbytes[bm.Width * y + x] == SEFER &&
                            bmbytes[bm.Width * (y - 1) + (x - 1)] == SEFER &&
                            bmbytes[bm.Width * (y - 1) + x] == SEFER &&
                            bmbytes[bm.Width * (y - 1) + (x + 1)] == SEFER &&
                            bmbytes[bm.Width * (y + 1) + (x - 1)] == WAHAD &&
                            bmbytes[bm.Width * (y + 1) + x] == WAHAD &&
                            bmbytes[bm.Width * (y + 1) + (x + 1)] == WAHAD)
                        {

                            tmpbytes[(x) + (y) * bm.Width] = WAHAD;
                        }
                        else
                        {
                            tmpbytes[(x) + (y) * bm.Width] = bmbytes[(x) + (y) * bm.Width];
                        }
                    }
                }

                bmbytes = CopyBytes(tmpbytes, bmbytes);

                // . 0 0
                // 1 0 0
                // 1 1 .
                for (int x = taille; x < bitmap.Width - taille; x++)
                {
                    for (int y = taille; y < bitmap.Height - taille; y++)
                    {
                        if (bmbytes[bm.Width * y + x] == SEFER &&
                            bmbytes[bm.Width * y + (x + 1)] == SEFER &&
                            bmbytes[bm.Width * y + (x - 1)] == WAHAD &&
                            bmbytes[bm.Width * (y - 1) + x] == SEFER &&
                            bmbytes[bm.Width * (y - 1) + (x + 1)] == SEFER &&
                            bmbytes[bm.Width * (y + 1) + (x - 1)] == WAHAD &&
                            bmbytes[bm.Width * (y + 1) + x] == WAHAD)
                        {

                            tmpbytes[(x) + (y) * bm.Width] = WAHAD;
                        }
                        else
                        {
                            tmpbytes[(x) + (y) * bm.Width] = bmbytes[(x) + (y) * bm.Width];
                        }
                    }
                }

                bmbytes = CopyBytes(tmpbytes, bmbytes);

                // 1 . 0 bm->tmp
                // 1 0 0
                // 1 . 0
                for (int x = taille; x < bitmap.Width - taille; x++)
                {
                    for (int y = taille; y < bitmap.Height - taille; y++)
                    {
                        if (bmbytes[bm.Width * y + x] == SEFER &&
                            bmbytes[bm.Width * y + (x + 1)] == SEFER &&
                            bmbytes[bm.Width * (y - 1) + (x + 1)] == SEFER &&
                            bmbytes[bm.Width * (y + 1) + (x + 1)] == SEFER &&
                            bmbytes[bm.Width * (y - 1) + (x - 1)] == WAHAD &&
                            bmbytes[bm.Width * y + (x - 1)] == WAHAD &&
                            bmbytes[bm.Width * (y + 1) + (x - 1)] == WAHAD)
                        {

                            tmpbytes[(x) + (y) * bm.Width] = WAHAD;
                        }
                        else
                        {
                            tmpbytes[(x) + (y) * bm.Width] = bmbytes[(x) + (y) * bm.Width];
                        }
                    }
                }

                bmbytes = CopyBytes(tmpbytes, bmbytes);

                // 1 1 .
                // 1 0 0
                // . 0 0
                for (int x = taille; x < bitmap.Width - taille; x++)
                {
                    for (int y = taille; y < bitmap.Height - taille; y++)
                    {
                        if (bmbytes[bm.Width * y + x] == SEFER &&
                            bmbytes[bm.Width * y + (x + 1)] == SEFER &&
                            bmbytes[bm.Width * (y + 1) + (x + 1)] == SEFER &&
                            bmbytes[bm.Width * y + (x - 1)] == WAHAD &&
                            bmbytes[bm.Width * (y - 1) + (x - 1)] == WAHAD &&
                            bmbytes[bm.Width * (y - 1) + x] == WAHAD &&
                            bmbytes[bm.Width * (y + 1) + x] == SEFER)
                        {

                            tmpbytes[(x) + (y) * bm.Width] = WAHAD;
                        }
                        else
                        {
                            tmpbytes[(x) + (y) * bm.Width] = bmbytes[(x) + (y) * bm.Width];
                        }
                    }
                }

                bmbytes = CopyBytes(tmpbytes, bmbytes);

                // 1 1 1 bm->tmp
                // . 0 .
                // 0 0 0
                for (int x = taille; x < bitmap.Width - taille; x++)
                {
                    for (int y = taille; y < bitmap.Height - taille; y++)
                    {
                        if (bmbytes[bm.Width * y + x] == SEFER &&
                            bmbytes[bm.Width * (y - 1) + x] == WAHAD &&
                            bmbytes[bm.Width * (y - 1) + (x - 1)] == WAHAD &&
                            bmbytes[bm.Width * (y - 1) + (x + 1)] == WAHAD &&
                            bmbytes[bm.Width * (y + 1) + x] == SEFER &&
                            bmbytes[bm.Width * (y + 1) + (x - 1)] == SEFER &&
                            bmbytes[bm.Width * (y + 1) + (x + 1)] == SEFER)
                        {

                            tmpbytes[(x) + (y) * bm.Width] = WAHAD;
                        }
                        else
                        {
                            tmpbytes[(x) + (y) * bm.Width] = bmbytes[(x) + (y) * bm.Width];
                        }
                    }
                }

                bmbytes = CopyBytes(tmpbytes, bmbytes);

                // . 1 1
                // 0 0 1
                // 0 0 .
                for (int x = taille; x < bitmap.Width - taille; x++)
                {
                    for (int y = taille; y < bitmap.Height - taille; y++)
                    {
                        if (bmbytes[bm.Width * y + x] == SEFER &&
                            bmbytes[bm.Width * (y - 1) + x] == WAHAD &&
                            bmbytes[bm.Width * (y + 1) + x] == SEFER &&
                            bmbytes[bm.Width * y + (x + 1)] == WAHAD &&
                            bmbytes[bm.Width * (y - 1) + (x + 1)] == WAHAD &&
                            bmbytes[bm.Width * y + (x - 1)] == SEFER &&
                            bmbytes[bm.Width * (y + 1) + (x - 1)] == SEFER)
                        {

                            tmpbytes[(x) + (y) * bm.Width] = WAHAD;
                        }
                        else
                        {
                            tmpbytes[(x) + (y) * bm.Width] = bmbytes[(x) + (y) * bm.Width];
                        }
                    }
                }

                bmbytes = CopyBytes(tmpbytes, bmbytes);

            }

            Marshal.Copy(bmbytes, 0, bmData.Scan0, bytes);
            bm.UnlockBits(bmData);
            tmp.UnlockBits(tmpData);

            return bm;

        }

        public static bool CompareByteArray(byte[] left, byte[] right)
        {

            for (int i = 0; i < left.Length; i++)
            {
                if (left[i] != right[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static Bitmap SkeletonByThining(Bitmap bitmap)
        {
            Bitmap bm = new Bitmap(bitmap);
            Bitmap tmp = new Bitmap(bitmap);
            int taille = 1;

            BitmapData bmData = bm.LockBits(new Rectangle(0, 0, bm.Width, bm.Height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
            BitmapData tmpData = tmp.LockBits(new Rectangle(0, 0, bm.Width, bm.Height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
            int bytes = bm.Width * bm.Height;
            byte[] bmbytes = new byte[bytes];
            byte[] tmpbytes = new byte[bytes];

            Marshal.Copy(bmData.Scan0, bmbytes, 0, bytes);
            Marshal.Copy(tmpData.Scan0, tmpbytes, 0, bytes);

            bool isEqual = false;
            byte[] prevbytes;


            while (!isEqual)
            {
                prevbytes = CopyBytes(bmbytes);
                // 0 . 1 bm->tmp
                // 0 1 1
                // 0 . 1
                for (int x = taille; x < bitmap.Width - taille; x++)
                {
                    for (int y = taille; y < bitmap.Height - taille; y++)
                    {
                        if (bmbytes[bm.Width * y + x] == WAHAD &&    //(x,y)
                            bmbytes[bm.Width * (y - 1) + (x + 1)] == WAHAD && //(x+1,y-1)
                            bmbytes[bm.Width * y + (x + 1)] == WAHAD &&     //(x+1,y)
                            bmbytes[bm.Width * (y + 1) + (x + 1)] == WAHAD &&//(x+1,y+1)
                            bmbytes[bm.Width * (y - 1) + (x - 1)] == SEFER && //(x-1,y-1)
                            bmbytes[bm.Width * y + (x - 1)] == SEFER &&     //(x-1,y)
                            bmbytes[bm.Width * (y + 1) + (x - 1)] == SEFER)         //(x-1,y+1)
                        {

                            tmpbytes[(x) + (y) * bm.Width] = SEFER;
                        }
                        else
                        {
                            tmpbytes[(x) + (y) * bm.Width] = bmbytes[(x) + (y) * bm.Width];
                        }
                    }
                }

                bmbytes = CopyBytes(tmpbytes, bmbytes);



                // 0 0 .
                // 0 1 1
                // . 1 1
                for (int x = taille; x < bitmap.Width - taille; x++)
                {
                    for (int y = taille; y < bitmap.Height - taille; y++)
                    {
                        if (bmbytes[bm.Width * y + x] == WAHAD &&
                            bmbytes[bm.Width * y + (x + 1)] == WAHAD &&
                            bmbytes[bm.Width * y + (x - 1)] == SEFER &&
                            bmbytes[bm.Width * (y - 1) + (x)] == SEFER &&
                            bmbytes[bm.Width * (y - 1) + (x - 1)] == SEFER &&
                            bmbytes[bm.Width * (y + 1) + x] == WAHAD &&
                            bmbytes[bm.Width * (y + 1) + (x + 1)] == WAHAD)
                        {
                            tmpbytes[(x) + (y) * bm.Width] = SEFER;
                        }
                        else
                        {
                            tmpbytes[(x) + (y) * bm.Width] = bmbytes[(x) + (y) * bm.Width];
                        }
                    }
                }

                bmbytes = CopyBytes(tmpbytes, bmbytes);


                // 0 0 0 bm->tmp
                // . 1 .
                // 1 1 1
                for (int x = taille; x < bitmap.Width - taille; x++)
                {
                    for (int y = taille; y < bitmap.Height - taille; y++)
                    {
                        if (bmbytes[bm.Width * y + x] == WAHAD &&
                            bmbytes[bm.Width * (y - 1) + (x - 1)] == SEFER &&
                            bmbytes[bm.Width * (y - 1) + x] == SEFER &&
                            bmbytes[bm.Width * (y - 1) + (x + 1)] == SEFER &&
                            bmbytes[bm.Width * (y + 1) + (x - 1)] == WAHAD &&
                            bmbytes[bm.Width * (y + 1) + x] == WAHAD &&
                            bmbytes[bm.Width * (y + 1) + (x + 1)] == WAHAD)
                        {
                            tmpbytes[(x) + (y) * bm.Width] = SEFER;
                        }
                        else
                        {
                            tmpbytes[(x) + (y) * bm.Width] = bmbytes[(x) + (y) * bm.Width];
                        }
                    }
                }

                bmbytes = CopyBytes(tmpbytes, bmbytes);

                // . 0 0
                // 1 1 0
                // 1 1 .
                for (int x = taille; x < bitmap.Width - taille; x++)
                {
                    for (int y = taille; y < bitmap.Height - taille; y++)
                    {
                        if (bmbytes[bm.Width * y + x] == WAHAD &&
                            bmbytes[bm.Width * y + (x + 1)] == SEFER &&
                            bmbytes[bm.Width * y + (x - 1)] == WAHAD &&
                            bmbytes[bm.Width * (y - 1) + x] == SEFER &&
                            bmbytes[bm.Width * (y - 1) + (x + 1)] == SEFER &&
                            bmbytes[bm.Width * (y + 1) + (x - 1)] == WAHAD &&
                            bmbytes[bm.Width * (y + 1) + x] == WAHAD)
                        {
                            tmpbytes[(x) + (y) * bm.Width] = SEFER;
                        }
                        else
                        {
                            tmpbytes[(x) + (y) * bm.Width] = bmbytes[(x) + (y) * bm.Width];
                        }
                    }
                }

                bmbytes = CopyBytes(tmpbytes, bmbytes);

                // 1 . 0 bm->tmp
                // 1 1 0
                // 1 . 0
                for (int x = taille; x < bitmap.Width - taille; x++)
                {
                    for (int y = taille; y < bitmap.Height - taille; y++)
                    {
                        if (bmbytes[bm.Width * y + x] == WAHAD &&
                            bmbytes[bm.Width * y + (x + 1)] == SEFER &&
                            bmbytes[bm.Width * (y - 1) + (x + 1)] == SEFER &&
                            bmbytes[bm.Width * (y + 1) + (x + 1)] == SEFER &&
                            bmbytes[bm.Width * (y - 1) + (x - 1)] == WAHAD &&
                            bmbytes[bm.Width * y + (x - 1)] == WAHAD &&
                            bmbytes[bm.Width * (y + 1) + (x - 1)] == WAHAD)
                        {
                            tmpbytes[(x) + (y) * bm.Width] = SEFER;
                        }
                        else
                        {
                            tmpbytes[(x) + (y) * bm.Width] = bmbytes[(x) + (y) * bm.Width];
                        }
                    }
                }

                bmbytes = CopyBytes(tmpbytes, bmbytes);

                // 1 1 .
                // 1 1 0
                // . 0 0
                for (int x = taille; x < bitmap.Width - taille; x++)
                {
                    for (int y = taille; y < bitmap.Height - taille; y++)
                    {
                        if (bmbytes[bm.Width * y + x] == WAHAD &&
                            bmbytes[bm.Width * y + (x + 1)] == SEFER &&
                            bmbytes[bm.Width * (y + 1) + (x + 1)] == SEFER &&
                            bmbytes[bm.Width * y + (x - 1)] == WAHAD &&
                            bmbytes[bm.Width * (y - 1) + (x - 1)] == WAHAD &&
                            bmbytes[bm.Width * (y - 1) + x] == WAHAD &&
                            bmbytes[bm.Width * (y + 1) + x] == SEFER)
                        {

                            tmpbytes[(x) + (y) * bm.Width] = SEFER;
                        }
                        else
                        {
                            tmpbytes[(x) + (y) * bm.Width] = bmbytes[(x) + (y) * bm.Width];
                        }
                    }
                }

                bmbytes = CopyBytes(tmpbytes, bmbytes);


                // 1 1 1 bm->tmp
                // . 1 .
                // 0 0 0
                for (int x = taille; x < bitmap.Width - taille; x++)
                {
                    for (int y = taille; y < bitmap.Height - taille; y++)
                    {
                        if (bmbytes[bm.Width * y + x] == WAHAD &&
                            bmbytes[bm.Width * (y - 1) + x] == WAHAD &&
                            bmbytes[bm.Width * (y - 1) + (x - 1)] == WAHAD &&
                            bmbytes[bm.Width * (y - 1) + (x + 1)] == WAHAD &&
                            bmbytes[bm.Width * (y + 1) + x] == SEFER &&
                            bmbytes[bm.Width * (y + 1) + (x - 1)] == SEFER &&
                            bmbytes[bm.Width * (y + 1) + (x + 1)] == SEFER)
                        {

                            tmpbytes[(x) + (y) * bm.Width] = SEFER;
                        }
                        else
                        {
                            tmpbytes[(x) + (y) * bm.Width] = bmbytes[(x) + (y) * bm.Width];
                        }
                    }
                }

                bmbytes = CopyBytes(tmpbytes, bmbytes);

                // . 1 1
                // 0 1 1
                // 0 0 .
                for (int x = taille; x < bitmap.Width - taille; x++)
                {
                    for (int y = taille; y < bitmap.Height - taille; y++)
                    {
                        if (bmbytes[bm.Width * y + x] == WAHAD &&
                            bmbytes[bm.Width * (y - 1) + x] == WAHAD &&
                            bmbytes[bm.Width * (y + 1) + x] == SEFER &&
                            bmbytes[bm.Width * y + (x + 1)] == WAHAD &&
                            bmbytes[bm.Width * (y - 1) + (x + 1)] == WAHAD &&
                            bmbytes[bm.Width * y + (x - 1)] == SEFER &&
                            bmbytes[bm.Width * (y + 1) + (x - 1)] == SEFER)
                        {
                            tmpbytes[(x) + (y) * bm.Width] = SEFER;
                        }
                        else
                        {
                            tmpbytes[(x) + (y) * bm.Width] = bmbytes[(x) + (y) * bm.Width];
                        }
                    }
                }

                bmbytes = CopyBytes(tmpbytes, bmbytes);
                isEqual = CompareByteArray(prevbytes, bmbytes);

            }

            Marshal.Copy(bmbytes, 0, bmData.Scan0, bytes);
            bm.UnlockBits(bmData);
            tmp.UnlockBits(tmpData);

            return bm;

        }

        private static bool CompareBitmaps(Bitmap bmp1, Bitmap bmp2)
        {
            if (bmp1 == null || bmp2 == null)
                return false;
            if (object.Equals(bmp1, bmp2))
                return true;
            if (!bmp1.Size.Equals(bmp2.Size) || !bmp1.PixelFormat.Equals(bmp2.PixelFormat))
                return false;

            int bytes = bmp1.Width * bmp1.Height * (Image.GetPixelFormatSize(bmp1.PixelFormat) / 8);

            bool result = true;
            byte[] b1bytes = new byte[bytes];
            byte[] b2bytes = new byte[bytes];

            BitmapData bitmapData1 = bmp1.LockBits(new Rectangle(0, 0, bmp1.Width, bmp1.Height), ImageLockMode.ReadOnly, bmp1.PixelFormat);
            BitmapData bitmapData2 = bmp2.LockBits(new Rectangle(0, 0, bmp2.Width, bmp2.Height), ImageLockMode.ReadOnly, bmp2.PixelFormat);

            Marshal.Copy(bitmapData1.Scan0, b1bytes, 0, bytes);
            Marshal.Copy(bitmapData2.Scan0, b2bytes, 0, bytes);

            for (int n = 0; n <= bytes - 1; n++)
            {
                if (b1bytes[n] != b2bytes[n])
                {
                    result = false;
                    break;
                }
            }

            bmp1.UnlockBits(bitmapData1);
            bmp2.UnlockBits(bitmapData2);

            return result;
        }



        private static Bitmap Union(Bitmap bitmap1, Bitmap bitmap2)
        {
            Bitmap bm = new Bitmap(bitmap2.Width, bitmap2.Height);

            for (int x = 0; x < bitmap2.Width; x++)
            {
                for (int y = 0; y < bitmap2.Height; y++)
                {
                    if (bitmap1.GetPixel(x, y).R == ONE || bitmap2.GetPixel(x, y).R == ONE)
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

        private static Bitmap Differrence(Bitmap bitmap1, Bitmap bitmap2)
        {
            Bitmap bm = new Bitmap(bitmap2.Width, bitmap2.Height);

            for (int x = 0; x < bitmap2.Width; x++)
            {
                for (int y = 0; y < bitmap2.Height; y++)
                {
                    int z = bitmap1.GetPixel(x, y).R;
                    if (bitmap1.GetPixel(x, y).R == ONE && bitmap2.GetPixel(x, y).R == ZERO)
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

        public static Bitmap ErosionHex(Bitmap bitmap, int taille)
        {
            Bitmap bm = new Bitmap(bitmap);
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    bm.SetPixel(x, y, Color.FromArgb(ZERO, ZERO, ZERO));
                }
            }
            BitmapData bmData = bm.LockBits(new Rectangle(0, 0, bm.Width, bm.Height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
            BitmapData tmpData = bitmap.LockBits(new Rectangle(0, 0, bm.Width, bm.Height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
            int bytes = bm.Width * bm.Height;
            byte[] bmbytes = new byte[bytes];
            byte[] tmpbytes = new byte[bytes];

            Marshal.Copy(bmData.Scan0, bmbytes, 0, bytes);
            Marshal.Copy(tmpData.Scan0, tmpbytes, 0, bytes);
            bool isOne = true;

            for (int x = 0; x < bm.Width; x++)
            {
                for (int y = 0; y < bm.Height; y++)
                {
                    isOne = true;
                    if (tmpbytes[x + y * bm.Width] == SEFER)
                    {
                        isOne = false;
                    }
                    else
                    {
                        for (int i = x - taille; i <= x + taille && isOne; i++)
                        {
                            for (int j = y - taille; j <= y + taille && isOne; j++)
                            {
                                if (i >= 0 && i < bm.Width
                            && j >= 0 && j < bm.Height
                            && tmpbytes[j * bm.Width + i] == SEFER)
                                {
                                    int rayon = (int)Math.Sqrt((i - x) * (i - x) + (j - y) * (j - y));
                                    if (rayon <= taille)
                                    {
                                        isOne = false;
                                    }

                                }
                            }
                        }

                    }
                    if (isOne)
                    {
                        bmbytes[(x) + (y) * bm.Width] = WAHAD;
                    }
                    else
                    {
                        bmbytes[(x) + (y) * bm.Width] = SEFER;
                    }

                }
            }
            Marshal.Copy(bmbytes, 0, bmData.Scan0, bytes);
            bm.UnlockBits(bmData);
            bitmap.UnlockBits(tmpData);

            return bm;
        }

        public static Bitmap OuvertureHex(Bitmap bitmap, int taille)
        {
            Bitmap erode = ErosionHex(bitmap, taille);

            Bitmap bm = DilatationHex(erode, taille);

            // Return bitmap
            return bm;
        }

        public static Bitmap DilatationHex(Bitmap bitmap, int taille)
        {
            Bitmap bm = new Bitmap(bitmap);
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    bm.SetPixel(x, y, Color.FromArgb(ZERO, ZERO, ZERO));
                }
            }
            BitmapData bmData = bm.LockBits(new Rectangle(0, 0, bm.Width, bm.Height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
            BitmapData tmpData = bitmap.LockBits(new Rectangle(0, 0, bm.Width, bm.Height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
            int bytes = bm.Width * bm.Height;
            byte[] bmbytes = new byte[bytes];
            byte[] tmpbytes = new byte[bytes];

            Marshal.Copy(bmData.Scan0, bmbytes, 0, bytes);
            Marshal.Copy(tmpData.Scan0, tmpbytes, 0, bytes);
            bool isOne = false;

            for (int x = 0; x < bm.Width; x++)
            {
                for (int y = 0; y < bm.Height; y++)
                {
                    isOne = false;
                    if (tmpbytes[x + y * bm.Width] == WAHAD)
                    {
                        isOne = true;
                    }
                    else
                    {
                        for (int i = x - taille; i <= x + taille && !isOne; i++)
                        {
                            for (int j = y - taille; j <= y + taille && !isOne; j++)
                            {
                                if (i >= 0 && i < bm.Width
                            && j >= 0 && j < bm.Height
                            && tmpbytes[j * bm.Width + i] == WAHAD)
                                {
                                    int rayon = (int)Math.Sqrt((i - x) * (i - x) + (j - y) * (j - y));
                                    if (rayon <= taille)
                                    {
                                        isOne = true;
                                    }

                                }
                            }
                        }

                    }
                    if (isOne)
                    {
                        bmbytes[(x) + (y) * bm.Width] = WAHAD;
                    }
                    else
                    {
                        bmbytes[(x) + (y) * bm.Width] = SEFER;
                    }

                }
            }
            Marshal.Copy(bmbytes, 0, bmData.Scan0, bytes);
            bm.UnlockBits(bmData);
            bitmap.UnlockBits(tmpData);

            return bm;
        }

        public static bool CheckBitmapEmpty(Bitmap bitmap)
        {
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    if (bitmap.GetPixel(x, y).R == ONE)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static Bitmap SkeletonByLantuejoul(Bitmap bitmap)
        {
            Bitmap erode = new Bitmap(bitmap);
            Bitmap erodeErode = new Bitmap(bitmap);
            Bitmap dilateErode = new Bitmap(bitmap);
            Bitmap result = new Bitmap(bitmap);

            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    erode.SetPixel(x, y, Color.FromArgb(ZERO, ZERO, ZERO));
                    erodeErode.SetPixel(x, y, Color.FromArgb(ZERO, ZERO, ZERO));
                    dilateErode.SetPixel(x, y, Color.FromArgb(ZERO, ZERO, ZERO));
                    result.SetPixel(x, y, Color.FromArgb(ZERO, ZERO, ZERO));
                }
            }
            bool stable = false;
            int lambda = 0;

            BitmapData erodeData = erode.LockBits(new Rectangle(0, 0, erode.Width, erode.Height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
            BitmapData erodeErodeData = erodeErode.LockBits(new Rectangle(0, 0, erode.Width, erode.Height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
            BitmapData dilateErodeData = dilateErode.LockBits(new Rectangle(0, 0, erode.Width, erode.Height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
            BitmapData tmpData = bitmap.LockBits(new Rectangle(0, 0, erode.Width, erode.Height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
            BitmapData resultData = result.LockBits(new Rectangle(0, 0, erode.Width, erode.Height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
            int bytes = erode.Width * erode.Height;
            byte[] bmbytes = new byte[bytes];
            byte[] bm1bytes = new byte[bytes];
            byte[] bm2bytes = new byte[bytes];
            byte[] tmpbytes = new byte[bytes];
            byte[] resultbytes = new byte[bytes];

            Marshal.Copy(erodeData.Scan0, bmbytes, 0, bytes);
            Marshal.Copy(erodeErodeData.Scan0, bm1bytes, 0, bytes);
            Marshal.Copy(dilateErodeData.Scan0, bm2bytes, 0, bytes);
            Marshal.Copy(tmpData.Scan0, tmpbytes, 0, bytes);
            Marshal.Copy(resultData.Scan0, resultbytes, 0, bytes);


            while (!stable || lambda < 10)
            {
                // erosion

                bool isZero = false;

                for (int x = 0; x < erode.Width; x++)
                {
                    for (int y = 0; y < erode.Height; y++)
                    {
                        isZero = false;
                        if (tmpbytes[x + y * erode.Width] == SEFER)
                        {
                            isZero = true;
                        }
                        else
                        {
                            for (int i = x - lambda; i <= x + lambda && !isZero; i++)
                            {
                                for (int j = y - lambda; j <= y + lambda && !isZero; j++)
                                {
                                    if (i >= 0 && i < erode.Width
                                && j >= 0 && j < erode.Height
                                && tmpbytes[j * erode.Width + i] == SEFER)
                                    {
                                        int rayon = (int)Math.Sqrt((i - x) * (i - x) + (j - y) * (j - y));
                                        if (rayon <= lambda)
                                        {
                                            isZero = true;
                                        }

                                    }
                                }
                            }

                        }
                        if (isZero)
                        {
                            bmbytes[(x) + (y) * erode.Width] = SEFER;
                        }
                        else
                        {
                            bmbytes[(x) + (y) * erode.Width] = WAHAD;
                        }

                    }
                }

                //ouverture

                // erosion

                isZero = false;

                for (int x = 0; x < erode.Width; x++)
                {
                    for (int y = 0; y < erode.Height; y++)
                    {
                        isZero = false;
                        if (bmbytes[x + y * erode.Width] == SEFER)
                        {
                            isZero = true;
                        }
                        else
                        {
                            for (int i = x - 1; i <= x + 1 && !isZero; i++)
                            {
                                for (int j = y - 1; j <= y + 1 && !isZero; j++)
                                {
                                    if (i >= 0 && i < erode.Width
                                && j >= 0 && j < erode.Height
                                && bmbytes[j * erode.Width + i] == SEFER)
                                    {
                                        int rayon = (int)Math.Sqrt((i - x) * (i - x) + (j - y) * (j - y));
                                        if (rayon <= 1)
                                        {
                                            isZero = true;
                                        }

                                    }
                                }
                            }

                        }
                        if (isZero)
                        {
                            bm1bytes[(x) + (y) * erode.Width] = SEFER;
                        }
                        else
                        {
                            bm1bytes[(x) + (y) * erode.Width] = WAHAD;
                        }

                    }
                }
                bool isOne;
                // dilatation
                for (int x = 0; x < erode.Width; x++)
                {
                    for (int y = 0; y < erode.Height; y++)
                    {
                        isOne = false;
                        if (bm1bytes[x + y * erode.Width] == WAHAD)
                        {
                            isOne = true;
                        }
                        else
                        {
                            for (int i = x - 1; i <= x + 1 && !isOne; i++)
                            {
                                for (int j = y - 1; j <= y + 1 && !isOne; j++)
                                {
                                    if (i >= 0 && i < erode.Width
                                && j >= 0 && j < erode.Height
                                && bm1bytes[j * erode.Width + i] == WAHAD)
                                    {
                                        int rayon = (int)Math.Sqrt((i - x) * (i - x) + (j - y) * (j - y));
                                        if (rayon <= 1)
                                        {
                                            isOne = true;
                                        }

                                    }
                                }
                            }

                        }
                        if (isOne)
                        {
                            bm2bytes[(x) + (y) * erode.Width] = WAHAD;
                        }
                        else
                        {
                            bm2bytes[(x) + (y) * erode.Width] = SEFER;
                        }

                    }
                }
                bm2bytes = RoundEdges(bm2bytes, erode.Width, erode.Height);


                // Diff and Union
                bool isEqual = CompareByteArray(bmbytes, bm2bytes);
                bool isEqual2 = CompareByteArray(bmbytes, tmpbytes);
                resultbytes = CopyBytes(UnionBytes(resultbytes, DiffBytes(bmbytes, bm2bytes)));

                stable = CheckByteArrayEmpty(bmbytes);
                lambda++;
            }
            Marshal.Copy(resultbytes, 0, resultData.Scan0, bytes);
            erode.UnlockBits(erodeData);
            erodeErode.UnlockBits(erodeErodeData);
            dilateErode.UnlockBits(dilateErodeData);
            bitmap.UnlockBits(tmpData);
            result.UnlockBits(resultData);


            return result;
        }

        private static byte[] RoundEdges(byte[] bm2bytes, int width,int height)
        {
            byte[] res = CopyBytes(bm2bytes);

            for(int x = 0; x < width; x++)
            {
                for(int y = 0; y < height; y++)
                {
                    if(bm2bytes[(x) + (y) * width] == WAHAD)
                    {
                        // 0 0 0
                        // 0 1 1
                        // 0 1 1 
                        if (
                            bm2bytes[(x - 1) + (y - 1) * width] == SEFER &&
                            bm2bytes[(x) + (y - 1) * width] == SEFER &&
                            bm2bytes[(x + 1) + (y - 1) * width] == SEFER &&
                            bm2bytes[(x - 1) + (y) * width] == SEFER &&
                            bm2bytes[(x + 1) + (y) * width] == WAHAD &&
                            bm2bytes[(x - 1) + (y + 1) * width] == SEFER &&
                            bm2bytes[(x) + (y + 1) * width] == WAHAD &&
                            bm2bytes[(x + 1) + (y + 1) * width] == WAHAD
                            )
                        {
                            res[(x) + (y) * width] = SEFER;
                        }
                        // 0 0 0
                        // 1 1 0
                        // 1 1 0
                        else if (
                            bm2bytes[(x - 1) + (y - 1) * width] == SEFER &&
                            bm2bytes[(x) + (y - 1) * width] == SEFER &&
                            bm2bytes[(x + 1) + (y - 1) * width] == SEFER &&
                            bm2bytes[(x - 1) + (y) * width] == WAHAD &&
                            bm2bytes[(x + 1) + (y) * width] == SEFER &&
                            bm2bytes[(x - 1) + (y + 1) * width] == WAHAD &&
                            bm2bytes[(x) + (y + 1) * width] == WAHAD &&
                            bm2bytes[(x + 1) + (y + 1) * width] == SEFER
                            )
                        {
                            res[(x) + (y) * width] = SEFER;
                        }
                        // 1 1 0
                        // 1 1 0
                        // 0 0 0
                        else if (
                            bm2bytes[(x - 1) + (y - 1) * width] == WAHAD &&
                            bm2bytes[(x) + (y - 1) * width] == WAHAD &&
                            bm2bytes[(x + 1) + (y - 1) * width] == SEFER &&
                            bm2bytes[(x - 1) + (y) * width] == WAHAD &&
                            bm2bytes[(x + 1) + (y) * width] == SEFER &&
                            bm2bytes[(x - 1) + (y + 1) * width] == SEFER &&
                            bm2bytes[(x) + (y + 1) * width] == SEFER &&
                            bm2bytes[(x + 1) + (y + 1) * width] == SEFER
                            )
                        {
                            res[(x) + (y) * width] = SEFER;
                        }
                        // 0 1 1
                        // 0 1 1
                        // 0 0 0
                        else if (
                            bm2bytes[(x - 1) + (y - 1) * width] == SEFER &&
                            bm2bytes[(x) + (y - 1) * width] == WAHAD &&
                            bm2bytes[(x + 1) + (y - 1) * width] == WAHAD &&
                            bm2bytes[(x - 1) + (y) * width] == SEFER &&
                            bm2bytes[(x + 1) + (y) * width] == WAHAD &&
                            bm2bytes[(x - 1) + (y + 1) * width] == SEFER &&
                            bm2bytes[(x) + (y + 1) * width] == SEFER &&
                            bm2bytes[(x + 1) + (y + 1) * width] == SEFER
                            )
                        {
                            res[(x) + (y) * width] = SEFER;
                        }
                            


                    }



                }
            }
            return res;
        }

        private static bool CheckByteArrayEmpty(byte[] bmbytes)
        {
            for (int i = 0; i < bmbytes.Length; i++)
            {
                if (bmbytes[i] == WAHAD)
                {
                    return false;
                }

            }
            return true;
        }

        private static byte[] UnionBytes(byte[] b1, byte[] b2)
        {
            byte[] res = new byte[b1.Length];
            for (int i = 0; i < b1.Length; i++)
            {
                if (b1[i] == WAHAD || b2[i] == WAHAD)
                {
                    res[i] = WAHAD;
                }
                else
                {
                    res[i] = SEFER;
                }
            }
            return res;
        }

        private static byte[] DiffBytes(byte[] bmbytes, byte[] bm2bytes)
        {
            byte[] res = new byte[bmbytes.Length];
            for (int i = 0; i < bmbytes.Length; i++)
            {
                if (bmbytes[i] == WAHAD && bm2bytes[i] == SEFER)
                {
                    res[i] = WAHAD;
                }
                else
                {
                    res[i] = SEFER;
                }
            }
            return res;
        }

        private static byte[,] MatrixRotation(byte[,] elt)
        {
            byte[,] result = new byte[3, 3];
            // center
            result[1, 1] = elt[1, 1];
            // fist line fill
            result[0, 0] = elt[1, 0];
            result[0, 1] = elt[0, 0];
            result[0, 2] = elt[0, 1];

            // second column
            result[1, 2] = elt[0, 2];
            result[2, 2] = elt[1, 2];

            // third line
            result[2, 1] = elt[2, 2];
            result[2, 0] = elt[2, 1];

            // first column
            result[1, 0] = elt[2, 0];

            return result;
        }


    }
}
