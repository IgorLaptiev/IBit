using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo.Strings
{
    public  class Palindrome
    {
        public void Execute()
        {
            isPalindrome("А роза упала на лапу азора").Dump();
        }

        public int isPalindrome(string A)
        {
            int i = 0;
            int j = A.Length - 1;
            while (i < j)
            {
                string left = A.Substring(i,1);
                if (! (Char.IsNumber(left, 0) || Char.IsLetter(left, 0)))
                {
                    i++;
                    continue;
                }
                string right = A.Substring(j, 1);
                if (!(Char.IsNumber(right, 0) || Char.IsLetter(right, 0)))
                {
                    j--;
                    continue;
                }
                if (!left.Equals(right, StringComparison.InvariantCultureIgnoreCase))
                {
                    return 0;
                }

                i++;
                j--;
            }
           
            return 1;
        }

    }
}
