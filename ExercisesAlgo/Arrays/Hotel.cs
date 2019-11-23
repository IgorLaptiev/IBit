using System;
using System.Collections.Generic;

using ConsoleDump;

namespace ExercisesAlgo
{
    class Hotel
    {
        public void Execute()
        {
            var A = new List<int>()
                        {
                            35, 8, 23, 22, 35, 6, 48, 45, 33, 43, 37, 12, 42, 3, 31, 38, 5, 33, 15
                        };

            var D = new List<int>()
                        {
                            43, 32, 34, 46, 74, 50, 95, 62, 59, 79, 83, 19, 88, 34, 75, 42, 42, 50, 58
                        };
            hotel(A,D,11).Dump();
        }

        public int hotel(List<int> A, List<int> B, int C)
        {
            A.Sort();
            B.Sort();

            for (int i = 0; i < A.Count; i++)
            {
                if(i+C < A.Count && A[i+C]<B[i])
                { 
                    return 0;
                }
            }

            return 1;
        }
    }
}

//1-6 2-5 3-4