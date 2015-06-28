using System;

namespace MyCSharpAlgorithms
{
	public class BSTIterator {

		SimpleStack<TreeNode> stack = new SimpleStack<TreeNode>();

		public BSTIterator(TreeNode root) {
			if (root != null) {
				PushToStack (root, stack);
			}
		}

		private void PushToStack(TreeNode root, SimpleStack<TreeNode> stack)
		{
			while (root != null) {
				stack.Push (root);
				root = root.left;
			}
		}

		/** @return whether we have a next smallest number */
		public bool HasNext() {
			return !stack.Empty ();
		}

		/** @return the next smallest number */
		public int Next() {
			TreeNode node = stack.Pop ();
			var res = node.val;

			if (node.right != null) {
				PushToStack (node.right, stack);
			}

			return res;
		}
	}
}

