using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathNet.Numerics.LinearAlgebra;
using Optimization.Differentation;

namespace Optimization.Gradient
{ 
    public abstract class AbstractMethod
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
		abstract public Vector<double> FindMinimum(Func<Vector<double>, double> f, Vector<double> x, AbstractGradientCalc gradient_calc, double eps, out int steps_count);


		//Расчет Евклидовой нормы
		protected static double calc_norm(Vector<double> v)
		{
			double sum = 0;
			foreach (var x in v)
				sum += x * x;

			return Math.Sqrt(sum);
		}
	}
}
