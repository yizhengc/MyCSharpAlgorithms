using System;
using System.Collections.Generic;

namespace MyCSharpAlgorithms
{
	public class GreyCode
	{
		public GreyCode ()
		{
		}

		public IList<int> GrayCodeGen(int n) {
			IList<int> result = new List<int>();
			result.Add(0);

			if (n >= 1)
			{

				result.Add(1);

				for (int i = 1; i < n; i++)
				{
					int len = result.Count;

					for(int k = len - 1; k >=0; k--)
					{
						result.Add((1 << i) + result[k]);
					}
				}
			}

			return result;
		}
	}
}

