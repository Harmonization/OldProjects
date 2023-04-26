using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MouseEvents;
using System.Drawing.Imaging;
using System.Threading;

namespace FlyPhoto
{
    public partial class Convert : Form
    {
        Form1 F1;
        public Convert(Form1 F1_)
        {
            F1 = F1_;
            InitializeComponent();
        }
        
        public static double Maximum(double a, double b, double c)
        {
            if ((a >= b) && (a >= c)) return a;
            else if ((b >= a) && (b >= c)) return b;
            else return c;
        }
        public static double Minimum(double a, double b, double c)
        {
            if ((a <= b) && (a <= c)) return a;
            else if ((b <= a) && (b <= c)) return b;
            else return c;
        }
        public double Limit(double a)
        {
            if (a > 255) a = 255;
            if (a < 0) a = 0;
            return a;
        }
        public static double[] RGBtoHSV(double r_, double g_, double b_)
        {
            double r = r_ / 255;
            double g = g_ / 255;
            double b = b_ / 255;

            double Cmax = Maximum(r, g, b);
            double Cmin = Minimum(r, g, b);

            double delta = Cmax - Cmin;

            double h;
            if (delta == 0) h = 0;
            else if (Cmax == r) h = 60 * (((g - b) / delta) % 6);
            else if (Cmax == g) h = 60 * ((b - r) / delta + 2);
            else h = 60 * ((r - g) / delta + 4);
            h = Math.Round(h);
            if (h < 0) h = 360 + h;

            double s;
            if (Cmax == 0) s = 0;
            else s = delta / Cmax;
            s = 100 * s;
            s = Math.Round(s, 1);

            double v = Cmax;
            v = 100 * v;
            v = Math.Round(v, 1);

            double[] Res = { h, s, v };

            return Res;
        }
        public static double[] HSVtoRGB(double h_, double s_, double v_)
        {
            double h = h_;
            double s = s_ / 100;
            double v = v_ / 100;

            double C = v * s;

            double x = C * (1 - Math.Abs((h / 60) % 2 - 1));

            double m = v - C;

            double r, g, b;
            if ((h >= 0) && (h < 60))
            {
                r = C;
                g = x;
                b = 0;
            }
            else if ((h >= 60) && (h < 120))
            {
                r = x;
                g = C;
                b = 0;
            }
            else if ((h >= 120) && (h < 180))
            {
                r = 0;
                g = C;
                b = x;
            }
            else if ((h >= 180) && (h < 240))
            {
                r = 0;
                g = x;
                b = C;
            }
            else if ((h >= 240) && (h < 300))
            {
                r = x;
                g = 0;
                b = C;
            }
            else
            {
                r = C;
                g = 0;
                b = x;
            }

            r = (r + m) * 255;
            g = (g + m) * 255;
            b = (b + m) * 255;

            r = Math.Round(r);
            g = Math.Round(g);
            b = Math.Round(b);

            double[] BGR = { r, g, b };

            return BGR;
        }
        public static Bitmap HSV_Convert(Bitmap Image, int num)
        {
            Bitmap NewBitmap = (Bitmap)Image.Clone();
            BitmapData data = NewBitmap.LockBits(
             new Rectangle(0, 0, NewBitmap.Width, NewBitmap.Height),
             ImageLockMode.ReadWrite,
             NewBitmap.PixelFormat);
            int Height = NewBitmap.Height;
            int Width = NewBitmap.Width;

            unsafe
            {
                for (int y = 0; y < Height; ++y)
                {
                    byte* row = (byte*)data.Scan0 + (y * data.Stride);
                    int columnOffset = 0;
                    for (int x = 0; x < Width; ++x)
                    {
                        byte B = row[columnOffset];
                        byte G = row[columnOffset + 1];
                        byte R = row[columnOffset + 2];

                        double[] Con = RGBtoHSV(R, G, B);

                        double[] Con1;

                        if (num == 1)
                        {
                            Con1 = HSVtoRGB(Con[0], 100, 100);
                        }
                        else if (num == 2)
                            Con1 = HSVtoRGB(360, Con[1], 100);
                        else
                            Con1 = HSVtoRGB(360, 100, Con[2]);

                        
                        row[columnOffset] = (byte)Con1[2];
                        row[columnOffset + 1] = (byte)Con1[1];
                        row[columnOffset + 2] = (byte)Con1[0];

                        columnOffset += 4;
                    }
                }
            }

            NewBitmap.UnlockBits(data);

            return NewBitmap;
        }
        public static Bitmap H_Scroll(Bitmap Image, int val)
        {
            Bitmap NewBitmap = (Bitmap)Image.Clone();
            BitmapData data = NewBitmap.LockBits(
             new Rectangle(0, 0, NewBitmap.Width, NewBitmap.Height),
             ImageLockMode.ReadWrite,
             NewBitmap.PixelFormat);
            int Height = NewBitmap.Height;
            int Width = NewBitmap.Width;

            unsafe
            {
                for (int y = 0; y < Height; ++y)
                {
                    byte* row = (byte*)data.Scan0 + (y * data.Stride);
                    int columnOffset = 0;
                    for (int x = 0; x < Width; ++x)
                    {
                        byte B = row[columnOffset];
                        byte G = row[columnOffset + 1];
                        byte R = row[columnOffset + 2];

                        double[] Con = RGBtoHSV(R, G, B);

                        double[] Con1;
                        
                        Con1 = HSVtoRGB(val, Con[1], Con[2]);

                        row[columnOffset] = (byte)Con1[0];
                        row[columnOffset + 1] = (byte)Con1[1];
                        row[columnOffset + 2] = (byte)Con1[2];

                        columnOffset += 4;
                    }
                }
            }

            NewBitmap.UnlockBits(data);

            return NewBitmap;
        }
        public static Bitmap S_Scroll(Bitmap Image, int val)
        {
            Bitmap NewBitmap = (Bitmap)Image.Clone();
            BitmapData data = NewBitmap.LockBits(
             new Rectangle(0, 0, NewBitmap.Width, NewBitmap.Height),
             ImageLockMode.ReadWrite,
             NewBitmap.PixelFormat);
            int Height = NewBitmap.Height;
            int Width = NewBitmap.Width;

            unsafe
            {
                for (int y = 0; y < Height; ++y)
                {
                    byte* row = (byte*)data.Scan0 + (y * data.Stride);
                    int columnOffset = 0;
                    for (int x = 0; x < Width; ++x)
                    {
                        byte B = row[columnOffset];
                        byte G = row[columnOffset + 1];
                        byte R = row[columnOffset + 2];

                        double[] Con = RGBtoHSV(R, G, B);

                        double[] Con1;

                        Con1 = HSVtoRGB(Con[0], val, Con[2]);

                        row[columnOffset] = (byte)Con1[0];
                        row[columnOffset + 1] = (byte)Con1[1];
                        row[columnOffset + 2] = (byte)Con1[2];

                        columnOffset += 4;
                    }
                }
            }

            NewBitmap.UnlockBits(data);

            return NewBitmap;
        }
        public static Bitmap V_Scroll(Bitmap Image, int val)
        {
            Bitmap NewBitmap = (Bitmap)Image.Clone();
            BitmapData data = NewBitmap.LockBits(
             new Rectangle(0, 0, NewBitmap.Width, NewBitmap.Height),
             ImageLockMode.ReadWrite,
             NewBitmap.PixelFormat);
            int Height = NewBitmap.Height;
            int Width = NewBitmap.Width;

            unsafe
            {
                for (int y = 0; y < Height; ++y)
                {
                    byte* row = (byte*)data.Scan0 + (y * data.Stride);
                    int columnOffset = 0;
                    for (int x = 0; x < Width; ++x)
                    {
                        byte B = row[columnOffset];
                        byte G = row[columnOffset + 1];
                        byte R = row[columnOffset + 2];

                        double[] Con = RGBtoHSV(R, G, B);

                        double[] Con1;

                        Con1 = HSVtoRGB(Con[0], Con[1], val);

                        row[columnOffset] = (byte)Con1[0];
                        row[columnOffset + 1] = (byte)Con1[1];
                        row[columnOffset + 2] = (byte)Con1[2];

                        columnOffset += 4;
                    }
                }
            }

            NewBitmap.UnlockBits(data);

            return NewBitmap;
        }

        private void Convert_Load(object sender, EventArgs e)
        {
            pictureBox2.Image = F1.pictureBox1.Image;
            panel1.Hide();
            pictureBox5.Image = pictureBox2.Image;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (MEvents.GetKeyStatus(MButtons.LEFT))
            {

                Bitmap bmp = new Bitmap(ClientSize.Width, ClientSize.Height);
                DrawToBitmap(bmp, new Rectangle(ClientRectangle.Location, ClientSize));
                Color c = bmp.GetPixel(MEvents.CursorPostionX, MEvents.CursorPostionY);
                Red.Text = System.Convert.ToString(c.R);
                Green.Text = System.Convert.ToString(c.G);
                Blue.Text = System.Convert.ToString(c.B);

                pictureBox1.BackColor = c;

                //пересчет
                double r = (double)c.R / 255;
                double g = (double)c.G / 255;
                double b = (double)c.B / 255;

                double Cmax = Maximum(r, g, b);
                double Cmin = Minimum(r, g, b);

                double delta = Cmax - Cmin;

                double h;
                if (delta == 0) h = 0;
                else if (Cmax == r) h = 60 * (((g - b) / delta) % 6);
                else if (Cmax == g) h = 60 * ((b - r) / delta + 2);
                else  h = 60 * ((r - g) / delta + 4);
                h = Math.Round(h);
                if (h < 0) h = 360 + h;

                double s;
                if (Cmax == 0) s = 0;
                else s = delta / Cmax;
                s = 100 * s;
                s = Math.Round(s, 1);

                double v = Cmax;
                v = 100 * v;
                v = Math.Round(v, 1);

                Hue.Text = System.Convert.ToString(h);
                Saturated.Text = System.Convert.ToString(s);
                Value.Text = System.Convert.ToString(v);

            }
        }

        private void Right_Click(object sender, EventArgs e)
        {
            
            double r_ = System.Convert.ToDouble(Red.Text);
            double g_ = System.Convert.ToDouble(Green.Text);
            double b_ = System.Convert.ToDouble(Blue.Text);
            r_ = Limit(r_);
            g_ = Limit(g_);
            b_ = Limit(b_);
            Red.Text = System.Convert.ToString(r_);
            Green.Text = System.Convert.ToString(g_);
            Blue.Text = System.Convert.ToString(b_);

            pictureBox1.BackColor = Color.FromArgb((int)r_, (int)g_, (int)b_);

            

            double r = System.Convert.ToDouble(Red.Text);
            double g = System.Convert.ToDouble(Green.Text);
            double b  = System.Convert.ToDouble(Blue.Text);

            double[] hsb = RGBtoHSV(r, g, b);
            

            Hue.Text = System.Convert.ToString(hsb[0]);
            Saturated.Text = System.Convert.ToString(hsb[1]);
            Value.Text = System.Convert.ToString(hsb[2]);

        }

        private void Left_Click(object sender, EventArgs e)
        {
            double h = System.Convert.ToDouble(Hue.Text);
            double s = System.Convert.ToDouble(Saturated.Text);
            double v = System.Convert.ToDouble(Value.Text);

            double[] BGR = HSVtoRGB(h, s, v);

            Red.Text = System.Convert.ToString(BGR[0]);
            Green.Text = System.Convert.ToString(BGR[1]);
            Blue.Text = System.Convert.ToString(BGR[2]);

            pictureBox1.BackColor = Color.FromArgb((int)BGR[0], (int)BGR[1], (int)BGR[2]);
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Show();
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void Ok1_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void RGB_Click(object sender, EventArgs e)
        {
            Bitmap input = new Bitmap(pictureBox2.Image);

            Bitmap output1 = new Bitmap(input.Width, input.Height);
            Bitmap output2 = new Bitmap(input.Width, input.Height);
            Bitmap output3 = new Bitmap(input.Width, input.Height);

            Graphics g1 = Graphics.FromImage(output1);
            Graphics g2 = Graphics.FromImage(output2);
            Graphics g3 = Graphics.FromImage(output3);

            ImageAttributes ia1 = new ImageAttributes();
            ImageAttributes ia2 = new ImageAttributes();
            ImageAttributes ia3 = new ImageAttributes();

            ColorMatrix cm1 = new ColorMatrix(new float[][] { new float[] { 1f, 0f, 0f, 0f, 0f }, new float[] { 0f, 0f, 0f, 0f, 0f }, new float[] { 0f, 0f, 0f, 0f, 0f }, new float[] { 0f, 0f, 0f, 1f, 0f }, new float[] { 0f, 0f, 0f, 0f, 0f } });
            ColorMatrix cm2 = new ColorMatrix(new float[][] { new float[] { 0f, 0f, 0f, 0f, 0f }, new float[] { 0f, 1f, 0f, 0f, 0f }, new float[] { 0f, 0f, 0f, 0f, 0f }, new float[] { 0f, 0f, 0f, 1f, 0f }, new float[] { 0f, 0f, 0f, 0f, 0f } });
            ColorMatrix cm3 = new ColorMatrix(new float[][] { new float[] { 0f, 0f, 0f, 0f, 0f }, new float[] { 0f, 0f, 0f, 0f, 0f }, new float[] { 0f, 0f, 1f, 0f, 0f }, new float[] { 0f, 0f, 0f, 1f, 0f }, new float[] { 0f, 0f, 0f, 0f, 0f } });

            ia1.SetColorMatrix(cm1);
            ia2.SetColorMatrix(cm2);
            ia3.SetColorMatrix(cm3);

            g1.DrawImage(input, new Rectangle(0, 0, input.Width, input.Height), 0, 0, input.Width, input.Height, GraphicsUnit.Pixel, ia1);
            g2.DrawImage(input, new Rectangle(0, 0, input.Width, input.Height), 0, 0, input.Width, input.Height, GraphicsUnit.Pixel, ia2);
            g3.DrawImage(input, new Rectangle(0, 0, input.Width, input.Height), 0, 0, input.Width, input.Height, GraphicsUnit.Pixel, ia3);

            g1.Dispose();
            g2.Dispose();
            g3.Dispose();

            ia1.Dispose();
            ia2.Dispose();
            ia3.Dispose();

            RGB1.Image = output1;
            RGB2.Image = output2;
            RGB3.Image = output3;
        }

        private void Ok2_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void HSV_Click(object sender, EventArgs e)
        {
            Bitmap input = new Bitmap(pictureBox2.Image);

            Bitmap output1 = HSV_Convert(input, 1);
            Bitmap output2 = HSV_Convert(input, 2);
            Bitmap output3 = HSV_Convert(input, 3);

            HSV1.Image = output1;
            HSV2.Image = output2;
            HSV3.Image = output3;
        }

        private void H_Bar_Scroll(object sender, EventArgs e)
        {
            int Value = H_Bar.Value;

            Bitmap input = new Bitmap(pictureBox5.Image);
            Bitmap output = H_Scroll(input, Value);
            pictureBox5.Image = output;

        }

        private void S_Bar_Scroll(object sender, EventArgs e)
        {
            int Value = S_Bar.Value;

            Bitmap input = new Bitmap(pictureBox5.Image);
            Bitmap output = S_Scroll(input, Value);
            pictureBox5.Image = output;
        }

        private void V_Bar_Scroll(object sender, EventArgs e)
        {
            int Value = V_Bar.Value;

            Bitmap input = new Bitmap(pictureBox5.Image);
            Bitmap output = V_Scroll(input, Value);
            pictureBox5.Image = output;
        }

        private void Original_Click(object sender, EventArgs e)
        {
            pictureBox5.Image = pictureBox2.Image;
        }

        private void Ok3_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            F1.pictureBox2.Image = pictureBox5.Image;
        }
    }
}
