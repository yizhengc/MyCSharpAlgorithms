using System;

namespace MyCSharpAlgorithms
{
	public class RemoveDuplicate
	{
		public RemoveDuplicate ()
		{
		}

		public int RemoveDuplicates(int[] nums) {
			if (nums == null || nums.Length <= 2)
			{
				return nums == null ? 0 : nums.Length;
			}

			int val = nums[0];
			int cnt = 1;
			int last = 0;

			for(int i = 1; i <= nums.Length; i++)
			{
				if (i < nums.Length && nums[i] == val)
				{
					cnt++;
				}
				else
				{
					if (cnt >= 2)
					{
						nums [++last] = val;
					}

					if (i < nums.Length)
					{
						val = nums[i];
						cnt = 1;
						nums[++last] = val;
					}
				}
			}

			return last + 1;
		}
	}
}

