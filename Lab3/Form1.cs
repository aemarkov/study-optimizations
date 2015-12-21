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
using Optimization.BarrierFunctions;

namespace Lab3
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();


			Func<Vector<double>, double> f = x => x[0] * x[0] + x[1] * x[1];
			Func<Vector<double>, double> f1 = x => x[0] - 1;
			Func<Vector<double>, double> f2 = x => 2 - x[0] - x[1];

			var x0 = Vector<double>.Build.DenseOfArray(new double[] { 2, 2});
			var a = BarrierMinimizer.FindMinimum(f, new Func<Vector<double>, double>[] { f1, f2 }, BarrierMinimizer.KarrolBarrier, x0, 1, 0.1, 0.1);

			int b = 1 + 2;
        }
	}
}
