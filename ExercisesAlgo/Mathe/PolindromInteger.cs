using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo.Mathe
{
    public class PolindromInteger
    {
        public void Execute()
        {
            isPalindrome(121021).Dump();
        }

        public int isPalindrome(int A)
        {
            if (A < 0) return 0;
            if (A == 0) return 1;
            var i = 1;
            var j = (int)Math.Ceiling(Math.Log(A, 10));
            while (i <= j)
            {
                var right = this.getRightDigit(A, i);
                var left = this.getRightDigit(A, j);
                if (left != right) return 0;
                i++;
                j--;
            }

            return 1;
        }

        private int getRightDigit(int number, int place)
        {
            return (int)(number % Math.Pow(10, place) / Math.Pow(10, place - 1));
        }
    }
}
