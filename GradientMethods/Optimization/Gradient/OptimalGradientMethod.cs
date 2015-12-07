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
	public class OptimalGradientMethod : AbstractMethod
	{

		/// <summary>
		/// Минимизация функции
		/// </summary>
		/// <param name="f">Функция</param>
		/// <param name="x">Начальное приближение</param>
		/// <param name="gradient_calc">Функция вычисление градиента</param>
		/// <param name="eps">Точность</param>
		/// <param name="steps_count">Возвращаемое значение: число шагов, за которое был найден ответ</param>
		/// <returns></returns>
		override public Vector<double> FindMinimum(Func<Vector<double>, double> f, Vector<double> x, AbstractGradientCalc gradient_calc, double eps, out int steps_count)
		{
			Vector<double> grad = null;

			///!!!!!!!!!
			double interval_h = 0.0001;     //Шаг для поиска интервала
			double min_eps = 0.0001;       //Точность для поиска минимума
			string g_s;

			steps_count = 0;

			//Вычисление градиента
			grad = gradient_calc.CalcGradient(f, x);
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
				grad = gradient_calc.CalcGradient(f, x);
				g_s = grad.Vector2String("N4");

				steps_count++;
			}

			return x;
		}

	}
}
