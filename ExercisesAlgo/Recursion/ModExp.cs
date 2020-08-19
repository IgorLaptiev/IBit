using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Recursion
{
    public class ModExp
    {
        public void Execute()
        {
            Mod(-1, 1, 20).Dump();
        }
        public int Mod(int A, int B, int C)
        {
            if (B == 0) return 1;
            var tmp = Mod(A, B / 2, C);
            if (B%2 != 0)
            {
                return mod(A * tmp * tmp, C);
            }
            else
            {
                return mod(tmp * tmp, C);
            }
        }
        int mod(int x, int m)
        {
            int r = x % m;
            return r < 0 ? r + m : r;
        }
    }
}
