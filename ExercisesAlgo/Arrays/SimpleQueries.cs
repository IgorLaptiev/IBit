using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo
{
    class SimpleQueries
    {
        public void Execute()
        {
        //    A: [39, 99, 70, 24, 49, 13, 86, 43, 88, 74, 45, 92, 72, 71, 90, 32, 19, 76, 84, 46, 63, 15, 87, 1, 39, 58, 17, 65, 99, 43, 83, 29, 64, 67, 100, 14, 17, 100, 81, 26, 45, 40, 95, 94, 86, 2, 89, 57, 52, 91, 45]
        //    B: [1221, 360, 459, 651, 958, 584, 345, 181, 536, 116, 1310, 403, 669, 1044, 1281, 711, 222, 280, 1255, 257, 811, 409, 698, 74, 838]

            var A = new List<int>()
                        {
                         //   1, 2, 4
                            39, 99, 70, 24, 49, 13, 86, 43, 88, 74, 45, 92, 72, 71, 90, 32, 19, 76, 84, 46, 63, 15, 87, 1, 39, 58, 17, 65, 99, 43, 83, 29, 64, 67, 100, 14, 17, 100, 81, 26, 45, 40, 95, 94, 86, 2, 89, 57, 52, 91, 45
                        };
            A.Count.Dump();
            this.solve(A, new List<int>(){ 1221, 360, 459, 651, 958, 584, 345, 181, 536, 116, 1310, 403, 669, 1044, 1281, 711, 222, 280, 1255, 257, 811, 409, 698, 74, 838 }).Dump();
        }
        //778688

        //51 39  99  70 24 49 13 86 43 88 74 45 92 72 71 90 32 19 76 84 46 63 15 87 1 39 58 17 65 99 43 83 29 64 67 100 14 17 100 81 26 45 40 95 94 86 2 89 57 52 91 45
        //1 1121

        public List<int> solve(List<int> A, List<int> B)
        {
            var result = generateMaxSubarrays(A).ToList();

            for (int i = 0; i < result.Count; i++)
            {
                result[i] = (int)(GetProductOfDivisors(result[i]));
            }

            result = result.OrderByDescending(e => e).ToList();


            
            return GetQueries(result, B).ToList();
        }

        private IEnumerable<int> GetQueries(List<int> result, List<int> B)
        {
            foreach (var query in B)
            {
                yield return result[query-1];
            }
        }

        private double GetProductOfDivisors(int number)
        {
            //var divisors = new List<int>();
            double count = 0;
            for (int j = 1; j <= number; j++)
            {
                if (number % j == 0)
                {
                    count++;
                }
            }

            return (Math.Pow(number, (count/2))) % 1000000007;
        }

        private IEnumerable<int> generateMaxSubarrays(List<int> A)
        {
            for (int i = 0; i < A.Count; i++)
            {
                for (int j = 0; j < A.Count - i; j++)
                {
                    var max = Int32.MinValue;
                    for (int k = i; k <= i+j; k++)
                    {
                        max = Math.Max(max, A[k]);

                    }
                    yield return max;
                }

            }
        }
    }
}
