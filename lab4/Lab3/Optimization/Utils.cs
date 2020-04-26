using System;
using System.Text;
using System.Globalization;

using MathNet.Numerics.LinearAlgebra;

namespace Optimization
{
	public static class  Utils
	{
		//Определяет формат строки для отображения чисел с точностью эпсилон
		//В результате все числа будут выводиться с таким же числом знаков после
		//запятой, как и эпсилон.
		//ВНИМАНИЕ: т.к double не является точным, метод не гарантирует качественный
		//результат, если eps не задан констатной а вычислен
		// 0.001 =>      3 знака после запятой
		// 0.00100099 => 8 знаков после запятой
		// будте осторожны
		public static string GetFormat(double eps)
		{
			//Определяем число знаков после запятой:
			//Просто приводим к строке и находим позицию разделителя
			string epsS = eps.ToString();
			int index = epsS.IndexOf(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);
			if (index == -1) return "N0";
			int digits = epsS.Length - 1 - index;

			return "N" + (digits);
		}


		/// <summary>
		/// Приводит нормально вектор к строке
		/// </summary>
		/// <param name="vector"></param>
		/// <param name="format"></param>
		/// <returns></returns>
		public static string Vector2String(this Vector<double> vector, string format=null)
		{
			StringBuilder sb = new StringBuilder("(");
			foreach(var dim in vector)
			{
				if (format != null)
					sb.Append(dim.ToString(format));
				else
					sb.Append(dim.ToString());

				sb.Append("; ");
			}
			sb.Append(")");
			return sb.ToString();
		}

		/// <summary>
		/// Проверка принадлежности точки области
		/// </summary>
		/// <param name="vec"></param>
		/// <param name="borders"></param>
		/// <returns></returns>
		public static bool CheckInD0(Vector<double> vec, Func<Vector<double>, double>[] borders)
		{
			bool is_corr = true;
			foreach (var b in borders)
				is_corr &= b(vec) >= 0;

			return is_corr;
		}

		//Расчет Евклидовой нормы
		public static double CalcNorm(Vector<double> v)
		{
			double sum = 0;
			foreach (var x in v)
				sum += x * x;

			return Math.Sqrt(sum);
		}

	}
}
