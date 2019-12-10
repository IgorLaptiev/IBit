using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo._2Pointers
{
    public class Triangles
    {
        public void Execute()
        {
            nTriang(new List<int>() { 1, 1, 1, 2, 2 }).Dump();
        }

        public int nTriang(List<int> A)
        {
            long cnt = 0;
            A.Sort();
            for (var i = 0; i < A.Count - 2; i++)
            {
                if (A[i]==0) continue;
                var k = i + 2;

                for (int j = i+1; j < A.Count-1; j++)
                {
               //     Console.WriteLine($"{A[i]} {A[j]} {A[k]}");
                    while (k < A.Count && A[i] + A[j] > A[k])
                    {
                      //  Console.WriteLine($"+");
                        k++;
                    }

                    cnt += k - j - 1;
                }
            }

            return (int)(cnt % 1000000007);
        }
    }
}
