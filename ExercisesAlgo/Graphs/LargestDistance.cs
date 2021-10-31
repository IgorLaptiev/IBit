using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Graphs
{
    public class LargestDistance
    {
        public static void Execute()
        {
            new LargestDistance().solve(new List<int> { -1, 0, 1}).Dump();
            new LargestDistance().solve(new List<int> { -1, 0, 0, 0, 3 }).Dump();
            new LargestDistance().solve(new List<int> { -1, 0, 1, 1, 3, 0, 4, 0, 2, 8, 9,/* 0 /*4, 6, 12, 14, 7, 9, 6, 4, 14, 13, 1, 9, 16, 17, 17, 0, 21, 10, 13, 14, 25, 28, 27, 0, 35, 20, 34, 23, 37, 3, 6, 25, 30, 22, 15, 37, 8, 6, 11, 22, 50, 12, 4, 2, 54, 23, 18, 52, 34, 49, 61, 8, 15, 63, 31, 51, 48, 41, 26, 37, 30, 15, 59, 12, 0, 40, 37, 73, 32, 19, 70, 29, 8, 21, 83, 33, 7, 13, 12, 82, 43, 86, 38, 31, 1, 84, 62, 83 */}).Dump();
            new LargestDistance().solve(new List<int> { -1, 0, 1, 1, 3, 0, 4, 0, 2, 8, 9, 0, 4, 6, 12, 14, 7, 9, 6, 4, 14, 13, 1, 9, 16, 17, 17, 0, 21, 10, 13, 14, 25, 28, 27, 0, 35, 20, 34, 23, 37, 3, 6, 25, 30, 22, 15, 37, 8, 6, 11, 22, 50, 12, 4, 2, 54, 23, 18, 52, 34, 49, 61, 8, 15, 63, 31, 51, 48, 41, 26, 37, 30, 15, 59, 12, 0, 40, 37, 73, 32, 19, 70, 29, 8, 21, 83, 33, 7, 13, 12, 82, 43, 86, 38, 31, 1, 84, 62, 83 }).Dump();
        }
        int maxPath = 0;
        public int solve(List<int> A)
        {
            if (A.Count == 1) return 0;
            var tree = new Dictionary<int, List<int>>();
            for (var i = 0; i < A.Count; i++)
            {
                if (!tree.ContainsKey(A[i]))
                {
                    tree[A[i]] = new List<int>();
                }
                tree[A[i]].Add(i);
            }
            maxPath = Math.Max(GetMaxDistance(tree[-1].First(), tree) -1, maxPath);
            return maxPath;
        }

        private int GetMaxDistance(int root, Dictionary<int, List<int>> tree)
        {
            if (!tree.ContainsKey(root)) return 1;

            var distances = tree[root].Select(node => GetMaxDistance(node, tree)).OrderByDescending(d => d).Take(2).ToList();
            if (distances.Count == 2)
            {
                var max = distances[0] + distances[1];
                if(max > maxPath)
                {
                    maxPath = max;
                }
            }
            return distances.Max() + 1;
        }
    }
}
