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
    public partial class Gamma : Form
    {
        Form1 F1;
        public Gamma(Form1 F1_)
        {
            F1 = F1_;
            InitializeComponent();
        }

        private void Red_Scroll(object sender, EventArgs e)
        {
            if (F1.pictureBox1.Image != null) // если изображение в pictureBox1 имеется
            {
                double value = Red.Value * 0.04;
                Bitmap input;
                if (F1.radioButton1.Checked == true)
                    input = new Bitmap(F1.pictureBox1.Image);
                else input = new Bitmap(F1.pictureBox2.Image);

                Bitmap output = new Bitmap(input.Width, input.Height);

                Graphics clone = Graphics.FromImage(output);

                ImageAttributes cat = new ImageAttributes();

                ColorMatrix gray = new ColorMatrix(new float[][] { new float[] { (float)value, 0f, 0f, 0f, 0f }, new float[] { 0f, 1f, 0f, 0f, 0f }, new float[] { 0f, 0f, 1f, 0f, 0f }, new float[] { 0f, 0f, 0f, 1f, 0f }, new float[] { 0f, 0f, 0f, 0f, 1f } });

                cat.SetColorMatrix(gray);

                clone.DrawImage(input, new Rectangle(0, 0, input.Width, input.Height), 0, 0, input.Width, input.Height, GraphicsUnit.Pixel, cat);
                clone.Dispose();
                cat.Dispose();

                F1.pictureBox2.Image = output;

            }
        }

        private void Green_Scroll(object sender, EventArgs e)
        {
            if (F1.pictureBox1.Image != null) // если изображение в pictureBox1 имеется
            {
                double value = Green.Value * 0.04;
                Bitmap input;
                if (F1.radioButton1.Checked == true)
                    input = new Bitmap(F1.pictureBox1.Image);
                else input = new Bitmap(F1.pictureBox2.Image);

                Bitmap output = new Bitmap(input.Width, input.Height);

                Graphics clone = Graphics.FromImage(output);

                ImageAttributes cat = new ImageAttributes();

                ColorMatrix gray = new ColorMatrix(new float[][] { new float[] { 1f, 0f, 0f, 0f, 0f }, new float[] { 0f, (float)value, 0f, 0f, 0f }, new float[] { 0f, 0f, 1f, 0f, 0f }, new float[] { 0f, 0f, 0f, 1f, 0f }, new float[] { 0f, 0f, 0f, 0f, 1f } });

                cat.SetColorMatrix(gray);

                clone.DrawImage(input, new Rectangle(0, 0, input.Width, input.Height), 0, 0, input.Width, input.Height, GraphicsUnit.Pixel, cat);
                clone.Dispose();
                cat.Dispose();

                F1.pictureBox2.Image = output;

            }
        }

        private void Blue_Scroll(object sender, EventArgs e)
        {

            if (F1.pictureBox1.Image != null) // если изображение в pictureBox1 имеется
            {
                double value = Blue.Value * 0.04;
                Bitmap input;
                if (F1.radioButton1.Checked == true)
                    input = new Bitmap(F1.pictureBox1.Image);
                else input = new Bitmap(F1.pictureBox2.Image);

                Bitmap output = new Bitmap(input.Width, input.Height);

                Graphics clone = Graphics.FromImage(output);

                ImageAttributes cat = new ImageAttributes();

                ColorMatrix gray = new ColorMatrix(new float[][] { new float[] { 1f, 0f, 0f, 0f, 0f }, new float[] { 0f, 1f, 0f, 0f, 0f }, new float[] { 0f, 0f, (float)value, 0f, 0f }, new float[] { 0f, 0f, 0f, 1f, 0f }, new float[] { 0f, 0f, 0f, 0f, 1f } });

                cat.SetColorMatrix(gray);

                clone.DrawImage(input, new Rectangle(0, 0, input.Width, input.Height), 0, 0, input.Width, input.Height, GraphicsUnit.Pixel, cat);
                clone.Dispose();
                cat.Dispose();

                F1.pictureBox2.Image = output;

            }
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Return_Click(object sender, EventArgs e)
        {
            Red.Value = 25;
            Green.Value = 25;
            Blue.Value = 25;
            F1.pictureBox2.Image = F1.pictureBox1.Image;
        }

        private void Swap_Click(object sender, EventArgs e)
        {
            F1.Photo = (Bitmap)F1.pictureBox1.Image;
            F1.pictureBox1.Image = F1.pictureBox2.Image;
        }
    }
}
