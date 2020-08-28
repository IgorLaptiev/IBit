using ConsoleDump;
using System.Collections.Generic;
using System.Linq;

namespace ExercisesAlgo.Recursion
{
    public class CombinationsSum
    {
        public void Execute()
        {
            var list = new List<int> {
                // 8, 10, 6, 11, 1, 16, 8 };
                2, 3, 6, 7,4 };
            var subs = combinationSum(list, 28);
            subs.ForEach(s => s.Dump());
        }

        public List<List<int>> combinationSum(List<int> A, int B)
        {
            A.Sort();
            var results = new List<List<int>>();
            combinationSum(A, new List<int>(), results, 0, B);
            return results;
        }

        private void combinationSum(List<int> set, List<int> currentSubset, List<List<int>> results, int start, int sum)
        {
            if (sum <= 0)
            {
                if (sum == 0)
                {
                    results.Add(new List<int>(currentSubset));
                }
                return;
            }
            for (var i = start; i < set.Count; i++)
            {
                if(i == start || set[i] != set[i-1])
                {
                    currentSubset.Add(set[i]);
                    combinationSum(set, currentSubset, results, i, sum - set[i]);
                    currentSubset.RemoveAt(currentSubset.Count-1);
                }
            }
        }
    }
}
