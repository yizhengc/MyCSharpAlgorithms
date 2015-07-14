using System;
using System.Text;

namespace MyCSharpAlgorithms
{
	public class RegexMatch
	{
		public RegexMatch ()
		{
		}

		public bool IsMatch(string s, string p) {
			if (p == null || s == null)
			{
				return false;
			}

			if (p.Length > 2) {
				p = CompactPattern (p);
			}

			return rIsMatch(s, 0, p, 0);
		}

		string CompactPattern(string p)
		{
			int i = 0;
			string last;
			if (IsWildAny (p, 0) || IsCharAny (p, 0)) {
				last = p.Substring (0, 2);
				i = 2;
			} else {
				i = 1;
				last = p.Substring (0, 1);
			}



			StringBuilder sb = new StringBuilder ();

			sb.Append (last);
			while (i < p.Length) {
				if (IsWildAny (p, i)) {
					if (last != ".*") {
						sb.Append (".*");
						last = ".*";
					}

					i += 2;
				} else if (IsCharAny (p, i)) {
					var c = p.Substring (i, 2);
					if (last != c) {
						sb.Append (c);
						last = c;
					}

					i += 2;
				} else {
					var c = p.Substring (i, 1);
					sb.Append (c);
					last = c;
					i++;
				}
			}

			return sb.ToString ();
		}

		bool IsWildOnly(string p, int ps)
		{
			return p[ps] == '.' && (ps == p.Length - 1 || ps < p.Length - 1 && p[ps + 1] != '*');
		}

		bool IsWildAny(string p, int ps)
		{
			return p[ps] == '.' && ps < p.Length - 1 && p[ps + 1] == '*';
		}

		bool IsCharAny(string p, int ps)
		{
			return p[ps] != '.' && ps < p.Length - 1 && p[ps + 1] == '*';
		}

		bool IsCharOnly(string p, int ps)
		{
			return p[ps] != '.' && (ps == p.Length - 1 || ps < p.Length - 1 && p[ps + 1] != '*');
		}

		bool rIsMatch(string s, int ss, string p, int ps)
		{
			if (ps == p.Length && ss == s.Length)
			{
				return true;
			}
			else if (ps == p.Length && ss < s.Length)
			{
				return false;
			}
			else if (ss == s.Length)
			{
				if (IsWildAny(p, ps) || IsCharAny(p, ps))
				{
					return rIsMatch(s, ss, p, ps + 2);
				}
				else
				{
					return false;
				}
			}

			if (IsCharOnly(p, ps))
			{
				if (s[ss] != p[ps])
				{
					return false;
				}
				else
				{
					return rIsMatch(s, ss + 1, p, ps + 1);
				}
			}
			else if (IsCharAny(p, ps))
			{
				if (s[ss] != p[ps])
				{
					return rIsMatch(s, ss, p, ps + 2);
				}
				else
				{
					return rIsMatch(s, ss + 1, p, ps + 2) || rIsMatch(s, ss + 1, p, ps) || rIsMatch(s, ss, p, ps + 2);
				}
			}
			else if (IsWildOnly(p, ps))
			{
				return rIsMatch(s, ss + 1, p, ps + 1);   
			}
			else
			{
				return rIsMatch(s, ss + 1, p, ps + 2) || rIsMatch(s, ss + 1, p, ps) || rIsMatch(s, ss, p, ps + 2);
			}

		}
	}
}

