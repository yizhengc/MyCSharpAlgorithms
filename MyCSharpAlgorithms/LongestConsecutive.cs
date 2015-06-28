using System;
using System.Collections.Generic;

namespace MyCSharpAlgorithms
{
	public class LongestConsecutive
	{
		public LongestConsecutive ()
		{
		}

		public int GetLongestConsecutive(int[] nums) {
			if (nums == null || nums.Length == 0)
			{
				return 0;
			}

			var cache = new Dictionary<int, int> ();

			int max = 1;

			for(int i = 0; i < nums.Length; i++)
			{
				if (!cache.ContainsKey(nums[i]))
				{

					if (cache.ContainsKey(nums[i] + 1) && !cache.ContainsKey(nums[i] - 1))
					{
						if (cache[nums[i] + 1] >= 0)
						{
							var len = cache[nums[i] + 1] + 1;
							cache[nums[i]] = len;
							cache[nums[i] + len] = -len;
							max = Math.Max(max, Math.Abs(len) + 1);
						}
					}
					else if (!cache.ContainsKey(nums[i] + 1) && cache.ContainsKey(nums[i] - 1))
					{
						if (cache[nums[i] - 1] <= 0)
						{
							var len = cache[nums[i] - 1] - 1;
							cache[nums[i]] = len;
							cache[nums[i] + len] = -len;
							max = Math.Max(max, Math.Abs(len) + 1);
						}
					}
					else if (cache.ContainsKey(nums[i] + 1) && cache.ContainsKey(nums[i] - 1))
					{
						if (cache[nums[i] + 1] >= 0 && cache[nums[i] - 1] <= 0)
						{
							var len1 = cache[nums[i] - 1];
							var len2 = cache[nums[i] + 1];
							var len = len2 + 2 - len1;
							cache[nums[i] - 1 + len1] = len;
							cache[nums[i] + 1 + len2] = -len;
							cache [nums [i]] = 0;
							max = Math.Max(max, len + 1);
						}
					}
					else
					{
						cache[nums[i]] = 0;
					}
				}
			}

			return max;
		}
	}
}

