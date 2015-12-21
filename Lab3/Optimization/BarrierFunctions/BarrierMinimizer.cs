using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathNet.Numerics.LinearAlgebra;

using Optimization.Gradient;
using Optimization.Differentation;

namespace Optimization.BarrierFunctions
{
	class BarrierMinimizer
	{
		/// <summary>
		/// Минимизирует функцию методом барьерных функций
		/// </summary>
		/// <param name="f">Минимизируемая функция</param>
		/// <param name="borders">Массиф функци ограничений</param>
		/// <param name="barrier_func">Функция барьера</param>
		/// <param name="x0">Начальная точка</param>
		/// <param name="r0">Начальное значение штрафа</param>
		/// <param name="z">Коэффициент уменьшения штрафа</param>
		/// <param name="eps">Точность</param>
		/// <returns></returns>
		public static Vector<double> FindMinimum(Func<Vector<double>,double> f, Func<Vector<double>, double>[] borders, Func<double,double> barrier_func, Vector<double> x0, double r0, double z, double eps)
		{
			/*
				ВОПРОСЫ
				1) Какой выбрать шаг
				2) Действительно ли F не зависит от rk
				3) Какую давать точность
				4) Проверка??!!
			*/

			int k;					//Номер шага
			double rk;				//Штарф
			double B;				//WTF
			Vector<double> min_x;	//Миниум ф-ии F

			var gradient_method = new DFPMethod();
			var gradient_calc = new CentralGradientCalc(0.0001);		//!!! (1)
			int steps;

			//1.
			k = 0;
			rk = r0;

			do
			{
				//2.
				//Это sum(phi_i(f_i(x)));
				Func<Vector<double>, double> sum_f = x =>
				 {
					 double sum = 0;
					 foreach (var b in borders)
						 sum += barrier_func(b(x));
					 return sum;
				 };

				//Это вспомогательная функция F(x,rk)
				//Func<Vector<double>, double, double> F = (x, rk) => f(x) + rk * sum_f(x);
				//Преобразуем вспомогательную функцию вида F(x,rk) к F'(x'), где x' = (x, rk)=(x1,...,xn,rk)
				//Func<Vector<double>, double> F_ = v => F(decrease_dimension(v), v[v.Count - 1]);

				//!!! (2)
				Func<Vector<double>, double> F = x => f(x) + rk * sum_f(x);

				//3.
				//!!! (3)
				//Минимизируем
				//!!! (4)
				min_x = gradient_method.FindMinimum(F, x0, gradient_calc, eps/10, out steps);
				bool is_in = check_in_D0(min_x, borders);

				//4. 
				//Вычисляем какую-то хрень
				B = rk * sum_f(min_x);

				if (Math.Abs(B) >= eps)
				{
					rk = z * rk;
					x0 = min_x;
					k++;
				}

			} while (Math.Abs(B) >= eps);

			return min_x;
		}

		//Барьерные ф-ии
		//Я помещаю их здесь, чтобы можно было юзать
		//пользователю сразу готовые

		/// <summary>
		/// Функция барьера Кэррола
		/// </summary>
		/// <param name="fx">Значение функции границы</param>
		/// <returns></returns>
		public static double KarrolBarrier(double fx)
		{
			return 1 / fx;
		}

		/// <summary>
		/// Функция барьера Фриша
		/// </summary>
		/// <param name="fx"></param>
		/// <returns></returns>
		public static double FrishBarrier(double fx)
		{
			return -Math.Log(fx);
		}


		private static bool check_in_D0(Vector<double> vec, Func<Vector<double>, double>[] borders)
		{
			bool is_corr = true;
			foreach (var b in borders)
				is_corr &= b(vec) >= 0;

			return is_corr;
		}

		//[НЕ НУЖНО]
		//Уменьшает размерность вектора, отбирая последнее измереение
		private static Vector<double> decrease_dimension(Vector<double> vec)
		{
			var new_vec = Vector<double>.Build.Dense(vec.Count - 1);
			for (int i = 0; i < vec.Count - 1; i++)
				new_vec[i] = vec[i];

			return new_vec;
				
		}
	}
}
