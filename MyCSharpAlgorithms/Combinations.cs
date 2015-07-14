using System;
using System.Collections.Generic;
using System.Text;

namespace MyCSharpAlgorithms
{
	public class Combinations
	{
		public Combinations ()
		{
		}

		public IList<IList<int>> Combine(int n, int k) {
			IList<IList<int>> result = new List<IList<int>>();

			if (n > 0 && k > 0 && n >= k)
			{
				result = rCombine(1, n, k);

				foreach(var v in result)
				{
					(v as List<int>).Reverse();
				}
			}

			return result;
		}

		public IList<IList<int>> rCombine(int s, int n, int k)
		{
			var result = new List<IList<int>>();
			for (int i = s; i <= n + 1 - k; i++)
			{
				if (k == 1)
				{
					result.Add(new List<int>(){i});
				}
				else
				{
					var res = rCombine(i + 1, n, k - 1);

					foreach(var r in res)
					{
						r.Add(i);

						result.Add(r);
					}
				}
			}

			return result;
		}

		public string GetPermutation(int n, int k) {
			if (n == 1)
			{
				if (k == 1)
				{
					return "1";
				}
				else
				{
					return "";
				}
			}

			var selection = new List<int>();

			for (int i = 1; i <= n; i++)
			{
				selection.Add(i);
			}

			List<int> result = new List<int>();
			var fac = factorial(n); 

			while(n > 0)
			{
				fac /= n;
				for(int j = 0; j < n; j++)
				{
					if (k <= (j + 1) * fac)
					{
						result.Add(selection[j]);
						selection.RemoveAt(j);
						k -= j * fac;
						break;
					}
				}

				n--;
			}

			StringBuilder sb = new StringBuilder();

			foreach(var v in result)
			{
				sb.Append(v);
			}

			return sb.ToString();
		}

		int factorial(int n)
		{
			int sum = 1;

			for(int i = 1; i <= n; i++)
			{
				sum *= i;
			}

			return sum;
		}
	}
}

