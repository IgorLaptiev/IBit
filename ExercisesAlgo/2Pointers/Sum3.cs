using System;
using System.Collections.Generic;
using ConsoleDump;

namespace ExercisesAlgo._2Pointers
{
    public class Sum3
    {
        public void Execute()
        {
            //threeSumClosest(new List<int>() {5, -20 ,-1, 5 ,16, 18}, 1).Dump();
            threeSumClosest(new List<int>() {-5, 1, 4, -7, 10, -7, 0, 7, 3, 0, -2, -5, -3, -6, 4, -7, -8, 0, 4, 9, 4, 1, -8, -6, -6, 0, -9, 5, 3, -9, -5, -9, 6, 3, 8, -10, 1, -2, 2, 1, -9, 2, -3, 9, 9, -10, 0, -9, -2, 7, 0, -4, -3, 1, 6, -3}, -1).Dump();
            
        }

        public int threeSumClosestBrutforce(List<int> A, int B)
        {
            var sum = 0;
            var diff = int.MaxValue;
            for (int i = 0; i < A.Count; i++)
            {
                for (int j = i+1; j < A.Count; j++)
                {
                    for (int k = j+1; k < A.Count; k++)
                    {

                        if (Math.Abs(A[i] + A[j] + A[k] - B) < diff)
                        {
                            sum = A[i] + A[j] + A[k];
                            diff = Math.Abs(A[i] + A[j] + A[k] - B);
                        }
                    }
                }
            }

            return sum;
        }
        
        public int threeSumClosest(List<int> A, int B)
        {
            var sumres = 0;
            var diff = int.MaxValue;
            A.Sort();
            var i = 0;
            var j = 1;
            var k = 2;
            for (i = 0; i < A.Count-2; i++)
            {
                j = i + 1;
                k = A.Count - 1;
                while (j<k)
                {
                    var sum = A[i] + A[j] + A[k];
                    var currdiff = Math.Abs(sum - B);
                    if (currdiff == 0) return sum;
                    if (currdiff < diff)
                    {
                        diff = currdiff;
                        sumres = sum;
                    }

                    if (sum < B)
                    {
                        j++;
                    }
                    else if (sum>B)
                    {
                        k--;
                    }
                }
            }
            return sumres;
        }

    }
}