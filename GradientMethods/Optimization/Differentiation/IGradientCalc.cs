using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathNet.Numerics.LinearAlgebra;

namespace GradientMethods.Optimization.Differentiation
{
	/// <summary>
	/// Интерфейс для расчета градиента функции многих переменных
	/// </summary>
	interface IGradientCalc
	{
		/// <summary>
		/// Вычисляет градиент
		/// </summary>
		/// <param name="f">Функция многих переменных</param>
		/// <param name="x">Точка, в которой ищется производная</param>
		/// <param name="h">Шаг</param>
		/// <returns></returns>
		Vector<double> CalcGradient(Func<Vector<double>, double> f, Vector<double> x, double h);		
	}
}
