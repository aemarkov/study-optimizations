using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MathNet.Numerics.LinearAlgebra;
using Optimization.Differentation;
using Optimization.Gradient;
using Optimization;

namespace GradientMethods
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			Vector<double> x0 = Vector<double>.Build.DenseOfArray(new double[] { 3, -1, 0, 1});
			Func<Vector<double>, double> f = x=>Math.Pow(x[0]+10*x[1],2)+
				5*Math.Pow(x[2]-x[3],2)+
				Math.Pow(x[1]-2*x[2],4)+
				10*Math.Pow(x[0]-x[3],4);

			//Vector<double> x0 = Vector<double>.Build.DenseOfArray(new double[] { 1,1 });
			//Func<Vector<double>, double> f = x => 4*Math.Pow(x[0]-5, 2) + Math.Pow(x[1]-6, 2);

			//Vector<double> x0 = Vector<double>.Build.DenseOfArray(new double[] { 1, -1 });
			//Func<Vector<double>, double> f = x => Math.Pow(x[0]*x[0]+x[1]-11,2) + Math.Pow(x[0] + x[1]*x[1]-7, 2);


			int steps;
			Vector <double> min = OptimalGradientMethod.FindMinimum(f, x0, new CentralGradientCalc(), 0.01, 0.01, out steps);
			string mins = min.Vector2String("N3");
			int a = 0;

		}
	}
}
