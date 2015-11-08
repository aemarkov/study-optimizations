using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Optimization;
using Optimization.Multivariate;

namespace Lab2
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			SimpleLogger.Logger.Setup(logToDebug: true, addDateTime: false);

			Point2D x0 = new Point2D(0, 0);
			Point2D h = new Point2D(1, 1);
			double eps = 0.01;

			var a = GaussZeidelMethod.FindMinimum(task211, x0, h, eps);

		}

		double test(double x1, double x2)
		{
			return 4 * Math.Pow(x1 - 2, 2) + Math.Pow(x2 + 2, 2);
		}

		double task211(double x1, double x2)
		{
			return Math.Pow(x1*x1+x2-11,2)+Math.Pow(x1+x2*x2-7,2);
		}
	}
}
