using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;

using ConsoleDump;

namespace ExercisesAlgo.Mathe
{
    public class LargestCoprimeDivisor
    {
        public void Execute()
        {
            cpFact(22, 38).Dump();

            cpFact(30, 12).Dump();
            cpFact(90, 47).Dump();
            cpFact(15, 5).Dump();
            cpFact(2, 2).Dump();
        }
        public int cpFact(int A, int B)
        {
            var gdc = this.gdc(A, B);
            while (gdc != 1)
            {
                A = A / gdc;
                gdc = this.gdc(A, B);
            }

            return A;
        }

        private IEnumerable<int> factors(int number)
        {
            for (int i = 1; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    yield return i;
                    if (i != Math.Sqrt(number))
                    {
                        yield return number/i;
                    }
                }
            }
        }

        private int gdc(int num1, int num2)
        {
            if (num2 == 0) return num1;
            var r = num2;
            while (r != 0)
            {
                r = num1 % num2;
                num1 = num2;
                num2 = r;
            }

            return num1;
        }
    }
}