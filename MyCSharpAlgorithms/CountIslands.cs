using System;
using System.Collections.Generic;

namespace MyCSharpAlgorithms
{
	public class CountIslands
	{
		public CountIslands ()
		{
		}

		public int NumIslands(char[,] grid) {
			int[,] color = new int[grid.GetLength(0), grid.GetLength(1)];

			int cur = 0;
			for(int i = 0; i < grid.GetLength(0); i++)
			{
				for(int j = 0; j < grid.GetLength(1); j++)
				{
					if (color[i, j] == 0 && grid[i,j] == '1')
					{
						cur++;
						Color(grid, i, j, color, cur);
					}


				}
			}

			return cur;
		}

		void Color(char[,] grid, int i, int j, int[,] color, int cur)
		{
			List<Tuple<int, int>> queue = new List<Tuple<int, int>>();
			int start = 0;

			color[i, j] = cur;
			queue.Add(new Tuple<int, int> (i, j));

			while(start < queue.Count)
			{
				var x = queue[start].Item1;
				var y = queue[start].Item2;

				if (x - 1 >= 0 && grid[x - 1, y] == '1' && color[x - 1, y] == 0)
				{
					/// Mark as visited first before adding to the queue !!!
					color[x - 1, y] = cur;
					queue.Add(new Tuple<int, int>( x -1 , y));
				}

				if (x + 1 < grid.GetLength(0) && grid[x + 1, y] == '1' && color[x + 1, y] == 0)
				{
					color[x + 1, y] = cur;
					queue.Add(new Tuple<int, int>( x + 1 , y));
				}

				if (y - 1 >= 0 && grid[x, y - 1] == '1' && color[x, y - 1] == 0)
				{
					color[x, y - 1] = cur;
					queue.Add(new Tuple<int, int>( x , y - 1));
				}

				if (y + 1 < grid.GetLength(1) && grid[x, y + 1] == '1' && color[x, y + 1] == 0)
				{
					color[x, y + 1] = cur;
					queue.Add(new Tuple<int, int>( x , y + 1));
				}

				start++;
			}
		}
	}
}

