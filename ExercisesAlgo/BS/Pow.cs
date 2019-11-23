using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo.BS
{
    public class Pow
    {
        public void Execute()
        {
            pow(-1, 1, 20).Dump();
            pow(79161127, 99046373, 57263970).Dump();

        }

        public long pow(long x, long n, long d)
        {
            long result = 1;
            if (n == 0) return 1 % d;
            if (n % 2 == 0)
            {
                result= pow((x * x) % d, n / 2, d);
            }
            else
            {
                result=(pow(x , n -1, d) * x)%d;
            }

            if (result < 0)
            {
                result = d + result;
            }

            return (int)(result);
        }
    }
}
