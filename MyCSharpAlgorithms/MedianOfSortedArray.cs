using System;

namespace MyCSharpAlgorithms
{
	public class MedianOfSortedArray
	{
		public MedianOfSortedArray ()
		{
		}

		public double FindMedianSortedArrays(int[] nums1, int[] nums2) {

			if (nums1.Length <= nums2.Length) {
				return rFindMedian (nums1, 0, nums1.Length - 1, nums2, 0, nums2.Length - 1);
			} else {
				return rFindMedian (nums2, 0, nums2.Length - 1, nums1, 0, nums1.Length - 1);
			}
		}


		public double rFindMedian(int[] nums1, int s1, int e1, int[] nums2, int s2, int e2)
		{
			int m1 = (s1 + e1) / 2;
			int m2 = (s2 + e2) / 2;

			if (e1 - s1 + 1 == 1) {
				if ((e2 - s2 + 1) % 2 == 0) {
					if (nums1 [m1] <= nums2 [m2]) {
						return nums2 [m2];
					} else if (nums1 [m1] >= nums2 [m2 + 1]) {
						return nums2 [m2 + 1];
					} else {
						return nums1 [m1];
					}
				} else {
					if (nums1 [m1] <= nums2 [m2]) {
						if (m2 == s2 || nums1 [m1] >= nums2 [m2 - 1]) {
							return (nums1 [m1] + nums2 [m2]) / 2;
						} else {
							return (nums2 [m2] + nums2 [m2 - 1]) / 2;
						}
					}
					else {
						if (m2 == e2 || nums1 [m1] <= nums2 [m2 + 1]) {
							return (nums1 [m1] + nums2 [m2]) / 2;
						} else {
							return (nums2 [m2] + nums2 [m2 + 1]) / 2;
						}
					}
				}
			}

			if (e1 - s1 + 1 == 2) {
				if (e2 - s2 + 1 == 2) {
					if (nums1 [m1 + 1] <= nums2 [m2]) {
						return (nums1 [m1 + 1] + nums2 [m2]) / 2;
					} else if (nums1 [m1] >= nums2 [m2 + 1]) {
						return (nums1 [m1] + nums2 [m2 + 1]) / 2;
					} else if (nums1 [m1] >= nums2 [m2] && nums1 [m1 + 1] <= nums2 [m2 + 1]) {
						return (nums1 [m1] + nums1 [m1 + 1]) / 2;
					} else if (nums1 [m1] <= nums2 [m2] && nums1 [m1 + 1] >= nums2 [m2 + 1]) {
						return (nums2 [m2] + nums2 [m2 + 1]) / 2;
					} else if (nums1 [m1] <= nums2 [m2 + 1] && nums1 [m1 + 1] >= nums2 [m2 + 1]) {
						return (nums1 [m1] + nums2 [m2 + 1]) / 2;
					} else if (nums1 [m1] <= nums2 [m2 + 1] && nums1 [m1 + 1] >= nums2 [m2 + 1]) {
						return (nums1 [m1] + nums2 [m2 + 1]) / 2;
					} else {
						return (nums1 [m1 + 1] + nums2 [m2]) / 2;
					}
				} else {
					if (nums1 [m1] >= nums2 [m2]) {
						return rFindMedian (nums1, m1, m1, nums2, s2 + 1, e2);
					} else {
						return rFindMedian (nums1, m1 + 1, m1 + 1, nums2, s2, e2 - 1);
					}
				}
			}



			if (nums1 [m1] <= nums2 [m2]) {
				return rFindMedian (nums1, m1, e1, nums1, s2, e2 - (m1 - s1));
			} else {
				return rFindMedian (nums1, s1, m1, nums1, s2 + (e1 - m1), e2);
			}
		}
	}
}

