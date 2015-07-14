using System;
using System.Collections.Generic;
using System.Text;

namespace MyCSharpAlgorithms
{
	public class ZigZag
	{
		public ZigZag ()
		{
		}

		public string Convert(string s, int numRows) {
			int r= 0; 
			int c = 0;

			List<char>[] result = new List<char>[numRows];
			int dir = 1;
			for (int i = 0; i < s.Length; i++)
			{
				if (result[r] == null)
				{
					result[r] = new List<char>();
				}
				result[r].Add(s[i]);

				if ( r == numRows - 1 && dir == 1 || r == 0 && dir == -1)
				{
					dir *= -1;
				}

				if (numRows != 1)
				{
					r += dir;
				}
			}

			StringBuilder sb = new StringBuilder();

			foreach(var l in result)
			{
				if (l != null)
					sb.Append(new string(l.ToArray()));
			}

			return sb.ToString();
		}
	}
}

