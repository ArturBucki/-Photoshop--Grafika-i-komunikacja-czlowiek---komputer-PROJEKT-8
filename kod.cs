using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// 1.Modyfikacja obrazu w oparciu filtr wyostrzający:
// w oparciu o operator Robertsa, Prewitta, Sobela (poziome i pionowe, 6 algorytmów)
// -operator Laplace’a (1 algorytm),

namespace lab8
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        int width;
        int height;

        public Form1()
        {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog Opfile = new OpenFileDialog();
            if (DialogResult.OK == Opfile.ShowDialog())
            {
                pictureBox1.Image = new Bitmap(Opfile.FileName);
                bitmap = (Bitmap)pictureBox1.Image;

                width = pictureBox1.Image.Width;
                height = pictureBox1.Image.Height;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                Bitmap bitmapEdited = (Bitmap)bitmap.Clone();
                Bitmap bitmapCopy = (Bitmap)bitmap.Clone();

                double pomocR = 0, pomocG = 0, pomocB = 0;

                int width = pictureBox1.Image.Width;
                int height = pictureBox1.Image.Height;

                int[,] macierz = new int[,] { { 0, 0, 0 }, { 0, 1, -1 }, { 0, 0, 0 } };


                for (int i = 1; i < height - 1; i++)
                {
                    for (int j = 1; j < width - 1; j++)
                    {

                        pomocR = 0; pomocG = 0; pomocB = 0;

                        for (int k = -1; k <= 1; k++)
                        {
                            for (int l = -1; l <= 1; l++)
                            {
                                Color p = bitmapCopy.GetPixel(j + k, i + l);

                                int r = (int)p.R;
                                int g = (int)p.G;
                                int b = (int)p.B;

                                pomocR += r * macierz[k + 1, l + 1];
                                pomocG += g * macierz[k + 1, l + 1];
                                pomocB += b * macierz[k + 1, l + 1];

                            }
                        }

                        pomocR = Math.Abs(pomocR);
                        pomocG = Math.Abs(pomocG);
                        pomocB = Math.Abs(pomocB);


                        if (pomocR >= 0 && pomocR <= 255) { }
                        else pomocR = 0;

                        if (pomocG >= 0 && pomocG <= 255) { }
                        else pomocG = 0;

                        if (pomocB >= 0 && pomocB <= 255) { }
                        else pomocB = 0;


                        bitmapEdited.SetPixel(j, i, Color.FromArgb((int)pomocR, (int)pomocG, (int)pomocB));
                    }
                }

                pictureBox2.Image = bitmapEdited;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap bitmapEdited = (Bitmap)bitmap.Clone();
            Bitmap bitmapCopy = (Bitmap)bitmap.Clone();

            double pomocR = 0, pomocG = 0, pomocB = 0;

            int width = pictureBox1.Image.Width;
            int height = pictureBox1.Image.Height;

            int[,] macierz = new int[,] { { 0, 0, 0 }, { 0, 1, 0 }, { 0, -1, 0 } };


            for (int i = 1; i < height - 1; i++)
            {
                for (int j = 1; j < width - 1; j++)
                {

                    pomocR = 0; pomocG = 0; pomocB = 0;

                    for (int k = -1; k <= 1; k++)
                    {
                        for (int l = -1; l <= 1; l++)
                        {
                            Color p = bitmapCopy.GetPixel(j + k, i + l);

                            int r = (int)p.R;
                            int g = (int)p.G;
                            int b = (int)p.B;

                            pomocR += r * macierz[k + 1, l + 1];
                            pomocG += g * macierz[k + 1, l + 1];
                            pomocB += b * macierz[k + 1, l + 1];

                        }
                    }

                    pomocR = Math.Abs(pomocR);
                    pomocG = Math.Abs(pomocG);
                    pomocB = Math.Abs(pomocB);


                    if (pomocR >= 0 && pomocR <= 255) { }
                    else pomocR = 0;

                    if (pomocG >= 0 && pomocG <= 255) { }
                    else pomocG = 0;

                    if (pomocB >= 0 && pomocB <= 255) { }
                    else pomocB = 0;


                    bitmapEdited.SetPixel(j, i, Color.FromArgb((int)pomocR, (int)pomocG, (int)pomocB));
                }
            }

            pictureBox2.Image = bitmapEdited;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Bitmap bitmapEdited = (Bitmap)bitmap.Clone();
            Bitmap bitmapCopy = (Bitmap)bitmap.Clone();

            double pomocR = 0, pomocG = 0, pomocB = 0;

            int width = pictureBox1.Image.Width;
            int height = pictureBox1.Image.Height;

            int[,] macierz = new int[,] { { 1, 1, 1 }, { 0, 0, 0 }, { -1, -1, -1 } };


            for (int i = 1; i < height - 1; i++)
            {
                for (int j = 1; j < width - 1; j++)
                {

                    pomocR = 0; pomocG = 0; pomocB = 0;

                    for (int k = -1; k <= 1; k++)
                    {
                        for (int l = -1; l <= 1; l++)
                        {
                            Color p = bitmapCopy.GetPixel(j + k, i + l);

                            int r = (int)p.R;
                            int g = (int)p.G;
                            int b = (int)p.B;

                            pomocR += r * macierz[k + 1, l + 1];
                            pomocG += g * macierz[k + 1, l + 1];
                            pomocB += b * macierz[k + 1, l + 1];

                        }
                    }

                    pomocR = Math.Abs(pomocR);
                    pomocG = Math.Abs(pomocG);
                    pomocB = Math.Abs(pomocB);


                    if (pomocR >= 0 && pomocR <= 255) { }
                    else pomocR = 0;

                    if (pomocG >= 0 && pomocG <= 255) { }
                    else pomocG = 0;

                    if (pomocB >= 0 && pomocB <= 255) { }
                    else pomocB = 0;


                    bitmapEdited.SetPixel(j, i, Color.FromArgb((int)pomocR, (int)pomocG, (int)pomocB));
                }
            }

            pictureBox2.Image = bitmapEdited;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap bitmapEdited = (Bitmap)bitmap.Clone();
            Bitmap bitmapCopy = (Bitmap)bitmap.Clone();

            double pomocR = 0, pomocG = 0, pomocB = 0;

            int width = pictureBox1.Image.Width;
            int height = pictureBox1.Image.Height;

            int[,] macierz = new int[,] { { 1, 0, -1 }, { 1, 0, -1 }, { 1, 0, -1 } };


            for (int i = 1; i < height - 1; i++)
            {
                for (int j = 1; j < width - 1; j++)
                {

                    pomocR = 0; pomocG = 0; pomocB = 0;

                    for (int k = -1; k <= 1; k++)
                    {
                        for (int l = -1; l <= 1; l++)
                        {
                            Color p = bitmapCopy.GetPixel(j + k, i + l);

                            int r = (int)p.R;
                            int g = (int)p.G;
                            int b = (int)p.B;

                            pomocR += r * macierz[k + 1, l + 1];
                            pomocG += g * macierz[k + 1, l + 1];
                            pomocB += b * macierz[k + 1, l + 1];

                        }
                    }

                    pomocR = Math.Abs(pomocR);
                    pomocG = Math.Abs(pomocG);
                    pomocB = Math.Abs(pomocB);


                    if (pomocR >= 0 && pomocR <= 255) { }
                    else pomocR = 0;

                    if (pomocG >= 0 && pomocG <= 255) { }
                    else pomocG = 0;

                    if (pomocB >= 0 && pomocB <= 255) { }
                    else pomocB = 0;


                    bitmapEdited.SetPixel(j, i, Color.FromArgb((int)pomocR, (int)pomocG, (int)pomocB));
                }
            }

            pictureBox2.Image = bitmapEdited;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Bitmap bitmapEdited = (Bitmap)bitmap.Clone();
            Bitmap bitmapCopy = (Bitmap)bitmap.Clone();

            double pomocR = 0, pomocG = 0, pomocB = 0;

            int width = pictureBox1.Image.Width;
            int height = pictureBox1.Image.Height;

            int[,] macierz = new int[,] { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } };


            for (int i = 1; i < height - 1; i++)
            {
                for (int j = 1; j < width - 1; j++)
                {

                    pomocR = 0; pomocG = 0; pomocB = 0;

                    for (int k = -1; k <= 1; k++)
                    {
                        for (int l = -1; l <= 1; l++)
                        {
                            Color p = bitmapCopy.GetPixel(j + k, i + l);

                            int r = (int)p.R;
                            int g = (int)p.G;
                            int b = (int)p.B;

                            pomocR += r * macierz[k + 1, l + 1];
                            pomocG += g * macierz[k + 1, l + 1];
                            pomocB += b * macierz[k + 1, l + 1];

                        }
                    }

                    pomocR = Math.Abs(pomocR);
                    pomocG = Math.Abs(pomocG);
                    pomocB = Math.Abs(pomocB);


                    if (pomocR >= 0 && pomocR <= 255) { }
                    else pomocR = 0;

                    if (pomocG >= 0 && pomocG <= 255) { }
                    else pomocG = 0;

                    if (pomocB >= 0 && pomocB <= 255) { }
                    else pomocB = 0;


                    bitmapEdited.SetPixel(j, i, Color.FromArgb((int)pomocR, (int)pomocG, (int)pomocB));
                }
            }

            pictureBox2.Image = bitmapEdited;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Bitmap bitmapEdited = (Bitmap)bitmap.Clone();
            Bitmap bitmapCopy = (Bitmap)bitmap.Clone();

            double pomocR = 0, pomocG = 0, pomocB = 0;

            int width = pictureBox1.Image.Width;
            int height = pictureBox1.Image.Height;

            int[,] macierz = new int[,] { { 1, 0, -1 }, { 2, 0, -2 }, { 1, 0, -1 } };


            for (int i = 1; i < height - 1; i++)
            {
                for (int j = 1; j < width - 1; j++)
                {

                    pomocR = 0; pomocG = 0; pomocB = 0;

                    for (int k = -1; k <= 1; k++)
                    {
                        for (int l = -1; l <= 1; l++)
                        {
                            Color p = bitmapCopy.GetPixel(j + k, i + l);

                            int r = (int)p.R;
                            int g = (int)p.G;
                            int b = (int)p.B;

                            pomocR += r * macierz[k + 1, l + 1];
                            pomocG += g * macierz[k + 1, l + 1];
                            pomocB += b * macierz[k + 1, l + 1];

                        }
                    }

                    pomocR = Math.Abs(pomocR);
                    pomocG = Math.Abs(pomocG);
                    pomocB = Math.Abs(pomocB);


                    if (pomocR >= 0 && pomocR <= 255) { }
                    else pomocR = 0;

                    if (pomocG >= 0 && pomocG <= 255) { }
                    else pomocG = 0;

                    if (pomocB >= 0 && pomocB <= 255) { }
                    else pomocB = 0;


                    bitmapEdited.SetPixel(j, i, Color.FromArgb((int)pomocR, (int)pomocG, (int)pomocB));
                }
            }

            pictureBox2.Image = bitmapEdited;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Bitmap bitmapEdited = (Bitmap)bitmap.Clone();
            Bitmap bitmapCopy = (Bitmap)bitmap.Clone();

            double pomocR = 0, pomocG = 0, pomocB = 0;

            int width = pictureBox1.Image.Width;
            int height = pictureBox1.Image.Height;

            int[,] macierz = new int[,] { { 0, -1, 0 }, { -1, 4, -1 }, { 0, -1, 0 } };


            for (int i = 1; i < height - 1; i++)
            {
                for (int j = 1; j < width - 1; j++)
                {

                    pomocR = 0; pomocG = 0; pomocB = 0;

                    for (int k = -1; k <= 1; k++)
                    {
                        for (int l = -1; l <= 1; l++)
                        {
                            Color p = bitmapCopy.GetPixel(j + k, i + l);

                            int r = (int)p.R;
                            int g = (int)p.G;
                            int b = (int)p.B;

                            pomocR += r * macierz[k + 1, l + 1];
                            pomocG += g * macierz[k + 1, l + 1];
                            pomocB += b * macierz[k + 1, l + 1];

                        }
                    }

                    pomocR = Math.Abs(pomocR);
                    pomocG = Math.Abs(pomocG);
                    pomocB = Math.Abs(pomocB);


                    if (pomocR >= 0 && pomocR <= 255) { }
                    else pomocR = 0;

                    if (pomocG >= 0 && pomocG <= 255) { }
                    else pomocG = 0;

                    if (pomocB >= 0 && pomocB <= 255) { }
                    else pomocB = 0;


                    bitmapEdited.SetPixel(j, i, Color.FromArgb((int)pomocR, (int)pomocG, (int)pomocB));
                }
            }

            pictureBox2.Image = bitmapEdited;
        }

        static void sort(int[] tablica)
        {
            int n = tablica.Length;
            do
            {
                for (int i = 0; i < n - 1; i++)
                {
                    if (tablica[i] > tablica[i + 1])
                    {
                        int tmp = tablica[i];
                        tablica[i] = tablica[i + 1];
                        tablica[i + 1] = tmp;
                    }
                }
                n--;
            }
            while (n > 1);
        }


        private void button9_Click(object sender, EventArgs e)
        {
            Bitmap bitmapCopy = (Bitmap)bitmap.Clone();


            for (int x = 0; x < width - 1; ++x)
            {
                int x0 = Math.Max(0, x - (int)numericUpDown1.Value);
                int x1 = Math.Min(width - 1, x + (int)numericUpDown1.Value);

                for(int y = 0; y < height - 1; ++y)
                {
                    int y0 = Math.Max(0, y - (int)numericUpDown1.Value);
                    int y1 = Math.Min(height - 1, y + (int)numericUpDown1.Value);

                    Color maxPixel = bitmap.GetPixel(x, y);

                    for(int u = x0; u < x1; ++u)
                    {
                        for(int v = y0; v < y1; ++v)
                        {
                            if (bitmap.GetPixel(u, v).R > maxPixel.R & bitmap.GetPixel(u, v).G > maxPixel.G & bitmap.GetPixel(u, v).B > maxPixel.B)
                            {
                                maxPixel = bitmap.GetPixel(u, v);
                            }
                        }
                    }

                    bitmapCopy.SetPixel(x, y, maxPixel);
                }
            }
            pictureBox2.Image = bitmapCopy;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Bitmap bitmapCopy = (Bitmap)bitmap.Clone();


            for (int x = 0; x < width - 1; ++x)
            {
                int x0 = Math.Max(0, x - (int)numericUpDown1.Value);
                int x1 = Math.Min(width - 1, x + (int)numericUpDown1.Value);

                for (int y = 0; y < height - 1; ++y)
                {
                    int y0 = Math.Max(0, y - (int)numericUpDown1.Value);
                    int y1 = Math.Min(height - 1, y + (int)numericUpDown1.Value);

                    Color maxPixel = bitmap.GetPixel(x, y);

                    for (int u = x0; u < x1; ++u)
                    {
                        for (int v = y0; v < y1; ++v)
                        {
                            if (bitmap.GetPixel(u, v).R < maxPixel.R & bitmap.GetPixel(u, v).G < maxPixel.G & bitmap.GetPixel(u, v).B < maxPixel.B)
                            {
                                maxPixel = bitmap.GetPixel(u, v);
                            }
                        }
                    }

                    bitmapCopy.SetPixel(x, y, maxPixel);
                }
            }
            pictureBox2.Image = bitmapCopy;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Bitmap bitmapCopy = (Bitmap)bitmap.Clone();
            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    Point[] arrayP = new Point[] {  new Point(x - 1, y - 1),
                                                    new Point(x - 0, y - 1),
                                                    new Point(x + 1, y - 1),
                                                    new Point(x - 1, y - 0),
                                                    new Point(x - 0, y - 0),
                                                    new Point(x + 1, y - 0),
                                                    new Point(x - 1, y + 1),
                                                    new Point(x - 0, y + 1),
                                                    new Point(x + 1, y + 1)};

                    int sumA = 0, sumR = 0, sumG = 0, sumB = 0;
                    foreach (Point item in arrayP)
                    {
                        sumA += bitmapCopy.GetPixel(item.X, item.Y).A;
                        sumR += bitmapCopy.GetPixel(item.X, item.Y).R;
                        sumG += bitmapCopy.GetPixel(item.X, item.Y).G;
                        sumB += bitmapCopy.GetPixel(item.X, item.Y).B;
                    }
                    int meanARGB = 0x01000000 * (sumA / 9) +
                                   0x00010000 * (sumR / 9) +
                                   0x00000100 * (sumG / 9) +
                                   0x00000001 * (sumB / 9);

                    bitmapCopy.SetPixel(x, y, Color.FromArgb(meanARGB));
                }
            }
            pictureBox2.Image = bitmapCopy;
        }
    }
}
