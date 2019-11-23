using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo.Bits
{
    public class SingleNumber
    {
        public void Execute()
        {
         //   singleNumber(new List<int>{1, 2, 2, 3,3, 5,1}).Dump();
            singleNumber3(new List<int> { 1, 2, 4, 3, 3, 2, 2, 3, 1, 1 }).Dump();
        }
        public int singleNumber(List<int> A)
        {
            var res = 0;
            foreach (var i in A)
            {
                res = res ^ i;
            }

            return res;
        }

        public int singleNumber3(List<int> A)
        {
            int ones = 0, twos = 0;
            int common_bit_mask;

            foreach (var i in A)
            {
                twos = twos | (ones & i);
                ones = ones ^ i;
                common_bit_mask = ~(ones & twos);
                ones &= common_bit_mask;
                twos &= common_bit_mask;
            }

            return ones;
        }
    }
}
