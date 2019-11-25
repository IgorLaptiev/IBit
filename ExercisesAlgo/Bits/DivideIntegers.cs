using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBit.BitManipulation
{
    public class DivideIntegers
    {
        public void Execute()
        {
        //    divide(5, 2).Dump();
            divide(-2147483648, 1).Dump();
        }

        public int divide(int A, int B)
        {
            long quotient = 0;
            var sign = 1;
            long a = A;
            long b = B;
            if (a < 0)
            {
                sign = sign * -1;
                a = Math.Abs(a);
            }
            if (b < 0)
            {
                sign = sign * -1;
                b = Math.Abs(b);
            }
            if (b != 1)
            {
                while (a >= b)
                {
                   
                    quotient++;
                    a = a - b;
                }
            }
            else
            {
                quotient = a;
            }
            quotient = quotient * sign;
            if (quotient  > Int32.MaxValue || quotient < Int32.MinValue)
            {
                return Int32.MaxValue;
            }

            return (int)quotient* sign;
        }
    }
}
