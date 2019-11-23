using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo.Mathe
{
    public class PrimeSum
    {
        public void Execute()
        {
            var A = new List<int>()
                        {
                            4, 1, 2, 3, 4,0,8,9,22
                        }; //{ 3, 30, 34, 5, 9,99, 98 };
            primesum(4).Dump();
            primesum(6).Dump();
            primesum(8).Dump();
            primesum(10).Dump();
            primesum(12).Dump();
            primesum(14).Dump();
            primesum(16).Dump();
            primesum(18).Dump();
        }

        public List<int> primesum(int A)
        {
            if (A == 4)
            {
                return new List<int>(){2,2};
            }

            var primes = sieve(A);
            for (int i = 0; i < primes.Count; i++)
            {
                if (primes[i] == 1)
                {
                    var second = A - i;
                    if (primes[second] == 1)
                    {
                        return new List<int>() {i, second};
                    }
                }
            }

            return new List<int>();
        }

        private List<int> sieve(int A)
        {
            var list = new List<int>();
            var primes = new List<int>();
            list.Add(0);
            list.Add(0);
            for (int i = 2; i <= A; i++)
            {
                list.Add(1);
            }
            for (int i = 2; i <= A; i++)
            {
                if (list[i] == 1)
                {
                    for (int j = 2; j * i <= A; j++)
                    {
                        list[j * i] = 0;
                    }
                }
            }

            return list;
        }
    }
}
