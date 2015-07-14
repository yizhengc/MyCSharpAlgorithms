using System;

namespace MyCSharpAlgorithms
{
	public class ListToBST
	{
		public ListToBST ()
		{
		}

		public TreeNode SortedListToBST(ListNode head) {
			if (head == null)
			{
				return null;
			}
			else if (head.next == null)
			{
				return new TreeNode(head.val);
			}
			else
			{
				int size = 0;

				for(var cur = head; cur != null; cur = cur.next)
				{
					size++;
				}

				ListNode tail = null;

				return rSortedListToBST(head, size, out tail);
			}
		}

		public TreeNode rSortedListToBST(ListNode head, int size, out ListNode tail)
		{
			if (size == 1)
			{
				tail = head.next;
				return new TreeNode(head.val);
			}
			else
			{
				int left = size / 2;
				int right = size - 1 - left;

				var ltree = rSortedListToBST(head, left, out tail);

				var root = new TreeNode(tail.val);
				root.left = ltree;


				if (right > 0) {
					var rtree = rSortedListToBST (tail.next, right, out tail);
					root.right = rtree;
				} else {
					tail = tail.next;
				}

				return root;
			}
		}
	}
}

