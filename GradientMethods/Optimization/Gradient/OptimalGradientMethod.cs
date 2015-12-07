using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathNet.Numerics.LinearAlgebra;

using Optimization;
using Optimization.Differentation;

namespace Optimization.Gradient
{
	/// <summary>
	/// Оптимальный градиентный метод.
	/// </summary>
	static class OptimalGradientMethod
	{
		public static Vector<double> FindMinimum(Func<Vector<double>, double> f, Vector<double> x, AbstractGradientCalc gradient_calc, double h, double eps)
		{
			Vector<double> grad = null;

			grad = gradient_calc.CalcGradient(f, x, h);
			while(calc_norm(grad)>eps)
			{

			}

			return grad;
		}


		//Расчет Евклидовой нормы
		private static double calc_norm(Vector<double> v)
		{
			double sum = 0;
			foreach (var x in v)
				sum += x * x;

			return Math.Sqrt(sum);
		}
	}
}
