using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.HeapsAndMaps
{
    public class KLargest
    {
        public static void Execute()
        {
            new KLargest().solve(new List<int> { 725, 479, 359, 963, 465, 706, 146, 282, 828, 962 }, 2).Dump();
        }
        public List<int> solve(List<int> A, int B)
        {
            var pq = new PriorityQueue<int>();
            A.ForEach(a => pq.Enqueue(a));
            return pq.OrderByDescending(a => a).Take(B).ToList();
        }
    }
}
