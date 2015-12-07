using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathNet.Numerics.LinearAlgebra;

using Optimization;
using Optimization.Differentation;
using Optimization.Unidimensional;

namespace Optimization.Gradient
{
	/// <summary>
	/// Оптимальный градиентный метод.
	/// </summary>
	static class OptimalGradientMethod
	{
		public static Vector<double> FindMinimum(Func<Vector<double>, double> f, Vector<double> x, AbstractGradientCalc gradient_calc, double h, double eps, out int steps_count)
		{
			Vector<double> grad = null;

			double interval_h = 0.0001;     //Шаг для поиска интервала
			double min_eps = 0.0001;       //Точность для поиска минимума
			string g_s;

			steps_count = 0;

			//Вычисление градиента
			grad = gradient_calc.CalcGradient(f, x, h);
			g_s = grad.Vector2String("N4");

			while(calc_norm(grad)>eps)
			{
				//Вычисление длины шага
				//ak = arg min f(x-a*gradf(x));
				Func<double, double> f_ = y => f(x - y * grad);
				var interval = IntervalFinder.Find(0, interval_h, f_);
				var a = GoldenRatioMethod.FindMinimum(interval, f_, min_eps);

				//Шаг
				x = x - a * grad;
				g_s = x.Vector2String("N2");
				grad = gradient_calc.CalcGradient(f, x, h);
				g_s = grad.Vector2String("N4");

				steps_count++;
			}

			return x;
		}


		//Расчет Евклидовой нормы
		private static double calc_norm(Vector<double> v)
		{
			double sum = 0;
			foreach (var x in v)
				sum += x * x;

			return Math.Sqrt(sum);
		}
	}
}
