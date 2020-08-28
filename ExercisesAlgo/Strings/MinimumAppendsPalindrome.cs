using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Strings
{
    public class MinimumAppendsPalindrome
    {
        public static void Execute()
        {
            new MinimumAppendsPalindrome().solve("abede").Dump();
            new MinimumAppendsPalindrome().solve("oqycntornscygodzdctxnhoc").Dump();
        }

        //int[,] lps;
        public int solve(string A)
        {
            var str = String.Join("", A.Reverse().Cast<string>()) + "$" + A;
            var lps = getLPS(str, new int[str.Count()]);
            return A.Count() -lps.Last();
        }

        private int[] getLPS(string str, int[] lps)
        {
            var i = 1;
            var len = 0;
            lps[0] = 0;
            while(i < lps.Count())
            {
                if (str[i] == str[len])
                {
                    len++;
                    lps[i] = len;
                    i++;
                }
                else
                {
                    if (len != 0)
                    {
                        len = lps[len - 1];
                    }
                    else
                    {
                        lps[i] = len;
                        i++;
                    }
                }
            }
            return lps;
        }

        public int solveTLE(string A)
        {
            for (var i = 0; i < A.Count(); i++)
            {
                if (isPolindrom(A,i))
                {
                    return i;
                }
            }
            return A.Count();
        }

        private bool isPolindrom(string str, int start)
        {
            var j = str.Count() - 1;
            var middle = start + (j - start) / 2;
            for (var i = start; i <= middle; i++, j--)
            {
                if (str[i] != str[j])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
