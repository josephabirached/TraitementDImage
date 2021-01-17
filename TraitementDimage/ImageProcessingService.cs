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
        public static int DC = -1;

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
                            if (elt[i, j] == ONE)
                            {

                                if (bitmap.GetPixel(x - taille + i, y - taille + j).R != ONE)//akalit
                                {
                                    isZero = true;
                                }


                            }
                        }
                    }
                    if (!isZero)
                    {
                        for (int i = 0; i < width && !isZero; i++)
                        {
                            for (int j = 0; j < height && !isZero; j++)
                            {
                                if (elt[i, j] == ONE)
                                {
                                    bm.SetPixel(x, y, Color.FromArgb(ONE, ONE, ONE));
                                }
                            }
                        }

                    }

                }
            }

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
        public static int[,] GetThinningElt(int type = 0)
        {


            int[,] result = new int[3, 3];
            if (type == 0)
            {
                result[0, 0] = ZERO;
                result[0, 1] = ZERO;
                result[0, 2] = ZERO;
                result[1, 0] = DC;
                result[1, 1] = ONE;
                result[1, 2] = DC;
                result[2, 0] = ONE;
                result[2, 1] = ONE;
                result[2, 2] = ONE;
            }
            else
            {
                result[0, 0] = DC;
                result[0, 1] = ZERO;
                result[0, 2] = ZERO;
                result[1, 0] = ONE;
                result[1, 1] = ONE;
                result[1, 2] = ZERO;
                result[2, 0] = DC;
                result[2, 1] = ONE;
                result[2, 2] = DC;
            }


            return result;
        }

        public static int[,] GetThickeningElt(int type = 0)
        {


            int[,] result = new int[3, 3];
            if (type == 0)
            {
                result[0, 0] = ZERO;
                result[0, 1] = ZERO;
                result[0, 2] = ZERO;
                result[1, 0] = DC;
                result[1, 1] = ZERO;
                result[1, 2] = DC;
                result[2, 0] = ONE;
                result[2, 1] = ONE;
                result[2, 2] = ONE;
            }
            else
            {
                result[0, 0] = DC;
                result[0, 1] = ZERO;
                result[0, 2] = ZERO;
                result[1, 0] = ONE;
                result[1, 1] = ZERO;
                result[1, 2] = ZERO;
                result[2, 0] = DC;
                result[2, 1] = ONE;
                result[2, 2] = DC;
            }


            return result;
        }


        public static Bitmap ThinningCarre(Bitmap bitmap, int[,] elt)
        {
            Bitmap bm = new Bitmap(bitmap);
            int taille = 1;
            int width = 3;
            int height = width;

           
            bool isZero = true;
            // Process the pixels.
            for (int x = taille; x < bitmap.Width - taille; x++)
            {
                for (int y = taille; y < bitmap.Height - taille; y++)
                {
                    isZero = true;

                    for (int i = 0; i < width && isZero; i++)
                    {
                        for (int j = 0; j < height && isZero; j++)
                        {
                            if (elt[j, i] != DC)
                            {
                                try
                                {
                                    if (bitmap.GetPixel(x - taille + i, y - taille + j).R != elt[j, i])
                                    {
                                        isZero = false;
                                    }
                                }
                                catch (Exception ex) { }
                            }
                        }
                    }
                    if (isZero)
                    {
                        bm.SetPixel(x, y, Color.FromArgb(ZERO, ZERO, ZERO));
                    }

                }
            }
            return bm;

        }

        public static Bitmap ThickeningCarre(Bitmap bitmap, int[,] elt)
        {
            Bitmap bm = new Bitmap(bitmap);
            int taille = 1;
            int width = 3;
            int height = width;

            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    bm.SetPixel(x, y, Color.FromArgb(ZERO, ZERO, ZERO));
                }
            }
            bool isOne = true;
            // Process the pixels.
            for (int x = taille; x < bitmap.Width - taille; x++)
            {
                for (int y = taille; y < bitmap.Height - taille; y++)
                {
                    isOne = true;

                    for (int i = 0; i < width && isOne; i++)
                    {
                        for (int j = 0; j < height && isOne; j++)
                        {
                            if (elt[j, i] != DC)
                            {
                                try
                                {
                                    if (bitmap.GetPixel(x - taille + i, y - taille + j).R != elt[j, i])
                                    {
                                        isOne = false;
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

        public static Bitmap SkeletonByThining(Bitmap bitmap, int iteration = 4)
        {
            int[,] elt = GetThinningElt();
            Bitmap bm = new Bitmap(bitmap);
            Bitmap tmp = new Bitmap(bitmap);
            bool stable = false;
            while (!stable)
            {
                stable = false;

                for (int i = 0; i < 8; i++)
                {
                    tmp = ThinningCarre(bitmap, elt);
                    elt = MatrixRotation(elt);
                }

                stable = CompareBitmaps(tmp, bm);
                bm = new Bitmap(tmp);

            }

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

        public static Bitmap SkeletonByLantuejoul(Bitmap bitmap)
        {
            Bitmap bm = new Bitmap(bitmap);
            Bitmap tmp = new Bitmap(bitmap);
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    bm.SetPixel(x, y, Color.FromArgb(ZERO, ZERO, ZERO));
                    tmp.SetPixel(x, y, Color.FromArgb(ZERO, ZERO, ZERO));
                }
            }
            bool stable = false;
            int lambda = 0;
            int[,] lambdaB;
            int[,] B = GetEltCarre(1);
            Bitmap erode;
            Bitmap ouvert;

            while (!stable)
            {
                stable = false;
                lambdaB = GetEltCarre(lambda);
                erode = ErosionCarre(bitmap, lambdaB, lambda);
                ouvert = OuvertureCarre(erode, B, 1);
                tmp = Addition(tmp, Substraction(erode, ouvert));
                stable = CompareBitmaps(tmp, bm);
                bm = new Bitmap(tmp);
                lambda++;
            }
            return bm;
        }


        private static int[,] MatrixRotation(int[,] elt)
        {
            int[,] result = new int[3, 3];
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
