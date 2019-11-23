using System;
using System.Collections.Generic;
using System.Linq;

using ConsoleDump;

namespace ExercisesAlgo.BS
{
    public class Painters
    {
        public void Execute()
        {
            paint(1, 1000000, new List<int>()
                             {
                                 1000000, 1000000
                             }).Dump();
        }
        public int paint(int A, int B, List<int> C)
        {
            // split by painters
            long hi = C.Sum();
            long lo = C.Max();
            while (lo < hi)
            {
                var mid = lo + (hi - lo) / 2;
                var painters = getPainters(C, mid);
                if (painters <= A)
                {
                    hi = mid;
                }
                else
                {
                    lo = (mid + 1);
                }
            }
            return (int)(lo * B % 10000003);
        }

        private int getPainters(List<int> boards, long mid)
        {
            var total = 0;
            var painters = 1;
            foreach (var board in boards)
            {
                total += board;
                if (total > mid)
                {
                    painters++;
                    total = board;  
                }
            }

            return painters;
        }
    }
}