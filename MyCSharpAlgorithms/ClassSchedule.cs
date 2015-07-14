using System;
using System.Collections.Generic;

namespace MyCSharpAlgorithms
{
	public class ClassSchedule
	{
		public ClassSchedule ()
		{
		}

		public bool CanFinish(int numCourses, int[,] prerequisites) {
			Dictionary<int, HashSet<int>> dep = new Dictionary<int, HashSet<int>>();

			for(int i = 0; i < prerequisites.GetLength(0); i++)
			{
				var s = prerequisites[i, 0];
				var e = prerequisites[i, 1];

				if (!dep.ContainsKey(s))
				{
					dep[s] = new HashSet<int>();
				}

				if (!dep[s].Contains(e))
				{
					dep[s].Add(e);
				}
			}

			foreach(var c in dep)
			{
				var visited = new bool[numCourses];

				if (!DFS(dep, c.Key, visited))
				{
					return false;
				}
			}

			return true;
		}

		private bool DFS(Dictionary<int, HashSet<int>> map, int start, bool[] visited)
		{
			if(visited[start] == true)
			{
				return false;
			}
			else
			{
				visited[start] = true;

				if (map.ContainsKey(start))
				{
					foreach(var c in map[start])
					{
						if (!DFS(map, c, visited))
						{
							return false;
						}
					}
				}

				visited [start] = false;
				return true;
			}
		}

		public int[] FindOrder(int numCourses, int[,] prerequisites) {
			List<int>[] adj = new List<int>[numCourses];

			for (int r = 0; r < prerequisites.GetLength (0); r++) {
				if (adj [prerequisites [r, 1]] == null) {
					adj [prerequisites [r, 1]] = new List<int> ();	
				}

				adj [prerequisites [r, 1]].Add(prerequisites [r, 0]);
			}

			var stack = new SimpleStack<int> ();

			bool[] visited = new bool[numCourses];
			int i = 0;
			for (; i < numCourses; i++) {
				if (!visited [i]) {
					DFS (i, adj, stack, visited);
				}
			}

			var result = new int[numCourses];

			i = 0;
			while (!stack.Empty ()) {
				result [i++] = stack.Pop ();
			}

			return result;
		}

		public void DFS(int start, List<int>[] adj, SimpleStack<int> stack, bool[] visited)
		{
			visited [start] = true;
			if (adj[start] != null) {
				foreach (var r in adj[start]) {
					if (!visited [r]) {
						DFS (r, adj, stack, visited);
					}
				}
			}

			stack.Push (start);
		}
	}
}

