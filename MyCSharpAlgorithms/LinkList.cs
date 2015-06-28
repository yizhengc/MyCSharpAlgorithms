using System;

namespace MyCSharpAlgorithms
{
	public class ListNode {
		public int val;
		public ListNode next;
		public ListNode(int x) {
		    val = x;
			next = null;
		}
	}

	public class LinkList
	{
		public LinkList ()
		{
		}

		public ListNode DetectCycle(ListNode head) {
			ListNode slow = head;
			ListNode fast = head;

			bool found = false;
			while(fast != null && fast.next != null && fast.next.next != null)
			{
				slow = slow.next;
				fast = fast.next.next;

				if (fast == slow)
				{
					found = true;
					break;
				}
			}

			if (found == false)
			{
				return null;
			}
			else
			{
				int len = 1;

				while(fast.next != slow)
				{
					len++;
					fast = fast.next;
				}

				if (len == 1)
				{
					return slow;
				}
				else
				{
					for(fast = head; len > 0; len--)
					{
						fast = fast.next;
					}

					slow = head;
					while(fast != slow)
					{
						fast = fast.next;
						slow = slow.next;
					}

					return slow;
				}
			}
		}
	}
}

