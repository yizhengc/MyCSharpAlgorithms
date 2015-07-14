using System;
using System.Collections.Generic;

namespace MyCSharpAlgorithms
{
	public class PathSum
	{
		public PathSum ()
		{
		}

		public IList<IList<int>> PathSumI(TreeNode root, int sum) {
			if (root == null) {
				return new List<IList<int>> ();
			}

			var result = rPathSum(root, sum);

			foreach(var lst in result)
			{
				(lst as List<int>).Reverse();
			}

			return result;
		}

		public List<IList<int>> rPathSum(TreeNode root, int sum)
		{
			if (root.left == null && root.right == null)
			{
				if (root.val == sum)
				{
					return new List<IList<int>>() { new List<int>() {root.val} };
				}
				else
				{
					return new List<IList<int>>();
				}
			}
			else
			{
				List<IList<int>> result = new List<IList<int>> ();
				if (root.left != null)
				{
					var left = rPathSum(root.left, sum - root.val);

					foreach(var lst in left)
					{
						lst.Add(root.val);
					}

					result.AddRange (left);
				}

				if (root.right != null)
				{
					var right = rPathSum(root.right, sum - root.val);

					foreach(var lst in right)
					{
						lst.Add(root.val);
					}

					result.AddRange (right);
				}

				return result;
			}

		}
	}
}

