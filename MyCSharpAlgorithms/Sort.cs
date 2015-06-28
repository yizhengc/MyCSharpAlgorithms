using System;

namespace MyCSharpAlgorithms
{
	public class Sort<T> where T : IComparable
	{
		public static T[] HeapSort(T[] input)
		{
			if (input == null || input.Length == 0 || input.Length == 1) {
				return input;
			}

			var result = new T[input.Length];

			var minHeap = new MinHeap<T> (input.Length);

			for (int i = 0; i < input.Length; i++) {
				minHeap.Add (input [i]);
			}

			for (int i = 0; i < input.Length; i++) {
				result [i] = minHeap.Pop ();
			}

			return result;
		}


		public static T FindNthElement(T[] input, int n)
		{
			if (n < 0 || input == null || input.Length == 0) {
				throw new Exception (); 
			}

			return FindNthElement (input, n, 0, input.Length - 1);
		}

		private static T FindNthElement(T[] input, int n, int start, int end)
		{
			int pivot = Partition (input, start, end);

			if (pivot == end - n + 1) {
				return input [pivot];
			} else if (pivot > end - n + 1) {
				return FindNthElement (input, n - (end - pivot + 1), start, pivot - 1);
			} else {
				return FindNthElement (input, n, pivot + 1, end);
			}
		}

		private static int Partition(T[] input, int start, int end)
		{
			while (end > start) {

				if (input [end - 1].CompareTo (input [end]) < 0) {
					Swap (input, start, end - 1);
					start++;
				} else {
					Swap (input, end - 1, end);
					end--;
				}
			}

			return end;
		}

		private static void Swap(T[] input, int a, int b)
		{
			T temp = input [a];
			input [a] = input [b];
			input [b] = temp;
		}
	}
}

