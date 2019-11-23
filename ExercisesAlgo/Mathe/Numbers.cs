using System;
using System.Collections.Generic;
using System.Linq;

using ConsoleDump;

namespace ExercisesAlgo.Mathe
{
    public class Numbers
    {
        public void Execute()
        {
            solve(new List<int>() { 0, 1, 2, 5 }, 2, 40).Dump();
            solve(new List<int>() { 0 }, 1, 5).Dump();
        }
        public int solve(List<int> A, int B, int C)
        {
            
            return solveEq(A,B,C ,true);
         }

        private int solveEq(List<int> ints, int b, int c,bool start = false)
        {
            if (c <= 0 || b <= 0 || ints.Count == 0)
                return 0;

            var Cstr = c.ToString();
            if ( Cstr.Length < b) return 0;
            if (Cstr.Length > b)
            {
                if (ints[0] == 0 && b > 1)
                {
                    return Convert.ToInt32((ints.Count - 1) * Math.Pow(ints.Count, b - 1));
                }
                return Convert.ToInt32(Math.Pow(ints.Count, b));
            }

            int count = 0;
            int max_number = Cstr[0] - '0';

            foreach (var  a in ints)
            {

                if (a == 0 && start && Cstr.Length > 1) continue;

                if (a < max_number)
                {
                    count += (int)Math.Pow(ints.Count, Cstr.Length - 1);
                }
                else if (a == max_number)
                {
                    if (Cstr.Length == 1) continue;

                    int new_c = Int32.Parse(Cstr.Substring(1));

                    if (ints[0] != 0)
                    {
                        count += solveEq(ints, b - 1, new_c, false);
                    }
                    else
                    {
                        count += solveEq(ints, new_c.ToString().Length, new_c, false);
                    }

                }
            }

            return count;
        }
    }
}