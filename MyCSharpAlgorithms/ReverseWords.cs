using System;
using System.Collections.Generic;

namespace MyCSharpAlgorithms
{
	public class ReverseWords
	{
		public ReverseWords ()
		{
		}

		public string Reverse(string s) {

			if (s == null || string.IsNullOrEmpty(s))
			{
				return s;
			}

			int start = 0;
			int end = s.Length - 1;
			for (int i = 0; i < s.Length; i++) {
				if (s [i] != ' ' && s [i] != '\t') {
					start = i;
					break;
				}
			}

			for (int i = s.Length - 1; i >= 0; i--) {
				if (s [i] != ' ' && s [i] != '\t') {
					end = i;
					break;
				}
			}

			if (start >= end || s.IndexOf (' ') > end) {
				return s;
			}


			char[] input = s.ToCharArray();

			FlipString(input, start, end);


			int l = start;
			for(int i = start + 1; i <= end; i++)
			{
				if (input [i] != ' ' && input [i - 1] == ' ') {
					l = i;
				}

				if (i == end || input [i] == ' ' && input [i - 1] != ' ') {
					FlipString (input, l, i - 1);
				}
			}

			return new String(input);
		}

		void Swap(char[] s, int l, int r)
		{
			var tmp = s[l];
			s[l] = s[r];
			s[r] = tmp;
		}

		void FlipString(char[] s, int l, int r)
		{
			for(int i = 0; l + i <= (l + r)/ 2; i++)
			{
				Swap(s, l + i, r - i);
			}
		}
	}
}

