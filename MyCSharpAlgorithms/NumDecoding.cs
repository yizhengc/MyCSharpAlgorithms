using System;
using System.Collections.Generic;

namespace MyCSharpAlgorithms
{
	public class NumDecoding
	{
		public NumDecoding ()
		{
		}

		public int NumDecodings(string s) {
			int total = 0;

			List<int> result = new List<int> ();

			if (s != null && s.Length > 0 && s [0] != '0') {
					
				result.Add (1);
				result.Add (1);

				for (int i = 1; i < s.Length; i++) {
					if (s [i] == '0') {
						if (s [i - 1] > '2' || s [i - 1] == '0') {
							return 0;
						} else {
							result.Add (result [i + 1 - 2]);
						}
					} else {
						if (s [i - 1] == '2' && s[i] < '7' || s [i - 1] == '1') {
							var t = result [i] + result [i - 1];
							result.Add (t);
						} else {
							result.Add (result [i]);
						}
					}
				}

				total = result [result.Count - 1];
			}

			return total;
		}
	}
}

