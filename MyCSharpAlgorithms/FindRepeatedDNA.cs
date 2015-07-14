using System;
using System.Collections.Generic;

namespace MyCSharpAlgorithms
{
	public class FindRepeatedDNA
	{
		public FindRepeatedDNA ()
		{
		}

		public IList<string> FindRepeatedDnaSequences(string s) {
			var result = new List<string>();

			if (s == null || s.Length < 10)
			{
				return result;
			}

			var history = new Dictionary<long, int> ();

			for (int i = 0; i <= s.Length - 10; i++)
			{
				var sub = String2Int(s.Substring(i, 10));

				if (!history.ContainsKey(sub))
				{
					history[sub] = 0;
				}

				history[sub]++;
			}

			foreach(var ss in history)
			{
				if (ss.Value > 1)
				{
					result.Add(Int2String(ss.Key));
				}
			}

			return result;
		}

		public long String2Int(string sub)
		{
			long res = 0;
			for(int i = 0; i < sub.Length; i++)
			{
				int v = 0;
				switch(sub[i])
				{
				case 'A':
					v = 1;
					break;
				case 'C':
					v = 2;
					break;
				case 'T':
					v = 3;
					break;
				case 'G':
					v = 4;
					break;
				}

				res = res * 10 + v;
			}

			return res;
		}

		public string Int2String(long val)
		{
			string res = val.ToString();

			char[] str = new char[res.Length];

			for(int i = 0; i < res.Length; i++)
			{
				int v = 0;
				switch(res[i])
				{
				case '1':
					str[i] = 'A';
					break;
				case '2':
					str[i] = 'C';
					break;
				case '3':
					str[i] = 'T';
					break;
				case '4':
					str[i] = 'G';
					break;
				}
			}

			return new string(str);
		}
	}
}

