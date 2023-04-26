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
using ZedGraph;

namespace Integration
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        int length, lengthX, lengthY;
        int width;
        int Xdx, Ydx;
        Table table;

        class Integral
        {
            Function F, Px, Py;
            Argument x, t;
            Expression E, Ex, Ey;
            double a, b;

            public Integral(string Func, double min = 0, double max = 1)
            {
                F = new Function("F(x) = " + Func);
                x = new Argument("x", 0);
                E = new Expression("F(x)", F, x);

                a = min; b = max;
            }
            public Integral(string FuncX, string FuncY, double min = 0, double max = 1)
            {
                Px = new Function("Px(t) = " + FuncX);
                Py = new Function("Py(t) = " + FuncY);
                t = new Argument("t", 0);

                Ex = new Expression("Px(t)", Px, t);
                Ey = new Expression("Py(t)", Py, t);

                a = min; b = max;
            }

            double Func(double x)
            {
                E.setArgumentValue("x", x);
                return E.calculate();
            }
            double FuncX(double t)
            {
                Ex.setArgumentValue("t", t);
                return Ex.calculate();
            }
            double FuncY(double t)
            {
                Ey.setArgumentValue("t", t);
                return Ey.calculate();
            }

            double dX(double t)
            {
                return (FuncX(t + 0.001) - FuncX(t - 0.001)) / (2 * 0.001);
            }

            public double Trapeze(int n)
            {
                double res = 0;
                double h = (double)(b - a) / n;
                
                res += (Func(a) + Func(b)) / 2;
                for (double xi = a + h; xi < b; xi += h)
                {
                    res += Func(xi);
                }
                res *= h;
                return res;
            }
            public double ParamTrapeze(int n)
            {
                double res = 0;
                double h = (double)(b - a) / n;
                
                res += (dX(a) * FuncY(a) + dX(b) * FuncY(b)) / 2;
                for (double xi = a + h; xi < b; xi += h)
                {
                    res += dX(xi) * FuncY(xi);
                }
                res *= h;
                return res;
            }

            public void Graph(ZedGraphControl zed, CheckBox S)
            {
                GraphPane panel = zed.GraphPane;
                panel.CurveList.Clear();
                PointPairList f1_list = new ZedGraph.PointPairList();
               
                for (double xi = a; xi <= b; xi += 0.001)
                {
                    f1_list.Add(xi, Func(xi));
                }
                
                LineItem Curve1 = panel.AddCurve("", f1_list, Color.Red, SymbolType.None);

                if (S.Checked)
                {
                    Curve1.Line.Fill = new ZedGraph.Fill(Color.Red, Color.Yellow, Color.Blue, 90.0f);
                }

                zed.AxisChange();
                zed.Invalidate();
            }
            public void ParamGraph(ZedGraphControl zed, CheckBox S)
            {
                GraphPane panel = zed.GraphPane;
                panel.CurveList.Clear();
                PointPairList f1_list = new ZedGraph.PointPairList();
                
                for (double ti = a; ti <= b; ti += 0.001)
                {
                    f1_list.Add(FuncX(ti), FuncY(ti));
                }
                
                LineItem Curve1 = panel.AddCurve("", f1_list, Color.Red, SymbolType.None);

                if (S.Checked)
                {
                    Curve1.Line.Fill = new ZedGraph.Fill(Color.Red, Color.Yellow, Color.Blue, 90.0f);
                }
                zed.AxisChange();
                zed.Invalidate();
            }
        }

        class Table
        {
            DataGridView table;

            public Table(DataGridView t)
            {
                table = t;

                //Выравнивание столбцов по содержимому
                table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //Выравнивание строк по содержимому
                table.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                //Удаляет самый левый столбец(Заголовки)
                table.RowHeadersVisible = false;
                table.ColumnHeadersVisible = false;
            }

            int Find(DataGridView Table, string str)
            {
                for (int i = 0; i < Table.RowCount; i++)
                {
                    if (str == Convert.ToString(table.Rows[i].Cells[0].Value)) return i;
                }
                return 100;
            }

            public void CreatePi()
            {
                table.RowCount = 10;
                table.ColumnCount = 2;
                table.Rows[0].Cells[0].Value = "Число пи";
                table.Rows[0].Cells[1].Value = "Значение";

                int h = 1;
                for (int i = 1; i < 7; i++)
                {
                    table.Rows[i].Cells[0].Value = "Pi/" + Convert.ToString(h);
                    h++;
                }
                h = 1;
                for (int i = 1; i < 7; i++)
                {
                    table.Rows[i].Cells[1].Value = Math.PI / h;
                    h++;
                }
                table.Rows[7].Cells[0].Value = "Pi/12 ";
                table.Rows[7].Cells[1].Value = Math.PI / 12;
                table.Rows[8].Cells[0].Value = "3*Pi/2 ";
                table.Rows[8].Cells[1].Value = 3 * Math.PI / h;
                table.Rows[9].Cells[0].Value = "2*Pi ";
                table.Rows[9].Cells[1].Value = 2 * Math.PI;
            }

            public double Limit(string str)
            {
                double res = 0;

                if (Find(table, str) != 100)
                {
                    int i = Find(table, str);
                    res = Convert.ToDouble(table.Rows[i].Cells[1].Value);
                }
                else res = Convert.ToDouble(str);
                return res;
            }
        }
        
        int Find(DataGridView Table, string str)
        {
            for(int i = 0; i < Table.RowCount; i++)
            {
                if (str == Convert.ToString(dataGridView1.Rows[i].Cells[0].Value)) return i;
            }
            return 100;
        }

        private void Fy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double min = table.Limit(x0.Text);
                double max = table.Limit(xn.Text);

                // Интеграл

                Integral I = new Integral(Fx.Text, Fy.Text, min, max);

                I1.Text = Convert.ToString(I.ParamTrapeze(1000));

                // График 

                I.ParamGraph(zedGraphControl1, S);

                Fy.Enabled = false;
                Fx.Focus();
            }
        }
        
        private void Fx_TextChanged(object sender, EventArgs e)
        {
            int a = Fx.Text.Length;
            if (a >= lengthX && a < 50)
            {
                Fx.Width = width + 8 * (a - lengthX);
            }
        }

        private void Fy_TextChanged(object sender, EventArgs e)
        {
            int a = Fy.Text.Length;
            if (a >= lengthY && a < 50)
            {
                Fy.Width = width + 8 * (a - lengthY);
            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            GraphPane panel = zedGraphControl1.GraphPane;
            panel.Title.Text = "";
            panel.XAxis.Title.Text = "";
            panel.YAxis.Title.Text = "";
            
            Func.Focus();

            table = new Table(dataGridView1);

            table.CreatePi();
            
            length = Func.Text.Length;
            lengthX = Fx.Text.Length;
            lengthY = Fy.Text.Length;
            width = Func.Width;
            Xdx = dx.Location.X;
            Ydx = dx.Location.Y;

            Func.Enabled = true;
            Fx.Hide();
            Fy.Hide();
            label2.Hide();
            label3.Hide();
            
        }

        private void Func_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double min = table.Limit(x0.Text);
                double max = table.Limit(xn.Text);

                // Интеграл

                Integral I = new Integral(Func.Text, min, max);

                I1.Text = Convert.ToString(I.Trapeze(1000));

                // График 

                I.Graph(zedGraphControl1, S);    

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked)
            {
                Fy.Enabled = false;
                Func.Enabled = false;
                Fx.Show();
                Fy.Show();
                Fx.Focus();
                label2.Show();
                label3.Show();
                Func.Text = "y(t) * x'(t)";
                dx.Text = "dt";
            }
            else
            {
                Func.Enabled = true;
                Fx.Hide();
                Fy.Hide();
                Func.Focus();
                label2.Hide();
                label3.Hide();
                Func.Text = "x * cos(x)";
                dx.Text = "dx";
            }
        }

        private void Fx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Fy.Enabled = true;
                Fy.Focus();
            }
        }

        private void Func_TextChanged(object sender, EventArgs e)
        {
            int a = Func.Text.Length;
            if (a >= length && a < 50)
            {
                Func.Width = width + 8 * (a - length);
                dx.Location = new Point(Xdx + 8 * (a - length), Ydx);
            }

        }
    }
}
