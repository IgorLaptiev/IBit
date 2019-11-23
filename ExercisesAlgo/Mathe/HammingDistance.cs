using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo.Mathe
{
    public class HammingDistance
    {
        public void Execute()
        {
            var A = new List<int>()
                        {
                            //  2, 4, 6,2
                            94, 94, 73, 15, 65, 79, 65, 20, 5, 20
                        }; //{ 3, 30, 34, 5, 9,99, 98 };

            hammingDistance(A).Dump();
        }

        public int hammingDistance(List<int> A)
        {
            Int64 sum = 0;
            for (int i = 0; i < 32; i++)
            {
                Int64 count = 0;
                for (int j = 0; j < A.Count; j++)
                {
                    if ((A[j] & (1 << i)) == 0)
                    {
                        count++;
                    }
                }

                sum += (count * ((Int64)A.Count - count) * 2);
            }



            return (int) sum % 1000000007;
        }
    }
}
