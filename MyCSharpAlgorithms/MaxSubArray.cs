using System;

namespace MyCSharpAlgorithms
{
	public class MaxSubArray
	{
		public MaxSubArray ()
		{
		}

		public int MaxSub(int[] nums)
		{
			SimpleStack<int> stack = new SimpleStack<int> ();

			var lastMax = int.MinValue;
			for (int i = 0; i < nums.Length; i++) {
				if (nums [i] < 0) {
					if (lastMax <= nums [i]) {
						lastMax = nums [i];
					}

					if (!stack.Empty ()) {
						var last = stack.Pop ();
						lastMax = Math.Max (lastMax, last);

						last += nums [i];

						if (last > 0) {
							stack.Push (last);
						}
					}
				} else if (nums [i] > 0) {
					if (stack.Empty ()) {
						stack.Push (nums [i]);
					} else {
						var last = stack.Pop ();
						last += nums [i];

						stack.Push (last);
					}
				} else {
					lastMax = Math.Max (nums [i], lastMax);
				}
			}

			if (!stack.Empty ()) {
				var f = stack.Pop ();
				lastMax = Math.Max (lastMax, f);
			}

			return lastMax;
		}
	}
}

