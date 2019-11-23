using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo.Mathe
{
    public class ReverseInteger
    {
        public void Execute()
        {
            reverse(112345).Dump();
            reverse(-1146467285).Dump();
        }

        public int reverse(int A)
        {
            Int64 result = 0;
            var number = A;
            while (number != 0)
            {
                var digit = number % 10;
                number = number / 10;
                result = result *10 + digit;
            }
            if (result > Int32.MaxValue) return 0;
            if (result < Int32.MinValue) return 0;

            return (int)result;
        }
    }
}
