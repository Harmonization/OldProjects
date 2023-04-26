using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using org.mariuszgromada.math.mxparser;
using Tao.FreeGlut;
using Tao.OpenGl;
using Tao.Platform.Windows;
using MathNet.Numerics.LinearAlgebra.Double;
using System.IO;

namespace Graph3D
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AnT.InitializeContexts();
            this.MouseWheel += new MouseEventHandler(AnT_MouseWheel);
        }

        GlutInit GL;
        static bool param = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            GL = new GlutInit(AnT, checkBox, comboBox, Func.Text);
            GL.StartGlut();

            comboBox.Text = "Сетка";
            ColorBox.Text = "Градиент 1";
            FuncBox.Text = "Явная";
            GL.Draw();
        }

        class GlutInit
        {
            public double h, k;
            public int value = 0;
            public int rot_1 = 0, rot_2 = 0;
            public double a, b, c, d;
            SimpleOpenGlControl AnT;
            CheckBox checkBox;
            ToolStripComboBox comboBox;
            public int color = 1;

            public List<List<double>> FUNC = new List<List<double>>();

            List<List<double>> FUNCX = new List<List<double>>();
            List<List<double>> FUNCY = new List<List<double>>();
            List<List<double>> FUNCZ = new List<List<double>>();

            Functions F;
            Functions Fp;

            public GlutInit(SimpleOpenGlControl AnT_, CheckBox checkBox_, ToolStripComboBox comboBox_, string func, double h_ = 0.05, double k_ = 0.05, double a_ = -1, double b_ = 1, double c_ = -1, double d_ = 1)
            {
                h = h_;
                k = k_;
                a = a_;
                b = b_;
                c = c_;
                d = d_;
                AnT = AnT_;
                checkBox = checkBox_;
                comboBox = comboBox_;
                F = new Functions(func, a, b);
                Fp = new Functions(func, a, b);

                newMassiv();
            }

            public void StartGlut()
            {
                // инициализация Glut 
                Glut.glutInit();
                Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
                // очистка окна 
                Gl.glClearColor(255, 255, 255, 1);
                // установка порта вывода в соответствии с размерами элемента anT 
                Gl.glViewport(0, 0, AnT.Width, AnT.Height);
                // настройка проекции 
                Gl.glMatrixMode(Gl.GL_PROJECTION);
                Gl.glLoadIdentity();
                Glu.gluPerspective(45, (float)AnT.Width / (float)AnT.Height, 0.1, 200);
                Gl.glMatrixMode(Gl.GL_MODELVIEW); Gl.glLoadIdentity();
                // настройка параметров OpenGL для визуализации 
                Gl.glEnable(Gl.GL_DEPTH_TEST);
                //Gl.glEnable(Gl.GL_LIGHTING);
                //Gl.glEnable(Gl.GL_LIGHT0);
            }

            public void newFunc(string Func)
            {
                F.newFunc(Func);
            }

            public void newParamFunc(string FuncX, string FuncY, string FuncZ)
            {
                Fp.newFunc(FuncX, FuncY, FuncZ);
            }

            public void newMassiving()
            {
                FUNC.Clear();
                for (double i = a; i <= b; i += h)
                {
                    List<double> a = new List<double>();
                    for (double j = c; j <= d; j += k)
                    {
                        a.Add(F.Func(i, j));
                    }
                    FUNC.Add(a);
                }
            }

            public void newParamMassiv()
            {
                FUNCX.Clear();
                for (double i = a; i <= b; i += h)
                {
                    List<double> a = new List<double>();
                    for (double j = c; j <= d; j += k)
                    {
                        a.Add(Fp.FuncX(i, j));
                    }
                    FUNCX.Add(a);
                }

                FUNCY.Clear();
                for (double i = a; i <= b; i += h)
                {
                    List<double> a = new List<double>();
                    for (double j = c; j <= d; j += k)
                    {
                        a.Add(Fp.FuncY(i, j));
                    }
                    FUNCY.Add(a);
                }

                FUNCZ.Clear();
                for (double i = a; i <= b; i += h)
                {
                    List<double> a = new List<double>();
                    for (double j = c; j <= d; j += k)
                    {
                        a.Add(Fp.FuncZ(i, j));
                    }
                    FUNCZ.Add(a);
                }
            }

            public void newMassiv()
            {
                if (!param)
                    newMassiving();
                else
                    newParamMassiv();
            }

            public void Drawing()
            {
                // два параметра, которые мы будем использовать для непрерывного вращения сцены вокруг 2 координатных осей 

                // очистка буфера цвета и буфера глубины 
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
                Gl.glClearColor(255, 255, 255, 1);
                // очищение текущей матрицы 
                Gl.glLoadIdentity();

                // установка положения камеры (наблюдателя). Как видно из кода, 
                // дополнительно на положение наблюдателя по оси Z влияет значение, 
                // установленное в ползунке, доступном для пользователя. 

                // таким образом, при перемещении ползунка, наблюдатель будет отдаляться или приближаться к объекту наблюдения 
                Gl.glTranslated(0, 0, -7 - value);
                // 2 поворота (углы rot_1 и rot_2) 
                Gl.glRotated(rot_1, 1, 0, 0);
                Gl.glRotated(rot_2, 0, 1, 0);

                // устанавливаем размер точек, равный 5 
                Gl.glPointSize(5.0f);

                // условие switch определяет установленный режим отображения, на основе выбранного пункта элемента 
                // comboBox, установленного в форме программы 

                if (checkBox.Checked == true)
                {
                    Gl.glLineWidth(5.0f);

                    Gl.glColor3f(255f, 0f, 0f);
                    Gl.glBegin(Gl.GL_LINE_STRIP);
                    Gl.glVertex3d(a, 0, 0);
                    Gl.glVertex3d(b, 0, 0);
                    Gl.glEnd();

                    Gl.glColor3f(0f, 255f, 0f);
                    Gl.glBegin(Gl.GL_LINE_STRIP);
                    Gl.glVertex3d(0, c, 0);
                    Gl.glVertex3d(0, d, 0);
                    Gl.glEnd();

                    Gl.glColor3f(0f, 0f, 255f);
                    Gl.glBegin(Gl.GL_LINE_STRIP);
                    Gl.glVertex3d(0, 0, -2);
                    Gl.glVertex3d(0, 0, 2);
                    Gl.glEnd();

                    Gl.glLineWidth(1.0f);
                }
                switch (comboBox.SelectedIndex)
                {
                    case 0:
                        // отображение в виде точек 
                        {
                            // режим вывода геометрии - точки 
                            Gl.glBegin(Gl.GL_POINTS);
                            // выводим всю ранее просчитанную геометрию объекта 
                            int l1 = 0, l2 = 0;
                            for (double i = a; i <= b; i += h)
                            {
                                l2 = 0;
                                for (double j = c; j <= d; j += k)
                                {
                                    if (color == 1)
                                        Gl.glColor3f((float)(i - a), (float)(j - c), 0.4f);
                                    else if (color == 2)
                                        Gl.glColor3f(0.4f, (float)(i - a), (float)(j - c));
                                    else if (color == 3)
                                        Gl.glColor3f((float)(j - c), 0.4f, (float)(i - a));
                                    else if (color == 4)
                                        Gl.glColor3f((float)(j - c), 0.4f, (float)(j + k));
                                    else if (color == 5)
                                        Gl.glColor3f((float)(i + b), (float)(i - a), 0.5f);
                                    // отрисовка точки 
                                    Gl.glVertex3d(i, j, FUNC[l1][l2]);
                                    l2++;
                                }
                                l1++;
                            }
                            // завершаем режим рисования 
                            Gl.glEnd();
                            break;
                        }
                    case 1:
                        // отображение объекта в сеточном режиме, используя режим GL_LINES_STRIP 
                        {
                            // устанавливаем режим отрисовки линиями (последовательность линий) 
                            Gl.glBegin(Gl.GL_LINE_STRIP);
                            int l1 = 0, l2 = 0;
                            for (double i = a; i <= b; i += h)
                            {
                                l2 = 0;
                                Gl.glBegin(Gl.GL_LINE_STRIP);
                                for (double j = c; j <= d; j += k)
                                {
                                    if (color == 1)
                                        Gl.glColor3f((float)(i - a), (float)(j - c), 0.4f);
                                    else if (color == 2)
                                        Gl.glColor3f(0.4f, (float)(i - a), (float)(j - c));
                                    else if (color == 3)
                                        Gl.glColor3f((float)(j - c), 0.4f, (float)(i - a));
                                    else if (color == 4)
                                        Gl.glColor3f((float)(j - c), 0.4f, (float)(j + k));
                                    else if (color == 5)
                                        Gl.glColor3f((float)(i + b), (float)(i - a), 0.5f);
                                    Gl.glVertex3d(i, j, FUNC[l1][l2]);
                                    if (i == a)
                                    {
                                        Gl.glVertex3d(i + h, j, FUNC[l1 + 1][l2]);
                                        if (j + k <= d)
                                        {
                                            Gl.glVertex3d(i + h, j + k, FUNC[l1 + 1][l2 + 1]);
                                            Gl.glVertex3d(i, j + k, FUNC[l1][l2 + 1]);
                                            Gl.glVertex3d(i, j, FUNC[l1][l2]);
                                        }
                                        else
                                        {
                                            Gl.glVertex3d(i, j, FUNC[l1][l2]);
                                        }
                                    }
                                    if (i + h <= b)
                                    {
                                        Gl.glVertex3d(i + h, j, FUNC[l1 + 1][l2]);
                                        if (j + k <= d)
                                        {
                                            Gl.glVertex3d(i + h, j + k, FUNC[l1 + 1][l2 + 1]);
                                        }
                                        else
                                        {
                                            Gl.glVertex3d(i, j, FUNC[l1][l2]);
                                        }
                                    }
                                    else
                                    {
                                        if (j + k <= d)
                                        {
                                            Gl.glVertex3d(i, j + k, FUNC[l1][l2 + 1]);
                                        }
                                        else
                                        {
                                            Gl.glVertex3d(i - h, j, FUNC[l1 - 1][l2]);
                                        }
                                    }
                                    l2++;
                                }
                                Gl.glEnd();
                                Gl.glBegin(Gl.GL_LINE_STRIP);
                                l1++;
                            }
                            Gl.glEnd();
                            break;
                        }
                    case 2:
                        // отрисовка оболочки с расчетом нормалей для корректного затенения граней объекта 
                        {
                            Gl.glBegin(Gl.GL_QUADS);
                            // режим отрисовки полигонов состоящих из 4 вершин 
                            int l1 = 0, l2 = 0;
                            for (double i = a; i <= b; i += h)
                            {
                                l2 = 0;
                                for (double j = c; j <= d; j += k)
                                {
                                    if (color == 1)
                                        Gl.glColor3f((float)(i - a), (float)(j - c), 0.4f);
                                    else if (color == 2)
                                        Gl.glColor3f(0.4f, (float)(i - a), (float)(j - c));
                                    else if (color == 3)
                                        Gl.glColor3f((float)(j - c), 0.4f, (float)(i - a));
                                    else if (color == 4)
                                        Gl.glColor3f((float)(j - c), 0.4f, (float)(j + k));
                                    else if (color == 5)
                                        Gl.glColor3f((float)(i + b), (float)(i - a), 0.5f);
                                    // вспомогательные переменные для более наглядного использования кода при расчете нормалей 
                                    double x1 = 0, x2 = 0, x3 = 0, x4 = 0, y1 = 0, y2 = 0, y3 = 0, y4 = 0, z1 = 0, z2 = 0, z3 = 0, z4 = 0;
                                    // первая вершина 
                                    x1 = i;
                                    y1 = j;
                                    z1 = FUNC[l1][l2];
                                    if (i + h <= b)
                                    // если текущий ax не последний 
                                    {
                                        // берем следующую точку последовательности 
                                        x2 = i + h;
                                        y2 = j;
                                        z2 = FUNC[l1 + 1][l2];
                                        if (j + k <= d)
                                        // если текущий bx не последний 
                                        {
                                            // берем следующую точку последовательности и следующий медиан 
                                            x3 = i + h;
                                            y3 = j + k;
                                            z3 = FUNC[l1 + 1][l2 + 1];
                                            // точка, соответствующая по номеру, только на соседнем медиане 
                                            x4 = i;
                                            y4 = j + k;
                                            z4 = FUNC[l1][l2 + 1];
                                        }
                                        else
                                        {
                                            // если это последний медиан, то в качестве след. мы берем начальный (замыкаем геометрию фигуры) 
                                            x3 = i + h;
                                            y3 = j;
                                            z3 = FUNC[l1 + 1][l2];
                                            x4 = i;
                                            y4 = j;
                                            z4 = FUNC[l1][l2];
                                        }
                                    }
                                    else
                                    // данный элемент ax последний, следовательно, мы будем использовать начальный (нулевой) вместо данного ax
                                    {
                                        // следующей точкой будет нулевая ax
                                        x2 = i - h;
                                        y2 = j;
                                        z2 = FUNC[l1 - 1][l2];
                                        if (j + k <= d)
                                        {
                                            x3 = i - h;
                                            y3 = j + k;
                                            z3 = FUNC[l1 - 1][l2 + 1];
                                            x4 = i;
                                            y4 = j + h;
                                            z4 = FUNC[l1][l2 + 1];
                                        }
                                        else
                                        {
                                            x3 = i - h;
                                            y3 = j - k;
                                            z3 = FUNC[l1 - 1][l2 - 1];
                                            x4 = i;
                                            y4 = j - k;
                                            z4 = FUNC[l1][l2 - 1];
                                        }
                                    }
                                    // переменные для расчета нормали 
                                    double n1 = 0, n2 = 0, n3 = 0;
                                    // нормаль будем рассчитывать как векторное произведение граней полигона 
                                    // для нулевого элемента нормаль мы будем считать немного по-другому.
                                    // на самом деле разница в расчете нормали актуальна только для первого и последнего полигона на медиане 
                                    if (i == -1)
                                    // при расчете нормали для ax мы будем использовать точки 1,2,3 
                                    {
                                        n1 = (y2 - y1) * (z3 - z1) - (y3 - y1) * (z2 - z1);
                                        n2 = (z2 - z1) * (x3 - x1) - (z3 - z1) * (x2 - x1);
                                        n3 = (x2 - x1) * (y3 - y1) - (x3 - x1) * (y2 - y1);
                                    }
                                    else
                                    // для остальных - 1,3,4
                                    {
                                        n1 = (y4 - y3) * (z1 - z3) - (y1 - y3) * (z4 - z3);
                                        n2 = (z4 - z3) * (x1 - x3) - (z1 - z3) * (x4 - x3);
                                        n3 = (x4 - x3) * (y1 - y3) - (x1 - x3) * (y4 - y3);
                                    }
                                    // если не включен режим GL_NORMILIZE, то мы должны в обязательном порядке
                                    // произвести нормализацию вектора нормали перед тем как передать информацию о нормали 
                                    double n5 = (double)Math.Sqrt(n1 * n1 + n2 * n2 + n3 * n3);
                                    n1 /= (n5 + 0.01);
                                    n2 /= (n5 + 0.01);
                                    n3 /= (n5 + 0.01);
                                    // передаем информацию о нормали 
                                    Gl.glNormal3d(-n1, -n2, -n3);
                                    // передаем 4 вершины для отрисовки полигона 
                                    Gl.glVertex3d(x1, y1, z1);
                                    Gl.glVertex3d(x2, y2, z2);
                                    Gl.glVertex3d(x3, y3, z3);
                                    Gl.glVertex3d(x4, y4, z4);
                                    l2++;
                                }
                                l1++;
                            }
                            // завершаем выбранный режим рисования полигонов 
                            Gl.glEnd();
                            break;
                        }
                }
                // возвращаем сохраненную матрицу
                Gl.glPopMatrix();
                // завершаем рисование
                Gl.glFlush();
                // обновляем элемент AnT 
                AnT.Invalidate();
            }

            public void ParamDraw()
            {
                // два параметра, которые мы будем использовать для непрерывного вращения сцены вокруг 2 координатных осей 

                // очистка буфера цвета и буфера глубины 
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
                Gl.glClearColor(255, 255, 255, 1);
                // очищение текущей матрицы 
                Gl.glLoadIdentity();

                // установка положения камеры (наблюдателя). Как видно из кода, 
                // дополнительно на положение наблюдателя по оси Z влияет значение, 
                // установленное в ползунке, доступном для пользователя. 

                // таким образом, при перемещении ползунка, наблюдатель будет отдаляться или приближаться к объекту наблюдения 
                Gl.glTranslated(0, 0, -7 - value);
                // 2 поворота (углы rot_1 и rot_2) 
                Gl.glRotated(rot_1, 1, 0, 0);
                Gl.glRotated(rot_2, 0, 1, 0);

                // устанавливаем размер точек, равный 5 
                Gl.glPointSize(5.0f);

                // условие switch определяет установленный режим отображения, на основе выбранного пункта элемента 
                // comboBox, установленного в форме программы 

                if (checkBox.Checked == true)
                {
                    Gl.glLineWidth(5.0f);

                    Gl.glColor3f(255f, 0f, 0f);
                    Gl.glBegin(Gl.GL_LINE_STRIP);
                    Gl.glVertex3d(-5, 0, 0);
                    Gl.glVertex3d(5, 0, 0);
                    Gl.glEnd();

                    Gl.glColor3f(0f, 255f, 0f);
                    Gl.glBegin(Gl.GL_LINE_STRIP);
                    Gl.glVertex3d(0, -5, 0);
                    Gl.glVertex3d(0, 5, 0);
                    Gl.glEnd();

                    Gl.glColor3f(0f, 0f, 255f);
                    Gl.glBegin(Gl.GL_LINE_STRIP);
                    Gl.glVertex3d(0, 0, -5);
                    Gl.glVertex3d(0, 0, 5);
                    Gl.glEnd();

                    Gl.glLineWidth(1.0f);
                }
                switch (comboBox.SelectedIndex)
                {
                    case 0:
                        // отображение в виде точек 
                        {
                            // режим вывода геометрии - точки 
                            Gl.glBegin(Gl.GL_POINTS);
                            // выводим всю ранее просчитанную геометрию объекта 
                            int l1 = 0, l2 = 0;
                            for (double i = a; i <= b; i += h)
                            {
                                l2 = 0;
                                for (double j = c; j <= d; j += k)
                                {
                                    if (color == 1)
                                        Gl.glColor3f((float)(i - a), (float)(j - c), 0.4f);
                                    else if (color == 2)
                                        Gl.glColor3f(0.4f, (float)(i - a), (float)(j - c));
                                    else if (color == 3)
                                        Gl.glColor3f((float)(j - c), 0.4f, (float)(i - a));
                                    else if (color == 4)
                                        Gl.glColor3f((float)(j - c), 0.4f, (float)(j + k));
                                    else if (color == 5)
                                        Gl.glColor3f((float)(i + b), (float)(i - a), 0.5f);
                                    // отрисовка точки 
                                    Gl.glVertex3d(FUNCX[l1][l2], FUNCY[l1][l2], FUNCZ[l1][l2]);
                                    l2++;
                                }
                                l1++;
                            }
                            // завершаем режим рисования 
                            Gl.glEnd();
                            break;
                        }
                    case 1:
                        // отображение объекта в сеточном режиме, используя режим GL_LINES_STRIP 
                        {
                            // устанавливаем режим отрисовки линиями (последовательность линий) 
                            Gl.glBegin(Gl.GL_LINE_STRIP);
                            int l1 = 0, l2 = 0;
                            for (double i = a; i <= b; i += h)
                            {
                                l2 = 0;
                                Gl.glBegin(Gl.GL_LINE_STRIP);
                                for (double j = c; j <= d; j += k)
                                {
                                    if (color == 1)
                                        Gl.glColor3f((float)(i - a), (float)(j - c), 0.4f);
                                    else if (color == 2)
                                        Gl.glColor3f(0.4f, (float)(i - a), (float)(j - c));
                                    else if (color == 3)
                                        Gl.glColor3f((float)(j - c), 0.4f, (float)(i - a));
                                    else if (color == 4)
                                        Gl.glColor3f((float)(j - c), 0.4f, (float)(j + k));
                                    else if (color == 5)
                                        Gl.glColor3f((float)(i + b), (float)(i - a), 0.5f);
                                    Gl.glVertex3d(FUNCX[l1][l2], FUNCY[l1][l2], FUNCZ[l1][l2]);
                                    if (i == a)
                                    {
                                        Gl.glVertex3d(FUNCX[l1 + 1][l2], FUNCY[l1 + 1][l2], FUNCZ[l1 + 1][l2]);
                                        if (j + k <= d)
                                        {
                                            Gl.glVertex3d(FUNCX[l1 + 1][l2 + 1], FUNCY[l1 + 1][l2 + 1], FUNCZ[l1 + 1][l2 + 1]);
                                            Gl.glVertex3d(FUNCX[l1][l2 + 1], FUNCY[l1][l2 + 1], FUNCZ[l1][l2 + 1]);
                                            Gl.glVertex3d(FUNCX[l1][l2], FUNCY[l1][l2], FUNCZ[l1][l2]);
                                        }
                                        else
                                        {
                                            Gl.glVertex3d(FUNCX[l1][l2], FUNCY[l1][l2], FUNCZ[l1][l2]);
                                        }
                                    }
                                    if (i + h <= b)
                                    {
                                        Gl.glVertex3d(FUNCX[l1 + 1][l2], FUNCY[l1 + 1][l2], FUNCZ[l1 + 1][l2]);
                                        if (j + k <= d)
                                        {
                                            Gl.glVertex3d(FUNCX[l1 + 1][l2 + 1], FUNCY[l1 + 1][l2 + 1], FUNCZ[l1 + 1][l2 + 1]);
                                        }
                                        else
                                        {
                                            Gl.glVertex3d(FUNCX[l1][l2], FUNCY[l1][l2], FUNCZ[l1][l2]);
                                        }
                                    }
                                    else
                                    {
                                        if (j + k <= d)
                                        {
                                            Gl.glVertex3d(FUNCX[l1][l2 + 1], FUNCY[l1][l2 + 1], FUNCZ[l1][l2 + 1]);
                                        }
                                        else
                                        {
                                            Gl.glVertex3d(FUNCX[l1 - 1][l2], FUNCY[l1 - 1][l2], FUNCZ[l1 - 1][l2]);
                                        }
                                    }
                                    l2++;
                                }
                                Gl.glEnd();
                                Gl.glBegin(Gl.GL_LINE_STRIP);
                                l1++;
                            }
                            Gl.glEnd();
                            break;
                        }
                    case 2:
                        // отрисовка оболочки с расчетом нормалей для корректного затенения граней объекта 
                        {
                            Gl.glBegin(Gl.GL_QUADS);
                            // режим отрисовки полигонов состоящих из 4 вершин 
                            int l1 = 0, l2 = 0;
                            for (double i = a; i <= b; i += h)
                            {
                                l2 = 0;
                                for (double j = c; j <= d; j += k)
                                {
                                    if (color == 1)
                                        Gl.glColor3f((float)(i - a), (float)(j - c), 0.4f);
                                    else if (color == 2)
                                        Gl.glColor3f(0.4f, (float)(i - a), (float)(j - c));
                                    else if (color == 3)
                                        Gl.glColor3f((float)(j - c), 0.4f, (float)(i - a));
                                    else if (color == 4)
                                        Gl.glColor3f((float)(j - c), 0.4f, (float)(j + k));
                                    else if (color == 5)
                                        Gl.glColor3f((float)(i + b), (float)(i - a), 0.5f);
                                    // вспомогательные переменные для более наглядного использования кода при расчете нормалей 
                                    double x1 = 0, x2 = 0, x3 = 0, x4 = 0, y1 = 0, y2 = 0, y3 = 0, y4 = 0, z1 = 0, z2 = 0, z3 = 0, z4 = 0;
                                    // первая вершина 
                                    x1 = FUNCX[l1][l2];
                                    y1 = FUNCY[l1][l2];
                                    z1 = FUNCZ[l1][l2];
                                    if (i + h <= b)
                                    // если текущий ax не последний 
                                    {
                                        // берем следующую точку последовательности 
                                        x2 = FUNCX[l1 + 1][l2];
                                        y2 = FUNCY[l1 + 1][l2];
                                        z2 = FUNCZ[l1 + 1][l2];
                                        if (j + k <= d)
                                        // если текущий bx не последний 
                                        {
                                            // берем следующую точку последовательности и следующий медиан 
                                            x3 = FUNCX[l1 + 1][l2 + 1];
                                            y3 = FUNCY[l1 + 1][l2 + 1];
                                            z3 = FUNCZ[l1 + 1][l2 + 1];
                                            // точка, соответствующая по номеру, только на соседнем медиане 
                                            x4 = FUNCX[l1][l2 + 1]; ;
                                            y4 = FUNCY[l1][l2 + 1];
                                            z4 = FUNCZ[l1][l2 + 1];
                                        }
                                        else
                                        {
                                            // если это последний медиан, то в качестве след. мы берем начальный (замыкаем геометрию фигуры) 
                                            x3 = FUNCX[l1 + 1][l2]; ;
                                            y3 = FUNCY[l1 + 1][l2]; ;
                                            z3 = FUNCZ[l1 + 1][l2];
                                            x4 = FUNCX[l1][l2];
                                            y4 = FUNCY[l1][l2];
                                            z4 = FUNCZ[l1][l2];
                                        }
                                    }
                                    else
                                    // данный элемент ax последний, следовательно, мы будем использовать начальный (нулевой) вместо данного ax
                                    {
                                        // следующей точкой будет нулевая ax
                                        x2 = FUNCX[l1 - 1][l2];
                                        y2 = FUNCY[l1 - 1][l2];
                                        z2 = FUNCZ[l1 - 1][l2];
                                        if (j + k <= d)
                                        {
                                            x3 = FUNCX[l1 - 1][l2 + 1];
                                            y3 = FUNCY[l1 - 1][l2 + 1];
                                            z3 = FUNCZ[l1 - 1][l2 + 1];
                                            x4 = FUNCX[l1][l2 + 1];
                                            y4 = FUNCY[l1][l2 + 1];
                                            z4 = FUNCZ[l1][l2 + 1];
                                        }
                                        else
                                        {
                                            x3 = FUNCX[l1 - 1][l2 - 1];
                                            y3 = FUNCY[l1 - 1][l2 - 1];
                                            z3 = FUNCZ[l1 - 1][l2 - 1];
                                            x4 = FUNCX[l1][l2 - 1];
                                            y4 = FUNCY[l1][l2 - 1];
                                            z4 = FUNCZ[l1][l2 - 1];
                                        }
                                    }
                                    // переменные для расчета нормали 
                                    double n1 = 0, n2 = 0, n3 = 0;
                                    // нормаль будем рассчитывать как векторное произведение граней полигона 
                                    // для нулевого элемента нормаль мы будем считать немного по-другому.
                                    // на самом деле разница в расчете нормали актуальна только для первого и последнего полигона на медиане 
                                    if (i == -1)
                                    // при расчете нормали для ax мы будем использовать точки 1,2,3 
                                    {
                                        n1 = (y2 - y1) * (z3 - z1) - (y3 - y1) * (z2 - z1);
                                        n2 = (z2 - z1) * (x3 - x1) - (z3 - z1) * (x2 - x1);
                                        n3 = (x2 - x1) * (y3 - y1) - (x3 - x1) * (y2 - y1);
                                    }
                                    else
                                    // для остальных - 1,3,4
                                    {
                                        n1 = (y4 - y3) * (z1 - z3) - (y1 - y3) * (z4 - z3);
                                        n2 = (z4 - z3) * (x1 - x3) - (z1 - z3) * (x4 - x3);
                                        n3 = (x4 - x3) * (y1 - y3) - (x1 - x3) * (y4 - y3);
                                    }
                                    // если не включен режим GL_NORMILIZE, то мы должны в обязательном порядке
                                    // произвести нормализацию вектора нормали перед тем как передать информацию о нормали 
                                    double n5 = (double)Math.Sqrt(n1 * n1 + n2 * n2 + n3 * n3);
                                    n1 /= (n5 + 0.01);
                                    n2 /= (n5 + 0.01);
                                    n3 /= (n5 + 0.01);
                                    // передаем информацию о нормали 
                                    Gl.glNormal3d(-n1, -n2, -n3);
                                    // передаем 4 вершины для отрисовки полигона 
                                    Gl.glVertex3d(x1, y1, z1);
                                    Gl.glVertex3d(x2, y2, z2);
                                    Gl.glVertex3d(x3, y3, z3);
                                    Gl.glVertex3d(x4, y4, z4);
                                    l2++;
                                }
                                l1++;
                            }
                            // завершаем выбранный режим рисования полигонов 
                            Gl.glEnd();
                            break;
                        }
                }
                // возвращаем сохраненную матрицу
                Gl.glPopMatrix();
                // завершаем рисование
                Gl.glFlush();
                // обновляем элемент AnT 
                AnT.Invalidate();
            }

            public void Draw()
            {
                if (!param)
                    Drawing();
                else
                    ParamDraw();
            }

            public string[] Save()
            {
                string[] res;
                if (!param)
                {
                    res = new string[6]; // границы, шаг, уравнение
                    res[0] = Convert.ToString(a);
                    res[1] = Convert.ToString(b);
                    res[2] = Convert.ToString(c);
                    res[3] = Convert.ToString(d);
                    res[4] = Convert.ToString(h);
                    res[5] = F.sF;
                }
                else
                {
                    res = new string[8];
                    res[0] = Convert.ToString(a);
                    res[1] = Convert.ToString(b);
                    res[2] = Convert.ToString(c);
                    res[3] = Convert.ToString(d);
                    res[4] = Convert.ToString(h);

                    res[5] = Fp.sFx;
                    res[6] = Fp.sFy;
                    res[7] = Fp.sFz;
                }
                return res;
            }
            public string[] Open(string[] input)
            {
                string[] res;

                a = Convert.ToDouble(input[0]);
                b = Convert.ToDouble(input[1]);
                c = Convert.ToDouble(input[2]);
                d = Convert.ToDouble(input[3]);
                h = Convert.ToDouble(input[4]);
                k = h;

                if (input.Length == 6)
                {
                    res = new string[1];
                    F.newFunc(input[5]);
                    
                    param = false;
                    res[0] = input[5];
                }
                else
                {
                    res = new string[3];
                    
                    Fp.newFunc(input[5], input[6], input[7]);
                    
                    param = true;
                    res[0] = input[5];
                    res[1] = input[6];
                    res[2] = input[7];
                }
                newMassiv();
                return res;
            }
            public void OpenPoint(string[] input)
            {
                //input[0] - input[4] - a,b,c,d,h

                a = Convert.ToDouble(input[0]);
                b = Convert.ToDouble(input[1]);
                c = Convert.ToDouble(input[2]);
                d = Convert.ToDouble(input[3]);
                h = Convert.ToDouble(input[4]);
                k = h;

                //input - значения функции через пробел

                FUNC.Clear();
                for (int i = 5; i < input.Length; i++)
                {
                    List<double> F = new List<double>();
                    for (int j = 0; j < input[i].Length; j++)
                    {
                        if (input[i][j] == '[')
                        {
                            string func = "";
                            int l = j + 1;
                            while (input[i][l] != ']')
                            {
                                func += input[i][l];
                                l++;
                            }
                            F.Add(Convert.ToDouble(func));
                        }
                    }
                    FUNC.Add(F);
                }
                param = false;
            }
            public string[] SavePoint()
            {
                List<string> res = new List<string>();

                res.Add(Convert.ToString(a));
                res.Add(Convert.ToString(b));
                res.Add(Convert.ToString(c));
                res.Add(Convert.ToString(d));
                res.Add(Convert.ToString(h));
                
                for(int i = 0; i < FUNC.Count; i++)
                {
                    string hi = "";
                    for(int j = 0; j < FUNC[i].Count; j++)
                    {
                        hi += "[" + Convert.ToString(FUNC[i][j]) + "] ";
                    }
                    res.Add(hi);
                }

                return res.ToArray();
            }
        }

        class Functions
        {
            double a, b;

            Function F, Fx, Fy, Fz;
            Argument x, y, u, v;
            public Expression E, Ex, Ey, Ez;
            public string sF, sFx, sFy, sFz;

            public Functions(string Func, double min = 0, double max = 1)
            {
                F = new Function("F(x, y) = " + Func);
                Fx = new Function("Fx(u, v) = " + Func);
                Fy = new Function("Fy(u, v) = " + Func);
                Fz = new Function("Fz(u, v) = " + Func);
                x = new Argument("x", 0);
                y = new Argument("y", 0);
                u = new Argument("u", 0);
                v = new Argument("v", 0);
                E = new Expression("F(x, y)", F, x, y);
                Ex = new Expression("Fx(u, v)", Fx, u, v);
                Ey = new Expression("Fy(u, v)", Fy, u, v);
                Ez = new Expression("Fz(u, v)", Fz, u, v);
                sF = Func;

                a = min; b = max;
            }

            public void newFunc(string Func)
            {
                E.setExpressionString(Func);
                sF = Func;
            }

            public void newFunc(string Fx, string Fy, string Fz)
            {
                Ex.setExpressionString(Fx);
                Ey.setExpressionString(Fy);
                Ez.setExpressionString(Fz);

                sFx = Fx;
                sFy = Fy;
                sFz = Fz;
            }

            public double Func(double x, double y)
            {
                E.setArgumentValue("x", x);
                E.setArgumentValue("y", y);
                return E.calculate();
            }

            public double FuncX(double u, double v)
            {
                Ex.setArgumentValue("u", u);
                Ex.setArgumentValue("v", v);
                return Ex.calculate();
            }
            public double FuncY(double u, double v)
            {
                Ey.setArgumentValue("u", u);
                Ey.setArgumentValue("v", v);
                return Ey.calculate();
            }
            public double FuncZ(double u, double v)
            {
                Ez.setArgumentValue("u", u);
                Ez.setArgumentValue("v", v);
                return Ez.calculate();
            }
        }

        void AnT_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                GL.value--;
            else
                GL.value++;

            GL.Draw();
        }

        private void AnT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                GL.rot_2 -= 5;
            }
            else if (e.KeyCode == Keys.D)
            {
                GL.rot_2 += 5;
            }
            else if (e.KeyCode == Keys.S)
            {
                GL.rot_1 += 5;
            }
            else if (e.KeyCode == Keys.W)
            {
                GL.rot_1 -= 5;
            }
            else if (e.KeyCode == Keys.E)
            {
                GL.rot_2 += 5;
                GL.rot_1 -= 5;
            }
            else if (e.KeyCode == Keys.Q)
            {
                GL.rot_2 -= 5;
                GL.rot_1 -= 5;
            }
            GL.Draw();
        }

        private void A_Leave(object sender, EventArgs e)
        {
            GL.a = Convert.ToDouble(A.Text);
            GL.newMassiv();
            GL.Draw();
        }

        private void B_Leave(object sender, EventArgs e)
        {
            GL.b = Convert.ToDouble(B.Text);
            GL.newMassiv();
            GL.Draw();
        }

        private void C_Leave(object sender, EventArgs e)
        {
            GL.c = Convert.ToDouble(C.Text);
            GL.newMassiv();
            GL.Draw();
        }

        private void D_Leave(object sender, EventArgs e)
        {
            GL.d = Convert.ToDouble(D.Text);
            GL.newMassiv();
            GL.Draw();
        }

        private void Func_Leave(object sender, EventArgs e)
        {
            GL.newFunc(Func.Text);
            GL.newMassiv();
            GL.Draw();
        }

        private void Func_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GL.newFunc(Func.Text);
                GL.newMassiv();
                GL.Draw();
            }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            GL.Draw();
        }

        private void comboBox_DropDownClosed(object sender, EventArgs e)
        {
            GL.Draw();
        }

        private void шагToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            GL.h = Convert.ToDouble(H.Text);
            GL.k = Convert.ToDouble(H.Text);
            GL.newMassiv();
            GL.Draw();
        }

        private void ColorBox_DropDownClosed(object sender, EventArgs e)
        {
            switch (ColorBox.SelectedIndex)
            {
                case 0:
                    {
                        GL.color = 1;
                        break;
                    }
                case 1:
                    {
                        GL.color = 2;
                        break;
                    }
                case 2:
                    {
                        GL.color = 3;
                        break;
                    }
                case 3:
                    {
                        GL.color = 4;
                        break;
                    }
                case 4:
                    {
                        GL.color = 5;
                        break;
                    }
            }
            GL.Draw();
        }

        private void FuncBox_DropDownClosed(object sender, EventArgs e)
        {
            switch (FuncBox.SelectedIndex)
            {
                case 0:
                    {
                        param = false;
                        Func.Show();
                        FuncX.Hide();
                        FuncY.Hide();
                        FuncZ.Hide();
                        labelX.Text = "X: [";
                        labelY.Text = "Y: [";

                        A.Text = "-1";
                        B.Text = "1";
                        C.Text = "-1";
                        D.Text = "1";

                        GL.a = Convert.ToDouble(A.Text);
                        GL.b = Convert.ToDouble(B.Text);
                        GL.c = Convert.ToDouble(C.Text);
                        GL.d = Convert.ToDouble(D.Text);

                        GL.newFunc(Func.Text);
                        break;
                    }
                case 1:
                    {
                        param = true;
                        Func.Hide();
                        FuncX.Show();
                        FuncY.Show();
                        FuncZ.Show();
                        labelX.Text = "u: [";
                        labelY.Text = "v: [";

                        A.Text = "0";
                        B.Text = "7";
                        C.Text = "0";
                        D.Text = "7";

                        GL.a = Convert.ToDouble(A.Text);
                        GL.b = Convert.ToDouble(B.Text);
                        GL.c = Convert.ToDouble(C.Text);
                        GL.d = Convert.ToDouble(D.Text);
                        GL.newParamFunc(FuncX.Text, FuncY.Text, FuncZ.Text);

                        break;
                    }
            }
            GL.newMassiv();
            GL.Draw();
        }

        private void FuncZ_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GL.newParamFunc(FuncX.Text, FuncY.Text, FuncZ.Text);
                GL.newMassiv();
                GL.Draw();
            }
        }

        private void FuncX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GL.newParamFunc(FuncX.Text, FuncY.Text, FuncZ.Text);
                GL.newMassiv();
                GL.Draw();
            }
        }

        private void FuncY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GL.newParamFunc(FuncX.Text, FuncY.Text, FuncZ.Text);
                GL.newMassiv();
                GL.Draw();
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] lines = GL.Save();

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Сохранить график как...";
            sfd.OverwritePrompt = true; // показывать ли "Перезаписать файл" если пользователь указывает имя файла, который уже существует
            sfd.CheckPathExists = true; // отображает ли диалоговое окно предупреждение, если пользователь указывает путь, который не существует
                                        // фильтр форматов файлов
                                        //sfd.Filter = "(*.txt) | *.txt.";
            sfd.ShowHelp = true; // отображается ли кнопка Справка в диалоговом окне
                                 // если в диалоге была нажата кнопка ОК
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllLines(sfd.FileName, lines);
                }
                catch // в случае ошибки выводим MessageBox
                {
                    MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            StreamReader sr;

            // если в диалоге была нажата кнопка ОК
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    sr = new StreamReader(ofd.FileName, System.Text.Encoding.Default);
                    var list = new List<string>();
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        list.Add(line);
                    }

                    var lines = list.ToArray();


                    string[] res = GL.Open(lines);
                    if (res.Length == 1)
                    {
                        Func.Text = res[0];
                    }
                    else
                    {
                        FuncX.Text = res[0];
                        FuncY.Text = res[1];
                        FuncZ.Text = res[2];
                    }
                    GL.Draw();
                }
                catch // в случае ошибки выводим MessageBox
                {
                    MessageBox.Show("Невозможно открыть выбранный файл", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (param) FuncBox.Text = "Параметрическая";
                else FuncBox.Text = "Явная";
                switch (FuncBox.SelectedIndex)
                {
                    case 0:
                        {
                            Func.Show();
                            FuncX.Hide();
                            FuncY.Hide();
                            FuncZ.Hide();
                            labelX.Text = "X: [";
                            labelY.Text = "Y: [";
                            break;
                        }
                    case 1:
                        {
                            Func.Hide();
                            FuncX.Show();
                            FuncY.Show();
                            FuncZ.Show();
                            labelX.Text = "u: [";
                            labelY.Text = "v: [";

                            break;
                        }
                }

                A.Text = Convert.ToString(GL.a);
                B.Text = Convert.ToString(GL.b);
                C.Text = Convert.ToString(GL.c);
                D.Text = Convert.ToString(GL.d);
                H.Text = Convert.ToString(GL.h);

                GL.newMassiv();
                GL.Draw();
            }
        }

        private void открытьНаборТочекToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            StreamReader sr;

            // если в диалоге была нажата кнопка ОК
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                sr = new StreamReader(ofd.FileName, System.Text.Encoding.Default);
                var list = new List<string>();
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    list.Add(line);
                }

                var lines = list.ToArray();

                GL.OpenPoint(lines);

                GL.Draw();

                FuncBox.Text = "Явная";
                Func.Show();
                FuncX.Hide();
                FuncY.Hide();
                FuncZ.Hide();
                labelX.Text = "X: [";
                labelY.Text = "Y: [";
                A.Text = Convert.ToString(GL.a);
                B.Text = Convert.ToString(GL.b);
                C.Text = Convert.ToString(GL.c);
                D.Text = Convert.ToString(GL.d);
                H.Text = Convert.ToString(GL.h);
            }
        }

        private void сохранитьНаборТочекToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] lines = GL.SavePoint();

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Сохранить график как...";
            sfd.OverwritePrompt = true; // показывать ли "Перезаписать файл" если пользователь указывает имя файла, который уже существует
            sfd.CheckPathExists = true; // отображает ли диалоговое окно предупреждение, если пользователь указывает путь, который не существует
                                        // фильтр форматов файлов
                                        //sfd.Filter = "(*.txt) | *.txt.";
            sfd.ShowHelp = true; // отображается ли кнопка Справка в диалоговом окне
                                 // если в диалоге была нажата кнопка ОК
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllLines(sfd.FileName, lines);
                }
                catch // в случае ошибки выводим MessageBox
                {
                    MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
