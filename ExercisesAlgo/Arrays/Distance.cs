using System;
using System.Collections.Generic;
using System.Linq;

using ConsoleDump;

namespace ExercisesAlgo
{
    class Distance
    {
        public void Execute()
        {
            var A = new List<int>()
                        {
                            3, 5, 4, 2, 5
                        };

            this.maximumGap(A).Dump();
        }

        public int maximumGap(List<int> A)
        {
            var B = A.Select((item, index) => new { item, index }).OrderBy(e => e.item).ToList();

            var maxgap = 0;
            var aind = 0;
            for (int i = B.Count-1; i >=0 ; i--)
            {
                if (B[i].item < A[aind])
                {
                    aind++;
                }

                maxgap = Math.Max(maxgap, B[i].index - aind);
                if (B[i].index == aind) aind++;
            }           
            return maxgap;
        }
    }
}