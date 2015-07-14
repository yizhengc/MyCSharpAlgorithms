using System;
using System.Collections.Generic;

namespace MyCSharpAlgorithms
{
	public class LargeNumber
	{
		public LargeNumber ()
		{
		}

		public string Multiply(string num1, string num2) {
			if (IsZero(num1) || IsZero(num2))
			{
				return "0";
			}

			List<string> sum = new List<string>();
			for(int i = num2.Length - 1; i >= 0; i--)
			{
				var v = (int)(num2[i] - '0');

				if (v != 0)
				{
					sum.Add(MultipleSingle(num1, v, num2.Length - 1 - i));
				}
			}

			return SumAll(sum);
		}

		public bool IsZero(string num)
		{
			return num.Length == 1 && num[0] == '0' ;
		}

		public string MultipleSingle(string num1, int n, int shift)
		{
			int cary = 0;
			List<char> result = new List<char>();

			for(int k = 0; k < shift; k++)
			{
				result.Add('0');
			}

			for(int i = num1.Length - 1; i >= 0; i--)
			{
				int a = (int)(num1[i] - '0');
				var res = a * n + cary;

				var residual = res % 10;

				result.Add((char)('0' + residual));

				cary = (res - residual) / 10;
			}

			if (cary != 0)
			{
				result.Add((char)(cary + '0'));
			}

			result.Reverse ();
			return new string(result.ToArray());
		}

		public string SumAll(List<string> input)
		{
			int cary = 0;
			List<char> result = new List<char>();

			for (int i = 0; i < input[input.Count - 1].Length; i++)
			{
				int sum = cary;

				for(int k = 0; k < input.Count; k++)
				{
					if (input[k].Length - 1 - i >= 0)
					{
						sum += (int)(input[k][input[k].Length - 1 -i] - '0');
					}
				}

				var residual = sum % 10;

				result.Add((char)('0' + residual));

				cary = (sum - residual) / 10;
			}

			if (cary != 0)
			{
				result.Add((char)(cary + '0'));
			}

			result.Reverse ();
			return new string(result.ToArray());
		}
	}
}

