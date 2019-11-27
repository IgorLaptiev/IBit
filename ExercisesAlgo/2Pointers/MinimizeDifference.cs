using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo._2Pointers
{
    public class MinimizeDifference
    {
        public void Execute()
        {
            solve(new List<int>() { 1, 4, 5, 8, 10 },
                new List<int>() { 6, 9, 10, 15 },
                new List<int>() { 2, 3, 6, 10 }).Dump();

            solve(new List<int>(){ 1, 4, 5, 8, 10 },
                new List<int>(){ 6, 9, 15 },
                new List<int>(){ 2, 3, 6, 6 }).Dump();

            solve(new List<int>() { -1 },
                new List<int>() { -2 },
                new List<int>() { -3 }).Dump();
        }

        public int solve(List<int> A, List<int> B, List<int> C)
        {
            var minmax = Int32.MaxValue;
            var a = 0;
            var b = 0;
            var c = 0;
            while (a < A.Count && b < B.Count && c < C.Count)
            {
                if (GetValue(A[a], B[b], C[c]) < minmax)
                {
                    minmax = GetValue(A[a], B[b], C[c]);
                }
                if (A[a] <= B[b] && A[a] <= C[c])
                {
                    if (a < A.Count)
                    {
                        a++;
                    }

                }
                else if (B[b] <= A[a] && B[b] <= C[c])
                {
                    if (b < B.Count)
                    {
                        b++;
                    }
                }
                else if (C[c] <= A[a] && C[c] <= B[b])
                {
                    if (c < C.Count)
                    {
                        c++;
                    }
                }
                else
                {
                    break;
                }

            
            }
         
            return minmax;
        }

        private static int GetValue(int a, int b, int c)
        {
            return Math.Abs(Math.Max(Math.Max(a, b), c) - Math.Min(Math.Min(a, b), c));
        }
    }
}
