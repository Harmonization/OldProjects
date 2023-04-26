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
using MouseEvents;
using System.Threading;
namespace FlyPhoto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Медленные 
        public Bitmap Photo, DopPhoto, SemiPhoto;
        public Bitmap Water;
        public bool b1 = true, b2 = true;
        public bool Rectangle_ = false, Threangle_ = false; 
        public Bitmap Binarization02(Bitmap src, int treshold = 150)
        {
            
            Bitmap dst = new Bitmap(src.Width, src.Height);

            for (int i = 0; i < src.Width; i++)
            {
                for (int j = 0; j < src.Height; j++)
                {
                    Color color = src.GetPixel(i, j);
                    int average = (int)(color.R + color.B + color.G) / 3;
                    dst.SetPixel(i, j, average < treshold ? Color.Black : Color.White);
                }
            }

            return dst;
        }
        public Bitmap Median(Bitmap input)
        {
            Bitmap output = new Bitmap(input.Width, input.Height);

            for (int i = 1; i < input.Width - 1; i++)
            {
                for (int j = 1; j < input.Height - 1; j++)
                {
                    Color a11 = input.GetPixel(i - 1, j - 1); Color a12 = input.GetPixel(i, j - 1); Color a13 = input.GetPixel(i + 1, j - 1);
                    Color a21 = input.GetPixel(i - 1, j); Color a22 = input.GetPixel(i, j); Color a23 = input.GetPixel(i + 1, j);
                    Color a31 = input.GetPixel(i - 1, j + 1); Color a32 = input.GetPixel(i, j + 1); Color a33 = input.GetPixel(i + 1, j + 1);


                    byte []red = { a11.R, a12.R, a13.R, a21.R, a22.R, a23.R, a31.R, a32.R, a33.R };
                    byte[] green = { a11.G, a12.G, a13.G, a21.G, a22.G, a23.G, a31.G, a32.G, a33.G };
                    byte[] blue = { a11.B, a12.B, a13.B, a21.B, a22.B, a23.B, a31.B, a32.B, a33.B };
                    Array.Sort<byte>(red);
                    Array.Sort<byte>(green);
                    Array.Sort<byte>(blue);
                    byte r = red[5];
                    byte g = green[5];
                    byte b = blue[5];
                    Color next = Color.FromArgb((byte)r, (byte)g, (byte)b);
                    output.SetPixel(i, j, next);
                }
            }

            return output;
        }
        public Bitmap BoxFilter(Bitmap input)
        {
            Bitmap output = new Bitmap(input.Width, input.Height);

            for(int i = 1; i < input.Width - 1; i++)
            {
                for(int j = 1; j < input.Height - 1; j++)
                {
                    Color a11 = input.GetPixel(i - 1, j - 1); Color a12 = input.GetPixel(i, j - 1); Color a13 = input.GetPixel(i + 1, j - 1);
                    Color a21 = input.GetPixel(i - 1, j); Color a22 = input.GetPixel(i, j); Color a23 = input.GetPixel(i + 1, j);
                    Color a31 = input.GetPixel(i - 1, j + 1); Color a32 = input.GetPixel(i, j + 1); Color a33 = input.GetPixel(i + 1, j + 1);
                    float red = (a11.R + a12.R + a13.R + a21.R + a22.R + a23.R + a31.R + a32.R + a33.R) / 9;
                    float green = (a11.G + a12.G + a13.G + a21.G + a22.G + a23.G + a31.G + a32.G + a33.G) / 9;
                    float blue = (a11.B + a12.B + a13.B + a21.B + a22.B + a23.B + a31.B + a32.B + a33.B) / 9;
                    UInt32 newPixel = 0xFF000000 | ((UInt32)red << 16) | ((UInt32)green << 8) | ((UInt32)blue);
                    output.SetPixel(i, j, Color.FromArgb((int)newPixel));
                }
            }

            return output;
        }
        public Bitmap GaussFilter(Bitmap input)
        {
            Bitmap output = new Bitmap(input.Width, input.Height);
            byte[,] a = { { 2, 4, 5, 4, 2 }, { 4, 9, 12, 9, 4 }, { 5, 12, 15, 12, 5 }, { 4, 9, 12, 9, 4 }, { 2, 4, 5, 4, 2 } };
            for (int l = 2; l < input.Width - 2; l++)
            {
                for (int k = 2; k < input.Height - 2; k++)
                {
                    float red = 0;
                    float green = 0;
                    float blue = 0;
                    for(int i = 0; i < 5; i++)
                        for(int j = 0; j < 5; j++)
                        {
                            red += a[i, j] * input.GetPixel(l - 2 + i, k - 2 + j).R / 159;
                            green += a[i, j] * input.GetPixel(l - 2 + i, k - 2 + j).G / 159;
                            blue += a[i, j] * input.GetPixel(l - 2 + i, k - 2 + j).B / 159;
                        }
                    Color next = Color.FromArgb((byte)red, (byte)green, (byte)blue);
                    output.SetPixel(l, k, next);
                }
            }

            return output;
        }
        public Bitmap Sobel_Operator(Bitmap input)
        {
            Bitmap output = new Bitmap(input.Width, input.Height);

            for (int i = 1; i < input.Width - 1; i++)
            {
                for (int j = 1; j < input.Height - 1; j++)
                {

                    Color a1 = input.GetPixel(i - 1, j - 1); Color a2 = input.GetPixel(i, j - 1); Color a3 = input.GetPixel(i + 1, j - 1);
                    Color a8 = input.GetPixel(i - 1, j); Color a9 = input.GetPixel(i, j); Color a4 = input.GetPixel(i + 1, j);
                    Color a7 = input.GetPixel(i - 1, j + 1); Color a6 = input.GetPixel(i, j + 1); Color a5 = input.GetPixel(i + 1, j + 1);

                        var z1 = (int)(a1.R + a1.G + a1.B) / 3; var z2 = (int)(a2.R + a2.G + a2.B) / 3; var z3 = (int)(a3.R + a3.G + a3.B) / 3;
                        var z4 = (int)(a4.R + a4.G + a4.B) / 3; var z5 = (int)(a5.R + a5.G + a5.B) / 3; var z6 = (int)(a6.R + a6.G + a6.B) / 3;
                        var z7 = (int)(a7.R + a7.G + a7.B) / 3; var z8 = (int)(a8.R + a8.G + a8.B) / 3; var z9 = (int)(a9.R + a9.G + a9.B) / 3;

                        var Gx = (z7 + 2 * z6 + z5 - z1 - 2 * z2 - z3);

                        var Gy = (z3 + 2 * z4 + z5 - z1 - 2 * z8 - z7);

                        var G = (int)Math.Sqrt(Math.Pow(Gx, 2) + Math.Pow(Gy, 2));

                        if (G > 255) G = 255;

                        Color next = Color.FromArgb(G, G, G);
                        output.SetPixel(i, j, next);
                }
            }

            return output;
        }
        public Bitmap Previtt_Operator(Bitmap input)
        {
            Bitmap output = new Bitmap(input.Width, input.Height);

            for (int i = 1; i < input.Width - 1; i++)
            {
                for (int j = 1; j < input.Height - 1; j++)
                {

                    Color a1 = input.GetPixel(i - 1, j - 1); Color a2 = input.GetPixel(i, j - 1); Color a3 = input.GetPixel(i + 1, j - 1);
                    Color a4 = input.GetPixel(i - 1, j); Color a5 = input.GetPixel(i, j); Color a6 = input.GetPixel(i + 1, j);
                    Color a7 = input.GetPixel(i - 1, j + 1); Color a8 = input.GetPixel(i, j + 1); Color a9 = input.GetPixel(i + 1, j + 1);

                    var z1 = (int)(a1.R + a1.G + a1.B) / 3; var z2 = (int)(a2.R + a2.G + a2.B) / 3; var z3 = (int)(a3.R + a3.G + a3.B) / 3;
                    var z4 = (int)(a4.R + a4.G + a4.B) / 3; var z5 = (int)(a5.R + a5.G + a5.B) / 3; var z6 = (int)(a6.R + a6.G + a6.B) / 3;
                    var z7 = (int)(a7.R + a7.G + a7.B) / 3; var z8 = (int)(a8.R + a8.G + a8.B) / 3; var z9 = (int)(a9.R + a9.G + a9.B) / 3;

                    var Gx = (z7 + z8 + z9 - z1 - z2 - z3);

                    var Gy = (z3 + z6 + z9 - z1 - z4 - z7);

                    var G = (int)Math.Sqrt(Math.Pow(Gx, 2) + Math.Pow(Gy, 2));

                    if (G > 255) G = 255;

                    Color next = Color.FromArgb(G, G, G);
                    output.SetPixel(i, j, next);
                }
            }

            return output;
        }
        public Bitmap Roberts_Operator(Bitmap input)
        {
            Bitmap output = new Bitmap(input.Width, input.Height);

            for (int i = 1; i < input.Width - 1; i++)
            {
                for (int j = 1; j < input.Height - 1; j++)
                {

                    Color a5 = input.GetPixel(i, j); Color a6 = input.GetPixel(i + 1, j);
                    Color a8 = input.GetPixel(i, j + 1); Color a9 = input.GetPixel(i + 1, j + 1);

                    var z5 = (int)(a5.R + a5.G + a5.B) / 3; var z6 = (int)(a6.R + a6.G + a6.B) / 3;
                    var z8 = (int)(a8.R + a8.G + a8.B) / 3; var z9 = (int)(a9.R + a9.G + a9.B) / 3;

                    var Gx = (z9 - z5);

                    var Gy = (z8 - z6);

                    var G = (int)Math.Sqrt(Math.Pow(Gx, 2) + Math.Pow(Gy, 2));

                    if (G > 255) G = 255;

                    Color next = Color.FromArgb(G, G, G);
                    output.SetPixel(i, j, next);
                }
            }

            return output;
        }  
        public Bitmap Erosion(Bitmap input)
        {
            Bitmap output = new Bitmap(input.Width, input.Height);

            for (int i = 0; i < input.Width; i++) output.SetPixel(i, 0, Color.White);
            for (int j = 0; j < input.Height; j++) output.SetPixel(0, j, Color.White);
            for (int i = 0; i < input.Width; i++) input.SetPixel(i, 0, Color.White);
            for (int j = 0; j < input.Height; j++) input.SetPixel(0, j, Color.White);
            for (int i = 1; i < input.Width - 1; i++)
            {
                for (int j = 1; j < input.Height - 1; j++)
                {

                    Color a1 = input.GetPixel(i - 1, j - 1); Color a2 = input.GetPixel(i, j - 1); Color a3 = input.GetPixel(i + 1, j - 1);
                    Color a4 = input.GetPixel(i - 1, j); Color a5 = input.GetPixel(i, j); Color a6 = input.GetPixel(i + 1, j);
                    Color a7 = input.GetPixel(i - 1, j + 1); Color a8 = input.GetPixel(i, j + 1); Color a9 = input.GetPixel(i + 1, j + 1);

                    Color[,] a = { { a1, a2, a3 }, { a4, a5, a6 }, { a7, a8, a9} };
                    int n = 0;
                   for (int k = 0; k < 3; k++)
                    {
                        for (int l = 0; l < 3; l++)
                        {
                            if ((a[k, l].R == 0) && (a[k, l].G == 0) && (a[k, l].B == 0)) n++;
                        }
                    }
                    if (n == 9)
                    {
                        Color next = Color.FromArgb(0, 0, 0);
                        output.SetPixel(i, j, next);
                    }
                    else
                    {
                        Color next = Color.FromArgb(255, 255, 255);
                        output.SetPixel(i, j, next);
                    }
                    
                }
            }
            
            return output;
        }
        public Bitmap Dilatation(Bitmap input)
        {
            Bitmap output = new Bitmap(input.Width, input.Height);

            for (int i = 1; i < input.Width - 1; i++)
            {
                for (int j = 1; j < input.Height - 1; j++)
                {
                    Color a = input.GetPixel(i, j);

                    if ((a.R == 0) && (a.G == 0) && (a.B == 0))
                    {
                        output.SetPixel(i - 1, j - 1, a); output.SetPixel(i, j - 1, a); output.SetPixel(i + 1, j - 1, a);
                        output.SetPixel(i - 1, j, a); output.SetPixel(i, j, a); output.SetPixel(i + 1, j, a);
                        output.SetPixel(i - 1, j + 1, a); output.SetPixel(i, j + 1, a); output.SetPixel(i + 1, j + 1, a);
                    }
                    else
                    {
                        if ((input.GetPixel(i - 1, j).R != 0) && (input.GetPixel(i, j - 1).R != 0) && (input.GetPixel(i - 1, j - 1).R != 0))
                        output.SetPixel(i, j, Color.White);
                    }
                }
            }

            return output;
        }
        public Bitmap Difference_WB(Bitmap input, Bitmap open)
        {
            Bitmap output = new Bitmap(input.Width, input.Height);

            for(int i = 0; i < input.Width; i++)
            {
                for(int j = 0; j < input.Height; j++)
                {
                    Color a = input.GetPixel(i, j);
                    Color b = open.GetPixel(i, j);

                    Color c;

                    if (a == b) c = Color.Black;
                    else c = Color.White;

                    output.SetPixel(i, j, c);
                }
            }
            return output;
        }
        public Bitmap Difference_BW(Bitmap input, Bitmap open)
        {
            Bitmap output = new Bitmap(input.Width, input.Height);

            for (int i = 0; i < input.Width; i++)
            {
                for (int j = 0; j < input.Height; j++)
                {
                    Color a = input.GetPixel(i, j);
                    Color b = open.GetPixel(i, j);

                    Color c;

                    if (a == b) c = Color.White;
                    else c = Color.Black;

                    output.SetPixel(i, j, c);
                }
            }
            return output;
        }
        public Bitmap Selection(Bitmap input)
        {
            Bitmap output = new Bitmap(input.Width, input.Height);

            for (int i = 0; i < input.Width; i++) output.SetPixel(i, 0, Color.White);
            for (int j = 0; j < input.Height; j++) output.SetPixel(0, j, Color.White);
            for (int i = 0; i < input.Width; i++) input.SetPixel(i, 0, Color.White);
            for (int j = 0; j < input.Height; j++) input.SetPixel(0, j, Color.White);
            for (int i = 1; i < input.Width - 1; i++)
            {
                for (int j = 1; j < input.Height - 1; j++)
                {

                                                         Color a2 = input.GetPixel(i, j - 1); 
                    Color a4 = input.GetPixel(i - 1, j); Color a5 = input.GetPixel(i, j); Color a6 = input.GetPixel(i + 1, j);
                                                         Color a8 = input.GetPixel(i, j + 1); 
                    Color[] a = { a2, a4, a5, a6, a8 };
                    int n = 0;
                    for (int k = 0; k < 5; k++)
                    {
                        if ((a[k].R == 0) && (a[k].G == 0) && (a[k].B == 0)) n++;
                    }
                    if (n == 5)
                    {
                        Color next = Color.FromArgb(0, 0, 0);
                        output.SetPixel(i, j, next);
                    }
                    else
                    {
                        Color next = Color.FromArgb(255, 255, 255);
                        output.SetPixel(i, j, next);
                    }

                }
            }

            return output;
        }
        // 
        public Bitmap Inverse(Bitmap input)
        {
            Bitmap output = new Bitmap(input.Width, input.Height);

            Graphics clone = Graphics.FromImage(output);

            ImageAttributes cat = new ImageAttributes();

            ColorMatrix gray = new ColorMatrix(new float[][] { new float[] { -1f, 0f, 0f, 0f, 0f }, new float[] { 0f, -1f, 0f, 0f, 0f }, new float[] { 0f, 0f, -1f, 0f, 0f }, new float[] { 0f, 0f, 0f, 1f, 0f }, new float[] { 1f, 1f, 1f, 0f, 1f } });

            cat.SetColorMatrix(gray);

            clone.DrawImage(input, new Rectangle(0, 0, input.Width, input.Height), 0, 0, input.Width, input.Height, GraphicsUnit.Pixel, cat);
            clone.Dispose();
            cat.Dispose();

            return output;
        }


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
        public static void ApplyGaussianBlur(ref Bitmap bmp, int Weight)
        {
            ConvolutionMatrix m = new ConvolutionMatrix();
            m.Apply(1);
            m.Pixel = Weight;
            m.TopMid = m.MidLeft = m.MidRight = m.BottomMid = 2;
            m.Factor = Weight + 12;

            Convolution C = new Convolution();
            C.Matrix = m;
            C.Convolution3x3(ref bmp);
        }
        public static void ApplyBoxBlur(ref Bitmap bmp)
        {
            ConvolutionMatrix m = new ConvolutionMatrix();
            m.Apply(1);
            m.Factor = 9;

            Convolution C = new Convolution();
            C.Matrix = m;
            C.Convolution3x3(ref bmp);
        }
        public static void Sharpen_F(ref Bitmap bmp)
        {
            ConvolutionMatrix m = new ConvolutionMatrix();
            m.Apply(-1);
            m.Pixel = 9;
            m.Factor = 1;

            Convolution C = new Convolution();
            C.Matrix = m;
            C.Convolution3x3(ref bmp);
        }
        public static void Excessive_F(ref Bitmap bmp)
        {
            ConvolutionMatrix m = new ConvolutionMatrix();
            m.Apply(1);
            m.Pixel = -7;
            m.Factor = 1;

            Convolution C = new Convolution();
            C.Matrix = m;
            C.Convolution3x3(ref bmp);
        }
        public static void Emboss_F(ref Bitmap bmp)
        {
            ConvolutionMatrix m = new ConvolutionMatrix();
            m.Apply(0);
            m.TopLeft = m.TopMid = m.MidLeft = -1;
            m.BottomMid = m.BottomRight = m.MidRight = 1;
            m.Factor = 1;
            m.Offset = 128;

            Convolution C = new Convolution();
            C.Matrix = m;
            C.Convolution3x3(ref bmp);
        }
        public static void Blur_F(ref Bitmap bmp)
        {
            ConvolutionMatrix m = new ConvolutionMatrix();
            m.Apply(1);
            m.TopLeft = m.TopRight = m.BottomLeft = m.BottomRight = 0;
            m.Factor = 5;

            Convolution C = new Convolution();
            C.Matrix = m;
            C.Convolution3x3(ref bmp);
        }
        public static void Find_Edges_F(ref Bitmap bmp)
        {
            ConvolutionMatrix m = new ConvolutionMatrix();
            m.Apply(-1);
            m.Pixel = 8;
            m.Factor = 1;

            Convolution C = new Convolution();
            C.Matrix = m;
            C.Convolution3x3(ref bmp);
        }
        
        public void Mediana(ref Bitmap bmp)
        {

            Bitmap TempBmp = (Bitmap)bmp.Clone();

            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData TempBmpData = TempBmp.LockBits(new Rectangle(0, 0, TempBmp.Width, TempBmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            unsafe
            {
                byte* ptr = (byte*)bmpData.Scan0.ToPointer();
                byte* TempPtr = (byte*)TempBmpData.Scan0.ToPointer();

                int Pix = 0;
                int Stride = bmpData.Stride;
                int DoubleStride = Stride * 2;
                int Width = bmp.Width - 2;
                int Height = bmp.Height - 2;

                for (int y = 0; y < Height; ++y)
                    for (int x = 0; x < Width; ++x)
                    {
                        byte[] Ptr3 = { TempPtr[2], TempPtr[5], TempPtr[8], TempPtr[2 + Stride], TempPtr[5 + Stride], TempPtr[8 + Stride], TempPtr[2 + DoubleStride], TempPtr[5 + DoubleStride], TempPtr[8 + DoubleStride] };

                        Array.Sort<Byte>(Ptr3);

                        Pix = Ptr3[5];

                        if (Pix < 0) Pix = 0;
                        else if (Pix > 255) Pix = 255;

                        ptr[5 + Stride] = (byte)Pix;

                        byte[] Ptr2 = { TempPtr[1], TempPtr[4], TempPtr[7], TempPtr[1 + Stride], TempPtr[4 + Stride], TempPtr[7 + Stride], TempPtr[1 + DoubleStride], TempPtr[4 + DoubleStride], TempPtr[7 + DoubleStride] };

                        Array.Sort<Byte>(Ptr2);

                        Pix = Ptr2[5];

                        if (Pix < 0) Pix = 0;
                        else if (Pix > 255) Pix = 255;

                        ptr[4 + Stride] = (byte)Pix;

                        byte[] Ptr1 = { TempPtr[0], TempPtr[3], TempPtr[6], TempPtr[0 + Stride], TempPtr[3 + Stride], TempPtr[6 + Stride], TempPtr[0 + DoubleStride], TempPtr[3 + DoubleStride], TempPtr[6 + DoubleStride] };

                        Array.Sort<Byte>(Ptr1);

                        Pix = Ptr1[5];

                        if (Pix < 0) Pix = 0;
                        else if (Pix > 255) Pix = 255;

                        ptr[3 + Stride] = (byte)Pix;

                        ptr += 3;
                        TempPtr += 3;
                    }

                bmp.UnlockBits(bmpData);
                TempBmp.UnlockBits(TempBmpData);
            }
        }
        public void Acidity(ref Bitmap bmp)
        {

            Bitmap TempBmp = (Bitmap)bmp.Clone();

            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format16bppRgb565);
            BitmapData TempBmpData = TempBmp.LockBits(new Rectangle(0, 0, TempBmp.Width, TempBmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format16bppRgb565);

            unsafe
            {
                byte* ptr = (byte*)bmpData.Scan0.ToPointer();
                byte* TempPtr = (byte*)TempBmpData.Scan0.ToPointer();

                int Pix = 0;
                int Stride = bmpData.Stride;
                int DoubleStride = Stride * 2;
                int Width = bmp.Width - 2;
                int Height = bmp.Height - 2;

                for (int y = 0; y < Height; ++y)
                    for (int x = 0; x < Width; ++x)
                    {
                        byte[] Ptr3 = { TempPtr[2], TempPtr[5], TempPtr[8], TempPtr[2 + Stride], TempPtr[5 + Stride], TempPtr[8 + Stride], TempPtr[2 + DoubleStride], TempPtr[5 + DoubleStride], TempPtr[8 + DoubleStride] };

                        Array.Sort<Byte>(Ptr3);

                        Pix = Ptr3[5];

                        if (Pix < 0) Pix = 0;
                        else if (Pix > 255) Pix = 255;

                        ptr[5 + Stride] = (byte)Pix;

                        byte[] Ptr2 = { TempPtr[1], TempPtr[4], TempPtr[7], TempPtr[1 + Stride], TempPtr[4 + Stride], TempPtr[7 + Stride], TempPtr[1 + DoubleStride], TempPtr[4 + DoubleStride], TempPtr[7 + DoubleStride] };

                        Array.Sort<Byte>(Ptr2);

                        Pix = Ptr2[5];

                        ptr[4 + Stride] = (byte)Pix;

                        byte[] Ptr1 = { TempPtr[0], TempPtr[3], TempPtr[6], TempPtr[0 + Stride], TempPtr[3 + Stride], TempPtr[6 + Stride], TempPtr[0 + DoubleStride], TempPtr[3 + DoubleStride], TempPtr[6 + DoubleStride] };

                        Array.Sort<Byte>(Ptr1);

                        Pix = Ptr1[5];

                        if (Pix < 0) Pix = 0;
                        else if (Pix > 255) Pix = 255;

                        ptr[3 + Stride] = (byte)Pix;

                        ptr += 2;
                        TempPtr += 2;
                    }

                bmp.UnlockBits(bmpData);
                TempBmp.UnlockBits(TempBmpData);
            }
        }
        
        class ConvolutionSobel
        {
            public void Convolution3x3(ref Bitmap bmp)
            {
               

                Bitmap TempBmp = (Bitmap)bmp.Clone();

                BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                BitmapData TempBmpData = TempBmp.LockBits(new Rectangle(0, 0, TempBmp.Width, TempBmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

                unsafe
                {
                    byte* ptr = (byte*)bmpData.Scan0.ToPointer();
                    byte* TempPtr = (byte*)TempBmpData.Scan0.ToPointer();

                    int Pix = 0;
                    int Stride = bmpData.Stride;
                    int DoubleStride = Stride * 2;
                    int Width = bmp.Width - 2;
                    int Height = bmp.Height - 2;
                    int stopAddress = (int)ptr + bmpData.Stride * bmpData.Height;

                    for (int y = 0; y < Height; ++y)
                        for (int x = 0; x < Width; ++x)
                        {
                            double Gx1 = (TempPtr[2] * (-1)) + (TempPtr[5] * (-2)) + (TempPtr[8] * (-1))
                              + (TempPtr[5 + Stride] * 1) + (TempPtr[8 + Stride] * 2) +
                              (TempPtr[2 + DoubleStride] * 1);

                            double Gy1 = (TempPtr[2] * (-1)) + (TempPtr[8] * 1) +
                              (TempPtr[2 + Stride] * 2) + (TempPtr[5 + Stride] * 1) +
                              (TempPtr[2 + DoubleStride] * (-1)) + (TempPtr[5 + DoubleStride] * (-2));

                            if (Pix < 0) Pix = 0;
                            else if (Pix > 255) Pix = 255;

                            ptr[5 + Stride] = (byte)(Math.Sqrt(Math.Pow(Gx1, 2) + Math.Pow(Gy1, 2)));

                            double Gx2 = (TempPtr[1] * (-1)) + (TempPtr[4] * (-2)) + (TempPtr[7] * (-1))
                              + (TempPtr[4 + Stride] * 1) + (TempPtr[7 + Stride] * 2) +
                              (TempPtr[1 + DoubleStride] * 1);

                            double Gy2 = (TempPtr[1] * (-1)) + (TempPtr[7] * 1) +
                              (TempPtr[1 + Stride] * 2) + (TempPtr[4 + Stride] * 1) +
                              (TempPtr[1 + DoubleStride] * (-1)) + (TempPtr[4 + DoubleStride] * (-2));

                            if (Pix < 0) Pix = 0;
                            else if (Pix > 255) Pix = 255;

                            ptr[4 + Stride] = (byte)(Math.Sqrt(Math.Pow(Gx2, 2) + Math.Pow(Gy2, 2)));

                            double Gx3 = (TempPtr[0] * (-1)) + (TempPtr[3] * (-2)) + (TempPtr[6] * (-1))
                               + (TempPtr[3 + Stride] * 1) + (TempPtr[6 + Stride] * 2) +
                               (TempPtr[0 + DoubleStride] * 1);

                            double Gy3 = (TempPtr[0] * (-1)) + (TempPtr[6] * 1) +
                              (TempPtr[0 + Stride] * 2) + (TempPtr[3 + Stride] * 1) +
                              (TempPtr[0 + DoubleStride] * (-1)) + (TempPtr[3 + DoubleStride] * (-2));

                            if (Pix < 0) Pix = 0;
                            else if (Pix > 255) Pix = 255;

                            ptr[3 + Stride] = (byte)(Math.Sqrt(Math.Pow(Gx3, 2) + Math.Pow(Gy3, 2)));

                            ptr += 3;
                            TempPtr += 3;
                        }
                }

                bmp.UnlockBits(bmpData);
                TempBmp.UnlockBits(TempBmpData);
            }

            public ConvolutionMatrix Matrix { get; set; }
        }
        public static void Sobel_O(ref Bitmap bmp)
        {
            ConvolutionMatrix m = new ConvolutionMatrix();

            ConvolutionSobel C = new ConvolutionSobel();
            C.Matrix = m;
            C.Convolution3x3(ref bmp);
        }

        class ConvolutionMatrix5
        {
            public ConvolutionMatrix5()
            {
                Pixel = 1;
                Factor = 1;
            }

            public void Apply(int Val)
            {
                A11 = A12 = A13 = A14 = A15 = 
                    A21 = A22 = A23 = A24 = A25 = 
                    A31 = A32 = Pixel = A34 = A35 = 
                    A41 = A42 = A43 = A44 = A45 = 
                    A51 = A52 = A53 = A54 = A55 = Val;
            }

            public int A11 { get; set; } public int A12 { get; set; } public int A13 { get; set; } public int A14 { get; set; } public int A15 { get; set; }
            
            public int A21 { get; set; } public int A22 { get; set; } public int A23 { get; set; } public int A24 { get; set; } public int A25 { get; set; }

            public int A31 { get; set; } public int A32 { get; set; } public int Pixel { get; set; } public int A34 { get; set; } public int A35 { get; set; }

            public int A41 { get; set; } public int A42 { get; set; } public int A43 { get; set; } public int A44 { get; set; } public int A45 { get; set; }

            public int A51 { get; set; } public int A52 { get; set; } public int A53 { get; set; } public int A54 { get; set; } public int A55 { get; set; }
            
            public int Factor { get; set; }

            public int Offset { get; set; }
        }
        class Convolution5
        {
            public void Convolution5x5(ref Bitmap bmp)
            {
                int Factor = Matrix.Factor;

                if (Factor == 0) return;

                int A11 = Matrix.A11; int A12 = Matrix.A12; int A13 = Matrix.A13; int A14 = Matrix.A14; int A15 = Matrix.A15;
                int A21 = Matrix.A21; int A22 = Matrix.A22; int A23 = Matrix.A23; int A24 = Matrix.A24; int A25 = Matrix.A25;
                int A31 = Matrix.A31; int A32 = Matrix.A32; int Pixel = Matrix.Pixel; int A34 = Matrix.A34; int A35 = Matrix.A35;
                int A41 = Matrix.A41; int A42 = Matrix.A42; int A43 = Matrix.A43; int A44 = Matrix.A44; int A45 = Matrix.A45;
                int A51 = Matrix.A51; int A52 = Matrix.A52; int A53 = Matrix.A53; int A54 = Matrix.A54; int A55 = Matrix.A55;
                
                int Offset = Matrix.Offset;

                Bitmap TempBmp = (Bitmap)bmp.Clone();

                BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
                BitmapData TempBmpData = TempBmp.LockBits(new Rectangle(0, 0, TempBmp.Width, TempBmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppRgb);

                unsafe
                {
                    byte* ptr = (byte*)bmpData.Scan0.ToPointer();
                    byte* TempPtr = (byte*)TempBmpData.Scan0.ToPointer();

                    int Pix = 0;
                    int Stride = bmpData.Stride;
                    int DoubleStride = Stride * 2;
                    int TripleStride = Stride * 3;
                    int MultyStride = Stride * 4;
                    int Width = bmp.Width - 4;
                    int Height = bmp.Height - 4;
                    int stopAddress = (int)ptr + bmpData.Stride * bmpData.Height;

                    for (int y = 0; y < Height; ++y)
                        for (int x = 0; x < Width; ++x)
                        {
                            

                            Pix = (((((TempPtr[5] * A11) + (TempPtr[10] * A12) + (TempPtr[15] * A13) + (TempPtr[20] * A14) + (TempPtr[25] * A15)) +
                                 ((TempPtr[5 + Stride] * A21) + (TempPtr[10 + Stride] * A22) + (TempPtr[15 + Stride] * A23) + (TempPtr[20 + Stride] * A24) + (TempPtr[25 + Stride] * A25)) +
                                 ((TempPtr[5 + DoubleStride] * A31) + (TempPtr[10 + DoubleStride] * A32) + (TempPtr[15 + DoubleStride] * Pixel) + (TempPtr[20 + DoubleStride] * A34) + (TempPtr[25 + DoubleStride] * A35)) +
                                 ((TempPtr[5 + TripleStride] * A41) + (TempPtr[10 + TripleStride] * A42) + (TempPtr[15 + TripleStride] * A43) + (TempPtr[20 + TripleStride] * A44) + (TempPtr[25 + TripleStride] * A45)) +
                                 ((TempPtr[5 + MultyStride] * A51) + (TempPtr[10 + MultyStride] * A52) + (TempPtr[15 + MultyStride] * A53) + (TempPtr[20 + MultyStride] * A54) + (TempPtr[25 + MultyStride] * A55))) / Factor) + Offset);

                            if (Pix < 0) Pix = 0;
                            else if (Pix > 255) Pix = 255;

                            ptr[15 + DoubleStride] = (byte)Pix;

                            Pix = (((((TempPtr[4] * A11) + (TempPtr[9] * A12) + (TempPtr[14] * A13) + (TempPtr[19] * A14) + (TempPtr[24] * A15)) +
                                  ((TempPtr[4 + Stride] * A21) + (TempPtr[9 + Stride] * A22) + (TempPtr[14 + Stride] * A23) + (TempPtr[19 + Stride] * A24) + (TempPtr[24 + Stride] * A25)) +
                                  ((TempPtr[4 + DoubleStride] * A31) + (TempPtr[9 + DoubleStride] * A32) + (TempPtr[14 + DoubleStride] * Pixel) + (TempPtr[19 + DoubleStride] * A34) + (TempPtr[24 + DoubleStride] * A35)) +
                                  ((TempPtr[4 + TripleStride] * A41) + (TempPtr[9 + TripleStride] * A42) + (TempPtr[14 + TripleStride] * A43) + (TempPtr[19 + TripleStride] * A44) + (TempPtr[24 + TripleStride] * A45)) +
                                  ((TempPtr[4 + MultyStride] * A51) + (TempPtr[9 + MultyStride] * A52) + (TempPtr[14 + MultyStride] * A53) + (TempPtr[19 + MultyStride] * A54) + (TempPtr[24 + MultyStride] * A55))) / Factor) + Offset);

                            if (Pix < 0) Pix = 0;
                            else if (Pix > 255) Pix = 255;

                            ptr[14 + DoubleStride] = (byte)Pix;

                            Pix = (((((TempPtr[3] * A11) + (TempPtr[8] * A12) + (TempPtr[13] * A13) + (TempPtr[18] * A14) + (TempPtr[23] * A15)) +
                                  ((TempPtr[3 + Stride] * A21) + (TempPtr[8 + Stride] * A22) + (TempPtr[13 + Stride] * A23) + (TempPtr[18 + Stride] * A24) + (TempPtr[23 + Stride] * A25)) +
                                  ((TempPtr[3 + DoubleStride] * A31) + (TempPtr[8 + DoubleStride] * A32) + (TempPtr[13 + DoubleStride] * Pixel) + (TempPtr[18 + DoubleStride] * A34) + (TempPtr[23 + DoubleStride] * A35)) +
                                  ((TempPtr[3 + TripleStride] * A41) + (TempPtr[8 + TripleStride] * A42) + (TempPtr[13 + TripleStride] * A43) + (TempPtr[18 + TripleStride] * A44) + (TempPtr[23 + TripleStride] * A45)) +
                                  ((TempPtr[3 + MultyStride] * A51) + (TempPtr[8 + MultyStride] * A52) + (TempPtr[13 + MultyStride] * A53) + (TempPtr[18 + MultyStride] * A54) + (TempPtr[23 + MultyStride] * A55))) / Factor) + Offset);

                            if (Pix < 0) Pix = 0;
                            else if (Pix > 255) Pix = 255;

                            ptr[13 + DoubleStride] = (byte)Pix;

                            Pix = (((((TempPtr[2] * A11) + (TempPtr[7] * A12) + (TempPtr[12] * A13) + (TempPtr[17] * A14) + (TempPtr[22] * A15)) +
                                  ((TempPtr[2 + Stride] * A21) + (TempPtr[7+ Stride] * A22) + (TempPtr[12 + Stride] * A23) + (TempPtr[17 + Stride] * A24) + (TempPtr[22 + Stride] * A25)) +
                                  ((TempPtr[2 + DoubleStride] * A31) + (TempPtr[7 + DoubleStride] * A32) + (TempPtr[12 + DoubleStride] * Pixel) + (TempPtr[17 + DoubleStride] * A34) + (TempPtr[22 + DoubleStride] * A35)) +
                                  ((TempPtr[2 + TripleStride] * A41) + (TempPtr[7 + TripleStride] * A42) + (TempPtr[12 + TripleStride] * A43) + (TempPtr[17 + TripleStride] * A44) + (TempPtr[22 + TripleStride] * A45)) +
                                  ((TempPtr[2 + MultyStride] * A51) + (TempPtr[7 + MultyStride] * A52) + (TempPtr[12 + MultyStride] * A53) + (TempPtr[17 + MultyStride] * A54) + (TempPtr[22 + MultyStride] * A55))) / Factor) + Offset);

                            if (Pix < 0) Pix = 0;
                            else if (Pix > 255) Pix = 255;

                            ptr[12 + DoubleStride] = (byte)Pix;

                            Pix = (((((TempPtr[1] * A11) + (TempPtr[6] * A12) + (TempPtr[11] * A13) + (TempPtr[16] * A14) + (TempPtr[21] * A15)) +
                                  ((TempPtr[1 + Stride] * A21) + (TempPtr[6 + Stride] * A22) + (TempPtr[11 + Stride] * A23) + (TempPtr[16 + Stride] * A24) + (TempPtr[21 + Stride] * A25)) +
                                  ((TempPtr[1 + DoubleStride] * A31) + (TempPtr[6 + DoubleStride] * A32) + (TempPtr[11 + DoubleStride] * Pixel) + (TempPtr[16 + DoubleStride] * A34) + (TempPtr[21 + DoubleStride] * A35)) +
                                  ((TempPtr[1 + TripleStride] * A41) + (TempPtr[6 + TripleStride] * A42) + (TempPtr[11 + TripleStride] * A43) + (TempPtr[16 + TripleStride] * A44) + (TempPtr[21 + TripleStride] * A45)) +
                                  ((TempPtr[1 + MultyStride] * A51) + (TempPtr[6 + MultyStride] * A52) + (TempPtr[11 + MultyStride] * A53) + (TempPtr[16 + MultyStride] * A54) + (TempPtr[21 + MultyStride] * A55))) / Factor) + Offset);

                            if (Pix < 0) Pix = 0;
                            else if (Pix > 255) Pix = 255;

                            ptr[11 + DoubleStride] = (byte)Pix;

                            Pix = (((((TempPtr[0] * A11) + (TempPtr[5] * A12) + (TempPtr[10] * A13) + (TempPtr[15] * A14) + (TempPtr[20] * A15)) +
                                  ((TempPtr[0 + Stride] * A21) + (TempPtr[5 + Stride] * A22) + (TempPtr[10 + Stride] * A23) + (TempPtr[15 + Stride] * A24) + (TempPtr[20 + Stride] * A25)) +
                                  ((TempPtr[0 + DoubleStride] * A31) + (TempPtr[5 + DoubleStride] * A32) + (TempPtr[10 + DoubleStride] * Pixel) + (TempPtr[15 + DoubleStride] * A34) + (TempPtr[20 + DoubleStride] * A35)) +
                                  ((TempPtr[0 + TripleStride] * A41) + (TempPtr[5 + TripleStride] * A42) + (TempPtr[10 + TripleStride] * A43) + (TempPtr[15 + TripleStride] * A44) + (TempPtr[20 + TripleStride] * A45)) +
                                  ((TempPtr[0 + MultyStride] * A51) + (TempPtr[5 + MultyStride] * A52) + (TempPtr[10 + MultyStride] * A53) + (TempPtr[15 + MultyStride] * A54) + (TempPtr[20 + MultyStride] * A55))) / Factor) + Offset);

                            if (Pix < 0) Pix = 0;
                            else if (Pix > 255) Pix = 255;

                            ptr[10 + DoubleStride] = (byte)Pix;

                            ptr += 4;
                            TempPtr += 4;
                        }
                }

                bmp.UnlockBits(bmpData);
                TempBmp.UnlockBits(TempBmpData);
            }

            public ConvolutionMatrix5 Matrix { get; set; }
        }
        public static void Big_Blur_F(ref Bitmap bmp)
        {
            ConvolutionMatrix5 m = new ConvolutionMatrix5();
            m.Apply(1);
            m.A11 = m.A12 = m.A14 = m.A15 = m.A21 = m.A25 = m.A41 = m.A45 = m.A51 = m.A52 = m.A54 = m.A55 = 0;
            m.Factor = 13;

            Convolution5 C = new Convolution5();
            C.Matrix = m;
            C.Convolution5x5(ref bmp);
        }

        public static Bitmap AdjustContrast(Bitmap Image, float Value)
        {
            Value = (100.0f + Value) / 100.0f;
            Value *= Value;
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

                        float Red = R / 255.0f;
                        float Green = G / 255.0f;
                        float Blue = B / 255.0f;
                        Red = (((Red - 0.5f) * Value) + 0.5f) * 255.0f;
                        Green = (((Green - 0.5f) * Value) + 0.5f) * 255.0f;
                        Blue = (((Blue - 0.5f) * Value) + 0.5f) * 255.0f;

                        int iR = (int)Red;
                        iR = iR > 255 ? 255 : iR;
                        iR = iR < 0 ? 0 : iR;
                        int iG = (int)Green;
                        iG = iG > 255 ? 255 : iG;
                        iG = iG < 0 ? 0 : iG;
                        int iB = (int)Blue;
                        iB = iB > 255 ? 255 : iB;
                        iB = iB < 0 ? 0 : iB;

                        row[columnOffset] = (byte)iB;
                        row[columnOffset + 1] = (byte)iG;
                        row[columnOffset + 2] = (byte)iR;

                        columnOffset += 4;
                    }
                }
            }

            NewBitmap.UnlockBits(data);

            return NewBitmap;
        }

        private void DrawWatermark(Bitmap watermark_bm, Bitmap result_bm, int x, int y)
        {
            // Создаем ColorMatrix, которая умножает
            // альфа-компонент на 0,5.
            ColorMatrix color_matrix = new ColorMatrix();
            color_matrix.Matrix33 = 0.5f;

            // Создаем ImageAttributes, который использует ColorMatrix.
            ImageAttributes image_attributes = new ImageAttributes();
            image_attributes.SetColorMatrices(color_matrix, null);

            // Создаем пиксели того же цвета, что и
            // один в верхнем левом прозрачном.
            watermark_bm.MakeTransparent(watermark_bm.GetPixel(0, 0));

            // Нарисуем изображение с помощью ColorMatrix.
            using (Graphics gr = Graphics.FromImage(result_bm))
            {
                Rectangle rect = new Rectangle(x, y,
                    watermark_bm.Width, watermark_bm.Height);
                gr.DrawImage(watermark_bm, rect, 0, 0,
                    watermark_bm.Width, watermark_bm.Height,
                    GraphicsUnit.Pixel, image_attributes);
            }
        }
        
        private void Average_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null) // если изображение в pictureBox1 имеется
            {
                Bitmap input;
                if (radioButton1.Checked == true)
                    input = new Bitmap(pictureBox1.Image);
                else input = new Bitmap(pictureBox2.Image);

                Bitmap output = new Bitmap(input.Width, input.Height);

                Graphics clone = Graphics.FromImage(output);

                ImageAttributes cat = new ImageAttributes();

                ColorMatrix gray = new ColorMatrix(new float[][] { new float[] { (float)1 / 3, (float)1 / 3, (float)1 / 3, 0f, 0f }, new float[] { (float)1 / 3, (float)1 / 3, (float)1 / 3, 0f, 0f }, new float[] { (float)1 / 3, (float)1 / 3, (float)1 / 3, 0f, 0f }, new float[] { 0f, 0f, 0f, 1f, 0f }, new float[] { 0f, 0f, 0f, 0f, 1f } });

                cat.SetColorMatrix(gray);

                clone.DrawImage(input, new Rectangle(0, 0, input.Width, input.Height), 0, 0, input.Width, input.Height, GraphicsUnit.Pixel, cat);
                clone.Dispose();
                cat.Dispose();

                pictureBox2.Image = output;
                
            }
        }

        private void Lightness_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null) // если изображение в pictureBox1 имеется
            {
                Bitmap input;
                if (radioButton1.Checked == true)
                    input = new Bitmap(pictureBox1.Image);
                else input = new Bitmap(pictureBox2.Image);
                // создаём Bitmap для черно-белого изображения
                Bitmap output = new Bitmap(input.Width, input.Height);
                // перебираем в циклах все пиксели исходного изображения
                for (int j = 0; j < input.Height; j++)
                    for (int i = 0; i < input.Width; i++)
                    {
                        // получаем (i, j) пиксель
                        UInt32 pixel = (UInt32)(input.GetPixel(i, j).ToArgb());
                        // получаем компоненты цветов пикселя
                        float R = (float)((pixel & 0x00FF0000) >> 16); // красный
                        float G = (float)((pixel & 0x0000FF00) >> 8); // зеленый
                        float B = (float)(pixel & 0x000000FF); // синий
                                                               // делаем цвет черно-белым (оттенки серого) - находим среднее арифметическое

                        float max = 0;
                        if (R >= G && R >= B) { max = R; }
                        else
                        {
                            if (G >= R && G >= B) { max = G; }
                            else
                            {
                                if (B >= G && B >= R) { max = B; }
                            }
                        }

                        float min = 0;
                        if (R <= G && R <= B) { min = R; }
                        else
                        {
                            if (G <= R && G <= B) { min = G; }
                            else
                            {
                                if (B <= G && B <= R) { min = B; }
                            }
                        }


                        R = G = B = (max + min) / 2.0f;
                        // собираем новый пиксель по частям (по каналам)
                        UInt32 newPixel = 0xFF000000 | ((UInt32)R << 16) | ((UInt32)G << 8) | ((UInt32)B);
                        // добавляем его в Bitmap нового изображения
                        output.SetPixel(i, j, Color.FromArgb((int)newPixel));
                    }
                // выводим черно-белый Bitmap в pictureBox2
                pictureBox2.Image = output;
            }
        }

        private void Luminosity_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null) // если изображение в pictureBox1 имеется
            {
                Bitmap input;
                if (radioButton1.Checked == true)
                    input = new Bitmap(pictureBox1.Image);
                else input = new Bitmap(pictureBox2.Image);

                Bitmap output = new Bitmap(input.Width, input.Height);

                Graphics clone = Graphics.FromImage(output);

                ImageAttributes cat = new ImageAttributes();

                ColorMatrix gray = new ColorMatrix(new float[][] { new float[] { 0.21f, 0.21f, 0.21f, 0f, 0f }, new float[] { 0.72f, 0.72f, 0.72f, 0f, 0f }, new float[] { 0.07f, 0.07f, 0.07f, 0f, 0f }, new float[] { 0f, 0f, 0f, 1f, 0f }, new float[] { 0f, 0f, 0f, 0f, 1f } });

                cat.SetColorMatrix(gray);

                clone.DrawImage(input, new Rectangle(0, 0, input.Width, input.Height), 0, 0, input.Width, input.Height, GraphicsUnit.Pixel, cat);
                clone.Dispose();
                cat.Dispose();

                pictureBox2.Image = output;

            }
        }

        private void GIMP_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null) // если изображение в pictureBox1 имеется
            {
                Bitmap input;
                if (radioButton1.Checked == true)
                    input = new Bitmap(pictureBox1.Image);
                else input = new Bitmap(pictureBox2.Image);

                Bitmap output = new Bitmap(input.Width, input.Height);

                Graphics clone = Graphics.FromImage(output);

                ImageAttributes cat = new ImageAttributes();

                ColorMatrix gray = new ColorMatrix(new float[][] { new float[] { 0.3f, 0.3f, 0.3f, 0f, 0f }, new float[] { 0.59f, 0.59f, 0.59f, 0f, 0f }, new float[] { 0.11f, 0.11f, 0.11f, 0f, 0f }, new float[] { 0f, 0f, 0f, 1f, 0f }, new float[] { 0f, 0f, 0f, 0f, 1f } });

                cat.SetColorMatrix(gray);

                clone.DrawImage(input, new Rectangle(0, 0, input.Width, input.Height), 0, 0, input.Width, input.Height, GraphicsUnit.Pixel, cat);
                clone.Dispose();
                cat.Dispose();

                pictureBox2.Image = output;
            }
        }

        private void ITU_R_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap input;
                if (radioButton1.Checked == true)
                    input = new Bitmap(pictureBox1.Image);
                else input = new Bitmap(pictureBox2.Image);

                Bitmap output = new Bitmap(input.Width, input.Height);

                Graphics clone = Graphics.FromImage(output);

                ImageAttributes cat = new ImageAttributes();

                ColorMatrix gray = new ColorMatrix(new float[][] { new float[] { 0.2126f, 0.2126f, 0.2126f, 0f, 0f }, new float[] { 0.7152f, 0.7152f, 0.7152f, 0f, 0f }, new float[] { 0.0722f, 0.0722f, 0.0722f, 0f, 0f }, new float[] { 0f, 0f, 0f, 1f, 0f }, new float[] { 0f, 0f, 0f, 0f, 1f } });

                cat.SetColorMatrix(gray);

                clone.DrawImage(input, new Rectangle(0, 0, input.Width, input.Height), 0, 0, input.Width, input.Height, GraphicsUnit.Pixel, cat);
                clone.Dispose();
                cat.Dispose();

                pictureBox2.Image = output;
                
            }
        }

        private void Max_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null) // если изображение в pictureBox1 имеется
            {
                Bitmap input;
                if (radioButton1.Checked == true)
                    input = new Bitmap(pictureBox1.Image);
                else input = new Bitmap(pictureBox2.Image);
                // создаём Bitmap для черно-белого изображения
                Bitmap output = new Bitmap(input.Width, input.Height);
                // перебираем в циклах все пиксели исходного изображения
                for (int j = 0; j < input.Height; j++)
                    for (int i = 0; i < input.Width; i++)
                    {
                        // получаем (i, j) пиксель
                        UInt32 pixel = (UInt32)(input.GetPixel(i, j).ToArgb());
                        // получаем компоненты цветов пикселя
                        float R = (float)((pixel & 0x00FF0000) >> 16); // красный
                        float G = (float)((pixel & 0x0000FF00) >> 8); // зеленый
                        float B = (float)(pixel & 0x000000FF); // синий
                                                               // делаем цвет черно-белым (оттенки серого) - находим среднее арифметическое

                        float max = 0;
                        if (R >= G && R >= B) { max = R; }
                        else
                        {
                            if (G >= R && G >= B) { max = G; }
                            else
                            {
                                if (B >= G && B >= R) { max = B; }
                            }
                        }


                        R = G = B = (float)max;
                        // собираем новый пиксель по частям (по каналам)
                        UInt32 newPixel = 0xFF000000 | ((UInt32)R << 16) | ((UInt32)G << 8) | ((UInt32)B);
                        // добавляем его в Bitmap нового изображения
                        output.SetPixel(i, j, Color.FromArgb((int)newPixel));
                    }
                // выводим черно-белый Bitmap в pictureBox2
                pictureBox2.Image = output;
            }
        }

        private void Min_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null) // если изображение в pictureBox1 имеется
            {
                Bitmap input;
                if (radioButton1.Checked == true)
                    input = new Bitmap(pictureBox1.Image);
                else input = new Bitmap(pictureBox2.Image);
                // создаём Bitmap для черно-белого изображения
                Bitmap output = new Bitmap(input.Width, input.Height);
                // перебираем в циклах все пиксели исходного изображения
                for (int j = 0; j < input.Height; j++)
                    for (int i = 0; i < input.Width; i++)
                    {
                        // получаем (i, j) пиксель
                        UInt32 pixel = (UInt32)(input.GetPixel(i, j).ToArgb());
                        // получаем компоненты цветов пикселя
                        float R = (float)((pixel & 0x00FF0000) >> 16); // красный
                        float G = (float)((pixel & 0x0000FF00) >> 8); // зеленый
                        float B = (float)(pixel & 0x000000FF); // синий
                                                               // делаем цвет черно-белым (оттенки серого) - находим среднее арифметическое


                        float min = 0;
                        if (R <= G && R <= B) { min = R; }
                        else
                        {
                            if (G <= R && G <= B) { min = G; }
                            else
                            {
                                if (B <= G && B <= R) { min = B; }
                            }
                        }


                        R = G = B = (float)min;
                        // собираем новый пиксель по частям (по каналам)
                        UInt32 newPixel = 0xFF000000 | ((UInt32)R << 16) | ((UInt32)G << 8) | ((UInt32)B);
                        // добавляем его в Bitmap нового изображения
                        output.SetPixel(i, j, Color.FromArgb((int)newPixel));
                    }
                // выводим черно-белый Bitmap в pictureBox2
                pictureBox2.Image = output;
            }
        }

        private void Gray_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null) 
            {
                
                Bitmap input;
                if (radioButton1.Checked == true)
                    input = new Bitmap(pictureBox1.Image);
                else input = new Bitmap(pictureBox2.Image);

                Bitmap output = new Bitmap(input.Width, input.Height);

                Graphics clone = Graphics.FromImage(output);

                ImageAttributes cat = new ImageAttributes();

                ColorMatrix gray = new ColorMatrix(new float[][] { new float[] { 0.2952f, 0.2952f, 0.2952f, 0f, 0f }, new float[] { 0.5547f, 0.5547f, 0.5547f, 0f, 0f }, new float[] { 0.148f, 0.148f, 0.148f, 0f, 0f }, new float[] { 0f, 0f, 0f, 1f, 0f }, new float[] { 0f, 0f, 0f, 0f, 1f } });

                cat.SetColorMatrix(gray);

                clone.DrawImage(input, new Rectangle(0, 0, input.Width, input.Height), 0, 0, input.Width, input.Height, GraphicsUnit.Pixel, cat);
                clone.Dispose();
                cat.Dispose();

                pictureBox2.Image = output;
                
            }
        }
        

        private void Adapted_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null) // если изображение в pictureBox1 имеется
            {
                Bitmap input;
                if (radioButton1.Checked == true)
                    input = new Bitmap(pictureBox1.Image);
                else input = new Bitmap(pictureBox2.Image);

                Bitmap output = new Bitmap(input.Width, input.Height);

                Graphics clone = Graphics.FromImage(output);

                ImageAttributes cat = new ImageAttributes();
                var k = 1000;

                ColorMatrix gray = new ColorMatrix(new float[][] { new float[] { k, k, k, 0f, 0f }, new float[] { k, k, k, 0f, 0f }, new float[] { k, k, k, 0f, 0f }, new float[] { 0f, 0f, 0f, 1f, 0f }, new float[] { -k / 2, -k / 2, -k / 2, 0f, 0f } });

                cat.SetColorMatrix(gray);

                clone.DrawImage(input, new Rectangle(0, 0, input.Width, input.Height), 0, 0, input.Width, input.Height, GraphicsUnit.Pixel, cat);

                clone.Dispose();
                cat.Dispose();

                pictureBox2.Image = output;

            }
        }

        private void Binarization_Scroll(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null) // если изображение в pictureBox1 имеется
            {
                float x = Binarization.Value;
                x = -100 / x;
                Bitmap input;
                if (radioButton1.Checked == true)
                    input = new Bitmap(pictureBox1.Image);
                else input = new Bitmap(pictureBox2.Image);

                Bitmap output = new Bitmap(input.Width, input.Height);

                Graphics clone = Graphics.FromImage(output);

                ImageAttributes cat = new ImageAttributes();
                var k = 1000;

                ColorMatrix gray = new ColorMatrix(new float[][] { new float[] { k, k, k, 0f, 0f }, new float[] { k, k, k, 0f, 0f }, new float[] { k, k, k, 0f, 0f }, new float[] { 0f, 0f, 0f, 1f, 0f }, new float[] { -k / x, -k / x, -k / x, 0f, 0f } });

                cat.SetColorMatrix(gray);

                clone.DrawImage(input, new Rectangle(0, 0, input.Width, input.Height), 0, 0, input.Width, input.Height, GraphicsUnit.Pixel, cat);

                clone.Dispose();
                cat.Dispose();

                pictureBox2.Image = output;

            }
        }

        private void MFilter_Click(object sender, EventArgs e)
        {
            Bitmap input;
            if (radioButton1.Checked == true)
                input = new Bitmap(pictureBox1.Image);
            else input = new Bitmap(pictureBox2.Image);

            Mediana(ref input);

            pictureBox2.Image = input;
        }

        private void UFilter_Click(object sender, EventArgs e)
        {
            Bitmap input;
            if (radioButton1.Checked == true)
                input = new Bitmap(pictureBox1.Image);
            else input = new Bitmap(pictureBox2.Image);

            ApplyBoxBlur(ref input);

            pictureBox2.Image = input;

        }

        private void GFilter_Click(object sender, EventArgs e)
        {
            Bitmap input;
            if (radioButton1.Checked == true)
                input = new Bitmap(pictureBox1.Image);
            else input = new Bitmap(pictureBox2.Image);

            ApplyGaussianBlur(ref input, 4);

            pictureBox2.Image = input;
        }

        private void Inversion_Click(object sender, EventArgs e)
        {
            Bitmap input;
            if (radioButton1.Checked == true)
                input = new Bitmap(pictureBox1.Image);
            else input = new Bitmap(pictureBox2.Image);

            Bitmap output = Inverse(input);

            pictureBox2.Image = output;
        }

        private void Brightness_Scroll(object sender, EventArgs e)
        {
            float contrast = 0.04f * Brightness.Value;

            Bitmap input;
            if (radioButton1.Checked == true)
                input = new Bitmap(pictureBox1.Image);
            else input = new Bitmap(pictureBox2.Image);

            Bitmap output = new Bitmap(input.Width, input.Height);

            Graphics g = Graphics.FromImage(output);

            ImageAttributes ia = new ImageAttributes();

            ColorMatrix cm = new ColorMatrix(new float[][] { new float[] { contrast, 0f, 0f, 0f, 0f }, new float[] { 0f, contrast, 0f, 0f, 0f }, new float[] { 0f, 0f, contrast, 0f, 0f }, new float[] { 0f, 0f, 0f, 1f, 0f }, new float[] { 0.001f, 0.001f, 0.001f, 0f, 1f } });

            ia.SetColorMatrix(cm);

            g.DrawImage(input, new Rectangle(0, 0, input.Width, input.Height), 0, 0, input.Width, input.Height, GraphicsUnit.Pixel, ia);
            g.Dispose();
            ia.Dispose();

            pictureBox2.Image = output;
        }

        private void Sobel_Click(object sender, EventArgs e)
        {
            Bitmap input;
            if (radioButton1.Checked == true)
                input = new Bitmap(pictureBox1.Image);
            else input = new Bitmap(pictureBox2.Image);
        
            Bitmap output = Sobel_Operator(input);

            pictureBox2.Image = output;
        }

        private void Previtt_Click(object sender, EventArgs e)
        {
            Bitmap input;
            if (radioButton1.Checked == true)
                input = new Bitmap(pictureBox1.Image);
            else input = new Bitmap(pictureBox2.Image);

            Bitmap output = Previtt_Operator(input);

            pictureBox2.Image = output;
        }
        
        private void Roberts_Click(object sender, EventArgs e)
        {
            Bitmap input;
            if (radioButton1.Checked == true)
                input = new Bitmap(pictureBox1.Image);
            else input = new Bitmap(pictureBox2.Image);

            Bitmap output = Roberts_Operator(input);

            pictureBox2.Image = output;
        }

        private void Swap_Click(object sender, EventArgs e)
        {
            Photo = new Bitmap(pictureBox1.Image);
            Bitmap input = new Bitmap(pictureBox2.Image);
            pictureBox1.Image = input;
        }

        private void Return_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Photo;
        }

        private void Erose_Click(object sender, EventArgs e)
        {
            Bitmap input;
            if (radioButton1.Checked == true)
                input = new Bitmap(pictureBox1.Image);
            else input = new Bitmap(pictureBox2.Image);

            Bitmap output = Erosion(input);

            pictureBox2.Image = output;
        }

        private void Dilation_Click(object sender, EventArgs e)
        {
            Bitmap input;
            if (radioButton1.Checked == true)
                input = new Bitmap(pictureBox1.Image);
            else input = new Bitmap(pictureBox2.Image);

            Bitmap output = Dilatation(input);

            pictureBox2.Image = output;
        }

        private void Opening_Click(object sender, EventArgs e)
        {
            Bitmap input;
            if (radioButton1.Checked == true)
                input = new Bitmap(pictureBox1.Image);
            else input = new Bitmap(pictureBox2.Image);

            int k = System.Convert.ToInt32(textBox1.Text);

            for(int i = 0; i < k; i++)
            input = Erosion(input);

            for(int i = 0; i < k; i++)
            input = Dilatation(input);

            pictureBox2.Image = input;
        }

        private void Closing_Click(object sender, EventArgs e)
        {
            Bitmap input;
            if (radioButton1.Checked == true)
                input = new Bitmap(pictureBox1.Image);
            else input = new Bitmap(pictureBox2.Image);

            int k = System.Convert.ToInt32(textBox1.Text);

            for (int i = 0; i < k; i++)
                input = Dilatation(input);

            for (int i = 0; i < k; i++)
                input = Erosion(input);

            pictureBox2.Image = input;
        }

        private void Top_Hat_Click(object sender, EventArgs e)
        {
            Bitmap input;
            if (radioButton1.Checked == true)
                input = new Bitmap(pictureBox1.Image);
            else input = new Bitmap(pictureBox2.Image);

            int k = System.Convert.ToInt32(textBox1.Text);
            Bitmap output = input;
            for (int i = 0; i < k; i++)
                output = Erosion(output);

            for (int i = 0; i < k; i++)
                output = Dilatation(output);

            Bitmap result;
            if (checkBox2.Checked == true)
                result = Difference_WB(input, output);
            else result = Difference_BW(input, output);

            pictureBox2.Image = result;
        }

        private void Black_Hat_Click(object sender, EventArgs e)
        {
            Bitmap input;
            if (radioButton1.Checked == true)
                input = new Bitmap(pictureBox1.Image);
            else input = new Bitmap(pictureBox2.Image);

            int k = System.Convert.ToInt32(textBox1.Text);
            Bitmap output = input;
            for (int i = 0; i < k; i++)
                output = Dilatation(output);

            for (int i = 0; i < k; i++)
                output = Erosion(output);

            Bitmap result;
            if (checkBox2.Checked == true)
            result = Difference_WB(input, output);
            else result = Difference_BW(input, output);

            pictureBox2.Image = result;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true) checkBox1.Checked = false;
            if (checkBox2.Checked == false) checkBox1.Checked = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) checkBox2.Checked = false;
            if (checkBox1.Checked == false) checkBox2.Checked = true;
        }

        private void Limit_Click(object sender, EventArgs e)
        {
            Bitmap input;
            if (radioButton1.Checked == true)
                input = new Bitmap(pictureBox1.Image);
            else input = new Bitmap(pictureBox2.Image);

            int k = System.Convert.ToInt32(textBox1.Text);
            Bitmap output = input;
            for (int i = 0; i < k; i++)
                output = Selection(output);

            Bitmap result;
            if (checkBox2.Checked == true)
                result = Difference_WB(input, output);
            else result = Difference_BW(input, output);

            pictureBox2.Image = result;
        }

        private void Contrast_Scroll(object sender, EventArgs e)
        {
            Bitmap input;
            if (radioButton1.Checked == true)
                input = new Bitmap(pictureBox1.Image);
            else input = new Bitmap(pictureBox2.Image);

            int value = Contrast.Value;
            Bitmap output = AdjustContrast(input, value);
            

            pictureBox2.Image = output;

        }
     
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (Rectangle_ == false)
            {
                if (MEvents.GetKeyStatus(MButtons.LEFT))
                {
                    Bitmap bmp = new Bitmap(ClientSize.Width, ClientSize.Height);
                    DrawToBitmap(bmp, new Rectangle(ClientRectangle.Location, ClientSize));
                    Color c = bmp.GetPixel(MEvents.CursorPostionX, MEvents.CursorPostionY);
                    ColorPix.Text = "Цвет: " + System.Convert.ToString(c.ToString());

                    ColorPix.BackColor = c;

                    // инверсия текста 

                    byte red = c.R;
                    byte green = c.G;
                    byte blue = c.B;

                    ColorPix.ForeColor = Color.FromArgb(255 - red, 255 - green, 255 - blue);
                }
                else if ((MEvents.GetKeyStatus(MButtons.RIGHT)) && (b1 == true))
                {
                    Bitmap input = new Bitmap(pictureBox1.Image);

                    Bitmap output = new Bitmap(input.Width / 2, input.Height / 2);

                    Graphics clone = Graphics.FromImage(output);

                    ImageAttributes cat = new ImageAttributes();

                    int x = MEvents.CursorPostionX - pictureBox1.Location.X;
                    int y = MEvents.CursorPostionY - pictureBox1.Location.Y;
                    clone.DrawImage(input, new Rectangle(0, 0, input.Width / 2 + x, input.Height / 2 + y), x, y, input.Width / 2 + x, input.Height / 2 + y, GraphicsUnit.Pixel, cat);
                    clone.Dispose();
                    cat.Dispose();
                    pictureBox1.Image = output;
                    b1 = false;
                }
                else if (b1 == false)
                {
                    pictureBox1.Image = Photo;
                    b1 = true;
                }
            }
            else
            {
                if (MEvents.GetKeyStatus(MButtons.LEFT))
                {
                    int x = MEvents.CursorPostionX - pictureBox1.Location.X;
                    int y = MEvents.CursorPostionY - pictureBox1.Location.Y;
                    int Size_ = System.Convert.ToInt32(toolStripTextBox3.Text);

                    Pen blackPen = new Pen(Color.Blue, 5);
                    Bitmap bmp = new Bitmap(pictureBox1.Image);
                    Graphics g = Graphics.FromImage(bmp);
                    Color color = Color.Blue;
                    if (toolStripComboBox1.Text == "Голубой")
                    color = Color.Blue;
                    else if (toolStripComboBox1.Text == "Красный")
                        color = Color.Red;
                    else if (toolStripComboBox1.Text == "Зеленый")
                        color = Color.Green;
                    else if (toolStripComboBox1.Text == "Черный")
                        color = Color.Black;
                    else if (toolStripComboBox1.Text == "Белый")
                        color = Color.White;

                    Rectangle rectangle = new Rectangle(x, y, x + Size_,  y + Size_);
                    g.DrawRectangle(new Pen(color), rectangle);
                    pictureBox2.Image = bmp;
                    
                }
            }
        }
           
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (Rectangle_ == false)
            {
                if (MEvents.GetKeyStatus(MButtons.LEFT))
                {
                    Bitmap bmp = new Bitmap(ClientSize.Width, ClientSize.Height);
                    DrawToBitmap(bmp, new Rectangle(ClientRectangle.Location, ClientSize));
                    Color c = bmp.GetPixel(MEvents.CursorPostionX, MEvents.CursorPostionY);
                    ColorPix.Text = "Цвет: " + System.Convert.ToString(c.ToString());

                    ColorPix.BackColor = c;

                    // инверсия текста 

                    byte red = c.R;
                    byte green = c.G;
                    byte blue = c.B;

                    ColorPix.ForeColor = Color.FromArgb(255 - red, 255 - green, 255 - blue);
                }
                else if ((MEvents.GetKeyStatus(MButtons.RIGHT)) && (b2 == true))
                {
                    Bitmap input = new Bitmap(pictureBox2.Image);
                    DopPhoto = input;

                    Bitmap output = new Bitmap(input.Width / 2, input.Height / 2);

                    Graphics clone = Graphics.FromImage(output);

                    ImageAttributes cat = new ImageAttributes();

                    int x = MEvents.CursorPostionX - pictureBox2.Location.X;
                    int y = MEvents.CursorPostionY - pictureBox2.Location.Y;
                    clone.DrawImage(input, new Rectangle(0, 0, input.Width / 2 + x, input.Height / 2 + y), x, y, input.Width / 2 + x, input.Height / 2 + y, GraphicsUnit.Pixel, cat);
                    clone.Dispose();
                    cat.Dispose();
                    pictureBox2.Image = output;
                    b2 = false;
                }
                else if (b2 == false)
                {
                    pictureBox2.Image = DopPhoto;
                    b2 = true;
                }
            }
            else
            {
                if (MEvents.GetKeyStatus(MButtons.LEFT))
                {
                    int x = MEvents.CursorPostionX - pictureBox2.Location.X;
                    int y = MEvents.CursorPostionY - pictureBox2.Location.Y;
                    int Size_ = System.Convert.ToInt32(toolStripTextBox3.Text);

                    Pen blackPen = new Pen(Color.Blue, 5);
                    Bitmap bmp = new Bitmap(pictureBox2.Image);
                    Graphics g = Graphics.FromImage(bmp);
                    Color color = Color.Blue;
                    if (toolStripComboBox1.Text == "Голубой")
                        color = Color.Blue;
                    else if (toolStripComboBox1.Text == "Красный")
                        color = Color.Red;
                    else if (toolStripComboBox1.Text == "Зеленый")
                        color = Color.Green;
                    else if (toolStripComboBox1.Text == "Черный")
                        color = Color.Black;
                    else if (toolStripComboBox1.Text == "Белый")
                        color = Color.White;

                    Rectangle rectangle = new Rectangle(x, y, x + Size_, y + Size_);
                    g.DrawRectangle(new Pen(color), rectangle);
                    pictureBox2.Image = bmp;

                }
            }

        }

        private void Clarity_Scroll(object sender, EventArgs e)
        {
            float clar = (float)Clarity.Value / 100;

            Bitmap input;
            if (radioButton1.Checked == true)
                input = new Bitmap(pictureBox1.Image);
            else input = new Bitmap(pictureBox2.Image);

            Bitmap output = new Bitmap(input.Width, input.Height);

            Graphics g = Graphics.FromImage(output);

            ImageAttributes ia = new ImageAttributes();

            ColorMatrix cm = new ColorMatrix(new float[][] { new float[] { 1f, 0f, 0f, 0f, 0f }, new float[] { 0f, 1f, 0f, 0f, 0f }, new float[] { 0f, 0f, 1f, 0f, 0f }, new float[] { 0f, 0f, 0f, clar, 0f }, new float[] { 0f, 0f, 0f, 0f, 1f } });

            ia.SetColorMatrix(cm);

            g.DrawImage(input, new Rectangle(0, 0, input.Width, input.Height), 0, 0, input.Width, input.Height, GraphicsUnit.Pixel, ia);
            g.Dispose();
            ia.Dispose();

            pictureBox2.Image = output;
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // диалог для выбора файла
            OpenFileDialog ofd = new OpenFileDialog();

            // фильтр форматов файлов
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";

            // если в диалоге была нажата кнопка ОК
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // загружаем изображение
                    pictureBox1.Image = new Bitmap(ofd.FileName);
                    Photo = (Bitmap)pictureBox1.Image;
                }
                catch // в случае ошибки выводим MessageBox
                {
                    MessageBox.Show("Невозможно открыть выбранный файл", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null) // если изображение в pictureBox2 имеется
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Сохранить картинку как...";
                sfd.OverwritePrompt = true; // показывать ли "Перезаписать файл" если пользователь указывает имя файла, который уже существует
                sfd.CheckPathExists = true; // отображает ли диалоговое окно предупреждение, если пользователь указывает путь, который не существует
                                            // фильтр форматов файлов
                sfd.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                sfd.ShowHelp = true; // отображается ли кнопка Справка в диалоговом окне
                                     // если в диалоге была нажата кнопка ОК
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // сохраняем изображение
                        pictureBox2.Image.Save(sfd.FileName);
                    }
                    catch // в случае ошибки выводим MessageBox
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void водянойЗнакToolStripMenuItem_Click(object sender, EventArgs e)
        {   
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Bitmap image = new Bitmap(pictureBox1.Image);
            int x = System.Convert.ToInt32(toolStripTextBox1.Text);
            int y = System.Convert.ToInt32(toolStripTextBox2.Text);
            DrawWatermark(Water, image, x, y);
            pictureBox2.Image = image;
        }

        private void выбратьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Water = new Bitmap(ofd.FileName);

                }
                catch
                {
                    MessageBox.Show("Невозможно открыть выбранный файл", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private void Sharpen_Click(object sender, EventArgs e)
        {
            Bitmap input;
            if (radioButton1.Checked == true)
                input = new Bitmap(pictureBox1.Image);
            else input = new Bitmap(pictureBox2.Image);

            Sharpen_F(ref input);

            pictureBox2.Image = input;
        }

        private void Emboss_Click(object sender, EventArgs e)
        {
            Bitmap input;
            if (radioButton1.Checked == true)
                input = new Bitmap(pictureBox1.Image);
            else input = new Bitmap(pictureBox2.Image);

            Emboss_F(ref input);

            pictureBox2.Image = input;
        }

        private void Blur_Click(object sender, EventArgs e)
        {
            Bitmap input;
            if (radioButton1.Checked == true)
                input = new Bitmap(pictureBox1.Image);
            else input = new Bitmap(pictureBox2.Image);

            Blur_F(ref input);

            pictureBox2.Image = input;
        }

        private void Find_Edges_Click(object sender, EventArgs e)
        {
                Bitmap input;
            if (radioButton1.Checked == true)
                input = new Bitmap(pictureBox1.Image);
            else input = new Bitmap(pictureBox2.Image);

            Find_Edges_F(ref input);

            pictureBox2.Image = input;
        }

        private void Excessive_Click(object sender, EventArgs e)
        {
            Bitmap input;
            if (radioButton1.Checked == true)
                input = new Bitmap(pictureBox1.Image);
            else input = new Bitmap(pictureBox2.Image);

            Excessive_F(ref input);

            pictureBox2.Image = input;
        }

        private void Big_Blur_Click(object sender, EventArgs e)
        {
            Bitmap input;
            if (radioButton1.Checked == true)
                input = new Bitmap(pictureBox1.Image);
            else input = new Bitmap(pictureBox2.Image);

            Big_Blur_F(ref input);

            pictureBox2.Image = input;
        }

        private void Create3_Click(object sender, EventArgs e)
        {
            Form2 F2 = new Form2(this);
            F2.Show();
        }

        private void изменитьГаммуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gamma F2 = new Gamma(this);
            F2.Show();
        }

        private void Rotate90_Click(object sender, EventArgs e)
        {
            Bitmap input;
            if (radioButton1.Checked == true)
                input = new Bitmap(pictureBox1.Image);
            else input = new Bitmap(pictureBox2.Image);

            input.RotateFlip(RotateFlipType.Rotate90FlipNone);

            if (radioButton1.Checked == true)
                pictureBox1.Image = input;
            else pictureBox2.Image = input;
        }

        private void подтвердитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rectangle_ = true;
        }

        private void деактивироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rectangle_ = false;
        }
        
        private void обрезатьИзображениеToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
        }

        private void зашумленностьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Noise F2 = new Noise(this);
            F2.Show();
        }

        private void Acidity_F_Click(object sender, EventArgs e)
        {
            Bitmap input;
            if (radioButton1.Checked == true)
                input = new Bitmap(pictureBox1.Image);
            else input = new Bitmap(pictureBox2.Image);

            Acidity(ref input);

            pictureBox2.Image = input;
        }

        private void Saturation_Scroll(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null) 
            {
                float s = Saturation.Value;
                var sr = (1 - s) * 0.3086f;
                var sg = (1 - s) * 0.6094f;
                var sb = (1 - s) * 0.0820f;

                Bitmap input;
                if (radioButton1.Checked == true)
                    input = new Bitmap(pictureBox1.Image);
                else input = new Bitmap(pictureBox2.Image);

                Bitmap output = new Bitmap(input.Width, input.Height);

                Graphics clone = Graphics.FromImage(output);

                ImageAttributes cat = new ImageAttributes();

                ColorMatrix gray = new ColorMatrix(new float[][] { new float[] { (sr + s), sr, sr, 0f, 0f }, new float[] { sg, sg+s, sg, 0f, 0f }, new float[] { sb, sb, sb+s, 0f, 0f }, new float[] { 0f, 0f, 0f, 1f, 0f }, new float[] { 0f, 0f, 0f, 0f, 0f } });

                cat.SetColorMatrix(gray);

                clone.DrawImage(input, new Rectangle(0, 0, input.Width, input.Height), 0, 0, input.Width, input.Height, GraphicsUnit.Pixel, cat);

                clone.Dispose();
                cat.Dispose();

                pictureBox2.Image = output;

            }
        }

        private void конвертерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Convert con = new Convert(this);
            con.Show();
        }

        private void toolStripTextBox3_Click(object sender, EventArgs e)
        {        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        private void поГоризонталиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap input;
            if (radioButton1.Checked == true)
                input = new Bitmap(pictureBox1.Image);
            else input = new Bitmap(pictureBox2.Image);

            input.RotateFlip(RotateFlipType.RotateNoneFlipX);

            pictureBox2.Image = input;
        }

        private void поВертикалиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap input;
            if (radioButton1.Checked == true)
                input = new Bitmap(pictureBox1.Image);
            else input = new Bitmap(pictureBox2.Image);

            input.RotateFlip(RotateFlipType.RotateNoneFlipY);

            pictureBox2.Image = input;
        }

    }
}
