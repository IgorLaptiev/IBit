using System;
using System.Collections.Generic;
using System.Linq;

using ConsoleDump;

namespace ExercisesAlgo.Mathe
{
    public class SortedPermutationRank
    {
        public void Execute()
        {
            //this.findRank("bca").Dump();
            //this.findRank("cab").Dump();
            this.findRank("acb").Dump();
        }

        public int findRank(string A)
        {
            var dict = new Dictionary<char, int>();
            var charArray =  A.ToCharArray().OrderBy(e => e).ToList();
            for (int i = 0; i < charArray.Count; i++)
            {
                dict.Add(charArray[i], i);
            }

            long pos=0;
            for (int i = 0; i < A.Length; i++)
            {
                var chankSize = Fact(A.Length-i -1);
                var ind = dict[A[i]];
                pos += chankSize * ind;
            }

            return (int)(pos% 1000003);
        }

        public Int64 Fact(int number)
        {
            Int64 x = 1;
            while (number != 0)
            {
                x = number * x;
                number = number - 1;
            }

            return x % 1000003;
        }

    }
}