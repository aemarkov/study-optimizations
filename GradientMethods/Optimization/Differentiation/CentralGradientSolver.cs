using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathNet.Numerics.LinearAlgebra;

namespace Optimization.Differentation
{
	//Центральная разностная схема
	class CentralGradientSolver : AbstractGradientCalc
	{
		/// <summary>
		/// Вычисляет градиент
		/// </summary>
		/// <param name="f">Функция многих переменных</param>
		/// <param name="x">Точка, в которой ищется производная</param>
		/// <param name="h">Шаг</param>
		/// <returns></returns>
		public override Vector<double> CalcGradient(Func<Vector<double>, double> f, Vector<double> x, double h)
		{
			/*	Центральная разностная схема:
					  f(x+h)-f(x-h)
				f(x)= ------------
				          2h
				
				В частных производных:
				x1 = (f(x1+h, x2,...,xn)-f(x1-h, x2,...,xn))/2h
				x1 = (f(x1, x2+h,...,xn)-f(x1, x2-h,...,xn))/2h
				ну ты понел...
			*/
		
			var gradient = Vector<double>.Build.Dense(x.Count);         //Создаем вектор такой же размерности
			
			//Расчет градиента
			for(int i = 0; i<x.Count; i++)
			{
				var x_1 = build_vector(x, i, h);
				var x_2 = build_vector(x, i, -h);
				gradient[i] = (f(x_1) - f(x_2)) / (2*h);
			}
			
			return gradient;
		}
	}
}
