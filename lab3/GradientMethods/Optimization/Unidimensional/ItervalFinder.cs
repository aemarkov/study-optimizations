using System;
using Optimization;

namespace Optimization.Unidimensional
{
	/// <summary>
	/// Локализация отрезка минимума методом
	/// Дэвиса-Свенна-Кэмпи
	/// </summary>
	static class IntervalFinder
	{
		/// <summary>
		/// Ищет отрезок локализации минимума
		/// </summary>
		/// <param name="x0">Начальная точка</param>
		/// <param name="h">Шаг поиска</param>
		/// <param name="f">Минимизируемая функция</param>
		/// <returns>Найденный отрезок локализации минимума</returns>
		public static Interval Find(double x0, double h, Func<double, double> f)
		{
			double fk;              //Значение функции на k-м шаге
			double fk_h;			//

			//Определение направления поиска
			fk = f(x0);
			fk_h = f(x0 + h);

			//Идем вправо...
			if (fk > fk_h)
			{
				//Функция убывает
				return _search(x0, x0, 0, x0 + h, h, f);
			}
			else
			{
				//Если при движении вправо функция не убывает - идем влево
				fk_h = f(x0 - h);
				if (fk > fk_h)
				{
					//Функция убывает при движении влево
					return _search(x0, 0, x0, x0 - h, -h, f);
				}
				else
				{
					//Функция не убывает ни при движении вправо, ни при движении влево
					//Минимум где-то здесь
					return new Interval(x0 - h, x0 + h);
				}
			}
			
		}

		// Поиск в уже определенную сторону
		private static Interval _search(double x0, double a, double b, double xk, double h, Func<double, double> f)
		{
			double xk_prev;
			double fk_prev;			//Предыдущее значенеи функции
			double fk;				//Текущее значение функции
			int k = 2;              //Номер итерации


			//Поиск отрезка
			do
			{
				xk_prev = xk;
				fk_prev = f(xk);
				xk = x0 + Math.Pow(2, k - 1) * h;
				fk = f(xk);

				if (fk_prev <= fk)
				{
					//На очередном шаге значение функции не уменьшилось - мы нашли отрезок
					if (h > 0)
						b = xk;
					else
						a = xk;
				}
				else
				{
					//На очередном шаге значение функции уменьшилось - продолжаем поиск

					if (h > 0)
						a = xk_prev;
					else
						b = xk_prev;
				}

				k++;

			} while (fk_prev > fk);

			return new Interval(a, b);
		}
	}
}
