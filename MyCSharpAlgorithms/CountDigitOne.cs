
using System;

namespace MyCSharpAlgorithms
{
	public class CountDigitOne
	{
		public CountDigitOne ()
		{
		}

		public int DummyCount(int n)
		{
			int count = 0;
			for (int i = 1; i <= n; i++) {
				count += CountDigitOnes (i.ToString ());
			}

			return count;
		}

		public int CountDigitOnes(string val)
		{
			int count = 0;
			for (int i = 0; i < val.Length; i++) {
				if (val [i] == '1') {
					count++;
				}
			}

			return count;
		}

		public int Count(int n) {
			int k = 10;
			int total = 0;

			if (n <= 0)
			{
				return 0;
			}
			else if (n < 10)
			{
				return 1;
			}

			while(n >= k)
			{
				int c = n / k;
				int r = n % k;
				int t = r / (k / 10);
				if (t > 1)
				{
					total += k / 10;
				}
				else if (t == 1)

				{
					total += r % (k/10) + 1;
				}


				total += c * (k / 10);

				if (c > 1 && c < 10)
				{
					total += k;
				}
				else if (c == 1)
				{
					total += r + 1;
				}

				if (k <= int.MaxValue / 10) {
					k *= 10;
				} else {
					break;
				}
			}

			return total;
		}
	}
}

