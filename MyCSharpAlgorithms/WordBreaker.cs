using System;
using System.Collections.Generic;

namespace MyCSharpAlgorithms
{
	public class WordBreaker
	{
		TrieNode root = new TrieNode();

		public WordBreaker ()
		{
		}

		public void Insert(string word) {
			if (!string.IsNullOrEmpty(word))
			{
				var cur = root;
				foreach(char c in word)
				{
					if (!cur.Children.ContainsKey (c)) {
						cur.Children.Add (c, new TrieNode ());
					}

					cur = cur.Children [c];
				}

				cur.IsTerminal = true;
			}
		}

		public bool WordBreak(string s, ISet<string> wordDict) {
			foreach (var w in wordDict) {
				Insert (w);
			}

			return rWordBreak (s, 0, root);
		}

		public bool rWordBreak(string s, int start, TrieNode root)
		{
			if (start == s.Length)
				return true;

			TrieNode cur = root;
			for (int i = start; i < s.Length; i++) {

				if (cur.Children.ContainsKey (s [i])) {
					if (cur.Children [s [i]].IsTerminal) {
						if (rWordBreak (s, i + 1, root)) {
							return true;
						}
					}

					cur = cur.Children [s [i]];
				} else {
					return false;
				}
			}

			return false;
		}
	}
}

