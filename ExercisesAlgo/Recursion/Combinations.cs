using ConsoleDump;
using System.Collections.Generic;
using System.Linq;

namespace ExercisesAlgo.Recursion
{
    public class Combinations
    {
        public void Execute()
        {
            var subs = combine(1,4);
            subs.ForEach(s => s.Dump());
        }

        public List<List<int>> combine(int A, int B)
        {
            if (B > A) return new List<List<int>>() { };
            return combineRec(0, A, B);
        }

        public List<List<int>> combineRec(int start, int end, int cnt)
        {
            var results = new List<List<int>>() { };
            if (cnt == 0 || start >= end) return results;
            var combs = combineRec(++start, end, --cnt);
            for (var i = start; i <= end; i++)
            {
                combs.ForEach(c =>
                {
                    if (i < c[0]) {
                        results.Add((new List<int> { i }).Union(c).ToList());
                    }
                });
                if (combs.Count == 0)
                {
                    results.Add(new List<int> { i });
                }
            }
            return results;
        }
    }
}
