using ConsoleDump;
using System;
using System.Collections.Generic;

namespace ExercisesAlgo.Trees
{

    /*
    Find shortest unique prefix to represent each word in the list.

Example:

Input: [zebra, dog, duck, dove]
Output: { z, dog, du, dov}
    where we can see that
    zebra = z
dog = dog
duck = du
dove = dov
 NOTE : Assume that no word is prefix of another.In other words, the representation is always possible.
 */

    public class UniquePrefix
    {
        public static void Execute()
        {
            new UniquePrefix().prefix(new List<string> { "bearcat", "bert" }).Dump();
            new UniquePrefix().prefix(new List<string> { "zebra", "dog", "duck", "dove" }).Dump();
        }

        public List<string> prefix(List<string> A)
        {
            var trie = new Trie();
            var results = new List<string>();
            A.ForEach(str => trie.Add(str));

            A.ForEach(str =>
            {
                var curr = trie.Root;
                var sb = new List<char>();
                for (int i = 0; i < str.Length; i++)
                {
                    if (curr.children.ContainsKey(str[i]))
                    {
                        curr = curr.children[str[i]];
                        sb.Add(str[i]);
                        if (curr.endOfWord || curr.Cnt <=1)
                        {
                            break;
                        }
                    }
                }
                results.Add(new String(sb.ToArray()));
            });
            return results;
        }
    }
}
