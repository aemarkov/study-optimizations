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
using Optimization;

namespace GradientMethods
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			Vector<double> a = Vector<double>.Build.DenseOfArray(new double[] { 1, 1 });
			Func<Vector<double>, double> f = x => x[0]*x[0] + x[1]*x[1];

			var grad = (new CentralGradientCalc()).CalcGradient(f, a, 0.1);
			grad = (new RightGradientCalc()).CalcGradient(f, a, 0.1);

			var str = grad.Vector2String(); ;

			int b = 0;
		}
	}
}
