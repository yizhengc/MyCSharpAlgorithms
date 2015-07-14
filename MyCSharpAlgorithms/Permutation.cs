using System;

namespace MyCSharpAlgorithms
{
	public class Permutation
	{
		public Permutation ()
		{
		}

		public void NextPermutation(int[] nums) {
			if (nums != null && nums.Length > 1)
			{
				var stack = new SimpleStack<Tuple<int, int>>();
				stack.Push(new Tuple<int, int>(nums[nums.Length - 1], nums.Length - 1));

				int start = 0;
				for (int i = nums.Length - 2; i >= 0; i--)
				{
					Tuple<int, int> replace = null;
					while(!stack.Empty() && stack.Top().Item1 > nums[i])
					{
						replace = stack.Pop();
					}

					if (replace != null)
					{
						Swap(nums, i, replace.Item2);

						start = i + 1;
						break;
					}
					else
					{
						if (nums[i] > stack.Top().Item1)
						{
							stack.Push(new Tuple<int,int>(nums[i], i));
						}
					}
				}

				for (int i = 0; i <= (nums.Length - 1 - start) / 2; i++)
				{
					Swap(nums, start + i, nums.Length - 1 - i);
				}
			}
		}

		void Swap(int[] nums, int a, int b)
		{
			var tmp = nums[a];
			nums[a] = nums[b];
			nums[b] = tmp;
		}
	}
}

