using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo._2Pointers
{
    public class Diffk
    {
        public void Execute()
        {
            diffPossible(new List<int>() { 1, 3, 5 }, 4).Dump();
            diffPossible(new List<int>() { 1, 3, 5 }, 2).Dump();
            diffPossible(new List<int>() { 1, 3, 5 }, 1).Dump();
        }

        public int diffPossible(List<int> A, int B)
        {
            var i = 0;
            var j = i + 1;
            while (j < A.Count)
            {
                if (A[j] - A[i] < B)
                {
                    j++;
                }
                else if (A[j] - A[i] > B)
                {
                    i++;
                    j = i + 1;
                }
                else
                {
                    return 1;
                }
            }

            return 0;
        }

    }
}
