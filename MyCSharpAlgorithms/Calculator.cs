using System;

namespace MyCSharpAlgorithms
{
	public class Calculator
	{
		SimpleStack<char> stack = new SimpleStack<char> ();
		SimpleStack<int> result = new SimpleStack<int> ();

		public Calculator ()
		{


		}

		public int Calculate2(string input)
		{
			input = input.Replace (" ", "");

			for(int i = 0; i <= input.Length; i++)
			{
				if (i == input.Length || input [i] == '+' || input [i] == '-' || input [i] == '*' || input[i] == '/') {
					if (!stack.Empty () && (i == input.Length || input[i] == '*' || input[i] == '/')
						&& (stack.Top () == '*' || stack.Top () == '/'))
					{
							char op = stack.Pop ();
							int val2 = result.Pop ();
							int val1 = result.Pop ();

							switch (op) {
							case '*':
								result.Push (val1 * val2);
								break;
							case '/':
								result.Push (val1 / val2);
								break;
							}
					} 

					while (!stack.Empty () && (i == input.Length || input[i] == '+' || input[i] == '-')) {
						char op = stack.Pop ();
						int val2 = result.Pop ();
						int val1 = result.Pop ();

						switch (op) {
						case '+':
							result.Push (val1 + val2);
							break;
						case '-':
							result.Push (val1 - val2);
							break;
						case '*':
							result.Push (val1 * val2);
							break;
						case '/':
							result.Push (val1 / val2);
							break;
						}
					} 

					if (i < input.Length) {
						stack.Push (input [i]);
					}
				}
				else {

					result.Push(ReadInteger (input, i, out i));
				}
			}

			return result.Pop ();
		}

		public int Calculate(string input)
		{
			input = input.Replace (" ", "");

			for(int i = 0; i <= input.Length; i++)
			{
				if (i == input.Length || input [i] == '+' || input [i] == '-' || input [i] == ')') {
					if (!stack.Empty () && (stack.Top () == '+' || stack.Top () == '-')) {
						char op = stack.Pop ();
						int val2 = result.Pop ();
						int val1 = result.Pop ();

						if (op == '+') {
							result.Push (val1 + val2);
						} else {
							result.Push (val1 - val2);
						}
					} 

					if (i < input.Length) {

						if (input [i] == ')') {
							stack.Pop ();
						} else {
							stack.Push (input [i]);
						}
					}
				} else if (input [i] == '(') {
					stack.Push (input [i]);
				}
				else {

					result.Push(ReadInteger (input, i, out i));
				}
			}

			return result.Pop ();
		}

		public int ReadInteger(string s, int start, out int end)
		{
			int i = start;
			int val = 0;
			for (; i < s.Length && s[i] >= '0' && s[i] <= '9'; i++)

			{
				val *= 10;
				val += (int)(s[i] - '0');
			}

			end = i - 1;

			return val;
		}
	}
}

