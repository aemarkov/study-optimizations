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
			SimpleLogger.Logger.MessageWrited += Logger_MessageWrited;
		}
		
		//Запись сообщениея
		private void Logger_MessageWrited(string message)
		{
			txtLog.Text += message + Environment.NewLine;
		}

		//Тестовое задание
		double test(double x1, double x2)
		{
			return 4 * Math.Pow(x1 - 5, 2) + Math.Pow(x2 - 6, 2);
		}

		//Задание №2.1.1
		double task211(double x1, double x2)
		{
			return Math.Pow(x1*x1+x2-11,2)+Math.Pow(x1+x2*x2-7,2);
		}

		private void btnCalc_Click(object sender, EventArgs e)
		{
			Point2D x0, h;
			double eps=0, x0x=0, x0y=0, hx=0, hy=0;
			Point2D res;

			//Парсинг параметров
			try
			{
				x0x = double.Parse(txtX0X.Text);
				x0y = double.Parse(txtX0Y.Text);
				hx = double.Parse(txtHX.Text);
				hy = double.Parse(txtHY.Text);
				eps = double.Parse(txtEps.Text);
			}
			catch(FormatException exp)
			{
				MessageBox.Show("Неверный ввод - не число");
				return;
			}

			x0 = new Point2D(x0x, x0y);
			h = new Point2D(hx, hy);

			//Определяем функцию
			Func<double, double, double> f;

			if (rbTest.Checked)
				f = test;
			else
				f = task211;

			//Вычисление
			if (rbGZ.Checked)
				res = GaussZeidelMethod.FindMinimum(f, x0, h, eps);
			else
				res = HookJeevesMethod.FindMinimum(f, x0, h, eps);

			txtOut.Text = res.ToString(OptimizationUtils.GetFormat(eps));
		}
	}
}
