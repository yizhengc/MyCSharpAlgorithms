using System;

namespace MyCSharpAlgorithms
{
	public class Division
	{
		public Division ()
		{
		}

		public int Divide(int dividend, int divisor) {
			if (divisor == 0)
			{
				throw new ArgumentException();
			}
			else if (divisor == int.MinValue)
			{
				return 0;
			}
			else if (divisor == 1)
			{
				return dividend;
			}
			else if (divisor == -1)
			{
				if (dividend == int.MinValue)
				{
					return int.MaxValue;
				}
				else
				{
					return -dividend;
				}
			}
			else
			{
				var isPositive = dividend > 0 && divisor > 0 || dividend < 0 && dividend < 0;

				dividend = (dividend == int.MinValue ? int.MaxValue : Math.Abs(dividend));
				divisor = Math.Abs(divisor);

				int res = 0;

				while(dividend >= divisor)
				{
					res++;
					dividend -= divisor;
				}

				return isPositive ? res : -res;
			}
		}
	}
}

