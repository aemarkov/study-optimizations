using System;
using System.Diagnostics;

using Optimization.Univariate;
using SimpleLogger;

namespace Optimization.Multivariate
{
	//Оптимзация методом покоординатного спуска
	//(Метод Гаусса-Зейделя)
	class GaussZeidelMethod
	{
		/// <summary>
		/// Осуществляет оптимизацию многомерной функции методом Гаусса-Зейделя
		/// </summary>
		/// <param name="f">Минимизируемая функция</param>
		/// <param name="x0">начальной точки посика</param>
		/// <param name="interval">интервалы поиска</param>
		/// <param name="h">Векор положительных приращений координат</param>
		/// <param name="eps0">Точность</param>
		/// <returns></returns>
		public static Point2D FindMinimum(Func<double, double, double> f, Point2D x0, Point2D h, double eps0)
		{
			/*Стоило бы сделать поддержку функций многих переменных (N>2), но тут трудности в преобразовании
			Func<double[], double> -> Func<double, double>*/

			double finder_h = 0.05;         //Шаг поиска отрезка минимума
			double z = 0.1;					//Уменьшение шага поиска
			double equal_eps = eps0;		//Совпадение

			Point2D x = new Point2D(0, 0);
			Func<double, double> f_fixed;
			Interval interval;
			double ak;

			Logger.Write("===> Минимизация методом Гаусса-Зейделя <==");
			Logger.WriteContinue(" |Начальная точка x0: {0}", x0);
			Logger.WriteContinue(" |Шаг h: {0} ", h);
			Logger.WriteContinue(" |Точность eps: {0} ", eps0);


			string format = OptimizationUtils.GetFormat(eps0/10);

			do
			{
				do
				{
					x0.X = x.X;
					x0.Y = x.Y;

					Logger.Write("Минимазация по каждой координате");
					//Поочередная минимизация по каждой координате
					//X
					Logger.WriteContinue("X:");
					f_fixed = a => f(x0.X + a * h.X, x0.Y);
					interval = IntervalFinder.Find(x0.X, finder_h, f_fixed);
					ak = GoldenRatioMethod.FindMinimum(interval, f_fixed, eps0 / 5);
					x.X = x0.X + ak * h.X;
					Logger.WriteContinue("  3. ak = {0:" + format + "}", ak);
					Logger.WriteContinue("  4. x[k+1].X=x[k].X + ak*h.X = {0:" + format + "} + {1:" + format + "} * {2:" + format + "} = {3:" + format + "}", x0.X, ak, h.X, x.X);

					//Y
					Logger.WriteContinue("Y");
					f_fixed = a => f(x.X, x0.Y + a * h.Y);
					interval = IntervalFinder.Find(x0.Y, finder_h, f_fixed);
					ak = GoldenRatioMethod.FindMinimum(interval, f_fixed, eps0 / 5);
					x.Y = x0.Y + ak * h.Y;
					Logger.WriteContinue("  3. ak = {0:" + format + "}", ak);
					Logger.WriteContinue("  4. x[k+1].Y=x[k].Y + ak*h.Y = {0:" + format + "} + {1:" + format + "} * {2:" + format + "} = {3:" + format + "}", x0.Y, ak, h.Y, x.Y);
				}
				while (!check_equal(x0, x, equal_eps));
				Logger.Write("x[k+1]==x[k]");
				var h0 = h;

				if (OptimizationUtils.EuclidNorm(h) <= eps0) break;

				//Уменьшаем шаг
				h.X = z * h.X;
				h.Y = z * h.Y;

				Logger.WriteContinue("9. Уменьшаем шаг: h = {0:" + format + "} * {1:" + format + "} = {2:" + format + "}", z, h0, h);
				Logger.WriteContinue("Переход на шаг 3");
			} while (true);

			Logger.Write("||h|| = {0:" + format + "} < eps", OptimizationUtils.EuclidNorm(h));
			Logger.Write("Минимум найден: {0:" + format + "}", x);

			return x;
		}


		//Сравнение двух точек на равенство
		private static bool check_equal(Point2D a, Point2D b, double eps)
		{
			return (Math.Abs(a.X - b.X) < eps) && (Math.Abs(a.Y - b.Y) < eps);
        }
	}
}
