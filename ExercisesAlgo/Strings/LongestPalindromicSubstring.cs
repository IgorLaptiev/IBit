using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo.Strings
{
    public class LongestPalindromicSubstring
    {
        public void Execute()
        {
            longestPalindrome("").Dump();
        }
        public string longestPalindrome(string A)
        {
            if (A.Length <= 1) return A;
            int max = 1;
            string maxsubstr= A[0].ToString();
            int low, high;

            for (int i = 1; i < A.Length; i++)
            {
                low = i - 1;
                high = i;
                while (low >= 0 && high < A.Length && A[low] == A[high])
                {
                    if (high - low + 1 > max)
                    {
                        max = high - low + 1;
                        maxsubstr = A.Substring(low,  max);
                    }
                    --low;
                    ++high;
                }

                low = i - 1;
                high = i + 1;
                while (low >= 0 && high < A.Length && A[low] == A[high])
                {
                    if (high - low + 1 > max)
                    {
                        max = high - low + 1;
                        maxsubstr = A.Substring(low, max );
                    }
                    --low;
                    ++high;
                }
            }

            return maxsubstr;
        }

        private static string Reverse(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
