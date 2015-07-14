using System;

namespace MyCSharpAlgorithms
{
	public class UniquePathes
	{
		public UniquePathes ()
		{
		}

		public int UniquePaths(int m, int n) {
			if (m == 1 || n == 1)
			{
				return 1;
			}
			else
			{
				int sum = 1;
				int start = Math.Max (m - 1, n - 1);
				for (int i = 1; i <= m + n - 2 - start; i++) {
					sum = sum * (i + start) / i; 
				}

				return sum;
			}
		}
	}
}

