using System.Globalization;
using System;

namespace Optimization
{
	/// <summary>
	/// Различные вспомогательные утилиты
	/// </summary>
	public static class OptimizationUtils
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

		//Расчет евклидовой нормы
		//Расчитывает евклидову норму
		public  static double EuclidNorm(Point2D h)
		{
			return Math.Sqrt(h.X * h.X + h.Y * h.Y);
		}
	}
}
