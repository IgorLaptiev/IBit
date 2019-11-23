using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo.Bits
{
    public class NumberBits
    {
        public void Execute()
        {
            numSetBits(1101).Dump();
        }
        public int numSetBits(long a)
        {
            int cnt = 0;
            while (a!=0)
            {
                if (a % 2 != 0)
                {
                    cnt++;
                }
                a = a / 2;
            }

            return cnt;
        }
    }
}
