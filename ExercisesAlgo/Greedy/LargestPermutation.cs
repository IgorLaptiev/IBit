using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Greedy
{
    /*
     *  Problem Description

Given an integer array A of size N consisting of unique integers from 1 to N. You can swap any two integers atmost B times.

Return the largest lexicographical value array that can be created by executing atmost B swaps.



Problem Constraints
1 <= N <= 106

1 <= B <= 109



Input Format
First argument is an integer array A of size N.

Second argument is an integer B.



Output Format
Return an integer array denoting the largest lexicographical value array that can be created by executing atmost B swaps.



Example Input
Input 1:

 A = [1, 2, 3, 4]
 B = 1
Input 2:

 A = [3, 2, 1]
 B = 2


Example Output
Output 1:

 [4, 2, 3, 1]
Output 2:

 [3, 2, 1]


Example Explanation
Explanation 1:

 In one swap we can swap (1, 4) so that the array becomes : [4, 2, 3, 1].
Explanation 2:

 Array is already the largest lexicographical value array.
     */
    public class LargestPermutation
    {
        public static void Execute()
        {

            new LargestPermutation().solve(new List<int> { 3, 2, 4, 1, 5 },3).Dump();
        }

        public List<int> solve(List<int> A, int B)
        {
            if (B > A.Count)
            {
                return A.OrderByDescending(a => a).ToList();
            }

            var idx = new int[A.Count+1];
            for (var i = 0; i < A.Count; i++)
            {
                idx[A[i]] = i;
            }
            var swaps = 0;
            var n = A.Count;
            for (var i = 0; i < A.Count && swaps < B; i++)
            {
                if (A[i] != n - i)
                {
                    var oldInd = idx[n - i];
                    var oldValue = A[i];
                    Swap(A, i,oldInd);
                    var tmp = idx[n - i];
                    idx[n - i] = i;
                    idx[oldValue] = oldInd;
                    swaps++;
                }
            }
            return A;
        }

        public List<int> Step(List<int> A, int start, int B)
        {
            if (B == 0) return A;
            var first = A.Count - start;
            if (first < 1) return A;
            var pos = A.IndexOf(first);
            if (pos != start)
            {
                Swap(A, pos, start);
                Step(A, start + 1, B - 1);
            }
            else
            {
                Step(A, start + 1, B );
            }
            return A;

        }

        private void Swap(List<int> A, int first, int second)
        {
            var temp = A[first];
            A[first] = A[second];
            A[second] = temp;
        }

        public List<int> solveS(List<int> A, int B)
        {
            var values = new SortedList<int, int>();
            for (var k = 0; k < A.Count; k++)
            {
                values.Add(A[k], k);
            }
            var i = 0;
            var j = values.Count() - 1;
            var swaps = 0;
            while (0 <= j && swaps < B)
            {
                if (A[i] < values.Keys[j])
                {
                    var temp = A[i];
                    A[i] = A[values.Values[j]];
                    A[values.Values[j]] = temp;
                    var tmppos = values[A[i]];
                    values[A[i]] = i;
                    values[temp] = tmppos;
                    swaps++;
                }
                i++;
                j--;
            }
            return A;
        }
    }
}
