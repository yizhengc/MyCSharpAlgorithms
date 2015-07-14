using System;
using System.Collections.Generic;

namespace MyCSharpAlgorithms
{
	public class ThreeSumProblem
	{
		public ThreeSumProblem ()
		{
		}

		public IList<IList<int>> ThreeSum(int[] nums) {
			var result = new List<IList<int>>();

			if (nums != null && nums.Length >= 3)
			{
				var input = new List<int>(nums);

				input.Sort();

				int s = 0;
				int e = input.Count - 1;

				while (s < input.Count - 2) {
					for (e = input.Count - 1; e > s + 1;) {
						FindResult (input, s, e, result);
					
						var nextR = SeekNextFromRight (input, s, e);

						e = nextR;
					}

					var nextL = SeekNextFromLeft (input, s, input.Count - 1);

					if (nextL > 0) {
						s = nextL;
					} else {
						break;
					}
				}
			}

			return result;
		}

		int SeekNextFromLeft(List<int> input, int s, int e)
		{
			for (int i = s + 1; i < e - 1; i++) {
				if (input [s] != input [i]) {
					return i;
				}
			}

			return -1;
		}

		int SeekNextFromRight(List<int> input, int s, int e)
		{
			for (int i = e - 1; i > s + 1; i--) {
				if (input [e] != input [i]) {
					return i;
				}
			}

			return -1;
		}

		void FindResult(List<int> input, int s, int e, List<IList<int>> result)
		{
			var l = input[s];
			var r = input[e];
			var t = 0 - l - r;

			if (t >= l && t <= r)
			{
				var v = FindTarget(input, s + 1, e - 1, t);

				if (v > 0)
				{
					result.Add(new List<int>(){l, input[v], r});
				}
			}
		}

		int FindTarget(List<int> input, int s, int e, int val)
		{
			while(s <= e)
			{
				var m = (s + e) / 2;

				if (input[m] < val)
				{
					s = m + 1;
				}
				else if (input[m] > val)
				{
					e = m - 1;
				}
				else
				{
					return m;
				}
			}

			return -1;
		}
	}
}

