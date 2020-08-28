using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Hashing
{
    public class TwoSum
    {
        public static void Execute()
        {
            //new TwoSum().twoSum(new List<int> { 4, 7, -4, 2, 2, 2, 3, -5, -3, 9, -4, 9, -7, 7, -1, 9, 9, 4, 1, -4, -2, 3, -3, -5, 4, -7, 7, 9, -4, 4, -8 }, -3).Dump();
            new TwoSum().twoSum(new List<int> { 2, 5, 0, -6, 7, -4, 0, 4, 3, 0, -2, 0, 9, -3, -9, -3, 9, 3, 2, -10, -8, -3, -10, -5, 2, -8, 4, 5, 6, 7, -10, 4, -3, -10, 5, 4, 1, 5, 5, -3, -1, -8, -3, -6, -7, -8, -8, -7, 0, -2, 7, 7, 10, -7, -7, 10, -4, 0, 0, -6, -5, -5, 0, 8, 4, 1, 4, -1, -10, -4, -6, 10, -2, 9, -6, -3, -4, -1, 10, -9, -5, 10, -5, 8, 3 }, 0).Dump();

            new TwoSum().twoSum(new List<int> { 2,1,1,1 }, 2).Dump();
        }

        public List<int> twoSummy(List<int> A, int B)
        {
            var dict = new Dictionary<int, List<int>>();
            var results = new SortedDictionary<int, int>();
            for (var i = 1; i <= A.Count; i++)
            {
                if (!dict.ContainsKey(A[i - 1]))
                {
                    dict.Add(A[i - 1], new List<int>());
                }
                dict[A[i - 1]].Add(i);
            }
            for (var i = 1; i <= A.Count; i++)
            {
                var diff = B - A[i - 1];
                if (dict.ContainsKey(diff))
                {
                    var j = dict[diff].Where(val => val > i).FirstOrDefault();
                    if (j != 0 && !results.ContainsKey(j))
                    {
                        results.Add(j, i);
                    }
                }
            }
            if (results.Count == 0)
            {
                return new List<int>();
            }
            else
            {
                var first = results.First();
                return new List<int> { first.Value, first.Key };
            }
        }

        public List<int> twoSum(List<int> A, int B)
        {
            var valIndexDict = new Dictionary<int, int>();
            for (int i = 0; i < A.Count; i++)
            {
                var needed = B - A[i];
                int index;
                if (valIndexDict.TryGetValue(needed, out index))
                {
                    return new List<int> { index + 1 , i + 1};
                }
                else if (!valIndexDict.ContainsKey(A[i]))
                {
                    valIndexDict.Add(A[i], i);
                }
            }

            return new List<int>();
        }
    }
}
