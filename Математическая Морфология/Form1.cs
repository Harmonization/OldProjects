using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Morphology
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        class Square
        {
            public bool Black;
            float x, y;
            public int size;
            public int number;

            public Square(float x_, float y_, int number_ = 0, bool Black_ = false, int size_ = 30)
            {
                x = x_;
                y = y_;
                size = size_;
                Black = Black_;
                number = number_;
            }
            public void Copy(Square tmp)
            {
                   Black = tmp.Black;
            }
            public void OutCopy(Square tmp)
            {
                if(tmp.Black == true)
                Black = tmp.Black;
            }
            public bool Click(float Mx, float My, string a = "")
            {
                if(x < Mx && Mx < x + size)
                {
                    if(y < My && My < y + size)
                    {
                        Black = !Black;
                        return true;
                    }
                }
                return false;
            }
            public void Draw(Graphics g)
            {
                g.DrawRectangle(new Pen(Color.Black), x, y, size, size);
                if (Black) g.FillRectangle(new SolidBrush(Color.Black), x, y, size, size);
                else g.FillRectangle(new SolidBrush(Color.White), x + 1, y + 1, size - 1, size - 1);
            }
            public void DrawClick(Graphics g, float Mx, float My)
            {
                if (Click(Mx, My))
                    Draw(g);
            }
        }
        
        class Line
        {
            public List<Square> line;
            public int size;

            public Line(float x = 0, float y = 0, int size_ = 15, int number_ = 0)
            {
                line = new List<Square>();
                size = size_;

                
                for(int i = 0; i < size; i++)
                {
                    Square a = new Square(x, y, number_);
                    line.Add(a);
                    x += a.size;
                    number_++;
                }
            }
            public void Copy(Line tmp, int a = 0)
            {
                for(int i = 0; i < size; i++)
                {
                    line[i].Copy(tmp.line[a + i]);
                }
            }
            public void OutCopy(Line tmp, int a = 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    line[a + i].OutCopy(tmp.line[i]);
                }
            }
            public void NewCopy(Line tmp, int a = 0)
            {
                line[a + 1].Copy(tmp.line[1]);
            }
            public bool Click(float Mx, float My)
            {
                for(int i = 0; i < size; i++)
                {
                    if (line[i].Click(Mx, My)) return true;
                }
                return false;
            }
            public void Draw(Graphics g)
            {
                for(int i = 0; i < size; i++)
                {
                    line[i].Draw(g);
                }
            }
            public void DrawClick(Graphics g, float Mx, float My)
            {
                if (Click(Mx, My)) Draw(g);
            }
            
            public List<int> Number()
            {
                List<int> res = new List<int>();
                
                for(int i = 0; i < size; i++)
                {
                    if (line[i].Black) res.Add(line[i].number); 
                }

                return res;
            }
            public void OutNumber(List<int> a)
            {
                for(int i = 0; i < size; i++)
                {
                    for(int j = 0; j < a.Count; j++)
                    {
                        if (line[i].number == a[j]) line[i].Black = true;
                    }
                }
            }
            public void WhiteNumber(List<int> a)
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < a.Count; j++)
                    {
                        if (line[i].number == a[j]) line[i].Black = false;
                    }
                }
            }
            public void Clear()
            {
                for(int i = 0; i < size; i++)
                {
                    line[i].Black = false;
                }
            }
            public void Inverse()
            {
                for (int i = 0; i < size; i++)
                {
                    line[i].Black = !line[i].Black;
                }
            }
            public bool Pixel()
            {
                return line[1].Black;
            }
            public bool Erose(Line tmp)
            {
                for(int i = 0; i < size; i++)
                {
                    if (line[i].Black == true && tmp.line[i].Black == false) return false;
                }
                return true;
            }
            public void Add(int a = 0, bool Black = false)
            {
                line[a].Black = Black;
            }
        }

        class Grid
        {
            public int size;
            public List <Line> grid;

            public Grid(float x = 0, float y = 0, int size_ = 15, int number_ = 1)
            {
                grid = new List<Line>();
                size = size_;

                for(int i = 0; i < size; i++)
                {
                    Line a = new Line(x, y, size, number_);
                    grid.Add(a);
                    y += 30;
                    number_ += a.size;
                }
            }
            public void Copy(Grid tmp, int a = 0, int b = 0)
            {
                for(int i = 0; i < size; i++)
                {
                    grid[i].Copy(tmp.grid[b + i], a);
                }
            }
            public void OutCopy(Grid tmp, int a = 0, int b = 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    grid[b + i].OutCopy(tmp.grid[i], a);
                }
            }
            public void NewCopy(Grid tmp, int a = 0, int b = 0)
            {
                grid[b + 1].NewCopy(tmp.grid[1], a);
            }
            public bool Click(float Mx, float My)
            {
                for(int i = 0; i < size; i++)
                {
                    if(grid[i].Click(Mx, My))
                    {
                        return true;
                    }
                }
                return false;
            }
            public void Draw(Graphics g)
            {
                for (int i = 0; i < size; i++)
                {
                    grid[i].Draw(g);
                }
            }
            public void DrawClick(Graphics g, float Mx, float My)
            {
                if (Click(Mx, My)) Draw(g);
            }

            public List<int> Number()
            {
                List<int> res = new List<int>();
                List<int> dopres;

                for (int i = 0; i < size; i++)
                {
                    dopres = grid[i].Number();

                    for(int j = 0; j < dopres.Count; j++)
                    {
                        res.Add(dopres[j]);
                    }
                }

                return res;
            }
            public void OutNumber(List<int> a)
            {
                for(int i = 0; i < size; i++)
                {
                    grid[i].OutNumber(a);
                }
            }
            public void WhiteNumber(List<int> a)
            {
                for (int i = 0; i < size; i++)
                {
                    grid[i].WhiteNumber(a);
                }
            }
            public void Clear()
            {
                for(int i = 0; i < size; i++)
                {
                    grid[i].Clear();
                }
            }
            public void Inverse()
            {
                for (int i = 0; i < size; i++)
                {
                    grid[i].Inverse();
                }
            }
            public bool Pixel()
            {
                return grid[1].Pixel();
            }
            public bool Erose(Grid tmp)
            {
                for(int i = 0; i < size; i++)
                {
                    if (grid[i].Erose(tmp.grid[i]) == false) return false;
                }
                return true;
            }
            public void Add(int a = 0, int b = 0, bool Black = false)
            {
                grid[b].Add(a, Black);
            }
        }


        class Morph
        {
            Grid grid;
            Grid small;
            Grid GridCopy = new Grid(0, 0, 15);

            Grid medium1, medium2, res;

            public Morph(float x = 0, float y = 0, float Sx = 550, float Sy = 0)
            {
                grid = new Grid(x, y, 15);
                small = new Grid(Sx, Sy, 3);

                medium1 = new Grid(1100, 0, 5);
                medium2 = new Grid(1100, 250, 5);
                res = new Grid(1100, 500, 5);
            }
            public bool ClickGrid(float Mx, float My)
            {
                return grid.Click(Mx, My);
            }
            public bool ClickSmall(float Mx, float My)
            {
                return small.Click(Mx, My);
            }
            public bool ClickMedium1(float Mx, float My)
            {
                return medium1.Click(Mx, My);
            }
            public bool ClickMedium2(float Mx, float My)
            {
                return medium2.Click(Mx, My);
            }
            public bool ClickRes(float Mx, float My)
            {
                return res.Click(Mx, My);
            }
            public void DrawGrid(Graphics g)
            {
                grid.Draw(g);
            }
            public void DrawSmall(Graphics g)
            {
                small.Draw(g);
            }
            public void DrawMedium1(Graphics g)
            {
                medium1.Draw(g);
            }
            public void DrawMedium2(Graphics g)
            {
                medium2.Draw(g);
            }
            public void DrawRes(Graphics g)
            {
                res.Draw(g);
            }
            public void DrawClick(Graphics g, float Mx, float My)
            {
                if (ClickGrid(Mx, My)) DrawGrid(g);
                if (ClickSmall(Mx, My)) DrawSmall(g);

                if (ClickMedium1(Mx, My)) DrawMedium1(g);
                if (ClickMedium2(Mx, My)) DrawMedium2(g);
                if (ClickRes(Mx, My)) DrawRes(g);
            }

            public List<int> NumberGrid()
            {
                return grid.Number();
            }
            public List<int> NumberSmall()
            {
                return small.Number();
            }
            public List<int> NumberMedium1()
            {
                return medium1.Number();
            }
            public List<int> NumberMedium2()
            {
                return medium2.Number();
            }
            public List<int> NumberRes()
            {
                return res.Number();
            }

            public void OutNumberGrid(List<int> a)
            {
                grid.OutNumber(a);
            }
            public void OutNumberSmall(List<int> a)
            {
                small.OutNumber(a);
            }
            public void OutNumberMedium1(List<int> a)
            {
                medium1.OutNumber(a);
            }
            public void OutNumberMedium2(List<int> a)
            {
                medium2.OutNumber(a);
            }
            public void OutNumberRes(List<int> a)
            {
                res.OutNumber(a);
            }
            public void WhiteNumberRes(List<int> a)
            {
                res.WhiteNumber(a);
            }

            public void Union(Graphics g)
            {
                this.res.Clear();

                List<int> a = NumberMedium1();
                List<int> b = NumberMedium2();
                List<int> res = new List<int>();

                for(int i = 0; i < a.Count; i++)
                {
                    res.Add(a[i]);
                }
                for (int i = 0; i < b.Count; i++)
                {
                    res.Add(b[i]);
                }

                var c = res.Distinct();

                OutNumberRes(res);

                DrawRes(g);
            }
            public void Crossroad(Graphics g)
            {
                this.res.Clear();

                List<int> a = NumberMedium1();
                List<int> b = NumberMedium2();
                List<int> res = new List<int>();

                for (int i = 0; i < a.Count; i++)
                {
                    for(int j = 0; j < b.Count; j++)
                    {
                        if(a[i] == b[j]) res.Add(a[i]);
                    }
                }

                var c = res.Distinct();

                OutNumberRes(res);

                DrawRes(g);
            }
            public void Annex(Graphics g)
            {
                this.res.Clear();

                medium1.Inverse();
                List<int> a = NumberMedium1();
                medium1.Inverse();
                List<int> res = new List<int>();


                for (int i = 0; i < a.Count; i++)
                {
                    res.Add(a[i]);
                }
                
                OutNumberRes(res);

                DrawRes(g);
            }
            public void Difference(Graphics g)
            {
                this.res.Clear();

                List<int> a = NumberMedium1();
                List<int> b = NumberMedium2();
                List<int> crossroad = new List<int>();

                for (int i = 0; i < a.Count; i++)
                {
                    for (int j = 0; j < b.Count; j++)
                    {
                        if (a[i] == b[j]) crossroad.Add(a[i]);
                    }
                }
                
                OutNumberRes(a);

                WhiteNumberRes(crossroad);

                DrawRes(g);
            }

            public void AnswerDil(int x, int y, Graphics g)
            {
                Grid SmallCopy = new Grid(0, 0, 3);

                Grid local = new Grid(0, 0, 3);

                this.res.Clear();

                local.Copy(GridCopy, x, y);

                if (local.Pixel())
                {
                    List<int> a = NumberSmall();
                    List<int> b = local.Number();
                    List<int> res = new List<int>();

                    for (int i = 0; i < a.Count; i++)
                    {
                        res.Add(a[i]);
                    }
                    for (int i = 0; i < b.Count; i++)
                    {
                        res.Add(b[i]);
                    }
                    
                    local.OutNumber(res);

                    grid.OutCopy(local, x, y);
                    
                }
            }
            public void AnswerEr(int x, int y, Graphics g)
            {
                Grid SmallCopy = new Grid(0, 0, 3);

                Grid local = new Grid(0, 0, 3);

                this.res.Clear();

                local.Copy(GridCopy, x, y);

                if (local.Pixel())
                {
                    List<int> a = NumberSmall();
                    List<int> b = local.Number();
                    List<int> res = new List<int>();

                    for (int i = 0; i < a.Count; i++)
                    {
                        for (int j = 0; j < b.Count; j++)
                        {
                            if (a[i] == b[j]) res.Add(a[i]);
                        }
                    }

                    local.OutNumber(res);

                    if(small.Erose(local) == true)
                    {
                        local.Clear();
                        local.Add(1, 1, true);
                    }
                    else
                    {
                        local.Clear();
                        local.Add(1, 1, false);
                    }

                    grid.NewCopy(local, x, y);

                }
            }
            public void AnswerLim(int x, int y, Graphics g)
            {
                Grid SmallCopy = new Grid(0, 0, 3);

                Grid local = new Grid(0, 0, 3);

                this.res.Clear();

                local.Copy(GridCopy, x, y);

                if (local.Pixel())
                {
                    List<int> a = NumberSmall();
                    List<int> b = local.Number();
                    List<int> res = new List<int>();

                    for (int i = 0; i < a.Count; i++)
                    {
                        for (int j = 0; j < b.Count; j++)
                        {
                            if (a[i] == b[j]) res.Add(a[i]);
                        }
                    }

                    local.OutNumber(res);

                    if (small.Erose(local) == true)
                    {
                        local.Clear();
                        local.Add(1, 1, false);
                    }
                    else
                    {
                        local.Clear();
                        local.Add(1, 1, true);
                    }

                    grid.NewCopy(local, x, y);

                }
            }
            public void Dilatation(Graphics g)
            {
                GridCopy.Copy(grid);

                for(int i = 0; i < grid.size - 2; i++)
                {
                    for(int j = 0; j < grid.size - 2; j++)
                    {
                        AnswerDil(j, i, g);
                    }
                }

                DrawGrid(g);
            }
            public void Erosion(Graphics g)
            {
                GridCopy.Copy(grid);

                for (int i = 0; i < grid.size - 2; i++)
                {
                    for (int j = 0; j < grid.size - 2; j++)
                    {
                        AnswerEr(j, i, g);
                    }
                }

                DrawGrid(g);
            }
            public void Open(Graphics g)
            {
                Erosion(g);
                Dilatation(g);
            }
            public void Close(Graphics g)
            {
                Dilatation(g);
                Erosion(g);
            }
            public void Limit(Graphics g)
            {
                GridCopy.Copy(grid);

                for (int i = 0; i < grid.size - 2; i++)
                {
                    for (int j = 0; j < grid.size - 2; j++)
                    {
                        AnswerLim(j, i, g);
                    }
                }

                DrawGrid(g);
            }

            public void Clear(Graphics g)
            {
                grid.Clear();
                DrawGrid(g);
            }
        }

        Morph a;
        Graphics g;

        void DrawLineForm(Graphics g)
        {
            g.DrawLine(new Pen(Color.Black), 700, 0, 700, 700);
        }

        void FullDraw(Morph a, Graphics g)
        {
            g.Clear(Color.White);
            a.DrawGrid(g);
            a.DrawSmall(g);
            a.DrawMedium1(g);
            a.DrawMedium2(g);
            a.DrawRes(g);
            DrawLineForm(g);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            a = new Morph();
            g = this.CreateGraphics();
            FullDraw(a, g);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            a.DrawClick(g, e.X, e.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            a.Union(g);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            a.Crossroad(g);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            a.Annex(g);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            a.Difference(g);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            a.Dilatation(g);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            a.Erosion(g);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            a.Open(g);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            a.Close(g);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            a.Limit(g);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            a.Clear(g);
        }
    }
}
