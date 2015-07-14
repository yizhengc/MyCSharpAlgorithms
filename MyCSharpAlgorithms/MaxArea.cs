using System;
using System.Collections.Generic;

namespace MyCSharpAlgorithms
{
	public class MaxArea
	{
		public MaxArea ()
		{
		}

		public int ComputeMaxArea(int[] height) {
			if (height == null || height.Length < 2)
			{
				return 0;
			}

			int max = height[0];
			int indx = 0;

			List<Tuple<int,int>> maxHeights = new List<Tuple<int,int>>();
			maxHeights.Add(new Tuple<int,int>(height[0], 0));

			int[] lMax = new int[height.Length];
			int[] rMax = new int[height.Length];

			for(int i = 1; i < height.Length; i++)
			{
				if (maxHeights.Count == 0 || maxHeights[maxHeights.Count - 1].Item1 < height[i])
				{
					maxHeights.Add(new Tuple<int,int>(height[i], i));
				}
				else
				{
					bool found = false;
					for(int k = 0; k < maxHeights.Count; k++)
					{
						if (height[i] <= maxHeights[k].Item1)
						{
							lMax[i] = maxHeights[k].Item2;
							found = true;
							break;
						}
					}

					if (!found) {
						lMax [i] = i;
					}
				}
			}

			maxHeights.Clear();
			maxHeights.Add(new Tuple<int,int>(height[height.Length - 1], height.Length - 1));
			for(int i = height.Length - 1; i >= 0; i--)
			{
				if (maxHeights.Count == 0 || maxHeights[maxHeights.Count - 1].Item1 < height[i])
				{
					maxHeights.Add(new Tuple<int,int>(height[i], i));
				}
				else
				{
					bool found = false;
					for(int k = 0; k < maxHeights.Count; k++)
					{
						if (height[i] <= maxHeights[k].Item1)
						{
							rMax[i] = maxHeights[k].Item2;
							found = true;
							break;
						}
					}

					if (!found) {
						rMax [i] = i;
					}
				}
			}

			int maxArea = 0;
			for (int i = 0; i < height.Length; i++)
			{
				maxArea = Math.Max(maxArea, height[i] * Math.Max(rMax[i] - i, i - lMax[i]));
			}

			return maxArea;
		}
	}
}

