using System;
using System.Collections.Generic;

namespace MyCSharpAlgorithms
{
	public class WordLadder
	{
		public WordLadder ()
		{
		}

		public int LadderLength(string beginWord, string endWord, ISet<string> wordDict) {
			var queue = new List<Tuple<string, int>> ();
			queue.Add(new Tuple<string, int>(beginWord, 1));
			var dict = new List<string> (wordDict);

			int start = 0;

			while (start < queue.Count) {
				beginWord = queue [start].Item1;
				var last = queue [start].Item2;

				if (EditDistance (beginWord, endWord) == 1) {
					return last + 1;
				}

				var remain = new List<string> ();
				foreach (var w in dict) {

					if (EditDistance (beginWord, w) == 1) {
						queue.Add (new Tuple<string, int> (w, last + 1));
					} else {
						remain.Add (w);
					}
				}

				dict = remain;

				start++;
			}

			return 0;
		}

		private int EditDistance(string w1, string w2)
		{
			int sum = 0;
			for (int i = 0; i < w1.Length; i++) {
				if (w1 [i] - w2 [i] != 0) {
					sum++;
				}
			}

			return sum;
		}
	}
}

