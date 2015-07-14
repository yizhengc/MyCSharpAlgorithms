using System;
using System.Collections.Generic;

namespace MyCSharpAlgorithms
{
	public class Node<T>
	{
		public List<Node<T>> Children;
		public T val;
		public Node<T> Parent;

		public Node()
		{
		}
	}

	public class TreeNode
	{
		public int val;
		public TreeNode left;
		public TreeNode right;
		public TreeNode next;

		public TreeNode(int x)
		{
			val = x;
		}
	}

	public class Tree
	{
		public Tree ()
		{
		}

		public static int CountNodes(TreeNode root) {
			if (root == null) {
				return 0;
			}

			int height = 0;
			var c = rCountNodes(root, out height);

			return (int)Math.Pow(2, height - 1) - 1 + c;
		}

		public static int rCountNodes(TreeNode root, out int height)
		{
			if (root.left == null)
			{
				height = 1;
				return 1;
			}
			else
			{
				var c = rCountNodes(root.left, out height);

				if (root.right != null && c >= (int)Math.Pow(2, height - 1))
				{
					c += rCountNodes(root.right, out height);
				}

				height++;
				return c;
			}
		}

		public static IList<IList<int>> LevelOrderBottom(TreeNode root) {
			var final = new List<IList<TreeNode>>();
			var result = new List<TreeNode>();
			if (root != null)
			{
				result.Add(root);
			}

			while (result.Count != 0)
			{
				final.Add(result);

				result = new List<TreeNode>();
				for(int i = 0; i < final[final.Count - 1].Count; i++)
				{
					if (final[final.Count-1][i].left != null)
					{
						result.Add(final[final.Count - 1][i].left);
					}

					if (final[final.Count-1][i].right != null)
					{
						result.Add(final[final.Count - 1][i].right);
					}
				}
			}

			var res = new List<IList<int>>();
			for(int i = final.Count - 1; i >= 0; i--)
			{
				res.Add(new List<int>());

				for (int j = 0; j < final[i].Count; j++)
				{
					res[res.Count - 1].Add(final[i][j].val);
				}

			}

			return res;
		}

		public static IList<IList<int>> LevelOrder(TreeNode root) {
			var final = new List<IList<TreeNode>>();
			var result = new List<TreeNode>();
			if (root != null)
			{
				result.Add(root);
			}

			while (result.Count != 0)
			{
				final.Add(result);

				result = new List<TreeNode>();
				for(int i = 0; i < final[final.Count - 1].Count; i++)
				{
					if (final[final.Count-1][i].left != null)
					{
						result.Add(final[final.Count - 1][i].left);
					}

					if (final[final.Count-1][i].right != null)
					{
						result.Add(final[final.Count - 1][i].right);
					}
				}
			}

			var res = new List<IList<int>>();
			for(int i = 0; i < final.Count; i++)
			{
				res.Add(new List<int>());

				for (int j = 0; j < final[i].Count; j++)
				{
					res[res.Count - 1].Add(final[i][j].val);
				}

			}

			return res;
		}

		public static IList<int> RightSideView(TreeNode root) {
			Dictionary<int, int> result = new Dictionary<int, int>();
			IList<int> final = new List<int>();

			if (root != null)
			{
				rRightSideView(root, 0, result);

				for(int i = 0; i < result.Count; i++)
				{
					final.Add(result[i]);
				}
			}

			return final;
		}

		private static void rRightSideView(TreeNode root, int level, Dictionary<int, int> result)
		{
			if (root.right != null){
				rRightSideView(root.right, level + 1, result);
			}

			if (root.left != null) {
				rRightSideView(root.left, level + 1, result);
			}

			if (!result.ContainsKey(level))
			{
				result[level] = root.val;
			}
		}

		public IList<int> PreorderTraversal(TreeNode root) {
			SimpleStack<TreeNode> stack = new SimpleStack<TreeNode> ();

			IList<int> result = new List<int> ();

			if (root != null) {
				stack.Push (root);

				while (!stack.Empty ()) {
					var node = stack.Pop ();
					result.Add (node.val);

					if (node.right != null) {
						stack.Push (node.right);
					}

					if (node.left != null) {
						stack.Push (node.left);
					}
				}
			}

			return result;
		}

		public IList<int> InorderTraversal(TreeNode root) {
			var stack = new SimpleStack<TreeNode> ();

			var result = new List<int> ();

			if (root != null) {

				Push (root, stack);

				while (!stack.Empty ()) {
					var n = stack.Pop ();
					result.Add (n.val);

					if (n.right != null) {
						Push (n.right, stack);
					}
				}
			}

			return result;
		}

		private void Push(TreeNode node, SimpleStack<TreeNode> stack)
		{
			while (node != null) {
				stack.Push (node);
				node = node.left;
			}
		}

		public void SiblingTree(TreeNode root)
		{
			if (root == null) {
				return;
			}

			root.next = null;

			var head = root;
			var newHead = new TreeNode (1);
			var newCur = newHead;

			var cur = head;

			while(cur.left != null)
			{
				for (; cur != null; cur = cur.next) {
					newCur.next = cur.left;
					newCur = newCur.next;
					newCur.next = cur.right;
					newCur = newCur.next;
				}

				newCur.next = null;

				cur = newHead.next;
				newCur = newHead;
			}
		}

		public void PrintSiblingTree(TreeNode root)
		{
			while (root != null) {
				var nextRow = root.left;

				for (var cur = root; cur != null; cur = cur.next) {
					Console.Write (cur.val);
					Console.Write (" ");
				}

				Console.Write ("\n");
				root = nextRow;
			}
		}

		public void Flatten(TreeNode root) {
			if (root != null)
			{
				var newHead = new TreeNode(0);

				rFlatten(root, newHead);

				root = newHead.right;
			}
		}

		public TreeNode rFlatten(TreeNode root, TreeNode last)
		{
			last.right = root;
			last = root;


			var right = root.right;

			if (root.left != null)
			{
				last = rFlatten(root.left, root);
				root.left = null;
			}

			if (right != null)
			{
				last = rFlatten(right, last);
			}

			return last;
		}


		public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
			var lrstack = new SimpleStack<TreeNode> ();
			var rlstack = new SimpleStack<TreeNode> ();

			List<IList<int>> result = new List<IList<int>> ();
			if (root == null) {
				return result;
			} else {
				lrstack.Push (root);
				result.Add (new List<int> (){ root.val });

				var cur = lrstack;

				while (!cur.Empty ()) {
					var r = new List<int> ();

					while (!cur.Empty ()) {
						var n = cur.Pop ();

						if (cur == rlstack) {
							if (n.left != null) {
								r.Add (n.left.val);
								lrstack.Push (n.left);
							}

							if (n.right != null) {
								r.Add (n.right.val);
								lrstack.Push (n.right);
							}
						} else {
							if (n.right != null) {
								r.Add (n.right.val);
								rlstack.Push (n.right);
							}

							if (n.left != null) {
								r.Add (n.left.val);
								rlstack.Push (n.left);
							}
						}
					}

					if (r.Count > 0)
					{
						result.Add (r);
					}

					if (cur == rlstack) {
						cur = lrstack;
					} else {
						cur = rlstack;
					}
				}
			}

			return result;
		}
	}
}

