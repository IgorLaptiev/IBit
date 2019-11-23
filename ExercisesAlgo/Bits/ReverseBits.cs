using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo.Bits
{
    public class ReverseBits
    {
        public void Execute()
        {
            reverse(3).Dump();
        }

        public uint reverse(uint a)
        {
            uint y = 0;
            for (int i = 0; i < 32; ++i)
            {
                y <<= 1;
                y |= (a & 1);
                a >>= 1;
            }
            return y;
        }
    }
}
