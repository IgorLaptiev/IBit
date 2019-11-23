using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo.BS
{
    public class Sqrt
    {
        public void Execute()
        {
            sqrt(930675566).Dump();
            sqrt(17).Dump();
            sqrt(24).Dump();
            sqrt(1).Dump();
            sqrt(2).Dump();
            sqrt(4).Dump();
        }

        public int sqrt(int a)
        {
            if (a == 0) return 0;
            long lo = 1;
            long hi = Math.Max(a / 2,lo);
            long mid = 0;
            while (lo<=hi)
            {
                mid = lo + (hi - lo) / 2;
                if (mid * mid ==a) return (int)mid;

                if (mid* mid > a)
                {
                    hi = mid - 1;
                } else if (mid * mid < a)
                {
                    lo = mid + 1;
                } 
            }

            return (int)hi;
        }
    }
}
