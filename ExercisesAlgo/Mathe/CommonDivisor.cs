using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using ConsoleDump;

namespace ExercisesAlgo.Mathe
{
    public class CommonDivisor
    {
        public void Execute()
        {
            gcd(6, 9).Dump();
        }

        public int gcd(int A, int B)
        {
            if (B == 0) return A;
            if (A == 0) return B;
            int rest;
            do
            {
                rest = A % B;
                A = B;
                B = rest;
            }
            while (rest !=0 );

            return A;
          
        }
    }
}
