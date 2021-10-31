using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Arrays
{
    public class MinimumLights
    {
        public static void Execute()
        {
            new MinimumLights().solve(new List<int> { 0, 0, 1, 1, 1, 0, 0,0 }, 3).Dump();
            new MinimumLights().solve(new List<int> { 0, 1, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 0, 1, 0, 0 }, 12).Dump();
        }
        public int solve(List<int> A, int B)
        {
            var count = 0;
            var i = 0;
            while (i < A.Count)
            {
                var j = Math.Min(i + B - 1, A.Count - 1);
                var minleft = Math.Max(i - B + 1, 0);
                for (; j >= minleft; j--)
                {
                    if (A[j] == 1)
                    {
                        count++;
                        i = j + B;
                        if (i >= A.Count) return count;
                        break;
                    }
                }
                if (j <= minleft) return -1;
            }
            return -1;
        }
    }
}
