using System;
using System.Collections.Generic;

namespace MyCSharpAlgorithms
{
	public class TrieNode {
		// Initialize your data structure here.
		public TrieNode() {
			Children = new Dictionary<char, TrieNode> ();
			IsTerminal = false;
		}

		public bool IsTerminal;
		public Dictionary<char, TrieNode> Children;
	}

	public class Trie {
		private TrieNode root;

		public Trie() {
			root = new TrieNode();
		}

		public void addWord(string word)
		{
			Insert (word);
		}

		// Inserts a word into the trie.
		public void Insert(string word) {
			if (!string.IsNullOrEmpty(word))
			{
				var cur = root;
				foreach(char c in word)
				{
					if (!cur.Children.ContainsKey (c)) {
						cur.Children.Add (c, new TrieNode ());
					}

					cur = cur.Children [c];
				}

				cur.IsTerminal = true;
			}
		}

		// Returns if the word is in the trie.
		/*
		public bool Search(string word) {
			var cur = root;
			foreach(char c in word)
			{
				if (!cur.Children.ContainsKey (c)) {
					return false;
				}
				else
				{
					cur = cur.Children [c];
				}
			}

			return cur.IsTerminal;
		}
		*/

		public bool Search(string word)
		{
			return rSearch (word, 0, root);
		}

		public bool rSearch(string word, int start, TrieNode root)
		{
			if (start < word.Length - 1) {
				if (word [start] == '.') {
					bool find = false;

					foreach (var child in root.Children) {
						if (rSearch (word, start + 1, child.Value)) {
							return true;
						}
					}

					return false;
				} else {
					if (root.Children.ContainsKey (word [start])) {
						return rSearch (word, start + 1, root.Children [word [start]]);
					} else {
						return false;
					}
				}
			} else if (start == word.Length - 1) {
				if (word [start] == '.') {
					foreach (var child in root.Children) {
						if (child.Value.IsTerminal) {
							return true;
						}
					}

					return false;
				} else {
					return root.Children.ContainsKey (word [start]) && root.Children [word [start]].IsTerminal;
				}
			}

			return false;
		}

		// Returns if there is any word in the trie
		// that starts with the given prefix.
		public bool StartsWith(string word) {
			var cur = root;
			foreach(char c in word)
			{
				if (!cur.Children.ContainsKey (c)) {
					return false;
				}

				cur = cur.Children [c];
			}

			return true;
		}
	}
}

