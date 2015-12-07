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
			SimpleLogger.Logger.Setup(logToDebug: true, addDateTime: false, isDisable: false);
			SimpleLogger.Logger.MessageWrited += Logger_MessageWrited;
		}

		//Отображение лога
		private void Logger_MessageWrited(string message)
		{
			//throw new NotImplementedException();
			txtLog.Text += message;
		}

		private void btnCalc_Click(object sender, EventArgs e)
		{
			txtLog.Text = "";


			Vector<double> x0;
			double eps = 0, x0x = 0, x0y = 0, h = 0.1;
			Vector<double> res;
			int steps;

			//Парсинг параметров
			try
			{
				x0x = double.Parse(txtX0X.Text);
				x0y = double.Parse(txtX0Y.Text);
				eps = double.Parse(txtEps.Text);
				h = double.Parse(txtH.Text);
			}
			catch (FormatException exp)
			{
				MessageBox.Show("Неверный ввод - не число");
				return;
			}

			x0 = Vector<double>.Build.DenseOfArray(new double[] { x0x, x0y });

			//Определяем функцию
			Func<Vector<double>, double> f;
			if (rbTest.Checked)
				f = test;
			else
				f = task213;

			//Определение разностной схемы
			AbstractGradientCalc calc;
			if (rbCenter.Checked)
				calc = new CentralGradientCalc(h);
			else
				calc = new RightGradientCalc(h);

			//Вычисление
			if (rbGZ.Checked)
				res = (new OptimalGradientMethod()).FindMinimum(f, x0, new CentralGradientCalc(0.01), 0.01, out steps);
			else
				res = (new DFPMethod()).FindMinimum(f, x0, new CentralGradientCalc(0.01), 0.01, out steps);

			txtOut.Text = res.Vector2String(Utils.GetFormat(eps));
		}


		double task213(Vector<double> x)
		{
			return Math.Pow(
				x[0] + 10 * x[1], 2) +
				5 * Math.Pow(x[2] - x[3], 2) +
				Math.Pow(x[1] - 2 * x[2], 4) +
				10 * Math.Pow(x[0] - x[3], 4);
		}

		double test(Vector<double> x)
		{
			return 4 * Math.Pow(x[0]-5, 2) + Math.Pow(x[1] - 6, 2);
        }	
			


    }
}
