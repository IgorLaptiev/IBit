using ConsoleDump;
using System.Collections.Generic;
using System.Linq;

namespace ExercisesAlgo.Recursion
{
    public class UniquePerm
    {
        public static void Execute()
        {
            var subs = new UniquePerm().permute(new List<int> { 10, 9, 10, 9, 10 });
            subs.ForEach(s => s.Dump());
        }

        List<List<int>> permutes = new List<List<int>>();

        public List<List<int>> permute(List<int> A)
        {
            A.Sort();
            perm(A, new List<int>());
            return permutes;
        }

        private void perm(List<int> list, List<int> current)
        {
            if (list.Count == 0)
            {
                permutes.Add(current.ToList());
                return;
            }
            var dist = list.ToList();
            for (var i = 0; i < dist.Count; i++)
            {
                if (i == 0 || i > 0 && list[i] != list[i - 1])
                {
                    current.Add(dist[i]);
                    var temp = dist.ToList();
                    temp.RemoveAt(i);
                    perm(temp, current);
                    current.RemoveAt(current.Count - 1);
                }
            }
        }
    }
}
