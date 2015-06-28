using System;

namespace MyCSharpAlgorithms
{
	public class Factorial
	{
		public static int TrailingZeroes(int n)
		{
			int c = 0;
			int b = 5;
			int sum = 0;
			while (b <= int.MaxValue / 5 && b * 5 <= n)
			{

				b *= 5;
				c++;
				sum += c;
			}

			return sum + rTrailingZeroes(n);
		}

		public static int rTrailingZeroes(int n) {

			if (n <= 10) {
				if (n == 10) {
					return 2;
				} else if (n >= 5) {
					return 1;
				} else {
					return 0;
				}
			} else {
				int b = 1;
				int i = 0;
				while (b <= int.MaxValue / 10 && b * 10 < n) {
					b *= 10;
					i++;
				}

				if (b * 10 == n) {
					return i + 1 + 9 * rTrailingZeroes (b) + rTrailingZeroes (b - 1);
				} else {
					int c = n / b;

					return c * rTrailingZeroes (b) + rTrailingZeroes (n % b);
				}
			}
		}
	}
}

