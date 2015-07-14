using System;
using System.Collections.Generic;

namespace MyCSharpAlgorithms
{
	public class ValdateIP
	{
		public ValdateIP ()
		{
		}

		public IList<string> RestoreIpAddresses(string s) {
			s = s.TrimStart ('0');

			var result = new List<string> ();
			var prev = new List<int> ();
			rFindIp (s, 0, prev, result);

			return result;
		}

		public void rFindIp(string s, int start, List<int> prev, List<string> result)
		{
			if (start >= s.Length) {
				return;
			}

			if (prev.Count == 3) {
				if (start >= s.Length - 3 && s [start] != '0') {
					var v = int.Parse (s.Substring (start));

					if (v <= 255) {
						prev.Add (v);
						result.Add (string.Join (".", prev));
					}
				}
			} else {
				int sum = 0;
				if (s [start] != '0') {
					for (int i = start; i < s.Length; i++) {
						sum = sum * 10 + (s [i] - '0');

						if (sum <= 255) {
							var n = new List<int> (prev);
							n.Add (sum);
							rFindIp (s, i + 1, n, result);
						} else {
							break;
						}
					}
				}
			}
		}
	}
}

