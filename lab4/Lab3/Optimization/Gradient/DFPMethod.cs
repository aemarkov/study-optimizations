using System;
using MathNet.Numerics.LinearAlgebra;
using Optimization.Differentation;
using Optimization.Unidimensional;

namespace Optimization.Gradient
{
	public class DFPMethod
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
		public Vector<double> FindMinimum(Func<Vector<double>, double> f, Vector<double> x, AbstractGradientCalc gradient_calc, double eps, out int steps_count, Func<Vector<double>, double>[] borders)
		{
			///!!!!!!!!!
			double interval_h = eps;					//Шаг для поиска интервала
			double min_eps = eps;					//Точность для поиска минимума
			steps_count = 0;							//Число шагов
			string format = Utils.GetFormat(eps);
			double norm;

			//Создаем единичную квазиньютновскую матрицу
			Matrix<double> H = Matrix<double>.Build.DenseIdentity(x.Count, x.Count);
			//Matrix<double> H_prev = null;

			Vector<double> p = Vector<double>.Build.Dense(x.Count);
			Vector<double> grad = null;
			Vector<double> grad_prev = Vector<double>.Build.Dense(x.Count);
			Vector<double> x_prev = Vector<double>.Build.Dense(x.Count);

			//Вычисление градиента
			grad = gradient_calc.CalcGradient(f, x);
			
			while (((norm=Utils.CalcNorm(grad)) > eps)&&(steps_count<3000))
			{

				if (steps_count>0)
				{
					//Вспомогательные матрицы (Матрицы столбцы)
					var s_v = (x - x_prev);
					var s = s_v.ToColumnMatrix();

					var y_v = (grad - grad_prev);
                    var y = y_v.ToColumnMatrix();

					//Эти же транспонированные
					var y_t = y.Transpose();
					var s_t = s.Transpose();

					//Пересчет квазиньютоновской матрицы
					H = H - (H * y * y_t * H) / (y_t * H * y)[0, 0] + (s * s_t) / (y_t * s)[0, 0];
				}
				

				//Вычисление направления поиска
				p = -H * grad;
				//Определяем шаг поиска методом одномерной оптимизации
				Func<double, double> f_ = y => f(x + y * p);
				var interval = IntervalFinder.Find(0, interval_h, f_);
				var a = GoldenRatioMethod.FindMinimum(interval, f_, min_eps);
				
				x.CopyTo(x_prev);
				x = x + a * p;

				//WTF
				//if (!Utils.CheckInD0(x, borders)) return x;

				//Вычисление градиента
				grad.CopyTo(grad_prev);
				grad = gradient_calc.CalcGradient(f, x);

				steps_count++;
			}

			return x;
		}
	}
}
