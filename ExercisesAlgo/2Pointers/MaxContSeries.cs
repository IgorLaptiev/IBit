using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo._2Pointers
{
    public class MaxContSeries
    {
        public void Execute()
        {
            maxone(new List<int> { 1, 1, 0, 1, 1, 0, 0, 1, 1, 1 }, 2).Dump();
        }

        public List<int> maxone(List<int> A, int B)
        {
            var i = 0;
            var flips = B;
            var j = 0;
            var maxlength = 0;
            var result = new List<int>();
            var maxi = 0;
            var maxj = 0;
            while (j < A.Count)
            {
                if(A[j] == 0)
                {
                    flips--;
                }
                if (flips < 0)
                {
                    if (j - i > maxlength)
                    {
                        maxlength = j - i;
                        maxi = i;
                        maxj = j;
                    }
                    if (A[i] ==0)
                    {
                        flips++;
                    }
                    i++;
                    flips++;
                }
                else
                {
                    j++;
                }
            }
            if (j - i > maxlength)
            {
                maxlength = j - i;
                maxi = i;
                maxj = j;
            }
            return Enumerable.Range(maxi, maxlength).ToList();
        }
    }
}
