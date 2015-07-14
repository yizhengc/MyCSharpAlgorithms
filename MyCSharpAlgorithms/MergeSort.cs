using System;

namespace MyCSharpAlgorithms
{
	public class MergeSort
	{
		public MergeSort ()
		{
		}

		public static void Merge(int[] nums1, int m, int[] nums2, int n) {
			int i = m - 1;
			for(; i >=0; i--)
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

		public ListNode MergeKLists(ListNode[] lists) {
			ListNode[] cur = new ListNode[lists.Length];

			for(int i = 0; i < lists.Length; i++)
			{
				cur[i] = lists[i];
			}

			ListNode head = new ListNode(0);
			ListNode curr = head;


			while(true)
			{
				var min = int.MaxValue;

				var minPos = -1;

				for(int i = 0; i < lists.Length; i++)
				{
					if (cur[i] != null && cur[i].val < min)
					{
						min = cur[i].val;
						minPos = i;
					}
				}

				if (minPos < 0)
				{
					break;
				}
				else
				{
					curr.next = cur[minPos];
					curr = curr.next;
					cur[minPos] = cur[minPos].next;
				}
			}

			return head.next;
		}
	}
}

