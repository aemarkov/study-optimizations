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
		//----------------------------------------------------
		//Тестовая
		double test(Vector<double> x)
		{
			return x[0] * x[0] + x[1] * x[1];
		}

		Func<Vector<double>, double>[] test_borders =
		{
			x => x[0] - 1,
			x => 2 - x[0] - x[1]
		};

		//----------------------------------------------------
		//2.3
		double task2_3(Vector<double> x)
		{
			return Math.Pow(x[0] - 4, 2) + Math.Pow(x[1] - 4, 2);
		}

		Func<Vector<double>, double>[] task2_3_borders =
		{
			x=>-x[0]-x[1]+5
		};
		//----------------------------------------------------
		//2.9
		double task2_9(Vector<double> x)
		{
			return Math.Pow(x[0]+4,2)+Math.Pow(x[1]-4,2);
		}
		Func<Vector<double>, double>[] task2_9_borders =
		{
			x=>-2*x[0]+x[1]+2,
			x=>x[0],
			x=>x[1]
		};

		//----------------------------------------------------
		//2.13
		double task2_13(Vector<double> x)
		{
			return -x[0] * x[1] * x[2];
		}

		Func<Vector<double>, double>[] task2_13_borders =
		{
			x=>x[0],
			x=>-x[0]+42,
			x=>x[1],
			x=>-x[1]+42,
			x=>-x[0]-2*x[1]-2*x[2]+72
		};
		
		public Form1()
		{
			InitializeComponent();

			var x0 = Vector<double>.Build.DenseOfArray(new double[] { 2, 2});
			var a = BarrierMinimizer.FindMinimum(test, test_borders, BarrierMinimizer.KarrolBarrier, x0, 1, 0.1, 0.01);

			int b = 1 + 2;
        }

		private void button1_Click(object sender, EventArgs e)
		{

		}

		
	}
}
