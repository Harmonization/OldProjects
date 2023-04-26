using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
namespace FlyPhoto
{
    public partial class Noise : Form
    {
        Form1 F;
        public Noise(Form1 F_)
        {
            F = F_;
            InitializeComponent();
        }

        bool b = false;
        public static void Generation(ref Bitmap bmp)
            {
                Random rnd = new Random();
                Bitmap TempBmp = (Bitmap)bmp.Clone();

                BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
                BitmapData TempBmpData = TempBmp.LockBits(new Rectangle(0, 0, TempBmp.Width, TempBmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);

                unsafe
                {
                    byte* ptr = (byte*)bmpData.Scan0.ToPointer();
                    byte* TempPtr = (byte*)TempBmpData.Scan0.ToPointer();

                    int Pix = 0;
                    int Stride = bmpData.Stride;
                    int DoubleStride = Stride * 2;
                    int Width = bmp.Width;
                    int Height = bmp.Height;
                    int stopAddress = (int)ptr + bmpData.Stride * bmpData.Height;

                    for (int y = 0; y < Height; ++y)
                        for (int x = 0; x < Width; ++x)
                        {
                            Pix = rnd.Next(0, 2);

                            if (Pix == 0) Pix = 0;
                            else if (Pix == 1) Pix = 255;

                            ptr[1 + Stride] = (byte)Pix;

                            ptr += 1;
                            TempPtr += 1;
                        }
                }

                bmp.UnlockBits(bmpData);
                TempBmp.UnlockBits(TempBmpData);
            }
        private void Add(Bitmap Noise_bm, Bitmap result_bm, int x, int y, float val)
        {
            x = 0;
            y = 0;
            // Создаем ColorMatrix, которая умножает
            // альфа-компонент на 0,5.
            ColorMatrix color_matrix = new ColorMatrix();
            color_matrix.Matrix33 = (float)val;

            // Создаем ImageAttributes, который использует ColorMatrix.
            ImageAttributes image_attributes = new ImageAttributes();
            image_attributes.SetColorMatrices(color_matrix, null);

            // Создаем пиксели того же цвета, что и
            // один в верхнем левом прозрачном.
            Noise_bm.MakeTransparent(Noise_bm.GetPixel(0, 0));

            // Нарисуем изображение с помощью ColorMatrix.
            using (Graphics gr = Graphics.FromImage(result_bm))
            {
                Rectangle rect = new Rectangle(x, y,
                    Noise_bm.Width, Noise_bm.Height);
                gr.DrawImage(Noise_bm, rect, 0, 0,
                    Noise_bm.Width, Noise_bm.Height,
                    GraphicsUnit.Pixel, image_attributes);
            }
        }
        private void Noise_Load(object sender, EventArgs e)
        {
            Input.Image = F.pictureBox1.Image;
            Result.Image = Input.Image;

            timer.Interval = 50;
            timer.Tick += new EventHandler(timer_Tick); //подписываемся на события Tick
        }

        private void RandNoise_Click(object sender, EventArgs e)
        {
            Bitmap input = new Bitmap(Input.Image);
            Generation(ref input);
            Rand.Image = input;
        }

        private void AddNoise_Scroll(object sender, EventArgs e)
        {
            Bitmap res = new Bitmap(Input.Image);
            Bitmap r = new Bitmap(Rand.Image);
            float clar = (float)AddNoise.Value / 100;
            Add(r, res, 0, 0, clar);
            Result.Image = res;
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            F.pictureBox2.Image = Result.Image;
            this.Close();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            Bitmap input = new Bitmap(Input.Image);
            Generation(ref input);
            Rand.Image = input;
        }

        private void Animation_Click(object sender, EventArgs e)
        {
            if (b == false)
            {
                timer.Start();
                b = true;
            }
        }

        private void Anim_Click(object sender, EventArgs e)
        {
            if (b == true)
            {
                timer.Stop();
                b = false;
            }
        }
    }
}
