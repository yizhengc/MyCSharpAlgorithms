using System;
using System.Collections.Generic;

namespace MyCSharpAlgorithms
{
	public class Stack<T> {

		class Queue<T>
		{
			private List<T> _ary = new List<T>();
			private int _size = 0;
			private int _head = -1;

			public void Push(T x)
			{

				if (_head == -1)
				{
					_head++;
				}

				_ary.Add(x);
				_size++;
			}

			public T Peek()
			{
				if (_head >= 0)
				{
					return _ary[_head];
				}
				else
				{
					throw new Exception();
				}
			}

			public T Pop()
			{
				if (_size > 0)
				{
					_size--;

					T res;
					if (_size == 0)
					{
						res = _ary[_head];
						_head = -1;
					}
					else
					{
						res = _ary[_head++];
					}

					return res;
				}
				else
				{
					throw new Exception();
				}
			}

			public int Size()
			{
				return _size;
			}
		}

		Queue<T> target = new Queue<T>();
		Queue<T> backup = new Queue<T>();

		T _top;

		// Push element x onto stack.
		public void Push(T x) {
			target.Push(x);
			_top = x;
		}

		// Removes the element on top of the stack.
		public void Pop() {
			if (target.Size() == 0)
			{
				throw new Exception();
			}

			while(target.Size() > 1)
			{
				backup.Push(target.Pop());
			}

			target.Pop();

			var tmp = target;
			target = backup;
			backup = tmp; 
		}

		// Get the top element.
		public T Top() {
			if (target.Size() == 0)
			{
				throw new Exception();
			}
			else
			{
				return _top;
			}
		}

		// Return whether the stack is empty.
		public int Empty() {
			return target.Size() == 0 ? 1 : 0;
		}
	}

	public class SimpleStack<T>
	{
		private List<T> ary = new List<T>();
		private int top = -1;

		public void Push(T x)
		{
			if (top == ary.Count - 1) {
				ary.Add (x);
				top++;
			} else {
				ary [++top] = x;
			}
		}

		public T Pop()
		{
			if (top >= 0) {
				T result = ary [top--];
				return result;
			} else {
				throw new Exception ();
			}
		}

		public T Top()
		{
			if (top >= 0) {
				return ary [top];
			} else {
				throw new Exception ();
			}
		}

		public bool Empty()
		{
			return top == -1;
		}
	}
}

