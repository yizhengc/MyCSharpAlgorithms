using System;

namespace MyCSharpAlgorithms
{
	public class MinHeap<T> where T : IComparable
	{
		private T[] _ary;
		private int _last = -1;
		private const int c_minSize = 8;

		public MinHeap (int size)
		{
			if (size > c_minSize) {
				_ary = new T[size];
			} else {
				_ary = new T[c_minSize];
			}
		}

		public void Add(T element)
		{
			if (_last == _ary.Length - 1) {
				var old = _ary;
				_ary = new T[old.Length * 2];

				old.CopyTo (_ary, 0);
			}

			_ary [++_last] = element;

			Heapify ();
		}

		public T Pop()
		{
			if (_last >= 0) {
				var res = _ary [0];

				_ary [0] = _ary [_last--];

				int s = 0;
				while (s < _last) {
					int l = s * 2 + 1;
					int r = s * 2 + 2;

					int target = -1;

					if (l > _last) {
						break;
					} else if (r > _last) {
						target = l;
					} else {
						target = _ary[l].CompareTo( _ary [r]) < 0 ? l : r;
					}

					if (_ary [s].CompareTo (_ary [target]) > 0) {
						Swap (s, target);
						s = target;
					} else {
						break;
					}
				}

				return res;
				
			} else {
				throw new Exception ("Heap is empty");
			}
		}

		private void Heapify()
		{
			var last = _last;
			while (last > 0) {
				int p = (last - 1) / 2;
				if (_ary [p].CompareTo (_ary [last]) > 0) {
					Swap (p, last);
					last = p;
				} else {
					break;
				}
			}
		}

		private void Swap(int a, int b)
		{
			var tmp = _ary [a];
			_ary [a] = _ary [b];
			_ary [b] = tmp;
		}
	}
}

