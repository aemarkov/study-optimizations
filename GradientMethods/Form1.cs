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

namespace GradientMethods
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			Vector<double> a = Vector<double>.Build.DenseOfArray(new double[] { 1, 1 });
			Func<Vector<double>, double> f = x => x[0]*x[0] + x[1]*x[1];

			var grad = (new CentralGradientSolver()).CalcGradient(f, a, 0.1);
			int b = 0;
		}
	}
}
