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
using MathNet.Numerics;
using MathNet.Numerics.OdeSolvers;
using MathNet.Numerics.LinearAlgebra;
using System.Drawing.Drawing2D;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Phase_picture
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        class Picture
        {
            Function Fx, Fy;
            Argument x, y;
            Expression Ex, Ey;
            public double[] X, Y;
            public int N; // количество шагов 

            public Picture(string Func1, string Func2)
            {
                Fx = new Function("Fx(x, y) = " + Func1);
                Fy = new Function("Fy(x, y) = " + Func2);

                x = new Argument("x", 0);
                y = new Argument("y", 0);

                Ex = new Expression("Fx(x, y)", Fx, x, y);
                Ey = new Expression("Fy(x, y)", Fy, x, y);
            }

            Func<double, Vector<double>, Vector<double>> Core()
            {
                return (t, Z) =>
                {
                    double[] A = Z.ToArray();
                    
                    Ex.setArgumentValue("x", A[0]);
                    Ex.setArgumentValue("y", A[1]);
                    Ey.setArgumentValue("x", A[0]);
                    Ey.setArgumentValue("y", A[1]);

                    return Vector<double>.Build.Dense(new[] { Ex.calculate(), Ey.calculate() });
                };
            }

            void RK(double min = 0, double max = 15, double x0 = 1, double y0 = 6, int N_ = 150)
            {
                N = N_;

                var Y0 = Vector<double>.Build.Dense(new[] { x0, y0 });
                
                var r = RungeKutta.SecondOrder(Y0, min, max, N, Core());
                
                X = new double[N];
                Y = new double[N];
                for (int i = 0; i < N; i++)
                {
                    double[] R = r[i].ToArray();
                    X[i] = R[0];
                    Y[i] = R[1];
                }
            }

            void Graph(ZedGraphControl zed)
            {
                GraphPane panel = zed.GraphPane;
                PointPairList list = new ZedGraph.PointPairList(), list1 = new ZedGraph.PointPairList();
                
                list1.Add(0, 0);
                for (int index = 0; index < N; index++)
                {
                    list.Add(X[index], Y[index]);
                }

                LineItem Curve = panel.AddCurve("", list, Color.Blue, SymbolType.None);
                Curve = panel.AddCurve("", list1, Color.Blue, SymbolType.Circle);

                zed.AxisChange();
                zed.Invalidate();
            }
            
            public void Auto(ZedGraphControl zed, double min = 0, double max = 15, int N_ = 150, double minX0 = -10, double maxX0 = 10, double minY0 = -10, double maxY0 = 10, double hX0 = 2, double hY0 = 2)
            {
                for (double x0 = minX0; x0 <= maxX0; x0 += hX0)
                    for (double y0 = minY0; y0 <= maxY0; y0 += hY0)
                    {
                        RK(min, max, x0, y0, N_);
                        Graph(zed);
                    }
            }
        }

        Picture pic;

        private void Calculate_Click(object sender, EventArgs e)
        {
            double min = Convert.ToDouble(textBoxT0.Text);
            double max = Convert.ToDouble(textBoxTn.Text);
            int N = Convert.ToInt32(textBoxN.Text);
            double X0min = Convert.ToDouble(minX0.Text);
            double X0max = Convert.ToDouble(maxX0.Text);
            double X0h = Convert.ToDouble(hX0.Text);
            double Y0min = Convert.ToDouble(minY0.Text);
            double Y0max = Convert.ToDouble(maxY0.Text);
            double Y0h = Convert.ToDouble(hY0.Text);

            PhaseGraph.GraphPane.CurveList.Clear();
            PhaseGraph.AxisChange();
            PhaseGraph.Invalidate();

            pic.Auto(PhaseGraph, min, max, N, X0min, X0max, Y0min, Y0max, X0h, Y0h);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GraphPane panel = PhaseGraph.GraphPane;
            panel.XAxis.Scale.Min = -10;
            panel.XAxis.Scale.Max = 10;
            panel.YAxis.Scale.Min = -10;
            panel.YAxis.Scale.Max = 10;
            panel.Title.Text = "";
            panel.XAxis.Title.Text = "";
            panel.YAxis.Title.Text = "";
            
        }
        
        private void textBoxX_Leave(object sender, EventArgs e)
        {
            pic = new Picture(textBoxX.Text, textBoxY.Text);
        }

        private void textBoxY_Leave(object sender, EventArgs e)
        {
            pic = new Picture(textBoxX.Text, textBoxY.Text);
        }
    }
}
