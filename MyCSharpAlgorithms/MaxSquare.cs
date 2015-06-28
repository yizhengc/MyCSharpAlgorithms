using System;
using System.Collections.Generic;

namespace MyCSharpAlgorithms
{
	public class MaxSquare
	{
		public MaxSquare ()
		{
		}

		public char[,] CreateMatrix(string[] input)
		{
			var result = new char[input.Length, input [0].Length];

			int r = 0;
			foreach (var str in input) {
				for(int c = 0; c < str.Length; c++)
				{
					result[r, c] = str[c];
				}
				r++;
			}

			return result;
		}

		public int MaximalSquare(char[,] matrix) {
			if (matrix.Length == 0) {
				return 0;
			}

			int y = matrix.GetLength (0);
			int x = matrix.GetLength (1);


			int[,] aux = new int[y, x];
			int i = 0;
			int j = 0;

			for (i = 0; i < y; i++) {
				int len = 0;
				for (j = x - 1; j >= 0; j--) {
					if (matrix [i, j] == '1') {
						aux [i, j] = (++len);
					} else {
						len = 0;
					}
				}
			}

			int[,] maxEdge = new int[y, x];
			for (i = 0; i < x; i++) {
				int len = 0;

				for (j = y - 1; j >= 0; j--) {
					if (matrix [j, i] == '1') {
						maxEdge [j, i] = Math.Min (aux [j,i], ++len);
					} else {
						len = 0;
					}
				}
			}

			int max = 0;

			int[,] maxArea = new int[y, x];

			for (i = 0; i < y; i++) {
				for (j = 0; j < x; j++) {
					if (maxEdge [i, j] > max && maxArea [i, j] == 0) {
						var res = MaxEdge (maxEdge, i, j, maxArea);
						if (res > max) {
							max = res;
						}
					} else if (maxArea [i, j] > max) {
						max = maxArea [i, j];
					}
				}
			}

			return max * max;
		}

		int MaxEdge(int[,] maxEdge, int i, int j, int[,] maxArea)
		{
			int max = maxEdge [i, j];

			if (max <= 1) {
				maxArea [i, j] = 0;
				return max;
			} else if (maxArea [i, j] > 0) {
				return maxArea [i, j];
			}
			else
			{
				var res = MaxEdge (maxEdge, i + 1, j + 1, maxArea);

				res = Math.Min (maxEdge [i, j], res + 1);
				maxArea [i, j] = res;
				return res;
			}
		}
	}
}
