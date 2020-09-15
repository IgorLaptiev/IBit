using System;
using System.Collections.Generic;
using System.Linq;

namespace ExercisesAlgo.Trees
{
    public class Trie
    {
        TrieNode root;

        public TrieNode Root => root;

        public Trie()
        {
            root = new TrieNode();
        }

        public void Add(string chars)
        {
            TrieNode tempRoot = root;
            int total = chars.Length - 1;
            for (int i = 0; i < chars.Length; i++)
            {
                TrieNode newTrie;
                if (tempRoot.children.Keys.Contains(chars[i]))
                {
                    tempRoot = tempRoot.children[chars[i]];
                }
                else
                {
                    newTrie = new TrieNode();

                    if (total == i)
                    {
                        newTrie.endOfWord = true;
                    }

                    tempRoot.children.Add(chars[i], newTrie);
                    tempRoot = newTrie;
                }
                tempRoot.Cnt++;
            }
        }

        public bool Contains(string chars)
        {
            TrieNode tempRoot = root;
            int total = chars.Length- 1;
            for (int i = 0; i < chars.Length; i++)
            {
                if (tempRoot.children.Keys.Contains(chars[i]))
                {
                    tempRoot = tempRoot.children[chars[i]];

                    if (total == i)
                    {
                        if (tempRoot.endOfWord == true)
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }

    public class TrieNode
    {
        public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
        public bool endOfWord;
        public int Cnt { get; set; }

    }
}
