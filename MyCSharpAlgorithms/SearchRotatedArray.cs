using System;

namespace MyCSharpAlgorithms
{
	public class SearchRotatedArray
	{
		public SearchRotatedArray ()
		{
		}

		public int Search(int[] nums, int target) {
			int l = 0; 
			int h = nums.Length - 1;

			while (l <= h)
			{
				var m = (l + h) / 2;

				if (nums[m] < target)
				{
					if (nums[m] < nums[h] && nums[h] < target)
					{
						h = m -1;
					}
					else
					{
						l = m + 1;
					}
				}
				else if (nums[m] > target)
				{
					if (nums[m] > nums[l] && nums[l] > target)
					{
						l = m + 1;
					}
					else
					{
						h = m - 1;
					}
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

