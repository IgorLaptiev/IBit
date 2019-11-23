using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo
{
    class WaveSort
    {
        public void Execute()
        {
            var A = new List<int>()
                        {
                            4, 1, 2, 3, 4,0,8,9,22
                        }; //{ 3, 30, 34, 5, 9,99, 98 };
            wave(A).Dump();
        }

        public List<int> wave(List<int> A)
        {
            A.Sort();
            for (int i = 0; i +1 < A.Count; i+=2)
            {
                if (A[i] < A[i + 1])
                {
                    var temp = A[i];
                    A[i] = A[i + 1];
                    A[i + 1] =temp;
                }
            }
            return A;
        }
    }
}
