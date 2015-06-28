using System;
using System.Collections.Generic;

namespace MyCSharpAlgorithms
{
	public class UndirectedGraphNode {
		public int label;
		public IList<UndirectedGraphNode> neighbors;
		public UndirectedGraphNode(int x) { label = x; neighbors = new List<UndirectedGraphNode>(); }
	};

	public class Graph
	{
		public Graph ()
		{
		}

		public UndirectedGraphNode CloneGraph(UndirectedGraphNode node) {
			var visited = new Dictionary<UndirectedGraphNode, UndirectedGraphNode> ();
			var queue = new List<UndirectedGraphNode> ();
			int start = 0;

			if (node == null) {
				return null;
			}

			queue.Add (node); 
			var newHead = new UndirectedGraphNode (node.label);

			visited.Add (node, newHead);

			while (start < queue.Count) {
				foreach (var n in queue[start].neighbors) {
					if (!visited.ContainsKey (n)) {
						visited [n] = new UndirectedGraphNode (n.label);
						queue.Add (n);
					}

					visited [queue [start]].neighbors.Add (visited [n]);
				}

				start++;
			}

			return newHead;

		}
	}
}

