using System;
using System.Collections.Generic;

namespace MyCSharpAlgorithms
{
	public class SortTests
	{
		private static List<int[]> inputList = new List<int[]>() {
			null,
			new int[0],
			new int[] { -1 },
			new int[] { 0, -1, 2, -3, 5, 5, 10},
			new int[] { 0, -1, 2, -3, 5, 9, 9, 10},
			new int[] { 3, 1, 2, 4}
		};

		public SortTests (){

		}

		public static void TestHeapSort()
		{
			foreach(var input in inputList)
			{
				var res = Sort<int>.HeapSort(input);

				if (!ValidateOrder (res)) {
					Console.WriteLine ("Test Failure");
					Console.Write ("Input: ");
					PrintArray (input);
					Console.Write ("Actual: ");
					PrintArray (res);
				} 
			}
		}

		public static void TestFindNthElement()
		{
			var res = Sort<int>.FindNthElement (inputList [2], 1);
			res = Sort<int>.FindNthElement (inputList [3], 3);
			res = Sort<int>.FindNthElement (inputList [5], 2);
		}

		private static bool ValidateOrder(int[] input, bool asc = true)
		{
			if (input != null && input.Length >= 2)
			{
				for (int i = 0; i < input.Length - 1; i++) {
					if ((asc && input [i] > input [i + 1]) || (!asc && input [i] < input [i + 1])) {
						return false;
					}
				}
			}

			return true;
		}

		private static void PrintArray(int[] res)
		{
			Console.Write ('[');
			foreach (var i in res) {
				Console.Write (res);
				Console.Write (", ");
			}

			Console.Write ("]\n");
		}
	}
}

