﻿using System;
using System.Collections.Generic;

namespace MyCSharpAlgorithms
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			FindRepeatedDNA fd = new FindRepeatedDNA ();
			var res = fd.FindRepeatedDnaSequences ("AAAAAAAAAAA");

			Console.WriteLine (res);
		}
	}
}


//int idx = StringMatch.StrStr ("mississippi", "a");

//Console.WriteLine (string.Format ("Result: {0}", idx)); 

//SortTests.TestHeapSort ();
//SortTests.TestFindNthElement();

//var result = Factorial.TrailingZeroes (30);

//var result = PascalTriangle.Generate (3);

/*
			TreeNode root = new TreeNode (1);
			root.left = new TreeNode (2);
			root.right = new TreeNode (3);
			root.left.left = new TreeNode (4);

			//Tree.LevelOrder (root);

			//MergeSort.Merge (new int[]{ 1, 2, 4, 5, 6, 0 }, 5, new int[]{ 3 }, 1);
			Calculator cal = new Calculator();

			var res = cal.Calculate2 ("1+ 3*2 + 3/1 + 2* 4/ 2");

			//cal.Calculate ("(1+(4+5+2)-3)+(6+8)");

			//Tree.CountNodes (root);

			/*
			 MaxSquare square = new MaxSquare ();

			var input = square.CreateMatrix(new string[]{"00010111","01100101","10111101","00010000","00100010","11100111","10011001","01001100",
				"10010000"});
			
			var result = square.MaximalSquare(input);


			CombinationSUm cs = new CombinationSUm ();
			//cs.CombinationSum3 (3, 14);
			cs.CombinationSum2 (new int[]{ 2, 2 }, 4);

		
			Trie trie = new Trie ();
			trie.addWord ("bad");
			trie.addWord ("dad");
			trie.addWord ("mad");
			var result = trie.Search ("pad");
			result = trie.Search ("bad");
			result = trie.Search (".ad");
			result = trie.Search ("b..");

			ClassSchedule cs = new ClassSchedule ();
			var r = cs.CanFinish (3, new int[3, 2]{ { 0, 1 }, { 0, 2}, {1, 2}});


			TreeNode tree = new TreeNode (1);
			tree.left = new TreeNode (2);
			var res = Tree.RightSideView (tree);



			MaxSquare sq = new MaxSquare();
			var input = sq.CreateMatrix(new string[]{"11111011111111101011",
				                                     "01111111111110111110",
													 "10111001101111111111",
													 "11110111111111111111",
													 "10011111111111111111",
													 "10111111011101110111",
													 "01111111111101101111",
				                                     "11111111111101111011",
				                                     "11111111110111111111",
													 "11111111111111111111",
				       								 "01111111011111111111",
													 "11111111111111111111",
													 "11111111111111111111",
													 "11111011111110111111",
													 "10111110111011110111",
				 									 "11111111111101111110",
													 "11111111111110111100",
													 "11111111111111111111",
													 "11111111111111111111",
													 "11111111111111111111"});
			CountIslands ci = new CountIslands ();
			ci.NumIslands (input);



			TreeNode root = new TreeNode (2);
			root.left = new TreeNode (1);

			BSTIterator bi = new BSTIterator (root);

			while (!bi.HasNext ()) {
				var result = bi.Next ();
			}

			

			MaxProduct mp = new MaxProduct ();
			mp.MaxProd (new int[]{ 2, 0, 1, -1, 3, 4, -2, -3, 0});


			LinkList ll = new LinkList ();
			var l1 = new ListNode (3);
			var l2 = new ListNode (2);
			var l3 = new ListNode (0);
			var l4 = new ListNode (-4);
			l1.next = l2;
			l2.next = l3;
			l3.next = l4;
			l4.next = l2;

			var result = ll.DetectCycle (l1);




			WordBreaker wb = new WordBreaker ();

			HashSet<string> wordDict = new HashSet<string> () { "leet", "code" };
			var result = wb.WordBreak("leetcode", wordDict);
			

			LongestConsecutive lc = new LongestConsecutive ();



			SurroundingRegions sr = new SurroundingRegions ();
			sr.Solve (new char[,]{ { 'x', 'x', 'x' }, { 'x', '0', 'x' }, { 'x', 'x', 'x' } });

			

			WordLadder wl = new WordLadder ();

			var res = wl.LadderLength ("hit", "cog", new HashSet<string> (){ "hot","dot","dog","lot","log"});



			BuyStock bs = new BuyStock ();
			bs.MaxProfit (new int[]{ 1, 2, 4});


			ReverseWords rw = new ReverseWords ();

			var res = rw.Reverse ("   a   b ");

			Tree tr = new Tree ();

			TreeNode root = new TreeNode (1);
			root.left = new TreeNode (2);

			tr.Flatten(root);


			TreeNode root = new TreeNode (5);
			root.left = new TreeNode (4);
			root.right = new TreeNode (8);
			root.left.left = new TreeNode (11);
			root.left.left.left = new TreeNode (7);
			root.left.left.right = new TreeNode (2);
			root.right.left = new TreeNode (13);
			root.right.right = new TreeNode (4);
			root.right.right.left = new TreeNode (5);
			root.right.right.right = new TreeNode (1);

			PathSum ps = new PathSum ();
			var result = ps.PathSumI (root, 22);



			ListToBST ls = new ListToBST ();

			ls.SortedListToBST (LinkList.ArrayToList (new int[]{ 1, 2, 3, 4, 5, 6 }));


			Tree tr = new Tree ();
			var root = new TreeNode (3);
			root.left = new TreeNode (9);
			root.right = new TreeNode (20);
			root.right.left = new TreeNode (15);
			root.right.right = new TreeNode (7);

			var result = tr.ZigzagLevelOrder (root);

		

			ValdateIP vp = new ValdateIP ();
			var res = vp.RestoreIpAddresses ("25525511135");


			LinkList ll = new LinkList ();
			var head = LinkList.ArrayToList (new int[]{ 1, 2, 3, 4, 5, 6 });
			ll.ReverseBetween (head, 2, 4);

			
			GreyCode gc = new GreyCode ();
			var result = gc.GrayCodeGen (2); 


			NumDecoding nd = new NumDecoding ();
			var res = nd.NumDecodings ("1029");


			RemoveDuplicate rd = new RemoveDuplicate ();
			rd.RemoveDuplicates (new int[] { 1, 1, 1, 1, 3, 3 });


			Combinations cb = new Combinations ();
			var res = cb.Combine (2, 2);


			Matrix mx = new Matrix ();
			var res = mx.SearchMatrix (new int[,]{ { 1 } }, 1); 



			UniquePathes up = new UniquePathes ();

			var res = up.UniquePaths (4, 4);
						

			Combinations cb = new Combinations ();
			var res = cb.GetPermutation (2, 2);


			Matrix mx = new Matrix ();
			var res = mx.SpiralOrder (new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });


			var nums = new int[]{ 1,1,-2};
			MaxSubArray ms = new MaxSubArray ();
			var res = ms.MaxSub (nums);
					

			LargeNumber ln = new LargeNumber ();

			var res = ln.Multiply ("12", "232");


			Division dv = new Division ();

			var res = dv.Divide (-2147483648, 2);


			MaxArea ma = new MaxArea ();
			ma.ComputeMaxArea (new int[]{ 1, 1 });

			CountDigitOne cd = new CountDigitOne ();

			var res = cd.Count (1410065408);


			var cs = new ClassSchedule ();
			var res = cs.FindOrder (4, new int[,]{ { 1, 0 }, { 2, 0 }, { 3, 1 }, { 3, 2 } });
			*/