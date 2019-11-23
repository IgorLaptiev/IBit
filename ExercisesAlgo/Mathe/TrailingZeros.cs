using System;

using ConsoleDump;

namespace ExercisesAlgo.Mathe
{
    public class TrailingZeros
    {
        public void Execute()
        {
            trailingZeroes(5080).Dump();
            trailingZeroes(5090).Dump();
            trailingZeroes(5095).Dump();
            trailingZeroes(5100).Dump();
            trailingZeroes(9247).Dump();
        }
        public int trailingZeroes(int A)
        {
            var countzeroes = 0;
            var add = 1;
            var pow = 1;
            while (add > 0)
            {
                add = (int)(A / Math.Pow(5, pow));
                countzeroes += add;
                pow++;
            }

            return countzeroes;
        }
    }
}