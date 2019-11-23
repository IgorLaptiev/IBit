using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo.Bits
{
    public class MinXORvalue
    {

        public void Execute()
        {
            findMinXor(new List<int>() { 0, 2, 5, 7 }).Dump();
        }

        public int findMinXor(List<int> A)
        {
           A.Sort();
           var minXor = Int32.MaxValue;
           for (int i = 0; i < A.Count-1; i++)
           {
               if ((A[i] ^ A[i + 1]) < minXor)
               {
                   minXor = A[i] ^ A[i + 1];
               }
           }
           return minXor;
        }
    }
}
