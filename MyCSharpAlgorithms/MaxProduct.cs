using System;

namespace MyCSharpAlgorithms
{
	public class MaxProduct
	{
		public int MaxProd(int[] nums) {
			int start = 0;
			int end = 0;

			int max = nums[0];

			for(int i = 0; i <= nums.Length; i++)
			{
				int last = 0;

				if (i == nums.Length || nums[i] == 0 )
				{
					if (i != nums.Length && max < 0)
					{
						max = 0;
					}

					end = i - 1;

					if (start == end)
					{
						max = Math.Max(max, nums[start]);
					}
					else if (start < end)
					{
						var tmp = FindMax(nums, start, end);

						max = Math.Max(max, tmp);
					}

					start = i+1;
				}
			}

			return max;
		}

		public int FindMax(int[] nums, int start, int end)
		{
			int first = -1;
			int last = -1;

			int total = 1;
			int left = 1;
			int right = 1;

			for(int i = start; i <= end; i++)
			{
				total *= nums[i];

				if (nums[i] < 0)
				{
					if (first == -1)
					{
						first = i;
						left = total;
					}

					if (last < i)
					{
						last = i;
						right = total;
					}
				}
			}

			if (total > 0 || start == end)
			{
				return total;
			}
			else
			{
				if (first == end)
				{
					return total / nums[first];
				}
				else if (last == start)
				{
					return total / nums[last];
				}
				else
				{
					return Math.Max(total / left, right / nums[last]);
				}
			}
		}
	}
}

