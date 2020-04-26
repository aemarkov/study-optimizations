using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathNet.Numerics.LinearAlgebra;

using System.Diagnostics;
using Optimization.Differentation;
using Optimization.Unidimensional;
using SimpleLogger;

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
			double interval_h = 0.000001;					//Шаг для поиска интервала
			double min_eps = 0.000001;						//Точность для поиска минимума
			string format = Utils.GetFormat(eps/100);		//Форматная строка для вывода чисел с нужным числом знаков
			steps_count = 0;
			double norm = 0;

			Logger.Write("===> Минимизация оптимальным градиентным методом <==");
			Logger.WriteContinue(" |Начальная точка x0: {0}", x.Vector2String(format));
			Logger.WriteContinue(" |Точность eps: {0} ", eps.ToString(format));


			Logger.Write("Шаг 1: k = {0}", steps_count);

			//Вычисление градиента
			grad = gradient_calc.CalcGradient(f, x);

			while((norm=calc_norm(grad))>eps)
			{
				Debug.WriteLine("Grad: {0} fuck", "kek");

				Logger.Write("Шаг 2: Вычисление градиента");
				Logger.WriteContinue("grad = {0}", grad.Vector2String(format));

				Logger.Write("Шаг 3: Проверка критерия останова:");
				Logger.WriteContinue("Норма norm = {0}", norm.ToString(format));
				Logger.WriteContinue("norm > eps : {0} > {1}", norm.ToString(format), eps.ToString(format));

				//Вычисление длины шага
				//ak = arg min f(x-a*gradf(x));
				Func<double, double> f_ = y => f(x - y * grad);
				var interval = IntervalFinder.Find(0, interval_h, f_);
				var a = GoldenRatioMethod.FindMinimum(interval, f_, min_eps);

				Logger.Write("Шаг 4: Определение длины шага");
				Logger.WriteContinue("ak = {0}", a.ToString(format));

				//Шаг
				x = x - a * grad;
				//Debug.WriteLine("x: {0}", x.Vector2String("N3"));
				Logger.Write("Шаг 5: Xk+1 = Xk + a*grad = {0}", x.Vector2String(format));
				grad = gradient_calc.CalcGradient(f, x);

				steps_count++;
				Logger.Write("Шаг 6: k = k +1 = {0}", steps_count);
				Logger.Write("----------------------");
			}

			Logger.Write("Шаг 3: Проверка критерия останова:");
			Logger.WriteContinue("Норма norm = {0}", norm.ToString(format));
			Logger.WriteContinue("norm > eps : {0} > {1}", norm.ToString(format), eps.ToString(format));

			Logger.Write("Шаг 8: x* = x = {0}", x.Vector2String(format));
			Logger.WriteContinue("Поиск закончен");
			Logger.WriteContinue("Число итераций: {0}", steps_count);

			return x;
		}

	}
}
