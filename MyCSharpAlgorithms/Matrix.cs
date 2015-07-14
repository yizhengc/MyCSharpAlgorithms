using System;
using System.Collections.Generic;

namespace MyCSharpAlgorithms
{
	public class Matrix
	{
		public Matrix ()
		{
		}

		public bool SearchMatrix(int[,] matrix, int target) {
			int l = 0; 
			int r = matrix.GetLength(0) - 1;

			int t = -1;
			while(l <= r)
			{
				int m = (l + r) / 2;

				if (matrix[m, 0] > target)
				{
					if (m == 0)
					{
						return false;
					}
					else if(matrix[m - 1, 0] < target)
					{
						t = m - 1;
						break;
					}
					else
					{
						r = m - 1;
					}
				}
				else
				{
					if (matrix[m, 0] == target)
					{
						return true;
					}
					else if (m == matrix.GetLength(0) - 1 || matrix[m + 1, 0] > target)
					{
						t = m; 
						break;
					}
					else
					{
						l = m + 1;
					}
				}
			}

			if (t == -1)
			{
				return false;
			}
			else
			{
				l = 0; 
				r = matrix.GetLength(1) - 1;
				while(l < r)
				{
					int m = (l + r) / 2;

					if (matrix[t, m]    > target)
					{
						r = m - 1;
					}
					else if (matrix[t, m] < target)
					{
						l = m + 1;
					}
					else
					{
						return true;
					}
				}

				return false;
			}
		}

		enum Dir
		{
			Up = 0,
			Down = 1,
			Right = 2,
			Left = 3
		}

		public IList<int> SpiralOrder(int[,] matrix) {
			var dir = Dir.Right;
			IList<int> res = new List<int>();
			int r = 0;
			int c = 0;

			int rb = matrix.GetLength(1);
			int lb = 0;
			int tb = 0;
			int bb = matrix.GetLength(0);

			while(r < bb && c < rb && r >= tb && c >= lb)
			{
				res.Add(matrix[r,c]);

				switch (dir)
				{
				case Dir.Right:
					if (c == rb - 1)
					{
						dir = Dir.Down;
						r++;
						tb++;
					}
					else
					{
						c++;
					}
					break;
				case Dir.Down:
					if (r == bb - 1)
					{
						dir = Dir.Left;
						c--;
						rb--;
					}
					else
					{
						r++;
					}
					break;
				case Dir.Left:
					if (c == lb)
					{
						dir = Dir.Up;
						r--;
						bb--;
					}
					else
					{
						c--;
					}
					break;
				case Dir.Up:
					if (r == tb)
					{
						dir = Dir.Right;
						c++;
						lb++;
					}
					else
					{
						r--;
					}
					break;
				}
			}

			return res;
		}
	}
}

