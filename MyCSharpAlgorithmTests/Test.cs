using NUnit.Framework;
using System;
using System.Collections.Generic;
using MyCSharpAlgorithms;

namespace MyCSharpAlgorithmTests
{

	[TestFixture ()]
	public class Test
	{
		[Test ()]
		public void TestNextPermutation()
		{
			Permutation perm = new Permutation ();
			perm.NextPermutation (new int[]{ 1, 2 });
			perm.NextPermutation (new int[]{ 6, 4, 3, 2, 1 });
		}

		[Test ()]
		public void TestRotateArraySearch()
		{
			SearchRotatedArray sr = new SearchRotatedArray ();
			var res = sr.Search (new int[]{ 4, 5, 6, 7, 8, 1, 2, 3 }, 8);
		}

		[Test ()]
		public void TestReverseKGroup()
		{
			LinkList ll = new LinkList ();
			var input = LinkList.ArrayToList (new int[]{ 1, 2, 3, 4, 5 });

			var res = ll.ReverseKGroup (input, 2);
		}

		[Test ()]
		public void TestMergeSort()
		{
			MergeSort ms = new MergeSort ();

			var input = new ListNode[] {
				null, 
				LinkList.ArrayToList (new int[]{-1, 5, 11}),
				null, 
				LinkList.ArrayToList (new int[]{6, 10})
			};
				
			var res = ms.MergeKLists (input);
		}

		[Test ()]
		public void TestThreeSum()
		{
			ThreeSumProblem ts = new ThreeSumProblem ();
			var res = ts.ThreeSum (new int[]{ -4, -2, -2, -2, 0, 1, 2, 2, 2, 3, 3, 4, 4, 6, 6 });
			res = ts.ThreeSum (new int[]{-4,-2,1,-5,-4,-4,4,-2,0,4,0,-2,3,1,-5,0});
		}

		[Test ()]
		public void TestRegexMatch()
		{
			RegexMatch rm = new RegexMatch ();

			var res = rm.IsMatch ("cbaacacaaccbaabcb", "c*b*b*.*ac*.*bc*a*"); 
			res = rm.IsMatch("a", ".*..a*");
			res = rm.IsMatch ("aaaaaaaaaaaaab", "a*a*a*a*a*a*a*a*a*a*c");//false
			res = rm.IsMatch("aa","aa") ;//true
			res = rm.IsMatch("aaa","aa");// false
			res = rm.IsMatch("aa", "a*");// true
			res = rm.IsMatch("aa", ".*");// true
			res = rm.IsMatch("ab", ".*");// true
			res = rm.IsMatch("aab", "c*a*b");// true
			res = rm.IsMatch ("bbbba", ".*a*a");
			res = rm.IsMatch ("abcde", "a*.*");
			res = rm.IsMatch ("abcde", "a*c*d");
		}

		[Test ()]
		public void TestRepeatedDNA ()
		{
			FindRepeatedDNA fr = new FindRepeatedDNA ();
			var res = fr.FindRepeatedDnaSequences ("GAGAGAGAGAGA");
			Assert.AreEqual (new List<string>(){"GAGAGAGAGA"}, res);
		}
		/*
		[Test ()]
		public void TestMedianSortedArray()
		{
			MedianOfSortedArray msa = new MedianOfSortedArray ();
			var res = msa.FindMedianSortedArrays (new int[]{ 1, 3, 7 }, new int[]{ 2, 5 });
		}
		*/

		[Test ()]
		public void TestZigZag()
		{
			ZigZag zz = new ZigZag ();
			var res = zz.Convert ("PAYPALISHIRING", 2);
		}
	}
}

