using System;
using System.Collections.Generic;

namespace MyCSharpAlgorithms
{
	public class Subset
	{
		public Subset ()
		{
		}
		/*
		IList<IList<int>> FindAllSubsets(ISet<int> input)
		{
			var result = new List<IList<int>> ();

			if (input != null && input.Count != 0) {
				var all = new List<int> (input);
				all.Sort ();

				var dedup = new List<Tuple<int, int>> ();
				dedup.Add (new Tuple<int,int> (all [0], 1));
				for (int i = 1; i < all.Count; i++) {
					if (all [i] != all [i - 1]) {
						dedup.Add (new Tuple<int, int> (all [i], 1));
					} else {
						dedup [dedup.Count - 1]++;
					}
				}

				bool[] selection = new bool[dedup.Count];

				for (int i = 0; i < (int)Math.Pow (2, selection.Length); i++) {
					var r = new List<IList<int>> ();
					r.Add (new List<int> ());
					for (int k = 0; k < selection.Length; k++) {
						if (selection [k]) {
							if (dedup [k] == 1) {
								foreach (var t in r) {
									t.Add (dedup [k]);
								}
							}
						}
					}
				}
			}
		}
*/
		private void Increment(bool[] selection)
		{
			bool cary = true;
			for (int i = selection.Length - 1; i >= 0; i--) {
				if (selection [i] == false) {
					selection [i] = true;
					break;
				} else {
					if (cary == false) {
						break;
					} else {
						selection [i] = false;
						cary = true;
					}
				}
			}
		}
	}
}

