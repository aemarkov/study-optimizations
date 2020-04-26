using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SimpleLogger;
namespace Optimization.Multivariate
{
	//Метод Хука-Дживса
	class HookJeevesMethod
	{
		public static Point2D FindMinimum(Func<double, double, double> f, Point2D b1, Point2D h, double eps0)
		{
			Point2D b2, xk, x;
			bool flag;
			double z = 0.1;
			double f1, f2;

			Logger.Write("===> Минимизация методом Хука-Дживса <==");
			Logger.WriteContinue(" |Начальная точка b1: {0}", b1);
			Logger.WriteContinue(" |Шаг h: {0} ", h);
			Logger.WriteContinue(" |Точность eps: {0} ", eps0);

			do
			{
				do
				{
					xk = b1;
					//Исследуюший поиск
					b2 = search(f, xk, h);
					Logger.Write("1. xk = b1 = {0}", xk);
					Logger.Write("2. Выполняем исследующий поиск вокруг точки xk: b2 = {0}", b2);


					do
					{
						//Шаг по образцу
						xk = new Point2D(b1.X + 2 * (b2.X-b1.X), b1.Y + 2 * (b2.Y-b1.Y));
						Logger.Write("3. Выполняем шаг по образцу xk = b1 + 2(b2-b1) = {0}", xk);

						//Исследующий поиск
						x = search(f, xk, h);
						Logger.Write("4. Выполняем исследующий поиск вокруг точки xk: x = {0}",x);
						b1 = b2;
						Logger.Write("5. b1 = b2 = {0}", b1);

						f1 = f(x.X, x.Y);
						f2 = f(b1.X, b1.Y);

						Logger.Write("6. f(x) = {0};  f(b1) = {1}", f1, f2);
						if (f1 < f2)
						{
							b2 = x;
							Logger.WriteContinue("   f(x) < f(b1) => переход на шаг 3");
						}

					} while (f1<f2);

					flag = f(x.X, x.Y) > f(b1.X, b1.Y);
					if (flag)
						Logger.Write("f(x) > f(b1) => переход на шаг 1");
                } while (flag);

				if (OptimizationUtils.EuclidNorm(h) <= eps0) break;

				//Уменьшаем шаг
				h.X = z * h.X;
				h.Y = z * h.Y;

				Logger.Write("9. Уменьшаем шаг: h = {0} * h = {1}", z, h);

			} while (true);

			Logger.Write("||h|| = {0} <= eps => поиск завершен");
			Logger.WriteContinue("Минимум найден: b1 = {0}", b1);

			return b1;
		}

		//Исследующий поиск в окрестности точки
		static Point2D search(Func<double, double, double> f, Point2D b, Point2D h)
		{
			double fb, f_;
			fb = f(b.X, b.Y);

			//Для X
			double b_ = b.X + h.X;

			if((f_ = f(b.X + h.X, b.Y)) <fb)
			{
				b.X += h.X;
				fb = f_;
			}

			b_ = b.X - h.X;
			if((f_=f(b.X - h.X, b.Y))<fb)
            {
				b.X -= h.X;
				fb = f_;
			}

			//Для Y
			b_ = b.Y + h.Y;
			if ((f_ = f(b.X, b.Y+h.Y)) < fb)
			{
				b.Y += h.Y;
				fb = f_;
			}

			b_ = b.Y - h.Y;
			if ((f_ = f(b.X, b.Y-h.Y)) < fb)
			{
				b.Y -= h.Y;
				fb = f_;
			}

			return b;
		}
    }
}
