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

namespace GradientMethods
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			Vector<double> a = Vector<double>.Build.Dense(2);
			Vector<double> b = Vector<double>.Build.Dense(2);
			a[0] = 1;
			a[1] = 5;

			b[0] = 2;
			b[1] = 3;

			var c = a + b;

			var f = c[0];
		}
	}
}
