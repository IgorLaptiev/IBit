using System;
using System.Linq;

using ConsoleDump;

namespace ExercisesAlgo.Strings
{
    public class MakePalindrome
    {
        public void Execute()
        {
            solve("acabdbad").Dump();
        }


        public int solve(string A)
        {
            var str = A + "_";
            for (int i = A.Length-1; i >= 0; i--)
            {
                str += A[i];
            }
            var lps = CalculateLPS(str);
          //  lps = CalculateLPS(A);
            return A.Length - lps[str.Length-1];
        }

        private int[] CalculateLPS(string str)
        {
            var result = new int[str.Length];
            var i = 1;
            var len = 0;
            result[0] = 0;
            while (i < str.Length)
            {
                if (str[i] == str[len])
                {
                    len++;
                    result[i] = len;
                    i++;
                }
                else
                {
                    if (len != 0)
                    {
                        len = result[len - 1];
                    }
                    else
                    {
                        result[i] = 0;
                        i++;
                    }
                }
            }

            return result;
        }
    }
}
