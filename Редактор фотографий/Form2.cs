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
    public partial class Form2 : Form
    {
        Form1 F1;
        public Form2(Form1 F1_)
        {
            F1 = F1_;
            InitializeComponent();

        }
        public Bitmap input;
        class ConvolutionMatrix
        {
            public ConvolutionMatrix()
            {
                Pixel = 1;
                Factor = 1;
            }

            public void Apply(int Val)
            {
                TopLeft = TopMid = TopRight = MidLeft = MidRight = BottomLeft = BottomMid = BottomRight = Pixel = Val;
            }

            public double TopLeft { get; set; }

            public double TopMid { get; set; }

            public double TopRight { get; set; }

            public double MidLeft { get; set; }

            public double MidRight { get; set; }

            public double BottomLeft { get; set; }

            public double BottomMid { get; set; }

            public double BottomRight { get; set; }

            public double Pixel { get; set; }

            public double Factor { get; set; }

            public double Offset { get; set; }
        }
        class Convolution
        {
            public void Convolution3x3(ref Bitmap bmp)
            {
                double Factor = Matrix.Factor;

                if (Factor == 0) return;

                double TopLeft = Matrix.TopLeft;
                double TopMid = Matrix.TopMid;
                double TopRight = Matrix.TopRight;
                double MidLeft = Matrix.MidLeft;
                double MidRight = Matrix.MidRight;
                double BottomLeft = Matrix.BottomLeft;
                double BottomMid = Matrix.BottomMid;
                double BottomRight = Matrix.BottomRight;
                double Pixel = Matrix.Pixel;
                double Offset = Matrix.Offset;

                Bitmap TempBmp = (Bitmap)bmp.Clone();

                BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                BitmapData TempBmpData = TempBmp.LockBits(new Rectangle(0, 0, TempBmp.Width, TempBmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

                unsafe
                {
                    byte* ptr = (byte*)bmpData.Scan0.ToPointer();
                    byte* TempPtr = (byte*)TempBmpData.Scan0.ToPointer();

                    double Pix = 0;
                    int Stride = bmpData.Stride;
                    int DoubleStride = Stride * 2;
                    int Width = bmp.Width - 2;
                    int Height = bmp.Height - 2;
                    int stopAddress = (int)ptr + bmpData.Stride * bmpData.Height;

                    for (int y = 0; y < Height; ++y)
                        for (int x = 0; x < Width; ++x)
                        {
                            Pix = (((((TempPtr[2] * TopLeft) + (TempPtr[5] * TopMid) + (TempPtr[8] * TopRight)) +
                              ((TempPtr[2 + Stride] * MidLeft) + (TempPtr[5 + Stride] * Pixel) + (TempPtr[8 + Stride] * MidRight)) +
                              ((TempPtr[2 + DoubleStride] * BottomLeft) + (TempPtr[5 + DoubleStride] * BottomMid) + (TempPtr[8 + DoubleStride] * BottomRight))) / Factor) + Offset);

                            if (Pix < 0) Pix = 0;
                            else if (Pix > 255) Pix = 255;

                            ptr[5 + Stride] = (byte)Pix;

                            Pix = (((((TempPtr[1] * TopLeft) + (TempPtr[4] * TopMid) + (TempPtr[7] * TopRight)) +
                                  ((TempPtr[1 + Stride] * MidLeft) + (TempPtr[4 + Stride] * Pixel) + (TempPtr[7 + Stride] * MidRight)) +
                                  ((TempPtr[1 + DoubleStride] * BottomLeft) + (TempPtr[4 + DoubleStride] * BottomMid) + (TempPtr[7 + DoubleStride] * BottomRight))) / Factor) + Offset);

                            if (Pix < 0) Pix = 0;
                            else if (Pix > 255) Pix = 255;

                            ptr[4 + Stride] = (byte)Pix;

                            Pix = (((((TempPtr[0] * TopLeft) + (TempPtr[3] * TopMid) + (TempPtr[6] * TopRight)) +
                                  ((TempPtr[0 + Stride] * MidLeft) + (TempPtr[3 + Stride] * Pixel) + (TempPtr[6 + Stride] * MidRight)) +
                                  ((TempPtr[0 + DoubleStride] * BottomLeft) + (TempPtr[3 + DoubleStride] * BottomMid) + (TempPtr[6 + DoubleStride] * BottomRight))) / Factor) + Offset);

                            if (Pix < 0) Pix = 0;
                            else if (Pix > 255) Pix = 255;

                            ptr[3 + Stride] = (byte)Pix;

                            ptr += 3;
                            TempPtr += 3;
                        }
                }

                bmp.UnlockBits(bmpData);
                TempBmp.UnlockBits(TempBmpData);
            }

            public ConvolutionMatrix Matrix { get; set; }
        }
        public static void Create3_F(ref Bitmap bmp, double a11, double a12, double a13, double a21, double pixel, double a23, double a31, double a32, double a33, double factor, double offset)
        {
            ConvolutionMatrix m = new ConvolutionMatrix();
            m.TopLeft = a11;
            m.TopMid = a12;
            m.TopRight = a13;
            m.MidLeft = a21;
            m.Pixel = pixel;
            m.MidRight = a23;
            m.BottomLeft = a31;
            m.BottomMid = a32;
            m.BottomRight = a33;
            m.Factor = factor;
            m.Offset = offset;

            Convolution C = new Convolution();
            C.Matrix = m;
            C.Convolution3x3(ref bmp);
        }


        private void Form2_Load(object sender, EventArgs e)
        {
        }

        public void Create3_Click(object sender, EventArgs e)
        {

            if (F1.radioButton1.Checked == true)
                input = new Bitmap(F1.pictureBox1.Image);
            else input = new Bitmap(F1.pictureBox2.Image);

            double a11 = System.Convert.ToDouble(textBox1.Text);
            double a12 = System.Convert.ToDouble(textBox2.Text);
            double a13 = System.Convert.ToDouble(textBox3.Text);
            double a21 = System.Convert.ToDouble(textBox4.Text);
            double a22 = System.Convert.ToDouble(textBox5.Text);
            double a23 = System.Convert.ToDouble(textBox6.Text);
            double a31 = System.Convert.ToDouble(textBox7.Text);
            double a32 = System.Convert.ToDouble(textBox8.Text);
            double a33 = System.Convert.ToDouble(textBox9.Text);
            double factor = System.Convert.ToDouble(textBox10.Text);
            double offset = System.Convert.ToDouble(textBox11.Text);
            if (factor == 0) return;
            Create3_F(ref input, a11, a12, a13, a21, a22, a23, a31, a32, a33, factor, offset);
            
            F1.pictureBox2.Image = input;
        }
    }
}
