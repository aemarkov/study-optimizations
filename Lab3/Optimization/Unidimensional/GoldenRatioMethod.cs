using System;
using Optimization;

namespace Optimization.Unidimensional
{
	/// <summary>
	/// Ищет минимум функции используя метод золотого сечения
	/// </summary>
	class GoldenRatioMethod
	{
		public static double FindMinimum(Interval interval, Func<double, double> f, double eps)
		{
			double t = (Math.Sqrt(5) + 1) / 2;		//Золотое сечение

			double a = interval.A;                  //Границы интервала
			double b = interval.B;                  //
			double x1, x2;
			double f1, f2;                         //Значения функции в точках x1,  x2

			//Вычисление начальных точек
			x1 = a + (b - a) / (t * t);
			x2 = a + (b - a) / t;

			do
			{
				//Вычисление функции в точках x1, x2
				f1 = f(x1);
				f2 = f(x2);

				//Пересчет границ
				if (f1 <= f2)
				{
					b = x2;
					x2 = x1;
					x1 = a + b - x2;
				}
				else
				{
					a = x1;
					x1 = x2;
					x2 = a + b - x1;
				}

			} while ((b - a) / 2 >= eps);

			double min = (a + b) / 2;
			return min;
		}
	}
}
