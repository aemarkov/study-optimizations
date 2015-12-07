using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathNet.Numerics.LinearAlgebra;

namespace Optimization
{
	public static class  Utils
	{
		public static string Vector2String(this Vector<double> vector, string format)
		{
			StringBuilder sb = new StringBuilder("(");
			foreach(var dim in vector)
			{
				sb.Append(dim.ToString(format));
				sb.Append("; ");
			}
			sb.Append(")");
			return sb.ToString();
		}
	}
}
