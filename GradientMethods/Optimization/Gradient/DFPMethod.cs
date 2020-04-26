using System;

using SimpleLogger;
using MathNet.Numerics.LinearAlgebra;
using Optimization.Differentation;
using Optimization.Unidimensional;

namespace Optimization.Gradient
{
	public class DFPMethod : AbstractMethod
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
			///!!!!!!!!!
			double interval_h = 0.0001;					//Шаг для поиска интервала
			double min_eps = 0.0001;					//Точность для поиска минимума
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

			Logger.Write("===> Минимизация методом переменной метрики <==");
			Logger.WriteContinue(" |Начальная точка x0: {0}", x.Vector2String(format));
			Logger.WriteContinue(" |Точность eps: {0} ", eps.ToString(format));

			Logger.Write("Шаг 1: k=0");

			//Вычисление градиента
			grad = gradient_calc.CalcGradient(f, x);
			
			while ((norm=calc_norm(grad)) > eps)
			{
				Logger.Write("Шаг 2: Вычисление градиента");
				Logger.WriteContinue("grad = {0}", grad.Vector2String(format));

				Logger.Write("Шаг 3: Проверка критерия останова:");
				Logger.WriteContinue("Норма norm = {0}", norm.ToString(format));
				Logger.WriteContinue("norm > eps : {0} > {1}", norm.ToString(format), eps.ToString(format));

				if (steps_count>0)
				{
					//Вспомогательные матрицы (Матрицы столбцы)
					var s_v = (x - x_prev);
					var s = s_v.ToColumnMatrix();
					Logger.Write("Шаг 5: s:{0}T", s_v.Vector2String(format));

					var y_v = (grad - grad_prev);
                    var y = y_v.ToColumnMatrix();
					Logger.Write("Шаг 6: y:{0}T", y_v.Vector2String(format));

					//Эти же транспонированные
					var y_t = y.Transpose();
					var s_t = s.Transpose();

					//Пересчет квазиньютоновской матрицы
					H = H - (H * y * y_t * H) / (y_t * H * y)[0, 0] + (s * s_t) / (y_t * s)[0, 0];
					Logger.Write("Шаг 7: Пересчет матрицы H:\n{0}", H);
				}
				

				//Вычисление направления поиска
				p = -H * grad;
				Logger.Write("Шаг 8: Направление поиска p = {0}", p.Vector2String(format));

				//Определяем шаг поиска методом одномерной оптимизации
				Func<double, double> f_ = y => f(x + y * p);
				var interval = IntervalFinder.Find(0, interval_h, f_);
				var a = GoldenRatioMethod.FindMinimum(interval, f_, min_eps);

				Logger.Write("Шаг 9: Определение длины шага");
				Logger.WriteContinue("ak = {0}", a);

				x.CopyTo(x_prev);
				x = x + a * p;

				Logger.Write("Шаг 10: x = {0}", x.Vector2String(format));

				//Вычисление градиента
				grad.CopyTo(grad_prev);
				grad = gradient_calc.CalcGradient(f, x);

				steps_count++;
				Logger.Write("Шаг 11: k = k +1 = {0}", steps_count);
				Logger.Write("----------------------");
			}

			Logger.Write("Шаг 3: Проверка критерия останова:");
			Logger.WriteContinue("Норма norm = {0}", norm.ToString(format));
			Logger.WriteContinue("norm > eps : {0} > {1}", norm.ToString(format), eps.ToString(format));

			Logger.Write("Шаг 12: x* = x = {0}", x.Vector2String(format));
			Logger.WriteContinue("Поиск закончен");
			Logger.WriteContinue("Число итераций: {0}", steps_count);

			return x;
		}
	}
}
