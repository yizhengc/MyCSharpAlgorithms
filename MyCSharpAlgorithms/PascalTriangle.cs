using System;
using System.Collections.Generic;

namespace MyCSharpAlgorithms
{
	public class PascalTriangle
	{
		public PascalTriangle ()
		{
		}

		public static IList<int> GetRow(int rowIndex) {
			if (rowIndex == 0)
			{
				return null;
			}

			int[] prev = new int[rowIndex + 1];
			prev[0] = 1;

			List<int> result = new List<int>(rowIndex);
			result.Add(1);

			for(int i = 1; i <= rowIndex; i++)
			{
				result[0] = 1;
				int j = 1;
				for(; j < i; j++)
				{
					result[j] = prev[j - 1] + prev[j];
				}

				result.Add(1);

				result.CopyTo(prev);
			}

			return result;
		}

		public static IList<IList<int>> Generate(int numRows) {
			var final = new List<IList<int>> ();

			if (numRows > 0) {
				final.Add (new List<int> (){ 1 });
			}
				
			for(int i = 1; i < numRows; i++)
			{
				List<int> result = new List<int>(i);
				result.Add(1);
				int j = 1;
				for(; j < i; j++)
				{
					result.Add(final[i - 1][j - 1] + final[i - 1][j]);
				}

				result.Add(1);

				final.Add (result);
			}

			return final;
		}

	}
}

