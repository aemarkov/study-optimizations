using System;

namespace Optimization
{ 
	/// <summary>
	/// Представляет собой числовой интервал - две границы
	/// A - начало интервала
	/// B - конец интервала
	/// Названия выбраны не слишком очевидно, чтобы
	/// не делать использование класса громоздким
	/// </summary>
	public class Interval
	{
		/// <summary>
		/// Начало интервала
		/// </summary>
		public double A { get; set; }

		/// <summary>
		/// Конец интервала
		/// </summary>
		public double B { get; set; }

		/// <summary>
		/// Создает объект с заданными границами интервала
		/// </summary>
		/// <param name="a">Нижняя граница интервала</param>
		/// <param name="b">Верхняя граница интервала</param>
		public Interval(double a, double b)
		{
			if (b < a)
				throw new ArgumentException("Конец интервала должен быть больше его начала");
			A = a;
			B = b;
		}
	}
}
