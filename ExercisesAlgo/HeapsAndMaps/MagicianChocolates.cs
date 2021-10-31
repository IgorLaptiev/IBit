using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.HeapsAndMaps
{
    public class MagicianChocolates
    {
        public static void Execute()
        {
            new MagicianChocolates().nchoc(10, new List<int> { 2147483647, 2000000014, 2147483647 }).Dump();
            //new MagicianChocolates().nchoc(1, new List<int> { 1 }).Dump();
        }

        public int nchoc(int A, List<int> B)
        {
            Int64 res = 0;
            var pq = new PriorityQueue<int>();
            B.ForEach(b => pq.Enqueue(b));
            for (var i = 0; i < A; i++)
            {
                var q = pq.Dequeue();
                res = (res + q);
                pq.Enqueue((int)Math.Floor(q / 2m));
            }
            return (int)(res % 1000000007);
        }
    }
}
