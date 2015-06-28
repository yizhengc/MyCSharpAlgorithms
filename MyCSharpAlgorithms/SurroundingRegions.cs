using System;
using System.Collections.Generic;

namespace MyCSharpAlgorithms
{
	public class SurroundingRegions
	{
		public SurroundingRegions ()
		{
			
		}


		public void Solve(char[,] board) {

			for(int c = 0; c < board.GetLength(1); c++)
			{
				if (board[0,c] == '0')
				{
					ColorRegion(board, 0, c);
				}

				if (board[board.GetLength(0) - 1, c] == '0')
				{
					ColorRegion(board, board.GetLength(0) - 1, c);
				}
			}

			for(int r = 1; r < board.GetLength(0); r++)
			{
				if (board[r,0] == '0')
				{
					ColorRegion(board, r, 0);
				}

				if (board[r,board.GetLength(1) - 1] == '0')
				{
					ColorRegion(board, r, board.GetLength(1) - 1);
				}
			}

			for(int r = 0; r < board.GetLength(0); r++)
			{
				for(int c = 0; c < board.GetLength(1); c++)
				{
					if (board[r,c] == '1')
					{
						board[r,c] = '0';
					}
					else if (board[r,c] == '0')
					{
						board[r,c] = 'x';
					}
				}
			}
		}

		public void ColorRegion(char[,] board, int sr, int sc)
		{
			var queue = new List<Tuple<int, int>>();
			queue.Add(new Tuple<int, int> (sr, sc));

			int start = 0;
			board[sr,sc] = '1';

			while(start < queue.Count)
			{
				var a = queue[start];

				if (a.Item1 - 1 >=0 && board[a.Item1 - 1, a.Item2] == '0')
				{
					board[a.Item1 - 1, a.Item2] = '1';
					queue.Add(new Tuple<int, int>(a.Item1 - 1, a.Item2));
				}

				if (a.Item1 + 1 < board.GetLength(0) && board[a.Item1 + 1, a.Item2] == '0')
				{
					board[a.Item1 + 1, a.Item2] = '1';
					queue.Add(new Tuple<int, int>(a.Item1 + 1, a.Item2));
				}

				if (a.Item2 - 1 >= 0 && board[a.Item1, a.Item2 - 1] == '0')
				{
					board[a.Item1, a.Item2 - 1] = '1';
					queue.Add(new Tuple<int, int>(a.Item1, a.Item2 - 1));
				}

				if (a.Item2 + 1 < board.GetLength(1) && board[a.Item1, a.Item2 + 1] == '0')
				{
					board[a.Item1, a.Item2 + 1] = '1';
					queue.Add(new Tuple<int, int>(a.Item1, a.Item2 + 1));
				}

				start++;
			}
		}
	}
}

