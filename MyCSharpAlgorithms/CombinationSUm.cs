using System;
using System.Collections.Generic;
using System.Linq;

namespace MyCSharpAlgorithms
{
	public class CombinationSUm
	{
		public CombinationSUm ()
		{
		}

		class Cache
		{
			public Cache(int sum, int count, int val, Cache prev)
			{
				Sum = sum;
				Val = val;
				Prev = prev;
				Count = count;
			}

			public int Sum;

			public int Count;

			public int Val;

			public Cache Prev;
		}

		public IList<IList<int>> CombinationSum3(int k, int n) {

			List<IList<int>> result = new List<IList<int>> ();
			List<Cache> final = new List<Cache> ();

			if (k == 0 || k > 9 || k * 9 - (k - 1)* k / 2 < n || k == 1 && n > 9)
			{
				return result;
			}

			List<List<Cache>> res = new List<List<Cache>>();

			for (int i = 1; i < 10; i++) {
				var cur = new List<Cache> ();

				if (i <= n) {
					cur.Add (new Cache (i, 1, i, null));
				}

				if (res.Count > 0) {
					foreach (var t in res[res.Count - 1]) {
						if (t.Count < k) {
							if (t.Count == k - 1 && t.Sum + i == n) {
								var tmp = new Cache (n, k, i, t);
								final.Add (tmp);
							} else if (t.Sum + i < n) {
								cur.Add (t);
								cur.Add (new Cache (t.Sum + i, t.Count + 1, i, t));
							}
						}
					}
				}

				res.Add (cur);
			}

			foreach (var c in final) {
				List<int> r = new List<int> ();

				var cur = c; 
				while (cur != null) {
					r.Add (cur.Val);
					cur = cur.Prev;
				}

				r.Reverse ();
				result.Add(r);
			}

			return result;
		}

		public IList<IList<int>> CombinationSum(int[] candidates, int target) {
			List<int> cand = new List<int> (candidates);
			cand.Sort ();

			candidates = cand.ToArray ();

			var ret = rCombinationSum (candidates, 0, target);

			List<IList<int>> final = new List<IList<int>> ();

			foreach (var r in ret) {
				r.Sort ();
				final.Add (r);
			}

			return final;
		}

		private List<List<int>> rCombinationSum(int[] candidates, int start, int target) {
			var final = new List<List<int>> ();

			if (start < candidates.Length) {

				if (candidates [start] == target) {
					final.Add (new List<int> () { candidates [start] });
				}
				else if (candidates [start] < target) {
					var res1 = rCombinationSum (candidates, start + 1, target);
					var res2 = rCombinationSum (candidates, start, target - candidates [start]);

					final.AddRange (res1);

					foreach (var r in res2) {
						r.Add (candidates [start]);
						final.Add (r);
					}
				}
			}

			return final;
		}

		public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
			List<int> cand = new List<int> (candidates);
			cand.Sort ();

			candidates = cand.ToArray ();

			var ret = rCombinationSum2 (candidates, 0, target);

			foreach (var r in ret) {
				r.Sort ();
			}

			ret.Sort (CompareList);

			List<IList<int>> final = new List<IList<int>> ();

			if (ret.Count > 0) {
				final.Add (ret [0]);
			}

			for(int i = 1; i < ret.Count; i++) {
				if (ret [i].Count == final[final.Count - 1].Count) {
					bool isSame = true;
					for (int j = 0; j < ret [i].Count; j++) {
						if (ret [i] [j] != final [final.Count - 1] [j]) {
							isSame = false;
						}
					}

					if (!isSame) {
						final.Add (ret [i]);
					}
				} else {
					final.Add (ret [i]);
				}
			}

			return final;
		}

		private int CompareList(List<int> lst1, List<int> lst2)
		{
			if (lst1.Count == lst2.Count) {
				for (int i = 0; i < lst1.Count; i++) {
					if (lst1 [i] < lst2 [i]) {
						return -1;
					}
					else if (lst1[i] > lst2[i]){
						return 1;
					}
				}

				return 0;
			} else {
				return lst1.Count.CompareTo (lst2.Count);
			}
		}

		private List<List<int>> rCombinationSum2(int[] candidates, int start, int target) {
			var final = new List<List<int>> ();

			if (start < candidates.Length) {

				if (candidates [start] == target) {
					final.Add (new List<int> () { candidates [start] });
				}
				else if (candidates [start] < target) {
					var res1 = rCombinationSum2 (candidates, start + 1, target);
					var res2 = rCombinationSum2 (candidates, start + 1, target - candidates [start]);

					final.AddRange (res1);

					foreach (var r in res2) {
						r.Add (candidates [start]);
						final.Add (r);
					}
				}
			}

			return final;
		}
	}
}

