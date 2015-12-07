using System;
using MathNet.Numerics.LinearAlgebra;

namespace Optimization.Differentation
{
	/// <summary>
	/// Интерфейс для расчета градиента функции многих переменных
	/// </summary>
	public abstract class AbstractGradientCalc
	{
		/// <summary>
		/// Вычисляет градиент
		/// </summary>
		/// <param name="f">Функция многих переменных</param>
		/// <param name="x">Точка, в которой ищется производная</param>
		/// <param name="h">Шаг</param>
		/// <returns></returns>
		public abstract Vector<double> CalcGradient(Func<Vector<double>, double> f, Vector<double> x, double h);


		//Генерирует вектор исходных координат, где координата с заданным индексом измененеа
		//на h
		protected Vector<double> build_vector(Vector<double> x, int index, double h)
		{
			var new_x = Vector<double>.Build.Dense(x.Count);
			x.CopyTo(new_x);
			new_x[index] += h;
			return new_x;
		}
	}
}
