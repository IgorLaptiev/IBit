using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo._2Pointers
{
    public class Sum3Zero
    {
        public void Execute()
        {
            var list = new List<int>() { -1, 0, 1, 2, -1, -4 };
            var result = threeSum(list);
            foreach (var tuple in result)
            {
                tuple.Dump();
            }
        }

        public List<List<int>> threeSum(List<int> A)
        {
            var result = new List<List<int>>();

            A.Sort();
            var i = 0;
            var j = 1;
            var k = 2;
            for (i = 0; i < A.Count - 2; i++)
            {
                j = i + 1;
                k = A.Count - 1;
                while (j < k)
                {
                    var sum = A[i] + A[j] + A[k];
                    if (sum == 0)
                    {
                        result.Add(new List<int> { A[i], A[j], A[k] });
                    }

                    if (sum <= 0)
                    {
                        j++;
                    }
                    else if (sum >= 0)
                    {
                        k--;
                    }
                }
            }

            return result.Distinct(new Comparer()).ToList();
        }

        class Comparer : IEqualityComparer<List<int>> 
        {
            public bool Equals(List<int> x, List<int> y)
            {
                if (x.Count != y.Count) return false;
                for (int i = 0; i < x.Count; i++)
                {
                    if (x[i] != y[i]) return false;
                }

                return true;
            }

            public int GetHashCode(List<int> list)
            {
                var hash = 0;
                for (int i = 0; i < list.Count; i++)
                {
                    hash = hash + (list[i] * 10 ^ i);
                }

                return hash.GetHashCode();
            }
        }
    }
}
