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

namespace Functions
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        class Functions
        {
            double a, b;

            Function F1, F2;
            Argument x;
            Expression E1, E2;

            public Functions(string Func1, string Func2, double min = 0, double max = 1)
            {
                F1 = new Function("F1(x) = " + Func1);
                F2 = new Function("F2(x) = " + Func2);
                x = new Argument("x", 0);
                E1 = new Expression("F1(x)", F1, x);
                E2 = new Expression("F2(x)", F2, x);

                a = min; b = max;
            }

            double Func1(double x)
            {
                E1.setArgumentValue("x", x);
                return E1.calculate();
            }
            double Func2(double x)
            {
                E2.setArgumentValue("x", x);
                return E2.calculate();
            }

            public void Graph(ZedGraphControl zed)
            {
                GraphPane panel = zed.GraphPane;
                panel.CurveList.Clear();
                PointPairList f1_list = new ZedGraph.PointPairList(), f2_list = new ZedGraph.PointPairList(), f3_list = new ZedGraph.PointPairList();

                for (double xi = a; xi <= b; xi += 0.001)
                {
                    f1_list.Add(xi, Func1(xi));
                    f2_list.Add(xi, Func2(xi));
                    f3_list.Add(xi, Func1(xi));
                    f3_list.Add(xi, Func2(xi));
                }

                LineItem Curve1 = panel.AddCurve("", f3_list, Color.HotPink, SymbolType.None);
                Curve1 = panel.AddCurve("", f1_list, Color.Red, SymbolType.VDash);
                Curve1 = panel.AddCurve("", f2_list, Color.Blue, SymbolType.VDash);

                zed.AxisChange();
                zed.Invalidate();
            }
            public double Eps()
            {
                double res = 0;
                for (double xi = a; xi <= b; xi += 0.001)
                {
                    double eps = Math.Abs(Func1(xi) - Func2(xi));
                    res = (res < eps) ? eps : res;
                }
                return res;
            }
            public void GraphEps(ZedGraphControl zed)
            {
                GraphPane panel = zed.GraphPane;
                panel.CurveList.Clear();
                PointPairList f1_list = new ZedGraph.PointPairList();

                for (double xi = a; xi <= b; xi += 0.001)
                {
                    f1_list.Add(xi, Math.Abs(Func1(xi) - Func2(xi)));
                }

                LineItem Curve1 = panel.AddCurve("", f1_list, Color.Yellow, SymbolType.VDash);

                zed.AxisChange();
                zed.Invalidate();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GraphPane panel = zed.GraphPane;
            panel.Title.Text = "";
            panel.XAxis.Title.Text = "";
            panel.YAxis.Title.Text = "";

            GraphPane panel1 = zedEps.GraphPane;
            panel1.Title.Text = "";
            panel1.XAxis.Title.Text = "";
            panel1.YAxis.Title.Text = "";
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            Functions Func = new Functions(F.Text, G.Text, Convert.ToDouble(A.Text), Convert.ToDouble(B.Text));

            Func.Graph(zed);

            Eps.Text = "max|f(x) - g(x)| = " + Convert.ToString(Func.Eps());

            Func.GraphEps(zedEps);
        }
    }
}
