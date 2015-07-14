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

		public static ListNode ArrayToList(int[] input)
		{
			if (input == null || input.Length == 0) {
				return null;
			}

			ListNode head = new ListNode (input [0]);
			var cur = head;

			for (int i = 1; i < input.Length; i++) {
				cur.next = new ListNode (input [i]);
				cur = cur.next;
			}

			cur.next = null;

			return head;
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

		public ListNode ReverseBetween(ListNode head, int m, int n) {
			var cur = head;
			ListNode prev = null;
			ListNode last = null;
			ListNode tail = null;

			for(int i = 1; i <= n; i++)
			{
				if (i < m)
				{
					prev = cur;
					cur = cur.next;
				}
				else if (i >= m)
				{
					if (i == m)
					{
						last = prev;
						tail = cur;
					}

					var temp = cur.next;
					cur.next = prev;
					prev = cur;
					cur = temp;
				}
			}

			tail.next = cur;
			if (last == null)
			{
				return prev;
			}
			else
			{
				last.next = prev;
				return head;
			}
		}

		public ListNode ReverseKGroup(ListNode head, int k) {
			if (head == null || head.next == null || k <= 1)
			{
				return head;
			}

			ListNode newHead = new ListNode(0);
			ListNode prev = newHead;

			ListNode next = head;
			ListNode res = null;


			while(true)
			{
				res = FindKthNode(next, k);
				prev.next = res;
				prev = next;

				if (res == next)
				{
					break;
				}
				else
				{
					next = next.next;
				}
			}

			return newHead.next;
		}

		public ListNode FindKthNode(ListNode head, int k)
		{
			var cur = head;
			int i = 0;
			for(; i < k; i++)
			{
				if (cur != null)
				{
					cur = cur.next;
				}
				else
				{
					break;
				}
			}

			if (cur != null || i == k)
			{
				var newHead = Reverse(head, cur);
				head.next = cur;
				return newHead;
			}
			else
			{
				return head;
			}
		}


		public ListNode Reverse(ListNode head, ListNode end)
		{
			ListNode prev = null;
			ListNode cur = head;
			ListNode next = cur.next;

			while(cur != end)
			{
				next = cur.next;
				cur.next = prev;
				prev = cur;
				cur = next;
			}

			return prev;
		}
	}
}

