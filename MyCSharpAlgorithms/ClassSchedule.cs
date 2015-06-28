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
	}
}

