using System.Collections.Generic;
using System.Linq;

using ConsoleDump;

namespace ExercisesAlgo
{
    public class MaximumUnsortedSubArray
    {
        public void Execute()
        {
            var A = new List<int>()
                        {
                            1, 3, 5, 4, 2, 5
                        };

            this.subUnsort(A).Dump();
        }

        public List<int> subUnsort(List<int> A)
        {
            var result = new List<int>();
            var B = A.OrderBy(i => i).ToList();
            for (int i = 0; i < A.Count; i++)
            {
                if (A[i] != B[i])
                {
                    result.Add(i);
                    break;
                }
            }

            if (result.Count == 0)
            {
                return new List<int> { -1 };
            }
            for (int i = A.Count-1; i >= 0; i--)
            {
                if (A[i] != B[i])
                {
                    result.Add(i);
                    break;
                }
            }

            return result;
        }
        public List<int> subUnsort2(List<int> A)
        {
            var unsortedStart = 0;
            var unsortedEnd = A.Count - 1;
            for (int i = 1; i < A.Count; i++)
            {
                if (A[i] >= A[i - 1])
                {
                    unsortedStart = i;
                }
                else
                {
                    break;
                }
            }
            if (unsortedStart >= A.Count-1)
                return new List<int> { -1 };

            for (int i = A.Count -1; i < unsortedStart; i--)
            {
                if (A[i- 1] <= A[i])
                {
                    unsortedEnd = i;
                }
                else
                {
                    break;
                }

            }
            return A.Skip(unsortedStart).Take(unsortedEnd - unsortedStart).ToList();
        }
    }
}