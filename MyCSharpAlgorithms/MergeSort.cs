using System;

namespace MyCSharpAlgorithms
{
	public class MergeSort
	{
		public MergeSort ()
		{
		}

		public static void Merge(int[] nums1, int m, int[] nums2, int n) {
			int i = 0;
			for(; i < m; i++)
			{
				nums1[i + n] = nums1[i];
			}

			int j = 0; 
			i = n;
			int k = 0;

			while (j < n && i < n + m)
			{
				if (nums1[i] < nums2[j])
				{
					nums1[k++] = nums1[i++];
				}
				else
				{
					nums1[k++] = nums2[j++];
				}
			}

			while (j < n)
			{
				nums1[k++] = nums2[j++];
			}
		}
	}
}

