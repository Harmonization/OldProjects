using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;
using Tao.Platform.Windows;
using System.Drawing.Imaging;
using Tao.DevIl;
using System.Resources;

namespace Arcan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AnT.InitializeContexts();
        }
        static Random rnd = new Random();
        static Random brnd = new Random();
        static bool SearchList(List <int> a, int find)
        {
            for(int i = 0; i < a.Count; i++)
            {
                if (a[i] == find) return true;
            }
            return false;
        }

        class Bonus
        {
            private int t;
            int otskok = 0;
            public Bonus(int t0 = 35)
            {
                t = t0;
            }
            public void BonusTime(bool b)
            {
                otskok = 0;
                if(b == true) // бонусное время включено 
                {
                    t = 50;
                }
                else
                {
                    t = 35;
                }
            }
            public int get_t() { return t; }
            public void otskokUp() { otskok++; }
            public int get_otskok() { return otskok; }
        }

        static Bonus bonus = new Bonus();

        class Ball
        {
            private bool Wow; // усилен ли мячик
            private double x, y;
            private double r = 1; // радиус сферы
            private bool run = true; // тру - наверх, елс низ
            private bool stop = false; // остановился ли шарик
            public Ball(double x0 = 0, double y0 = -15)
            {
                x = x0;
                y = y0;
                Wow = false;
            }
            public void Move(double dx, double dy)
            {
                if (y < -16) stop = true;
                if (!stop)
                {
                    if (run)
                    {
                        x += dx;
                        y += dy;
                    }
                    else
                    {
                        x -= dx;
                        y -= dy;
                    }
                }
            }
            public void Draw()
            {
                // шарик
                Gl.glBegin(Gl.GL_LINE_STRIP);
                if(Wow == false)
                Gl.glColor3f(1f, 0f, 0f);
                else
                    Gl.glColor3f(0f, 0f, 1f);
                double h = 0.1, k = 0.1;
                for (double i = 0; i <= 2 * Math.PI; i += h)
                {
                    Gl.glBegin(Gl.GL_LINE_STRIP);
                    for (double j = 0; j <= 2 * Math.PI; j += k)
                    {
                        Gl.glVertex3d(x + r * Math.Sin(i) * Math.Cos(j), y + r * Math.Sin(i) * Math.Sin(j), r * Math.Cos(i));

                    }
                    Gl.glEnd();
                    Gl.glBegin(Gl.GL_LINE_STRIP);
                }
                Gl.glEnd();
            }
            public double get_x() { return x; }
            public double get_y() { return y + r; }
            public void vector(bool run_)
            {
                run = run_;
            }
            public void LogicMove()
            {
                if (y <= -15 && x >= platform.get_x0() && x <= platform.get_xn())
                {
                    vector(true);

                    double p0 = platform.get_x0();
                    double p = platform.get_x();
                    double pn = platform.get_xn();

                    double a = (double)rnd.Next(0, 18) / 10;

                    if (x == p0) Dx = -2.5;
                    else if (x == pn) Dx = 2.5;
                    else if (x < p) Dx = -a;
                    else if (x == p) Dx = 0;
                    else if (x > p) Dx = a;
                    
                }

                if (open == false)
                {
                    if (x <= -29)
                    {
                        Dx = -Dx;
                        x += 1.5;
                    }

                    if (x >= 29)
                    {
                        Dx = -Dx;
                        x -= 1.5;
                    }
                }
                else
                {
                    if (x <= -29)
                    {
                        x = 28;
                    }

                    if (x >= 29)
                    {
                        x = -28;
                    }
                }

                if (y >= 18)
                {
                    run = false;
                    Dx = -Dx;
                }

                Move(Dx, Dy);
            }
            public bool Stop()
            {
                return stop;
            }
            public void Wow_On()
            {
                Wow = true;
                timerT = 0;
            }
            public void Wow_Out() { Wow = false; }
            public bool get_Wow() { return Wow; }
        }
        
        class Platform
        {
            private double x;
            private double r = 4; // радиус по x
            public Platform(double x0 = 0)
            {
                x = x0;
            }
            public void MoveRight(double dx)
            {
                if(x + r <= 31)
                x += dx;
            }
            public void MoveLeft(double dx)
            {
                if (x - r >= -31)
                    x += dx;
            }
            public void Draw()
            {

                // платформа
                Gl.glBegin(Gl.GL_LINE_STRIP);
                Gl.glColor3f(0f, 0f, 0f);
                double h = 0.1, k = 0.1;
                double rx = r, ry = 1, rz = 1;
                for (double i = 0; i <= 7; i += h)
                {
                    Gl.glBegin(Gl.GL_LINE_STRIP);
                    for (double j = 0; j <= 7; j += k)
                    {
                        Gl.glVertex3d(x + rx * Math.Sin(i) * Math.Cos(j), -16 + ry *  Math.Sin(i) * Math.Sin(j), rz * Math.Cos(i));

                    }
                    Gl.glEnd();
                    Gl.glBegin(Gl.GL_LINE_STRIP);
                }
                Gl.glEnd();


            }

            public double get_x() { return x; } // координата центра 
            public double get_x0() { return x - r; } // левый край
            public double get_xn() { return x + r; } //правый край
        }
        
        class Block
        {
            private int strength;
            private bool priz; // содержит бонус или нет
            private double x, y;
            private double l = 5; // длина блока 
            bool shot = false; //попали в блок или нет
            public Block(double x0 = -30, double y0 = 15, bool priz_ = false, int strength_ = 1)
            {
                x = x0;
                y = y0;
                priz = priz_;
                strength = strength_;
            }
            public void Draw()
            {

                if (shot == false)
                {
                    // блок
                    double lz = 1, lx = l, ly = 3;
                    double x0 = x, y0 = y, z0 = 0;

                    Gl.glBegin(Gl.GL_LINE_STRIP);
                    Gl.glColor3f(0f, 0f, 1f);
                    Gl.glVertex3d(x0, y0, z0);
                    Gl.glVertex3d(x0, y0 + ly, z0);
                    Gl.glVertex3d(x0 + lx, y0 + ly, z0);
                    Gl.glVertex3d(x0 + lx, y0, z0);
                    Gl.glVertex3d(x0, y0, z0);
                    Gl.glEnd();

                    Gl.glBegin(Gl.GL_LINE_STRIP);
                    Gl.glColor3f(0f, 0f, 1f);
                    Gl.glVertex3d(x0, y0, z0 + lz);
                    Gl.glVertex3d(x0, y0 + ly, z0 + lz);
                    Gl.glVertex3d(x0 + lx, y0 + ly, z0 + lz);
                    Gl.glVertex3d(x0 + lx, y0, z0 + lz);
                    Gl.glVertex3d(x0, y0, z0 + lz);
                    Gl.glEnd();

                    Gl.glBegin(Gl.GL_LINE_STRIP);
                    Gl.glColor3f(1f, 0f, 0f);
                    Gl.glVertex3d(x0, y0, z0);
                    Gl.glVertex3d(x0, y0, z0 + lz);
                    Gl.glEnd();

                    Gl.glBegin(Gl.GL_LINE_STRIP);
                    Gl.glColor3f(1f, 0f, 0f);
                    Gl.glVertex3d(x0, y0 + ly, z0);
                    Gl.glVertex3d(x0, y0 + ly, z0 + lz);
                    Gl.glEnd();

                    Gl.glBegin(Gl.GL_LINE_STRIP);
                    Gl.glColor3f(1f, 0f, 0f);
                    Gl.glVertex3d(x0 + lx, y0 + ly, z0);
                    Gl.glVertex3d(x0 + lx, y0 + ly, z0 + lz);
                    Gl.glEnd();

                    Gl.glBegin(Gl.GL_LINE_STRIP);
                    Gl.glColor3f(1f, 0f, 0f);
                    Gl.glVertex3d(x0 + lx, y0, z0);
                    Gl.glVertex3d(x0 + lx, y0, z0 + lz);
                    Gl.glEnd();


                    // если текстура загружена 
                    if (textureIsLoad)
                    {
                        // включаем режим текстурирования 
                        Gl.glEnable(Gl.GL_TEXTURE_2D);

                        if (strength <= 2)
                        {
                            // включаем режим текстурирования, указывая идентификатор mGlTextureObject 
                            Gl.glBindTexture(Gl.GL_TEXTURE_2D, 2);
                        }
                        else
                        {
                            Gl.glBindTexture(Gl.GL_TEXTURE_2D, 3);
                        }
                        // сохраняем состояние матрицы 
                        Gl.glPushMatrix();
                        // выполняем перемещение для более наглядного представления сцены 
                        Gl.glTranslated(0, 0, 0);
                        // реализуем поворот объекта Gl.glRotated(rot, 0, 1, 0); 
                        // отрисовываем полигон 
                        Gl.glBegin(Gl.GL_QUADS);



                        // указываем поочередно вершины и текстурные координаты 
                        Gl.glVertex3d(x + l, y + 3, 1);
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3d(x + l, y, 1);
                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3d(x, y, 1);
                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3d(x, y + 3, 1);
                        Gl.glTexCoord2f(0, 1);

                        // завершаем отрисовку 
                        Gl.glEnd();

                        Gl.glBegin(Gl.GL_QUADS);
                        Gl.glVertex3d(x + l, y + 3, 0);
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3d(x + l, y, 0);
                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3d(x, y, 0);
                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3d(x, y + 3, 0);
                        Gl.glTexCoord2f(0, 1);
                        Gl.glEnd();

                        Gl.glBegin(Gl.GL_QUADS);
                        Gl.glVertex3d(x + l, y + 3, 0);
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3d(x + l, y, 0);
                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3d(x + l, y, 1);
                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3d(x + l, y + 3, 1);
                        Gl.glTexCoord2f(0, 1);
                        Gl.glEnd();

                        Gl.glBegin(Gl.GL_QUADS);
                        Gl.glVertex3d(x, y + 3, 1);
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3d(x, y, 1);
                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3d(x, y, 0);
                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3d(x, y + 3, 0);
                        Gl.glTexCoord2f(0, 1);
                        Gl.glEnd();

                        Gl.glBegin(Gl.GL_QUADS);
                        Gl.glVertex3d(x + l, y, 1);
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3d(x + l, y, 0);
                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3d(x, y, 0);
                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3d(x, y, 1);
                        Gl.glTexCoord2f(0, 1);
                        Gl.glEnd();

                        Gl.glBegin(Gl.GL_QUADS);
                        Gl.glVertex3d(x + l, y + 3, 0);
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3d(x, y + 3, 1);
                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3d(x, y, 0);
                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3d(x, y + 3, 0);
                        Gl.glTexCoord2f(0, 1);
                        Gl.glEnd();

                        // возвращаем матрицу 
                        Gl.glPopMatrix();
                        // отключаем режим текстурирования 
                        Gl.glDisable(Gl.GL_TEXTURE_2D);
                        // обновляем элемент со сценой 

                    }
                }

            }
            public void Shot() { shot = true; }
            public bool Vision()
            {
                if (shot == false) return true;
                else return false;
            }
            public void set_x(double x_) { x = x_; }
            public void set_y(double y_) { y = y_; }
            public double get_x0() { return x; }
            public double get_xn() { return x + l; }
            public double get_y0() { return y; }
            public bool get_priz() { return priz; }
            public int get_strength() { return strength; }
            public void strengthUp() { strength--; }
        }

        class MultyBlock
        {
            private int bonusblock; // блок с призом
            private int strengthblock; //прочный блок
            private double l = 5; // длина блока
            private double max = 30; // координата x правой стенки 
            private List <Block> blocks = new List<Block>();

            public MultyBlock(double x0 = -30, double y0 = 15)
            {
                bonusblock = brnd.Next(1, 12);
                strengthblock = brnd.Next(1, 12);
                
                double y = y0; // координата y первого блока в строке 
                int find = 0;
                for(double x = x0; x < max; x += l)
                {
                    bool b1; // бонусный ли блок
                    int b2; //прочный ли блок
                    if (bonusblock == find)
                    {
                        b1 = true;
                    }
                    else b1 = false;

                    if (strengthblock == find)
                    {
                        b2 = 8;
                    }
                    else b2 = 2;
                    Block b = new Block(x, y, b1, b2);
                    blocks.Add(b);
                    find++;
                }


            }
            public void Draw()
            {
                for(int i = 0; i < blocks.Count; i++)
                {
                    bool b = blocks[i].Vision();
                    if(b)
                    blocks[i].Draw();
                }
            }
            public void Shot()
            {
                bool Cheat = ball.get_Wow();

                double ballX = ball.get_x();
                double ballY = ball.get_y();

                for(int i = 0; i < blocks.Count; i++)
                {
                    double blocksX0 = blocks[i].get_x0();
                    double blocksXn = blocks[i].get_xn();
                    double blocksY0 = blocks[i].get_y0();



                    //if ((ballY - 2 <= blocksY0 && ballY >= blocksY0) || ((ballY - 2 <= blocksY0 + 3 && ballY >= blocksY0 + 3)))
                    //{
                    //    if(blocksX0 <= ballX - 1 && ballX + 1 <= blocksXn)
                    //    {
                    //        if (blocks[i].get_strength() <= 1)
                    //        {
                    //            blocks[i].Shot();
                    //            blocks[i].set_y(20);
                    //            if (!Cheat)
                    //            {
                    //                ball.vector(false);
                    //                Dx = -Dx;
                    //                blocks[i].strengthUp();
                    //            }
                    //        }
                    //    }
                    //}
                    //if((ballX - 1 <= blocksX0 && blocksX0 <= ballX + 1) || ((ballX - 1 <= blocksXn && blocksXn <= ballX + 1)))
                    //{
                    //    if(blocksY0 <= ballY - 2 && ballY <= blocksY0 + 3)
                    //    {
                    //        if (blocks[i].get_strength() <= 1)
                    //        {

                    //            blocks[i].Shot();
                    //            blocks[i].set_y(20);

                    //            if (!Cheat)
                    //            {
                    //                Dx = -Dx;
                    //            }

                    //            if (blocks[i].get_priz())
                    //            {
                    //                bonus.BonusTime(true);
                    //            }
                    //            bonus.otskokUp();

                    //            if (bonus.get_otskok() > 2)
                    //            {
                    //                bonus.BonusTime(false);
                    //            }
                    //        }
                    //        else
                    //        {
                    //            if (!Cheat)
                    //            {
                    //                Dx = -Dx;
                    //            }
                    //        }
                    //        blocks[i].strengthUp();
                    //    }
                    //}



                        if (ballY - 2 <= blocksY0 && ballY >= blocksY0)
                    {
                        if ((ballX - 1 <= blocksX0 && blocksX0 <= ballX + 1) || (ballX - 1 <= blocksXn && blocksXn <= ballX + 1))
                        {

                            if (blocks[i].get_strength() <= 1)
                            {

                                blocks[i].Shot();
                                blocks[i].set_y(20);

                                if (!Cheat)
                                {
                                    Dx = -Dx;
                                }

                                if (blocks[i].get_priz())
                                {
                                    bonus.BonusTime(true);
                                }
                                bonus.otskokUp();

                                if (bonus.get_otskok() > 2)
                                {
                                    bonus.BonusTime(false);
                                }
                            }
                            else
                            {
                                if (!Cheat)
                                {
                                    Dx = -Dx;
                                }
                            }
                            blocks[i].strengthUp();
                        }
                    }

                    if ((ballY - 2 <= blocksY0 + 3 && ballY >= blocksY0 + 3) || (ballY - 2 <= blocksY0 && ballY >= blocksY0))
                    {
                        if((ballX >= blocksX0 && ballX <= blocksXn))
                        {

                            if (blocks[i].get_strength() <= 1)
                            {
                                blocks[i].Shot();
                                blocks[i].set_y(20);
                                if (!Cheat)
                                {
                                    ball.vector(false);
                                    Dx = -Dx;
                                }
                            }
                            else
                            {
                                if (!Cheat)
                                {
                                    Dx = -Dx;
                                }
                            }
                            blocks[i].strengthUp();
                        }
                    }
                    
                }
            }
            public bool Vision()
            {
                for(int i = 0; i < blocks.Count; i++)
                {
                    if (blocks[i].Vision()) return true;
                }
                return false;
            }
        }

        class SuperBlock
        {
            private List<MultyBlock> blocks = new List<MultyBlock>();
            public SuperBlock(int max)
            {
                double y0 = 15;
                for (int i = 0; i < max; i++)
                {
                    MultyBlock b = new MultyBlock(-30, y0);
                    blocks.Add(b);
                    y0 -= 3;
                }
            }
            public void Draw()
            {
                for(int i = 0; i < blocks.Count; i++)
                {
                    blocks[i].Draw();
                }
            }
            public void Shot()
            {
                for(int i = 0; i < blocks.Count; i++)
                {
                    blocks[i].Shot();
                }
            }
            public bool Final()
            {
                for(int i = 0; i < blocks.Count; i++)
                {
                    if (blocks[i].Vision()) return false;
                }
                return true;
            }
        }

        void Save()
        {
            // Стенки 
            Gl.glBegin(Gl.GL_LINE_STRIP);
            Gl.glColor3f(0f, 1f, 0f);
            Gl.glVertex3d(31, 18, 0);
            Gl.glVertex3d(31, -18, 0);
            Gl.glVertex3d(-31, -18, 0);
            Gl.glVertex3d(-31, 18, 0);
            Gl.glEnd();
            
        }
        
        private double[,] GeometricArray = new double[64, 3];
        private double[,,] ResaultGeometric = new double[64, 64, 3];

        static bool MegaBonus = false;
        static int timerT = 0;
        static Ball ball = new Ball();
        static Platform platform = new Platform();
        SuperBlock blocks = new SuperBlock(width);
        static double Dx = 0, Dy = 1;
        bool timer = false; // запущен ли таймер
        static int width = 1;
        int d = 0;
        static bool open = false;
        //загружена ли текстура 
        static private bool textureIsLoad = false;
        // имя текстуры 
        public string texture_name = "";
        // идентификатор текстуры 
        public int imageId = 0, imageId1 = 1, imageId2 = 2;
        // текстурный объект 
        static public uint mGlTextureObject = 0, mGlTextureObject1 = 1, mGlTextureObject2 = 2;

        void loadpicture()
        {

            // создаем изображение с идентификатором imageId 
            Il.ilGenImages(1, out imageId);
            // делаем изображение текущим 
            Il.ilBindImage(imageId);
            // адрес изображения полученный с помощью окна выбора файла 
            string url;
            if (checkBox1.Checked == false)
                url = "bg32.jpg";
            else url = "star4.jpeg";

            // пробуем загрузить изображение 
            if (Il.ilLoadImage(url))
            {
                // если загрузка прошла успешно 
                // сохраняем размеры изображения 
                int width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
                int height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);
                // определяем число бит на пиксель 
                int bitspp = Il.ilGetInteger(Il.IL_IMAGE_BITS_PER_PIXEL);
                switch (bitspp)
                // в зависимости от полученного результата 
                {
                    // создаем текстуру, используя режим GL_RGB или GL_RGBA 
                    case 24:
                        mGlTextureObject = MakeGlTexture(Gl.GL_RGB, Il.ilGetData(), width, height);
                        break;
                    case 32:
                        mGlTextureObject = MakeGlTexture(Gl.GL_RGBA, Il.ilGetData(), width, height);
                        break;
                }
                // активируем флаг, сигнализирующий загрузку текстуры 
                textureIsLoad = true;
                // очищаем память 
                Il.ilDeleteImages(1, ref imageId);
            }

        }

        void Loaded()
        {

            // создаем изображение с идентификатором imageId 
            Il.ilGenImages(2, out imageId1);
            // делаем изображение текущим 
            Il.ilBindImage(imageId1);
            // адрес изображения полученный с помощью окна выбора файла 
            string url = "block3.jpg";

            // пробуем загрузить изображение 
            if (Il.ilLoadImage(url))
            {
                // если загрузка прошла успешно 
                // сохраняем размеры изображения 
                int width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
                int height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);
                // определяем число бит на пиксель 
                int bitspp = Il.ilGetInteger(Il.IL_IMAGE_BITS_PER_PIXEL);
                switch (bitspp)
                // в зависимости от полученного результата 
                {
                    // создаем текстуру, используя режим GL_RGB или GL_RGBA 
                    case 24:
                        mGlTextureObject = MakeGlTexture(Gl.GL_RGB, Il.ilGetData(), width, height);
                        break;
                    case 32:
                        mGlTextureObject = MakeGlTexture(Gl.GL_RGBA, Il.ilGetData(), width, height);
                        break;
                }
                // активируем флаг, сигнализирующий загрузку текстуры 
                textureIsLoad = true;
                // очищаем память 
                Il.ilDeleteImages(2, ref imageId1);
            }

        }

        void LoadStrength()
        {

            // создаем изображение с идентификатором imageId 
            Il.ilGenImages(3, out imageId2);
            // делаем изображение текущим 
            Il.ilBindImage(imageId2);
            // адрес изображения полученный с помощью окна выбора файла 
            string url = "block4.jpg";

            // пробуем загрузить изображение 
            if (Il.ilLoadImage(url))
            {
                // если загрузка прошла успешно 
                // сохраняем размеры изображения 
                int width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
                int height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);
                // определяем число бит на пиксель 
                int bitspp = Il.ilGetInteger(Il.IL_IMAGE_BITS_PER_PIXEL);
                switch (bitspp)
                // в зависимости от полученного результата 
                {
                    // создаем текстуру, используя режим GL_RGB или GL_RGBA 
                    case 24:
                        mGlTextureObject = MakeGlTexture(Gl.GL_RGB, Il.ilGetData(), width, height);
                        break;
                    case 32:
                        mGlTextureObject = MakeGlTexture(Gl.GL_RGBA, Il.ilGetData(), width, height);
                        break;
                }
                // активируем флаг, сигнализирующий загрузку текстуры 
                textureIsLoad = true;
                // очищаем память 
                Il.ilDeleteImages(3, ref imageId2);
            }

        }

        // создание текстуры фона в памяти openGL 
        private static uint MakeGlTexture( int Format, IntPtr pixels, int w, int h)
        {
            // идентификатор текстурного объекта 
            uint texObject;
            // генерируем текстурный объект 
            Gl.glGenTextures(1, out texObject);
            // устанавливаем режим упаковки пикселей 
            Gl.glPixelStorei( Gl.GL_UNPACK_ALIGNMENT, 1);
            // создаем привязку к только что созданной текстуре 
            Gl.glBindTexture( Gl.GL_TEXTURE_2D, texObject);
            // устанавливаем режим фильтрации и повторения текстуры 
            Gl.glTexParameteri( Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
            Gl.glTexParameteri( Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);
            Gl.glTexParameteri( Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri( Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexEnvf( Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_REPLACE);
            // создаем RGB или RGBA текстуру 
            switch (Format) 
            { 
                case Gl.GL_RGB: 
                Gl.glTexImage2D( Gl.GL_TEXTURE_2D, 0, Gl.GL_RGB, w, h, 0, Gl.GL_RGB, Gl.GL_UNSIGNED_BYTE, pixels);
                    break;
                case Gl.GL_RGBA: Gl.glTexImage2D( Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, w, h, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, pixels);
                    break;
            }
            // возвращаем идентификатор текстурного объекта 
            return texObject;
        }

        private void Draw()
        {
            // если текстура загружена 
            if (textureIsLoad)
            {
                // включаем режим текстурирования 
                Gl.glEnable( Gl.GL_TEXTURE_2D);
                // включаем режим текстурирования, указывая идентификатор mGlTextureObject 
                Gl.glBindTexture( Gl.GL_TEXTURE_2D, mGlTextureObject1);
                // сохраняем состояние матрицы 
                Gl.glPushMatrix();
                // выполняем перемещение для более наглядного представления сцены 
                Gl.glTranslated(0, -1, -5);
                // реализуем поворот объекта Gl.glRotated(rot, 0, 1, 0); 
                // отрисовываем полигон 
                Gl.glBegin( Gl.GL_QUADS);
                if (checkBox1.Checked == false)
                {
                    // указываем поочередно вершины и текстурные координаты 
                    Gl.glVertex3d(41, 22, 0);
                    Gl.glTexCoord2f(0, 0);
                    Gl.glVertex3d(41, -21, 0);
                    Gl.glTexCoord2f(1, 0);
                    Gl.glVertex3d(-41, -21, 0);
                    Gl.glTexCoord2f(1, 1);
                    Gl.glVertex3d(-41, 22, 0);
                    Gl.glTexCoord2f(0, 1);
                }
                else
                {
                    // указываем поочередно вершины и текстурные координаты 
                    Gl.glVertex3d(41, 22, 0);
                    Gl.glTexCoord2f(0, 0);
                    Gl.glVertex3d(41, -16, 0);
                    Gl.glTexCoord2f(1, 0);
                    Gl.glVertex3d(-41, -16, 0);
                    Gl.glTexCoord2f(1, 1);
                    Gl.glVertex3d(-41, 22, 0);
                    Gl.glTexCoord2f(0, 1);
                }
                // завершаем отрисовку 
                Gl.glEnd();
                // возвращаем матрицу 
                Gl.glPopMatrix();
                // отключаем режим текстурирования 
                Gl.glDisable( Gl.GL_TEXTURE_2D);
                // обновляем элемент со сценой 
                AnT.Invalidate();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel2.Hide();
            panel3.Hide();
            width = trackBar1.Value;
            trackBar1.Focus();
            label10.Hide();
            panel1.Location = new Point(0, 0);
            panel1.Size = new Size(1946, 1106);
            labeltime.Hide();

            // инициализация Glut 
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);

            //инициализация Il
            Il.ilInit();
            Il.ilEnable(Il.IL_ORIGIN_SET);

            // очистка окна 
            Gl.glClearColor(255, 255, 255, 1);
            // установка порта вывода в соответствии с размерами элемента anT 
            Gl.glViewport(0, 0, AnT.Width, AnT.Height);
            // настройка проекции 
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(45, (float)AnT.Width / (float)AnT.Height, 0.1, 200);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            // настройка параметров OpenGL для визуализации 
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            //Gl.glEnable(Gl.GL_LIGHTING);
            //Gl.glEnable(Gl.GL_LIGHT0);
        }

        private void AnT_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                if (MegaBonus == false)
                    ball.Wow_On();
                MegaBonus = true;
            }


            if(e.KeyCode == Keys.Enter)
            {
                if (timer == false)
                {
                    RenderTime.Start();
                    timer = true;
                    panel1.Hide();
                    width = trackBar1.Value;
                    blocks = new SuperBlock(width);
                    label10.Hide();
                    loadpicture(); //загрузка фона
                    Loaded();
                    LoadStrength();

                    if (checkBox1.Checked)
                    {
                        panel3.BackgroundImage = new Bitmap("star.jpg");
                    }
                }
                else
                {
                    RenderTime.Stop();
                    timer = false;
                    panel1.Show();
                }
            }

            double x = platform.get_x();
            if (e.KeyCode == Keys.D)
            {
                platform.MoveRight(4);
            }
            else if (e.KeyCode == Keys.A)
            {
                platform.MoveLeft(-4);
            }

            if (e.KeyCode == Keys.E)
            {
                platform.MoveRight(1);
            }
            else if (e.KeyCode == Keys.Q)
            {
                platform.MoveLeft(-1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void panel1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                panel1.Hide();
                AnT.Focus();
                label10.Show();
                label10.Location = new Point(300, 250);

                // очистка буфера цвета и буфера глубины 
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
                Gl.glClearColor(255, 255, 255, 1);
                // очищение текущей матрицы 
                Gl.glLoadIdentity();

                // установка положения камеры (наблюдателя). Как видно из кода, 
                // дополнительно на положение наблюдателя по оси Z влияет значение, 
                // установленное в ползунке, доступном для пользователя. 

                // приближение 
                Gl.glTranslated(0, 0, -45);
                // 2 поворота (углы rot_1 и rot_2) 
                Gl.glRotated(0, 1, 0, 0);
                Gl.glRotated(0, 0, 0, 1);

                // устанавливаем размер точек, равный 5 
                Gl.glPointSize(5.0f);

                Save();

                ball.Draw();
                ball.LogicMove();
                platform.Draw();
                blocks.Shot();
                blocks.Draw();

                if (blocks.Final())
                {
                    RenderTime.Stop();
                    panel2.Show();
                }

                // возвращаем сохраненную матрицу
                Gl.glPopMatrix();
                // завершаем рисование
                Gl.glFlush();
                // обновляем элемент AnT 
                AnT.Invalidate();
            }
        }

        private void trackBar1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                panel1.Hide();
                AnT.Focus();
                label10.Show();
                label10.Location = new Point(300, 250);

                // очистка буфера цвета и буфера глубины 
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
                Gl.glClearColor(255, 255, 255, 1);
                // очищение текущей матрицы 
                Gl.glLoadIdentity();

                // установка положения камеры (наблюдателя). Как видно из кода, 
                // дополнительно на положение наблюдателя по оси Z влияет значение, 
                // установленное в ползунке, доступном для пользователя. 

                // приближение 
                Gl.glTranslated(0, 0, -45);
                // 2 поворота (углы rot_1 и rot_2) 
                Gl.glRotated(0, 1, 0, 0);
                Gl.glRotated(0, 0, 0, 1);

                // устанавливаем размер точек, равный 5 
                Gl.glPointSize(5.0f);

                Save();

                ball.Draw();
                ball.LogicMove();
                platform.Draw();
                blocks.Shot();
                blocks.Draw();

                if (blocks.Final())
                {
                    RenderTime.Stop();
                    panel2.Show();
                }

                // возвращаем сохраненную матрицу
                Gl.glPopMatrix();
                // завершаем рисование
                Gl.glFlush();
                // обновляем элемент AnT 
                AnT.Invalidate();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) d = -45;
            else d = 0;
        }

        private void checkBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                panel1.Hide();
                AnT.Focus();
                label10.Show();
                label10.Location = new Point(300, 250);

                // очистка буфера цвета и буфера глубины 
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
                Gl.glClearColor(255, 255, 255, 1);
                // очищение текущей матрицы 
                Gl.glLoadIdentity();

                // установка положения камеры (наблюдателя). Как видно из кода, 
                // дополнительно на положение наблюдателя по оси Z влияет значение, 
                // установленное в ползунке, доступном для пользователя. 

                // приближение 
                Gl.glTranslated(0, 0, -45);
                // 2 поворота (углы rot_1 и rot_2) 
                Gl.glRotated(0, 1, 0, 0);
                Gl.glRotated(0, 0, 0, 1);

                // устанавливаем размер точек, равный 5 
                Gl.glPointSize(5.0f);

                Save();

                ball.Draw();
                ball.LogicMove();
                platform.Draw();
                blocks.Shot();
                blocks.Draw();

                if (blocks.Final())
                {
                    RenderTime.Stop();
                    panel2.Show();
                }

                // возвращаем сохраненную матрицу
                Gl.glPopMatrix();
                // завершаем рисование
                Gl.glFlush();
                // обновляем элемент AnT 
                AnT.Invalidate();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void checkBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                panel1.Hide();
                AnT.Focus();
                label10.Show();
                label10.Location = new Point(300, 250);

                // очистка буфера цвета и буфера глубины 
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
                Gl.glClearColor(255, 255, 255, 1);
                // очищение текущей матрицы 
                Gl.glLoadIdentity();

                // установка положения камеры (наблюдателя). Как видно из кода, 
                // дополнительно на положение наблюдателя по оси Z влияет значение, 
                // установленное в ползунке, доступном для пользователя. 

                // приближение 
                Gl.glTranslated(0, 0, -45);
                // 2 поворота (углы rot_1 и rot_2) 
                Gl.glRotated(0, 1, 0, 0);
                Gl.glRotated(0, 0, 0, 1);

                // устанавливаем размер точек, равный 5 
                Gl.glPointSize(5.0f);

                Save();

                ball.Draw();
                ball.LogicMove();
                platform.Draw();
                blocks.Shot();
                blocks.Draw();

                if (blocks.Final())
                {
                    RenderTime.Stop();
                    panel2.Show();
                }

                // возвращаем сохраненную матрицу
                Gl.glPopMatrix();
                // завершаем рисование
                Gl.glFlush();
                // обновляем элемент AnT 
                AnT.Invalidate();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false) open = true;
            else open = false;
        }
        
        private void RenderTime_Tick(object sender, EventArgs e)
        {
            if(ball.get_Wow())
            {
                timerT++;
                if (timerT >= 100)
                {
                    ball.Wow_Out();
                }
            }

            int tt = bonus.get_t();
            RenderTime.Interval = tt;
            if (tt == 35) labeltime.Hide();
            else labeltime.Show();

            // очистка буфера цвета и буфера глубины 
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glClearColor(255, 255, 255, 1);
            // очищение текущей матрицы 
            Gl.glLoadIdentity();

            // установка положения камеры (наблюдателя). Как видно из кода, 
            // дополнительно на положение наблюдателя по оси Z влияет значение, 
            // установленное в ползунке, доступном для пользователя. 

            // приближение 
            Gl.glTranslated(0, 0, -45);
            // 2 поворота (углы rot_1 и rot_2) 
            Gl.glRotated(d, 1, 0, 0);
            Gl.glRotated(0, 0, 0, 1);

            // устанавливаем размер точек, равный 5 
            Gl.glPointSize(5.0f);

            Save();

            ball.Draw();
            ball.LogicMove();
            platform.Draw();
            blocks.Shot();
            blocks.Draw();

            Draw();

            if(blocks.Final())
            {
                RenderTime.Stop();
                panel2.Show();
                panel2.Location = new Point(0, 0);
                panel2.Size = new Size(1946, 1106);
                panel2.BringToFront();
                panel2.BackgroundImage = new Bitmap("C:\\Users\\inter\\source\\repos\\Arcan\\picture\\bg32.jpg");
            }

            if(ball.Stop())
            {
                RenderTime.Stop();
                panel3.Show();
                panel3.Location = new Point(-25, -25);
                panel3.Size = new Size(1946, 1106);
                button5.Focus();
            }

            // возвращаем сохраненную матрицу
            Gl.glPopMatrix();
            // завершаем рисование
            Gl.glFlush();
            // обновляем элемент AnT 
            AnT.Invalidate();
        }
    }
}
