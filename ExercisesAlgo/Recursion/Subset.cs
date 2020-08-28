using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Recursion
{
    public class Subset
    {

        public void Execute()
        {
            var subs = subsets(new List<int> { 15, 20, 12, 19, 4 });
            //var subs = subsets(new List<int> { 1, 2, 3, 4});
            subs.ForEach(s => s.Dump());
        }

        public List<List<int>> subsets(List<int> A)
        {
            A.Sort();
            var results = subsetsReq(A);
            results.Insert(0, new List<int>(0));
            return results;
        }

        public List<List<int>> subsetsReq(List<int> A)
        {
            var head = A.Take(1).ToList();
            var results = new List<List<int>>();
            results.Add(head);
            if (A.Count == 1) return results;
            var tail = A.Skip(1).Take(A.Count - 1).ToList();
            var subsets = subsetsReq(tail);
            results.AddRange(subsets.Select(s => head.Union(s).ToList()));
            results.AddRange(subsets);

            return results;
        }
    }
}
